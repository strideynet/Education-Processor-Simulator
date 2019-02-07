using System.Collections.Generic;


namespace EPS.Instructions
{
    public delegate int? InstructionStage(Processor proc, ProcessorExecutionContext ctx);
    public class Instruction
    {
        public int currentStage = 0;
        public List<InstructionStage> InstructionStages = new List<InstructionStage>();

        public string Mnemonic = "";
        public string Description = "";

        public byte OpCode;
        
        /// <summary>
        /// Executes the substages of micro-code
        /// </summary>
        /// <returns>True when complete</returns>
        public bool Execute(ProcessorExecutionContext ctx)
        {
            ctx.StageCount = InstructionStages.Count;
            currentStage = InstructionStages[currentStage](ctx.Proc, ctx) ?? currentStage + 1; // Jump to specified microcode or just increment stage.

            if (currentStage != InstructionStages.Count) return false;
            
            currentStage = 0; // If at end, reset. 
            return true; // Signal system that an instruction is ready for execution.
        }
    }
}