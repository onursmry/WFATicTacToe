using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFATicTacToe
{
    public partial class Form1 : Form
    {
        private bool turn = true; // true = X false = O 
        private int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    b.BackColor = this.BackColor;
                } //end try
                catch
                {

                } //end catch
            }//end foreach
        }

        private void sıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_winCount.Text = "0";
            o_winCount.Text = "0";
            draw_Count.Text = "0";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Onur Esmeray tarafından", "Tic Tac Toe Hakkında");
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
            {
                b.Text = "X";
                b.BackColor = Color.Coral;
            }
            else
            {
                b.Text = "O";
                b.BackColor = Color.Crimson;
            }

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool there_is_a_winner = false;

            //yatay
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                there_is_a_winner = true;
            }

            //dikey
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                there_is_a_winner = true;
            }

            //çapraz
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                there_is_a_winner = true;
            }

            if (there_is_a_winner)
            {
                DisableButtons();

                String winner = "";
                if (turn)
                {
                    winner = "O";
                    o_winCount.Text = (Int32.Parse(o_winCount.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_winCount.Text = (Int32.Parse(x_winCount.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " Kazandı!", "Tebrikler!");
                newGameToolStripMenuItem.PerformClick();
            }//end if
            else
            {
                if (turn_count == 9)
                {
                    draw_Count.Text = (Int32.Parse(draw_Count.Text) + 1).ToString();
                    MessageBox.Show("Berabere!", "Tekrar Oyna!");
                }
            }

        }//end CheckForWinner

        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }//end try
            catch { }
        }
    }
}
