using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI.BackEnd
{
    class FCFS : schedAlgo
    {

        public override void getInput(DataGridView d)
        {

            foreach (DataGridViewRow r in d.Rows)
            {
                Process temp = new Process();
                temp.name = r.Cells[0].Value.ToString();
                temp.arrivalTime = Int32.Parse(r.Cells[1].Value.ToString());
                temp.burstTime = Int32.Parse(r.Cells[2].Value.ToString());

                processList.Add(temp);
            }
            this.noOfProcesses = processList.Count;
        }

        public override void schedule()
        {
            float wait;
            
            processList = processList.OrderBy(i => i.arrivalTime).ToList<Process>();
            timeTrack = processList[0].arrivalTime;
            foreach (Process itr in processList)
            {
                if (itr.arrivalTime <= timeTrack)
                {
                    itr.startTime = timeTrack;
                    itr.endTime = timeTrack + (itr.burstTime);
                    wait = timeTrack - (itr.arrivalTime);
                    //cout << itr->name << "    " << "arrivaltime = " << itr->arrivalTime << "    " << "burst time = " << itr->burstTime << "   " << "start = " << start << "   " << "end = " << end << "   " << "wait time = " << wait << endl;
                    Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                    output.Add(tem);
                    timeTrack = itr.endTime;
                    avgWaitingTime += wait;
                }
                else
                {
                    itr.startTime = itr.arrivalTime;
                    itr.endTime = (itr.arrivalTime) + (itr.burstTime);
                    wait = 0;
                    //cout << itr->name << "    " << "arrivaltime = " << itr->arrivalTime << "    " << "burst time = " << itr->burstTime << "   " << "start = " << start << "   " << "end = " << end << "   " << "wait time = " << wait << endl;
                    Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                    output.Add(tem);
                    timeTrack = itr.endTime;
                    avgWaitingTime += wait;
                }
            }
            avgWaitingTime = avgWaitingTime / noOfProcesses;
            //cout << "the average waiting time = " << AvgWatingTime << endl;
        }
    }
}
