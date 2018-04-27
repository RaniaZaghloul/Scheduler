using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI.BackEnd
{
    class Priority_NonPr : schedAlgo
    {
        public override void getInput(DataGridView d)
        {
            foreach (DataGridViewRow r in d.Rows)
            {
                Process temp = new Process() ;
                temp.name = r.Cells[0].Value.ToString();
                temp.arrivalTime = Int32.Parse(r.Cells[1].Value.ToString());
                temp.burstTime = Int32.Parse(r.Cells[2].Value.ToString());
                temp.priority = Int32.Parse(r.Cells[4].Value.ToString());

                processList.Add(temp);
            }
            noOfProcesses = processList.Count;

        }


        public override void schedule()
        {
            avgWaitingTime = 0;
            processList = processList.OrderBy(i => i.arrivalTime).ToList<Process>();
            timeTrack = processList[0].arrivalTime;
            //repeat while we still have processes (waiting or coming)
            while (processList.Count != 0 || currentProcessList.Count != 0)
            {
                //get waiting processes
                getWaitingProcess(currentProcessList);

                //execute waiting processes if any
                if (currentProcessList.Count != 0)
                {
                    //get the pr[ocess with highest priority
                    currentProcessList = currentProcessList.OrderBy(i => i.priority).ToList<Process>();

                    //set the start time and the end time of the process and push it to the output list
                    currentProcessList[0].startTime = timeTrack;
                    currentProcessList[0].endTime = timeTrack + currentProcessList[0].burstTime;

                    avgWaitingTime += currentProcessList[0].startTime - currentProcessList[0].arrivalTime;
                    Process tem = new Process(currentProcessList[0].name, currentProcessList[0].startTime, currentProcessList[0].endTime);
                    output.Add(tem);
                    timeTrack += currentProcessList[0].burstTime;

                    //remove it from currentProcess List
                    currentProcessList.RemoveAt(0);
                }
                else
                {
                    timeTrack += 1;
                }
            }
            avgWaitingTime = avgWaitingTime / noOfProcesses;

        }
    }
}
