using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSProUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     
        //[DllImport(@"C:\3anQa2\College\College Projects\OSPro\OSProDLL3\Debug\OSProDLL3.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern class Process;
       
        //[DllImport(@"C:\3anQa2\College\College Projects\OSPro\OSProDLL3\Debug\OSProDLL3.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int GetNextStartOrEndTime();

        //[DllImport(@"C:\3anQa2\College\College Projects\OSPro\OSProDLL3\Debug\OSProDLL3.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern string GetNextName();

        //[DllImport(@"C:\3anQa2\College\College Projects\OSPro\OSProDLL3\Debug\OSProDLL3.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int Initiate(string schedType, string n);

        private void button1_Click(object sender, EventArgs e)
        {

            Int32 n = Int32.Parse(txtBoxNoOfProcesses.Text);
            string s = SchedTypeCombo.Text;
           
            Form2 f2 = new Form2(n, SchedTypeCombo.Text, textBox1.Text);
            f2.Show();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SchedTypeCombo_TextChanged(object sender, EventArgs e)
        {
            if (SchedTypeCombo.Text == "RR")
            {
                label3.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBox1.Visible = false;
            }
        }
    }
}
