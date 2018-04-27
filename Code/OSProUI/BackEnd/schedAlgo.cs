using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI.BackEnd
{
   public class schedAlgo
    {
        public int noOfProcesses = 0;
        public int timeTrack = 0;
        public float avgWaitingTime;
        public Int32 QuantumTime;

        public List<Process> processList = new List<Process>();
        public List<Process> waitingProcessList = new List<Process>();
        public List<Process> executedProcessList = new List<Process>();
        public List<Process> currentProcessList = new List<Process>();
        public List<Process> output = new List<Process>();
        public virtual void getInput(DataGridView d)
        {
            //will differ due to the algo so must be overriden
        }
        //public virtual void showOutput() { }
        public virtual void schedule() { }
        public virtual void getWaitingProcess(List<Process> lst)
        {
            
            List<Process> tempDelList = new List<Process>();

            foreach (Process p in processList)
            {
                if (p.arrivalTime <= timeTrack)
                {
                    lst.Add(p);
                    tempDelList.Add(p);
                }
            }
            foreach(Process p in tempDelList)
            {
                processList.Remove(p);
            }
            //lw fy 7aga mestaneya w fy 7aga 48ala 
            
        }
    }
}
