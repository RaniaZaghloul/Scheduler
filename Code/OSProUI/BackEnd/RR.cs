using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI.BackEnd
{
    class RR:schedAlgo
    {
        Process tempProcess = new Process();
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
            List<Process> y;
            //List<Process>::iterator itr1;
            int max_burst;
            int max_b;
            y = processList;
            //initialize time track
            y = y.OrderBy(i => i.arrivalTime).ToList<Process>();
            timeTrack = y[0].arrivalTime;

            processList = processList.OrderBy(i => i.burstTime).ToList<Process>();
            max_burst = processList[noOfProcesses-1].burstTime;

            //foreach (Process itr1 in y)
            //{
            //    max_b= itr1.burstTime;
            //}
            //max_burst = max_b;
            

            float wait;
            avgWaitingTime = 0;

            // processList = processList.OrderBy(i => i.arrivalTime).ToList<Process>();
            //cout << "please enter the Quantum Time. " << endl;
            //cin >> QuantumTime;
            //for (itr = x.begin();;itr++)
            //for(int k=max_burst;k>0;)
            int m;
             while(max_burst>0)
           
            {
                processList = processList.OrderBy(i => i.arrivalTime).ToList<Process>();
                m = processList[0].arrivalTime;
                foreach (Process itr in processList)
                {
                    
                    if (itr.burstTime != 0)
                    {
                        if (itr.arrivalTime <= timeTrack)
                        {
                            if (itr.burstTime <= QuantumTime)
                            {


                                itr.startTime = timeTrack;
                                itr.endTime = timeTrack + itr.burstTime;

                                Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                                output.Add(tem);

                                wait = timeTrack - itr.arrivalTime;
                                itr.arrivalTime = itr.endTime;

                                //cout << itr.name << "   " << "startTime = " << startTime << "    " << "endTime = " << endTime << "  " << "wait= " << wait << endTimel;
                                timeTrack = itr.endTime;
                                itr.burstTime = 0;
                                avgWaitingTime += wait;
                            }
                            else
                            {


                                itr.startTime = timeTrack;
                                itr.endTime = timeTrack + QuantumTime;

                                Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                                output.Add(tem);

                                wait = timeTrack - itr.arrivalTime;

                                itr.arrivalTime = itr.endTime;
                                //cout << itr.name << "   " << "startTime = " << startTime << "    " << "endTime = " << endTime << "  " << "wait= " << wait << endTimel;
                                timeTrack = itr.endTime;

                                itr.burstTime = itr.burstTime - QuantumTime;
                                avgWaitingTime += wait;
                            }
                        }
                        else
                        {
                            if (itr.burstTime <= QuantumTime)
                            {

                                itr.startTime = itr.arrivalTime;
                                itr.endTime = itr.arrivalTime + itr.burstTime;
                                Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                                output.Add(tem);
                                wait = timeTrack - itr.arrivalTime;
                                if (wait < 0)
                                {
                                    wait = 0;
                                }
                                itr.arrivalTime = itr.endTime;

                                //cout << itr.name << "   " << "startTime = " << startTime << "    " << "endTime = " << endTime << "  " << "wait= " << wait << endTimel;
                                timeTrack = itr.endTime;
                                itr.burstTime = 0;
                                avgWaitingTime += wait;
                            }
                            else
                            {


                                itr.startTime = itr.arrivalTime;
                                itr.endTime = itr.arrivalTime + QuantumTime;
                                wait = timeTrack - itr.arrivalTime;
                                if (wait < 0)
                                {
                                    wait = 0;
                                }
                                itr.arrivalTime = itr.endTime;
                                Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                                output.Add(tem);
                                //cout << itr.name << "   " << "startTime = " << startTime << "    " << "endTime = " << endTime << "  " << "wait= " << wait << endTimel;
                                timeTrack = itr.endTime;
                                itr.burstTime = itr.burstTime - QuantumTime;
                                avgWaitingTime += wait;
                            }
                        }

                    }
                    else
                    {

                        itr.startTime = timeTrack;
                        itr.endTime = timeTrack;
                        wait = 0;
                        timeTrack = itr.endTime;
                        //Process tem = new Process(itr.name, itr.startTime, itr.endTime);
                        //output.Add(tem);

                    }

                }

                processList = processList.OrderBy(i => i.burstTime).ToList<Process>();
                max_burst = processList[noOfProcesses-1].burstTime;
            }
           


            avgWaitingTime = (avgWaitingTime ) / noOfProcesses;
            //cout << "the avg waiting time = " << AvgWaitingTime << endTimel;
            //cout << SumOfWait << endl;
        }
    }
}
