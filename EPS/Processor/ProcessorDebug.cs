using System;
using System.Diagnostics;

namespace EPS
{
    public partial class Processor
    {
        public void WriteState()
        {
            Debug.WriteLine("---------------------------------");  
            Debug.WriteLine("Current PC:");
            Debug.WriteLine(BitConverter.ToInt16(PC.Value, 0));
            Debug.WriteLine("Current MAR:");
            Debug.WriteLine(BitConverter.ToInt16(MAR.Value, 0));
            Debug.WriteLine("Current MDR:");
            Debug.WriteLine(BitConverter.ToInt16(MDR.Value, 0));
            Debug.WriteLine("Current ACC:");
            Debug.WriteLine(BitConverter.ToInt16(ACC.Value, 0));
            Debug.WriteLine("Current Instruction:");
            Debug.WriteLine(Fetch.currentStage);
        }
    }
}