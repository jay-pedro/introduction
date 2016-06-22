using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MSMove
{
    public partial class Form1 : Form
    {

        int intCounter;

        public Form1()
        {            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Visible = false;
            timer1.Interval = 30000;
            timer1.Enabled = true;
            intCounter = 0;
            MoveCursor();          
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  
                return cp;
            }
        }


        private void MoveCursor()
        {
            intCounter += 1;

            if (intCounter == 60)
            {
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files\Internet Explorer\iexplore.exe",
                        Arguments = "http://10.43.3.111",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                proc.Start();

                intCounter = 0;

            }

            Random myRnd = new Random();            
            int x = myRnd.Next(0, Screen.PrimaryScreen.Bounds.Width);
            int y = myRnd.Next(0, Screen.PrimaryScreen.Bounds.Height);
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(x,y);            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveCursor();
        }
    }
}
