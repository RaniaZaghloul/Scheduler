using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSProUI.BackEnd
{
    public class Process
    {
        public Process() { }
        public Process(string name, int startTime, int endTime)
        {
            this.name = name;
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public string name;
        public int arrivalTime, startTime, endTime, burstTime, priority;
        public List<int> start = new List<int>();
        public List<int> end = new List<int>();
    }
}
