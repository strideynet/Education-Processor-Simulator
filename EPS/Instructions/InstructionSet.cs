using System.Collections.Generic;
using EPS.Components;

namespace EPS.Instructions
{
    public class InstructionSet
    {
        public Instruction[] Instructions = new Instruction[64];

        public InstructionSet()
        {
            Instructions[0] = new Instruction
            {
                Mnemonic = "ADD",
                Description = "Adds reg1 to reg2 or memory location and stores output in ACC.",
                
                InstructionStages = new List<InstructionStage> {
                    proc => // 0: Check memory mode and begin fetch from memory if appropriate. If not read regb into ACC.
                    {
                        return null;
                    },
                    proc => // 1: Read from memory into ACC
                    {
                        return null;
                    },
                    proc => // 2: Trigger add operation
                    {
                        return null;
                    }
                }
            };
        }
    }
}