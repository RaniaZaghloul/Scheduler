using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSProUI.BackEnd;

namespace OSProUI
{
    public partial class data_gride : UserControl
    {
        public data_gride(schedAlgo tempAlgo)
        {
            InitializeComponent();
            //Process temp = new Process { s = 0, name1 = "Process1", e = 5 };
            //Process temp2 = new Process { s = 6, name1 = "Process2", e = 8 };
            //Process temp3 = new Process { s = 9, name1 = "Process3", e = 12 };

            //Process[] x = new Process[3];
            //x[0] = temp;
            //x[1] = temp2;
            //x[2] = temp3;

            dataGridView2.ColumnCount = tempAlgo.output.Count;
            dataGridView2.ColumnHeadersVisible = true;

            var tabs = new string(' ', 10);
            for (int i = 0; i < tempAlgo.output.Count; i++)
            {

                dataGridView2.Columns[i].Name = tempAlgo.output[i].name.ToString() + Environment.NewLine + tempAlgo.output[i].startTime.ToString() + tabs + tempAlgo.output[i].endTime.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
