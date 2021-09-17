using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        


        static int GetWordCount(string text)
            {
                int wordCount = 0, index = 0;

                // skip whitespace until first word
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;

                while (index < text.Length)
                {
                    // check if current char is part of a word
                    while (index < text.Length && !char.IsWhiteSpace(text[index]))
                        index++;

                    wordCount++;

                    // skip whitespace until next word
                    while (index < text.Length && char.IsWhiteSpace(text[index]))
                        index++;
                }

                return wordCount;
            }

            public DateTime agora { get; set; }
            public TimeSpan tempoPassado;
            

        public void button1_Click(object sender, EventArgs e)
        {
            //quando clicar aqui, o timer começa a correr.
            
            agora = DateTime.Now;
            timer1.Enabled = true;
            
            
        }

        private void Timer1_tick(object Sender, EventArgs e)
        {
            // Set the caption to the current time.  
            tempoPassado = DateTime.Now - agora;
            label1.Text = tempoPassado.ToString(@"mm\:ss\:ff");


            label2.Text = Convert.ToString(GetWordCount(textBox1.Text));
            string ppmlive;
            ppmlive = Convert.ToString(Math.Round((Convert.ToDouble(GetWordCount(textBox1.Text))*60) / Convert.ToDouble(tempoPassado.TotalSeconds), 2));
            label3.Text = ppmlive;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            // Quando clicar aqui o timer para e o calculo de
            // Palavras por minuto é efetuado.
            //DateTime agora = button1;

            timer1.Enabled = false;
            DateTime termino = DateTime.Now;
            TimeSpan intervalo = termino-agora;
            label1.Text = intervalo.ToString(@"mm\:ss\:ff");            
            double PPM = Math.Round(Convert.ToDouble(label2.Text) / Convert.ToDouble(intervalo.TotalSeconds)) * 60d;
            double ppm = PPM;
            label3.Text = Convert.ToString(ppm);
            label2.Text = Convert.ToString(GetWordCount(textBox1.Text));



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            label2.Text = Convert.ToString(GetWordCount(textBox1.Text));
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
