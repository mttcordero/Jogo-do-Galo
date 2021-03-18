using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogodoGalo
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int contar = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            contar++;

            VerificaVitoria();
        }

        private void VerificaVitoria()
        {
            bool vencedor = false;

            //3 em linha
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                vencedor = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                vencedor = true;

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                vencedor = true;

            // 3 em coluna
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                vencedor = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                vencedor = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!C3.Enabled))
                vencedor = true;

            // 3 em diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                vencedor = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                vencedor = true;


            if (vencedor)
            {
                desativarButton();
                string ganhou = "";
                if (turn)
                    ganhou = "O";
                else
                    ganhou = "X";

                richTextBox1.AppendText(ganhou + " Ganhou!");
            }
            else
            {
                if (contar == 9)
                {
                    richTextBox1.AppendText("Empate!");
                }
            }
        }

        private void desativarButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = c as Button;
                    if (b != null)
                    {
                        A1.Enabled = false;
                        A2.Enabled = false;
                        A3.Enabled = false;
                        B1.Enabled = false;
                        B2.Enabled = false;
                        B3.Enabled = false;
                        C1.Enabled = false;
                        C2.Enabled = false;
                        C3.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            turn = true;
            contar = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = c as Button;
                    A1.Text = string.Empty;
                    A2.Text = string.Empty;
                    A3.Text = string.Empty;
                    B1.Text = string.Empty;
                    B2.Text = string.Empty;
                    B3.Text = string.Empty;
                    C1.Text = string.Empty;
                    C2.Text = string.Empty;
                    C3.Text = string.Empty;
                    if (b != null)
                    {
                        A1.Enabled = true;
                        A2.Enabled = true;
                        A3.Enabled = true;
                        B1.Enabled = true;
                        B2.Enabled = true;
                        B3.Enabled = true;
                        C1.Enabled = true;
                        C2.Enabled = true;
                        C3.Enabled = true;
                    }

                }
            }
            catch { }
            richTextBox1.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }

