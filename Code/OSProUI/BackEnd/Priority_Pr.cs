using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI.BackEnd
{
    class Priority_Pr : schedAlgo
    {

        public override void getInput(DataGridView d)
        {
            foreach (DataGridViewRow r in d.Rows)
            {
                Process temp = new Process();
                temp.name = r.Cells[0].Value.ToString();
                temp.arrivalTime = Int32.Parse(r.Cells[1].Value.ToString());
                temp.burstTime = Int32.Parse(r.Cells[2].Value.ToString());
                temp.priority = Int32.Parse(r.Cells[4].Value.ToString());

                processList.Add(temp);
            }
            this.noOfProcesses = processList.Count;
        }

        public override void schedule()
        {
            //repeat while we still have processes (waiting or coming)
            avgWaitingTime = 0;
            processList = processList.OrderBy(i => i.arrivalTime).ToList<Process>();
            timeTrack = processList[0].arrivalTime;

            do
            {
               
                //get waiting processes
                getWaitingProcess(waitingProcessList);

                //sort according to the priority
                waitingProcessList = waitingProcessList.OrderBy(i => i.priority).ToList();
                //sort([](const Process &first, const Process &second) { return first.priority < second.priority; });

                //if we have no executing process take the first one from the waiting list
                if (currentProcessList.Count == 0)
                {
                    currentProcessList.Add(waitingProcessList[0]);
                    waitingProcessList.RemoveAt(0) ;

                    currentProcessList[0].start.Add(timeTrack);
                    currentProcessList[0].startTime = timeTrack;
                    //currentProcessList.splice(currentProcessList.begin(), waitingProcessList, waitingProcessList.begin());
                    //currentProcessList.begin()->start.push_back(timeTrack);
                }

                //cheeck if there is upcoming process have a higher priority
                else if (waitingProcessList.Count != 0 && (waitingProcessList[0].priority < currentProcessList[0].priority))
                {
                    //move the currently executed process to the current process list and set its end time 
                    currentProcessList[0].end.Add(timeTrack);
                    currentProcessList[0].endTime = timeTrack;
                    Process tempO = new Process(currentProcessList[0].name, currentProcessList[0].startTime, currentProcessList[0].endTime);
                    output.Add(tempO);

                    waitingProcessList.Add(currentProcessList[0]);
                    currentProcessList.Remove(currentProcessList[0]);

                    currentProcessList.Add(waitingProcessList[0]);
                    currentProcessList.RemoveAt(0);

                    if(currentProcessList.Count != 0)
                    {
                        currentProcessList[0].start.Add(timeTrack);
                        currentProcessList[0].startTime = timeTrack;
                    }
                    

                    //waitingProcessList.splice(waitingProcessList.end(), currentProcessList, currentProcessList.begin());
                    //put the other process in the currentExecutedList and set its start time
                    //currentProcessList.splice(currentProcessList.begin(), waitingProcessList, waitingProcessList.begin());
                    //currentProcessList.begin()->start.push_back(timeTrack);
                }

                //decrease the burst time and cheeck if it's equal to zero
                if (currentProcessList.Count != 0)
                {
                    currentProcessList[0].burstTime--;
                    //currentProcessList.begin()->burstTime--;
                    avgWaitingTime--;

                    if (currentProcessList[0].burstTime == 0)
                    {
                        currentProcessList[0].endTime = timeTrack + 1;
                        currentProcessList[0].end.Add(timeTrack + 1);
                        avgWaitingTime += timeTrack + 1 - currentProcessList[0].arrivalTime;

                        Process tempO = new Process(currentProcessList[0].name, currentProcessList[0].startTime, currentProcessList[0].endTime);
                        output.Add(tempO);
                        //output.Add(currentProcessList[0]);
                        currentProcessList.RemoveAt(0);
                        //output.splice(output.begin(), currentProcessList, currentProcessList.begin());
                    }
                    timeTrack++;

                }

            } while (processList.Count != 0 || waitingProcessList.Count != 0 || currentProcessList.Count != 0);

            float tempavgWaitingTime = 0;
            foreach (Process it in output)
            {
                tempavgWaitingTime += (it.endTime - it.arrivalTime);
            }
            avgWaitingTime = (avgWaitingTime) / noOfProcesses;
        }

        //void showOutput()
        //{
        //    float tempavgWaitingTime = 0;

        //    foreach (Process it in output)
        //    {
        //        tempavgWaitingTime += (it.endTime - it.arrivalTime);
        //    }
        //    avgWaitingTime = (tempavgWaitingTime - avgWaitingTime) / noOfProcesses;
        //    //cout << "avgWaitingTime Is :   " << avgWaitingTime << endl;
        //}

    }
}
