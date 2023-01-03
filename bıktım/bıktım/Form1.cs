using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bıktım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int secim, baslangıc, bahisbakiyesi = 15, bahis = 0;
        Random rastgele = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Visible = false;
            button4.Visible = false;
            label7.Text = bahis.ToString();
            label6.Text = bahisbakiyesi.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secim = 1;
            button2.Enabled = false;
            button3.Visible = true;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += rastgele.Next(5, 17);
            pictureBox2.Left += rastgele.Next(5, 17);

            int bitis = label12.Left;

            if (pictureBox1.Left > pictureBox2.Left)
            {
                label11.Text = "Tavsan Önde Götürüyor";
            }
            else if (pictureBox2.Left > pictureBox1.Left)
            {
                label11.Text = "Kaplumbağa Önde Götürüyor";
            }

            if (pictureBox1.Width + pictureBox1.Left >= bitis)
            {
                timer1.Enabled = false;
                MessageBox.Show("Tavsan Negs");
                button4.Visible = true;
                if (secim == 1)
                {
                    MessageBox.Show("Tahmininiz Doğru Tebrikler");
                    MessageBox.Show($"bakiyenize yaptıpınız {bahis} eklendi");
                    bahisbakiyesi += bahis;
                    label6.Text = bahisbakiyesi.ToString();
                }
                else
                {
                    MessageBox.Show("tahmininiz yanlış");
                    bahisbakiyesi -= bahis;
                    label6.Text = bahisbakiyesi.ToString();
                    if (bahisbakiyesi < 1)
                    {
                        MessageBox.Show("Bakiye bitti.....");
                    }
                }
            }
            else if (pictureBox2.Width + pictureBox2.Left >= bitis)
            {
                timer1.Enabled = false;
                MessageBox.Show("Kaplumbağa Negs");
                button4.Visible = true;
                if (secim == 2)
                {
                    MessageBox.Show("tahmininiz doğru tebrikler");
                    MessageBox.Show($"bakiyenize yaptıpınız {bahis} eklendi");
                    bahisbakiyesi += bahis;
                    label6.Text = bahisbakiyesi.ToString();
                }
                else
                {
                    MessageBox.Show("tahmininiz yanlış");
                    bahisbakiyesi -= bahis;
                    label6.Text = bahisbakiyesi.ToString();
                    if (bahisbakiyesi < 1)
                    {
                        MessageBox.Show("Bakiye bitti.....");
                    }
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bahisbakiyesi > bahis)
            {
                bahis++;
                label7.Text = bahis.ToString();
            }
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bahisbakiyesi > 0)
            {
                bahis--;
                label7.Text = bahis.ToString();
            }
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secim = 2;
            button2.Enabled = false;
            button3.Visible = true;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = baslangıc;
            pictureBox2.Left = baslangıc;
            button4.Visible = false;
            button3.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            bahis = 0;
            label7.Text = bahis.ToString();
        }
    }
}
