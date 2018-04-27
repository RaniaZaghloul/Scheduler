using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI.BackEnd
{
    class SJF_NonPr : schedAlgo
    {
        Process getExecProcess()
        {

            //get All processes that arrived now into the waiting queue
            List<Process> tempDelLst = new List<Process>();
            foreach(Process it in processList)
            {
                if (it.arrivalTime <= timeTrack)
                {
                    waitingProcessList.Add(it);
                    tempDelLst.Add(it);

                    //waitingProcessList.splice(waitingProcessList.begin(), processList, it);
                    //it = processList.begin();
                }
            }
            foreach(Process it in tempDelLst)
            {
                processList.Remove(it);
            }
            tempDelLst.Clear();
            //sort the waiting processes queue by Shortest burst time
            waitingProcessList = waitingProcessList.OrderBy(i => i.burstTime).ToList<Process>();
            //waitingProcessList.sort([](const Process &first, const Process &second){ return first.burstTime < second.burstTime; });
            Process p = new Process();
            if (waitingProcessList.Count != 0)
                p = waitingProcessList[0];
            else
                processList = null;
            return p;
        }

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

            //=================== initialization =====================//
            avgWaitingTime = 0;
            //sort the list -_- 
            processList = processList.OrderBy(i => i.arrivalTime).ToList<Process>();
		    //processList.sort([](const Process &first, const Process & second){return first.arrivalTime<second.arrivalTime;});
		
		    //initialize the timeTrack to the arrival time of the process that arrived first
		    timeTrack = (processList[0]).arrivalTime;

            //====================== execution =======================//
            Process processAtExecution = getExecProcess();

            for (; waitingProcessList.Count!=0; )
		    {
                
		        //processAtExecution = getExecProcess();
		        //set start time
		        if( processAtExecution.arrivalTime > timeTrack)
                {
                    processAtExecution.startTime = processAtExecution.arrivalTime;
                    timeTrack = processAtExecution.arrivalTime;
                }
                else 
    			{
                    processAtExecution.startTime = timeTrack;
                    avgWaitingTime += processAtExecution.startTime - processAtExecution.arrivalTime;
                }

    		    //set end time and update track
		        processAtExecution.endTime = timeTrack + (processAtExecution.burstTime);
                output.Add(processAtExecution);
		        timeTrack = ((processAtExecution).endTime);
                //exIt = waitingProcessList[0];
                executedProcessList.Add(waitingProcessList[0]);
                waitingProcessList.RemoveAt(0);
                processAtExecution = getExecProcess();

                //executedProcessList.splice(executedProcessList.begin(), waitingProcessList, exIt);
            }
            avgWaitingTime = avgWaitingTime /(float) noOfProcesses;
	}	

    }
}
