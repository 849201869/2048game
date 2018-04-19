using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048game
{
    public partial class Form1 : Form
    {
        Button[,] btns = new Button[4, 4];
        string[,] btnsc = new string[4, 4];
        int score;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateAllButton();
            btns[1, 2].Text = "2";
        }

        void GenerateAllButton()
        {
            int x0 = 50, y0 = 30, w = 45, d = 50;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    btn.Top = y0 + i * d;
                    btn.Left = x0 + j * d;
                    btn.Width = w;
                    btn.Height = w;
                    //btn.Dock = DockStyle.Fill;
                    btn.Font = new Font("默认",10f,FontStyle.Bold);
                    btn.Visible = true;
                    btn.Tag = i * 4 + j;
                    btns[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }
        }

        void GenerateNewNum()
        {
            Random r = new Random();
            int x = r.Next(4);
            int y = r.Next(4);
            do
            {
                x = r.Next(4);
                y = r.Next(4);
            } while (btns[x, y].Text != "");
            btns[x, y].Text = "2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateNewNum();
        }

        #region
        void up()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int t = 3 - i;
                    while (t >= 0 && t <= 3)
                    {
                        if (btns[i, j].Text == "")
                        {
                            string temp;
                            temp = btns[i, j].Text;
                            btns[i, j].Text = btns[i + t, j].Text;
                            btns[i + t, j].Text = temp;
                            t--;
                        }
                        else
                            t--;
                    }
                }
            }
        }
        void upcal()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (btns[i, j].Text == btns[i + 1, j].Text && btns[i + 1, j].Text != "")
                    {
                        btns[i, j].Text = (Int32.Parse(btns[i, j].Text) * 2).ToString();
                        btns[i + 1, j].Text = "";
                        score += 100;
                    }
                }
            }
        }

        void down()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i >=0; i--)
                {
                    int t =i;
                    while (t>=0&&t<=3)
                    {
                        if (btns[i, j].Text == "")
                        {
                            string temp;
                            temp = btns[i, j].Text;
                            btns[i, j].Text = btns[ t, j].Text;
                            btns[t, j].Text = temp;
                            t--;
                        }
                        else
                            t--;
                    }
                }
            }
        }
        void downcal()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i >0; i--)
                {
                    if (btns[i, j].Text == btns[i - 1, j].Text && btns[i - 1, j].Text != "")
                    {
                        btns[i, j].Text = (Int32.Parse(btns[i, j].Text) * 2).ToString();
                        btns[i - 1, j].Text = "";
                        score += 100;
                    }
                }
            }
        }

        void left()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int t =  j;
                    while (t >= 0 && t <= 3)
                    {
                        if (btns[i, j].Text == "")
                        {
                            string temp;
                            temp = btns[i, j].Text;
                            btns[i, j].Text = btns[i, t].Text;
                            btns[i, t].Text = temp;
                            t++;
                        }
                        else
                            t++;
                    }
                }
            }
        }
        void leftcal()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (btns[i, j].Text == btns[i, j + 1].Text && btns[i, j + 1].Text != "")
                    {
                        btns[i,j].Text= (Int32.Parse(btns[i, j].Text) * 2).ToString();
                        btns[i, j + 1].Text = "";
                        score += 100;
                    }
                }
            }
        }

        void right()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >=0; j--)
                {
                    int t = j;
                    while (t>=0&&t<=3)
                    {
                        if (btns[i, j].Text == "")
                        {
                            string temp;
                            temp = btns[i, j].Text;
                            btns[i, j].Text = btns[i, t].Text;
                            btns[i, t].Text = temp;
                            t--;
                        }
                        else
                            t--;
                    }
                }
            }
        }
        void rightcal()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >0; j--)
                {
                    if (btns[i, j].Text == btns[i, j - 1].Text && btns[i, j - 1].Text != "")
                    {
                        btns[i, j].Text = (Int32.Parse(btns[i, j].Text)*2).ToString();
                        btns[i, j - 1].Text = "";
                        score += 100;
                    }
                }
            }
        }
        #endregion

        bool cangen()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (btns[i, j].Text == btnsc[i, j])
                        continue;
                    else if(btns[i, j].Text != btnsc[i, j])
                        return true;
                }
            }
            return false;
        }
        void Copyb()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    btnsc[i, j] = btns[i, j].Text;
                }
            }
        } 

        void ChangeColor()
        {
            foreach (Button b in btns)
            {
                if (b.Text == "2")
                    b.ForeColor = Color.Green;
                else if (b.Text == "4")
                    b.ForeColor = Color.GreenYellow;
                else if (b.Text == "8")
                    b.ForeColor = Color.Honeydew;
                else if (b.Text == "16")
                    b.ForeColor = Color.HotPink;
                else if (b.Text == "32")
                    b.ForeColor = Color.IndianRed;
                else if (b.Text == "64")
                    b.ForeColor = Color.Indigo;
                else if (b.Text == "128")
                    b.ForeColor = Color.Ivory;
                else if (b.Text == "256")
                    b.ForeColor = Color.Khaki;
                else if (b.Text == "512")
                    b.ForeColor = Color.Lavender;
                else if (b.Text == "1024")
                    b.ForeColor = Color.LavenderBlush;
                else if (b.Text == "2048")
                    MessageBox.Show("Congratulations!"); 
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 100)
            {
                Copyb();
                right();
                rightcal();
                if(cangen())
                  GenerateNewNum();
                ChangeColor();
                label1.Text = score.ToString();
            }
            else if (e.KeyChar == 97)
            {
                Copyb();
                left();
                leftcal();
                if (cangen())
                    GenerateNewNum();
                ChangeColor();
                label1.Text = score.ToString();
            }
            else if (e.KeyChar == 119)
            {
                Copyb();
                up();
                upcal();
                if (cangen())
                    GenerateNewNum();
                ChangeColor();
                label1.Text = score.ToString();
            }
            else if (e.KeyChar == 115)
            {
                Copyb();
                down();
                downcal();
                if (cangen())
                    GenerateNewNum();
                ChangeColor();
                label1.Text = score.ToString();
            }
        }
    }
}

