using System;
using System.Collections.Generic;
using EPS.Components;

namespace EPS.Instructions
{
    public class InstructionSet
    {
        public Instruction[] Instructions = new Instruction[64];

        public InstructionSet()
        {
            Instructions[0b00_000000] = new Instruction
            {
                Mnemonic = "NOP",
                Description = "No operation. Consumes one processor execution cycle.",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => // 0: do nothing....
                    {
                        return null;
                    }
                }
            };

            Instructions[0b00_000001] = new Instruction
            {
                Mnemonic = "ADD",
                Description = "Sets ACC to RegA, then adds value from bus to ACC and stores in Reg A.",
                
                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: RegA to ACC
                    {
                        ctx.RegA.SetFlag(BusFlags.Read);
                        ctx.Proc.ACC.SetFlag(BusFlags.Write);

                        return ctx.MemoryMode == MemoryMode.Direct ? 1 : 2;
                    },
                    (proc, ctx) => // 1: Direct only. Load into MDR
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.MAR.SetFlag(BusFlags.Write);
                            proc.MemoryBank.SetFlag(MemoryFlags.Read);
                            proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);
                        }
                        return null;
                    },
                    (proc, ctx) => // 2: Trigger add operation. Result will sit in the ACC.
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.MDR.SetFlag(BusFlags.Read);
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read);
                        } else
                        {
                            proc.SystemBus.Value = BitConverter.GetBytes((short) ctx.Immediate);
                        }
                        proc.ALU.SetMode(ALUModes.Add);

                        return null;
                    },
                    (proc, ctx) => // 3: Acc to RegA
                    {
                        ctx.Proc.ACC.SetFlag(BusFlags.Read);
                        ctx.RegA.SetFlag(BusFlags.Write);

                        return null;
                    }
                }
            };
        }
    }
}