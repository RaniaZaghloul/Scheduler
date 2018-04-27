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
    public partial class Form3 : Form
    {
        private schedAlgo temp = null;
        public Form3(schedAlgo tempAlgo)
        {
            InitializeComponent();
            temp = tempAlgo;
            List<data_gride> buttons = new List<data_gride>();

            data_gride newButton = new data_gride(temp);
            buttons.Add(newButton);
            this.Controls.Add(newButton);
            this.textBox1.Text = tempAlgo.avgWaitingTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
