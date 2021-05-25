using System;
using System.Windows.Forms;

namespace GooseGame
{
    public partial class Menu : Form
    {

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private RadioButton selectedrb;
        private RadioButton selectedrb2;
        private int NumofPlayers;
        private int NumofSquares;

        public Menu()
        {
            InitializeComponent();
            InizializzaRadioButton();
            selectedrb = radioButton1;
            selectedrb2 = radioButton6;
        }

        public int getSquares
        {
            get { return NumofSquares; }
        }

        public int getPlayers
        {
            get { return NumofPlayers; }
        }

        private void InizializzaRadioButton()
        {
            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton4.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton5.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton6.CheckedChanged += new EventHandler(radioButton_CheckedChanged2);
            radioButton7.CheckedChanged += new EventHandler(radioButton_CheckedChanged2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedrb.Text.Contains("2"))
                NumofPlayers = 2;
            else if (selectedrb.Text.Contains("3"))
                NumofPlayers = 3;
            else if (selectedrb.Text.Contains("4"))
                NumofPlayers = 4;
            else if (selectedrb.Text.Contains("5"))
                NumofPlayers = 5;
            else if (selectedrb.Text.Contains("6"))
                NumofPlayers = 6;

            if (selectedrb2.Text.Contains("63"))
                NumofSquares = 63;
            else if (selectedrb2.Text.Contains("90"))
                NumofSquares = 90;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedrb = rb;
            }
        }

        private void radioButton_CheckedChanged2(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                selectedrb2 = rb;
            }
        }
    }
}
