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

                        return ctx.MemoryMode == MemoryMode.Direct ? 1 : 2; // step 1 if memory mode direct, else 2
                    },
                    (proc, ctx) => // 1: Direct only. Load into MDR
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => MAR
                            proc.CIR.SetFlag(BusFlags.SecondWord);
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
                        } else if (ctx.MemoryMode == MemoryMode.Immediate)
                        {
                           proc.CIR.SetFlag(BusFlags.Read);
                           proc.CIR.SetFlag(BusFlags.SecondWord);
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

            Instructions[0b00_000010] = new Instruction
            {
                Mnemonic = "SUB",
                Description = "Sets ACC to RegA, (ACC-Bus) and stores in Reg A.",

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
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => MAR
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.MAR.SetFlag(BusFlags.Write);

                            proc.MemoryBank.SetFlag(MemoryFlags.Read);
                            proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);
                        }
                        return null;
                    },
                    (proc, ctx) => // 2: Trigger sub operation. Result will sit in the ACC.
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.MDR.SetFlag(BusFlags.Read);
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read);
                        } else if (ctx.MemoryMode == MemoryMode.Immediate)
                        {
                            proc.CIR.SetFlag(BusFlags.Read);
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                        }
                        proc.ALU.SetMode(ALUModes.Subtract);

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

            Instructions[0b00_000011] = new Instruction
            {
                Mnemonic = "BRA",
                Description = "Jumps to RegB, Immediate or Direct",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: Initiate memory transfer for direct
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => MAR
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.MAR.SetFlag(BusFlags.Write);

                            proc.MemoryBank.SetFlag(MemoryFlags.Read); // Config mem bank to read two bytes
                            proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read); // RegB => PC
                            proc.PC.SetFlag(BusFlags.Write);
                        } else
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => PC
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.PC.SetFlag(BusFlags.Write);
                        }
                        return ctx.MemoryMode == MemoryMode.Direct ? 1 : ctx.StageCount; // if direct mem mode, move to next step, else finish
                    },
                    (proc, ctx) => //1: Set PC value
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.MDR.SetFlag(BusFlags.Read); // MDR => PC
                            proc.PC.SetFlag(BusFlags.Write);
                        } 

                        return null;
                    }
                }
            };

            Instructions[0b00_000100] = new Instruction
            {
                Mnemonic = "BRZ",
                Description = "Jumps to RegB, Immediate or Direct when RegA is 0.",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: Initiate memory transfer for direct
                    {
                        if (BitConverter.ToInt16(ctx.RegA.Value, 0) != 0) // If non-zero, end instruction.
                        {
                            return ctx.StageCount;
                        }

                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => MAR
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.MAR.SetFlag(BusFlags.Write);
            
                            proc.MemoryBank.SetFlag(MemoryFlags.Read); // Config mem bank to read two bytes
                            proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read); // RegB => PC
                            proc.PC.SetFlag(BusFlags.Write);
                        } else if (ctx.MemoryMode == MemoryMode.Immediate)
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => PC
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.PC.SetFlag(BusFlags.Write);

                        }
                        return ctx.MemoryMode == MemoryMode.Direct ? 1 : ctx.StageCount; // if direct mem mode, move to next step, else finish
                    },
                    (proc, ctx) => //1: Set PC value
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.MDR.SetFlag(BusFlags.Read); // MDR => PC
                            proc.PC.SetFlag(BusFlags.Write);
                        }

                        return null;
                    }
                }
            };

            Instructions[0b00_000101] = new Instruction
            {
                Mnemonic = "BRP",
                Description = "Jumps to RegB, Immediate or Direct when RegA >= 0.",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: Initiate memory transfer for direct
                    {
                        if (BitConverter.ToInt16(ctx.RegA.Value, 0) < 0) // If less than zero, end instruction.
                        {
                            return ctx.StageCount;
                        }

                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => MAR
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.MAR.SetFlag(BusFlags.Write);

                            proc.MemoryBank.SetFlag(MemoryFlags.Read); // Config mem bank to read two bytes
                            proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read); // RegB => PC
                            proc.PC.SetFlag(BusFlags.Write);
                        } else if (ctx.MemoryMode == MemoryMode.Immediate)
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // CIR Second Word => PC
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.PC.SetFlag(BusFlags.Write);
                        }
                        return ctx.MemoryMode == MemoryMode.Direct ? 1 : ctx.StageCount; // if direct mem mode, move to next step, else finish
                    },
                    (proc, ctx) => //1: Set PC value
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            proc.MDR.SetFlag(BusFlags.Read); // MDR => PC
                            proc.PC.SetFlag(BusFlags.Write);
                        }

                        return null;
                    }
                }
            };

            Instructions[0b00_000110] = new Instruction
            {
                Mnemonic = "MOV",
                Description = "Moves a value into RegA from RegB, Immediate",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: Read from CIR, or RegB into RegA
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            return null; // Direct mode not supported.
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read);
                        } else if (ctx.MemoryMode == MemoryMode.Immediate)
                        {
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                            proc.CIR.SetFlag(BusFlags.Read);
                        }
                        ctx.RegA.SetFlag(BusFlags.Write); //Read bus into RegA
                        return null;
                    }
                }
            };

            Instructions[0b00_000111] = new Instruction
            {
                Mnemonic = "STA",
                Description = "Saves a value from RegA into memory address specified by RegB or Immediate",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: Setup MAR
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            return ctx.StageCount; // Direct memory mode not supported.
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read); // RegB => Bus
                        } else
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // Immediate Val => Bus
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                        }
                        proc.MAR.SetFlag(BusFlags.Write); // Bus => MAR
  
                        return null;
                    },
                    (proc, ctx) => //1: Setup MDR
                    {
                        ctx.RegA.SetFlag(BusFlags.Read); // RegA => Bus
                        proc.MDR.SetFlag(BusFlags.Write); // Bus => MDR
                        proc.MemoryBank.SetFlag(MemoryFlags.Write); // Trigger memory write of length two bytes
                        proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);

                        return null;
                    }
                }
            };

            Instructions[0b00_001000] = new Instruction
            {
                Mnemonic = "LDA",
                Description = "Loads a value from Memory Address specified by RegB or Immediate",

                InstructionStages = new List<InstructionStage> {
                    (proc, ctx) => //0: Setup MAR
                    {
                        if (ctx.MemoryMode == MemoryMode.Direct)
                        {
                            return ctx.StageCount; // Direct memory mode not supported.
                        } else if (ctx.MemoryMode == MemoryMode.Register)
                        {
                            ctx.RegB.SetFlag(BusFlags.Read); // RegB => Bus
                        } else
                        {
                            proc.CIR.SetFlag(BusFlags.Read); // Immediate Val => Bus
                            proc.CIR.SetFlag(BusFlags.SecondWord);
                        }
                        proc.MAR.SetFlag(BusFlags.Write); // Bus => MAR
                        proc.MemoryBank.SetFlag(MemoryFlags.Write); // Trigger memory read of length two bytes
                        proc.MemoryBank.SetFlag(MemoryFlags.TwoBytes);
                        return null;
                    },
                    (proc, ctx) => //1: Setup MDR
                    {
                        proc.MDR.SetFlag(BusFlags.Read); // MDR => Bus
                        ctx.RegA.SetFlag(BusFlags.Write); // Bus => RegA

                        return null;
                    }
                }
            };
        }
    }
}