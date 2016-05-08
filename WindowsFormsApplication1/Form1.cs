using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApplication1
{
  
    public partial class Form1 : Form
    {
        string[] word=  { "红","黄","蓝","绿","黑" };
        SolidBrush[] color = { new SolidBrush(Color.Red), new SolidBrush(Color.Yellow), new SolidBrush(Color.Blue), new SolidBrush(Color.Green), new SolidBrush(Color.Black) };
        Color[] bgcolor = { Color.Red, Color.Yellow ,Color.Blue,Color.Green,Color.Black};
        string textstring = "";


        Graphics g1,g2,g3;

        Bitmap aaa,bbb,ccc;
        
        System.Timers.Timer abc;
        

        Random ra = new Random();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            abc = new System.Timers.Timer();
            abc.Interval = 200*int.Parse(trackBar2.Value.ToString())+500;
            label3.Text = "时间间隔为: " + abc.Interval/1000+"s";
            abc.Elapsed+=apple;
            abc.Start();
        }

        public void apple(object source, System.Timers.ElapsedEventArgs e)
        {
           
            

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        pictureBox2.Image = randomdrawcolor();
                        break;
                    case 1:
                        pictureBox1.Image = randomdrawint();
                        break;
                    case 2:
                        pictureBox3.Image = randomdrawbg();
                        break;
                    default:
                        break;
                }
               
            
        }

        public Bitmap randomdrawint()
        {
            //aaa.Dispose();
           // if (aaa != null) 
           //     aaa.Dispose();
           // if (g2 != null) g2.Dispose();
            aaa = new Bitmap(pictureBox3.Size.Width, pictureBox3.Size.Height);
            g1 = Graphics.FromImage(aaa);
            string string1 = ra.Next(10).ToString();
            int number = ra.Next(6)+1;
            for (int i = 0; i < number; i++)
            {
                textstring = string1 + textstring;
            }
                g1.DrawString(textstring, new Font("Arial", 
                    72 + 9 * int.Parse(trackBar1.Value.ToString())
                   ), color[ra.Next(5)], new PointF(pictureBox3.Size.Width / 2 - (72 + 9 * int.Parse(trackBar1.Value.ToString()))*(number/2), pictureBox3.Size.Height / 2 - (72 + 9 * int.Parse(trackBar1.Value.ToString()))));
                number = 0;
                textstring = "";
                
                return aaa;
        }

        public Bitmap randomdrawbg()
        {
            //aaa.Dispose();
           // if (aaa != null) aaa.Dispose();
           // if (g2 != null) g2.Dispose();
            
            bbb = new Bitmap(pictureBox3.Size.Width, pictureBox3.Size.Height);
            
            g2 = Graphics.FromImage(bbb);
            int choosebgcolor = ra.Next(5);
            g2.Clear(bgcolor[choosebgcolor]);
            int choosecolor=ra.Next(5);
            while(true)
            {
                if (choosecolor!=choosebgcolor) 
                {
                    break;
                }
                else 
                {
                    choosecolor=ra.Next(5);
                }
            }
            g2.DrawString(word[ra.Next(5)], new Font("Arial", 72 + 18 * int.Parse(trackBar1.Value.ToString())), color[choosecolor], new PointF(
                (pictureBox3.Size.Width / 2 - (72 + 18 * int.Parse(trackBar1.Value.ToString())))>0? pictureBox3.Size.Width / 2 - (72 + 18 * int.Parse(trackBar1.Value.ToString())):0
                , 
                (pictureBox3.Size.Height / 2 - (72 + 18 * int.Parse(trackBar1.Value.ToString())))>0?pictureBox3.Size.Height / 2 - (72 + 18 * int.Parse(trackBar1.Value.ToString())):0
                ));
            
            return bbb;
        }

        public Bitmap randomdrawcolor()
        {
            //aaa.Dispose();
           // if (aaa != null) aaa.Dispose();
           // if (g3 != null) g2.Dispose();
            ccc = new Bitmap(pictureBox3.Size.Width, pictureBox3.Size.Height); 
            
            g3 = Graphics.FromImage(ccc);

            g3.DrawString(word[ra.Next(5)], new Font("Arial", 188 + 27 * int.Parse(trackBar1.Value.ToString())), color[ra.Next(5)], new PointF(
                (pictureBox3.Size.Width / 2 - (188 + 27 * int.Parse(trackBar1.Value.ToString())))>0?pictureBox3.Size.Width / 2 - (188 + 27 * int.Parse(trackBar1.Value.ToString())):0
                , (pictureBox3.Size.Height / 2 - (188 + 27 * int.Parse(trackBar1.Value.ToString())))>0?pictureBox3.Size.Height / 2 - (188 + 27 * int.Parse(trackBar1.Value.ToString())):0
                ));
            
            return ccc;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            abc.Interval = 200 * int.Parse(trackBar2.Value.ToString()) + 500;
            label3.Text = "时间间隔为: " + abc.Interval/1000+"s";
        }

        
    }
}
