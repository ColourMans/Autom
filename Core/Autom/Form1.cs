using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TempSys;

namespace Autom
{
    public partial class Form1 : Form
    {
        [DllImport("LenovoEmExpandedAPI.dll")]
        public static extern int SetCleanDust(IntPtr arg_1, IntPtr arg_2);

        public Form1()
        {
            InitializeComponent();
            Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            string text = Convert.ToString(Temp.GetTemp());
            textBox2.Text = text + " C";
            notifyIcon1.Text = "Autom " + text + " C";
        }

        int temp = 45, temp2, temp3, temp4;
        int flgfan = 0, flgfan2 = 0, flgfansch = 0;

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    // возвращаем отображение окна
                    this.ShowInTaskbar = true;
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    // прячем наше окно
                    WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string text = Convert.ToString(Temp.GetTemp());
            textBox2.Text = text + " C";
            notifyIcon1.Text = "Autom " + text + " C";
            temp2 = temp;
            temp3 = ((temp2 + temp) / 2);
            temp4 = ((temp3 + temp2 + temp) / 3);
            temp = Convert.ToInt32(text);
            if (temp4 >= 68)
            {
                flgfansch = flgfansch + 1;
                if (flgfansch >= 12)
                {
                    flgfan = 0;
                    flgfansch = 1;
                }
                if (flgfan == 0 && flgfan2 == 0 && flgfansch == 1)
                {
                    SetCleanDust(new IntPtr(1), new IntPtr(0));
                    flgfan = 1;
                }
            }
            if (temp3 <= 66)
            {
                if (flgfan == 1 && flgfan2 == 0)
                {
                    SetCleanDust(new IntPtr(0), new IntPtr(0));
                    flgfan = 0;
                    flgfansch = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetCleanDust(new IntPtr(1), new IntPtr(0));
            flgfan2 = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetCleanDust(new IntPtr(0), new IntPtr(0));
            flgfan2 = 0;
        }
    }
}

