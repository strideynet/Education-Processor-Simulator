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
        }
    }
}