using System.Collections.Generic;


namespace EPS.Instructions
{
    public delegate void InstructionStage(Processor proc);
    public class Instruction
    {
        public int currentStage;
        public List<InstructionStage> InstructionStages = new List<InstructionStage>();

        public string Mnemonic = "";
        public string Description = "";

        public byte OpCode;
        
        /// <summary>
        /// Executes the substages of micro-code
        /// </summary>
        /// <returns>True when complete</returns>
        public bool Execute(Processor proc)
        {
            if (currentStage == InstructionStages.Count) currentStage = 0;

            InstructionStages[currentStage](proc);

            currentStage++;

            return currentStage == InstructionStages.Count;
        }
    }
}