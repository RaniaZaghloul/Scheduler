using OSProUI.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI
{
    public partial class Form2 : Form
    {
        schedAlgo tempAlgo = null;

        public Form2(Int32 n, string SchedType, string q)
        {
            InitializeComponent();
            int noOfProcess = n;
            dataGridView1.RowCount = noOfProcess;
            dataGridView1.RowHeadersVisible = false;

            DataGridViewCell cell = dataGridView1.Rows[0].Cells[0];
            dataGridView1.CurrentCell = cell;
            dataGridView1.BeginEdit(true);


            //Set The value Type Of The Cells
            dataGridView1.SelectAll();
            foreach (DataGridViewCell c in dataGridView1.SelectedCells)
            {
                if (c.OwningColumn.Name == "processName")
                    c.ValueType = typeof(string);
                else
                    c.ValueType = typeof(int);
            }

            //add thes priority and quantum columns if needed
            switch (SchedType)
            {
                case "Priority (NonPr)":
                    {
                        dataGridView1.Columns["priority"].Visible = true;
                        tempAlgo = new Priority_NonPr();
                        break;
                    }
                case "Priority (Pr)":
                    {
                        dataGridView1.Columns["priority"].Visible = true;
                        tempAlgo = new Priority_Pr();
                        break;
                    }
                case "RR":
                    {
                        tempAlgo = new RR();
                        tempAlgo.QuantumTime = Int32.Parse(q);
                        break;
                    }
                    
                case "FCFS":
                    {
                        tempAlgo = new FCFS();
                        break;
                    }

                case "SJF (Pr)":
                    {
                        tempAlgo = new SJF_Pr();
                        break;
                    }

                case "SJF (NonPr)":
                    {
                        tempAlgo = new SJF_NonPr();
                        break;
                    }
            }
        }
        private void Next_Click(object sender, EventArgs e)
        {
            bool emptyFields = false;
            List<Process> inputProcessList = null;

            //if we have an empty cell don't continue
            dataGridView1.SelectAll();
            //int counter = 0;
            foreach (DataGridViewCell c in dataGridView1.SelectedCells)
            {
                if (c.Visible == true)
                {
                    if (c.Value == null || c.Value == "")
                    {
                        emptyFields = true;
                        break;
                    }
                    else
                    {
                        //c.Value = counter;
                        //counter++;
                    }
                }
            }
            if (emptyFields)
                MessageBox.Show("You Should Fill All The Information To Continue");
            else
            {
                //Aman get the inputs
                tempAlgo.getInput(dataGridView1);
                tempAlgo.schedule();
                List<Process> o = tempAlgo.output;
                Form3 f3 = new Form3(tempAlgo);
                //this.Hide();
                f3.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

           
        }
    }
}
