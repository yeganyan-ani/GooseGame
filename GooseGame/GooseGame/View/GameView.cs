using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GooseGame.View
{
    /*
     * The GameView class contains everything to make work 
     * the graphical aspect of the program...
     */
    public partial class GameView : Form
    {
        //main attributes of the class
        private int NumofSquares;     //number of squares
        private int NumofPlayers;     //number of players
        //lists
        private List<Button> squares;           //the boxes rapresenting the squares
        private List<Button> pawn;              //the boxes rappresenting the pawns
        private GroupBox GroupPlayers;          //box list of the players
        private List<Label> LabelPlayers;       //names of players in the box
        private List<Button> ButtonPlayers;     //colored squares in the box
        //array contains all the colours of the pawn
        //the colours are assegned to each player
        //based on its id
        private Color[] colors = {
                   Color.FromArgb(255, 255, 0, 0),     //red
                   Color.FromArgb(255, 143, 0, 255),   //violet
                   Color.FromArgb(255, 0, 255, 0),     //green
                   Color.FromArgb(255, 0, 0, 255),     //blu   
                   Color.FromArgb(255, 255, 20, 147),  //orange
                   Color.FromArgb(255, 0, 0, 0)        //black
                   };
        //event that allows to replay the game
        public EventHandler OnReplay_Clicked;

        public GameView(int NumofSquares, int NumofPlayers)
        {
            this.NumofSquares = NumofSquares;
            this.NumofPlayers = NumofPlayers;
            this.squares = new List<Button>();
            this.pawn = new List<Button>();
            this.LabelPlayers = new List<Label>();
            this.ButtonPlayers = new List<Button>();
            this.GroupPlayers = new GroupBox();

            InitializeList();
            InitializeComponent();

            panelBoard.BackgroundImage = Properties.Resources.Background;
            panelBoard.BorderStyle = BorderStyle.FixedSingle;

            loadSquares();  //draw the squares
            inizialize();   //draw pawns
            loadIndex();    //draw the index of the players
        }//end 

        //property
        //pass the button roll dice to the controller
        public Button getButtonRollDice
        {
            get { return buttonRollDice; }
        }
        //pass the button reset to the controller
        public Button getButtonReset
        {
            get { return buttonReset; }
        }
        //set the labelRollingDice with the value of the roll of the dice
        public string setLabelRollingDice
        {
            set { labelRollingDice.Text = value; }
        }

        //public method that invokes the loading of the pawn
        public void inizialize()
        {
            loadPawn();
        }

        //method for initialising the lists
        private void InitializeList()
        {
            for (int i = 0; i <= NumofSquares; i++)
                squares.Add(new Button());
            for (int i = 0; i < NumofPlayers; i++)
            {
                pawn.Add(new Button());
                LabelPlayers.Add(new Label());
                ButtonPlayers.Add(new Button());
            }
        }//end Initializelist

        //method for drawing all the squares
        private void loadSquares()
        {
            int h = 0, w = 0;   //position of the first square

            if (NumofSquares == 63)
                w = 100;
            else
                w = 80;

            for (int i = 0; i < squares.Count; i++)
            {
                if (NumofSquares == 63)
                    squares[i].Size = new Size(50, 50);
                else
                    squares[i].Size = new Size(40, 40);

                squares[i].Enabled = true;
                squares[i].Text = i.ToString();
                squares[i].TabStop = false;
                squares[i].FlatStyle = FlatStyle.Flat;
                squares[i].FlatAppearance.BorderSize = 0;
                squares[i].Font = new Font(squares[i].Font, FontStyle.Bold);
                squares[i].Margin = new Padding(0);
                squares[i].ForeColor = Color.FromArgb(255, 32, 32, 32);

                if (NumofSquares == 63)
                {
                    squares[i].Location = new Point(w, h);
                    if (i < 12)
                        w += squares[i].Width;
                    else if (i < 19)
                        h += squares[i].Height;
                    else if (i < 33)
                        w -= squares[i].Width;
                    else if (i < 38)
                        h -= squares[i].Height;
                    else if (i < 50)
                        w += squares[i].Width;
                    else if (i < 53)
                        h += squares[i].Height;
                    else if (i <= 63)
                        w -= squares[i].Width;
                }
                else
                {
                    squares[i].Location = new Point(w, h);
                    if (i < 16)
                        w += squares[i].Width;
                    else if (i < 25)
                        h += squares[i].Height;
                    else if (i < 43)
                        w -= squares[i].Width;
                    else if (i < 50)
                        h -= squares[i].Height;
                    else if (i < 66)
                        w += squares[i].Width;
                    else if (i < 71)
                        h += squares[i].Height;
                    else if (i < 85)
                        w -= squares[i].Width;
                    else if (i < 88)
                        h -= squares[i].Width;
                    else if (i <= 90)
                        w += squares[i].Width;
                }

                panelBoard.Controls.Add(squares[i]);
                drawSquares();
                squares[i].Update();
            }
        }//end loadSquares

        //method for showing the pawn in the square number 0
        private void loadPawn()
        {
            for (int i = 0; i < NumofPlayers; i++)
            {
                pawn[i].BackColor = colors[i];        //set the color
                pawn[i].Location = positionPawn(i);   //set the position
                //set the size of the box
                if (NumofSquares == 63)
                    pawn[i].Size = new Size(14, 14);
                else
                    pawn[i].Size = new Size(12, 12);
                pawn[i].Text = "";
                pawn[i].Name = "Player" + i;  //name of the pawn
                pawn[i].TabStop = false;
                pawn[i].Enabled = false;
                //set the borders
                pawn[i].FlatStyle = FlatStyle.Flat;
                pawn[i].FlatAppearance.BorderSize = 2;
                pawn[i].FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255, 255);
                squares[i].Invalidate();
                //add all the pawn in the 0 square
                squares[0].Controls.Add(pawn[i]);
            }
        }//end loadPawn

        //method that loaded the index of the players
        private void loadIndex()
        {
            GroupPlayers.Location = new Point(12, 418);  //position
            GroupPlayers.Size = new Size(200, 91);       //dimention
            GroupPlayers.Text = "Players";
            GroupPlayers.TabStop = false;
            GroupPlayers.TabIndex = 7;

            panel1.Controls.Add(GroupPlayers);

            for (int i = 0; i < NumofPlayers; i++)
            {
                switch (i)
                {
                    case 0:
                        LabelPlayers[i].Location = new Point(28, 21);
                        ButtonPlayers[i].Location = new Point(6, 21);
                        break;
                    case 1:
                        LabelPlayers[i].Location = new Point(28, 44);
                        ButtonPlayers[i].Location = new Point(6, 44);
                        break;
                    case 2:
                        LabelPlayers[i].Location = new Point(28, 65);
                        ButtonPlayers[i].Location = new Point(6, 65);
                        break;
                    case 3:
                        LabelPlayers[i].Location = new Point(122, 21);
                        ButtonPlayers[i].Location = new Point(100, 21);
                        break;
                    case 4:
                        LabelPlayers[i].Location = new Point(122, 44);
                        ButtonPlayers[i].Location = new Point(100, 44);
                        break;
                    case 5:
                        LabelPlayers[i].Location = new Point(122, 65);
                        ButtonPlayers[i].Location = new Point(100, 65);
                        break;
                }
                //set the style of the label and the boxes
                LabelPlayers[i].AutoSize = true;
                LabelPlayers[i].Size = new Size(62, 13);
                LabelPlayers[i].Text = "Player" + i;
                ButtonPlayers[i].BackColor = colors[i];
                ButtonPlayers[i].Enabled = false;
                ButtonPlayers[i].Size = new Size(16, 16);
                ButtonPlayers[i].TabIndex = i;
                ButtonPlayers[i].FlatStyle = FlatStyle.Flat;
                ButtonPlayers[i].FlatAppearance.BorderSize = 0;
                ButtonPlayers[i].UseVisualStyleBackColor = false;
                //add a label e a box to the index
                GroupPlayers.Controls.Add(LabelPlayers[i]);
                GroupPlayers.Controls.Add(ButtonPlayers[i]);
            }
        }//end loadIndex

        //method to insert the images into the squares
        private void drawSquares()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                if ((i != 0 && i % 9 == 0 || i % 9 == 5) && i != NumofSquares) //goose squares
                    squares[i].BackgroundImage = Properties.Resources.Goose2;
                else if (i % 2 == 0) //all the even squares
                    squares[i].BackgroundImage = Properties.Resources.EvenBackground;
                else //all the odd squares
                    squares[i].BackgroundImage = Properties.Resources.OddBackground;

                squares[i].BackgroundImageLayout = ImageLayout.Stretch;
            }

            squares[6].BackgroundImage = Properties.Resources.Bridge;
            squares[19].BackgroundImage = Properties.Resources.Inn;
            squares[31].BackgroundImage = Properties.Resources.WaterWell;
            squares[52].BackgroundImage = Properties.Resources.Prison;
            squares[42].BackgroundImage = Properties.Resources.Labyrinth;
            squares[58].BackgroundImage = Properties.Resources.Skeleton;
            squares[NumofSquares].BackgroundImage = Properties.Resources.Goose3;
        }//end drawSquares


        //method to move a pawn to a new position 
        public void movePawn(int position, int NumofPawn)
        {
            squares[position].Controls.Add(pawn[NumofPawn]);
        }

        //method to calculate the position of the pawn inside the square
        private Point positionPawn(int NumofPawn)
        {
            Point position = new Point(0, 0);
            if (NumofSquares == 63)

                switch (NumofPawn)
                {
                    case 0:
                        position = new Point(6, 0);
                        break;
                    case 1:
                        position = new Point(6, 16);
                        break;
                    case 2:
                        position = new Point(6, 32);
                        break;
                    case 3:
                        position = new Point(28, 0);
                        break;
                    case 4:
                        position = new Point(28, 16);
                        break;
                    case 5:
                        position = new Point(28, 32);
                        break;
                }

            else if (NumofSquares == 90)

                switch (NumofPawn)
                {
                    case 0:
                        position = new Point(4, 0);
                        break;
                    case 1:
                        position = new Point(4, 13);
                        break;
                    case 2:
                        position = new Point(4, 26);
                        break;
                    case 3:
                        position = new Point(23, 0);
                        break;
                    case 4:
                        position = new Point(23, 13);
                        break;
                    case 5:
                        position = new Point(23, 26);
                        break;
                }

            return position;
        }//end positionPawn

        //method to print a un message that contains the winner of the game
        public void announceWinner(string s)
        {
            string text = "The Player " + s + " has won the game...";
            string title = "Victory!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Asterisk;
            MessageBox.Show(text, title, buttons, icon);
            replay();
        }
        //overload the method announceWinner to stop the game in the case of the parity
        public void announceWinner()
        {
            string text = "No player has won the game...";
            string title = "Parity";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Asterisk;
            MessageBox.Show(text, title, buttons, icon);
            replay();
        }
        /*
         * The method is called after a player's victory or in the case of the 
         * parity ask the user if he wants repeat the game keeping the same 
         * settings in the case of agreement, invoke the method OnReplay_Clicked   
         * which annonce a controller to reload the game, otherwise
         * the application ends 
         */
        private void replay()
        {
            string text = "Repeat the game?";
            string title = "Replay";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult replay = DialogResult.Yes;
            if (MessageBox.Show(text, title, buttons, icon) == replay)
            {
                OnReplay_Clicked.Invoke(this, new EventArgs());
            }
            else
                Application.Exit();
        }
        //show the rueles of the game
        private void buttonRules_Click(object sender, EventArgs e)
        {
            string rules = Properties.Resources.Rules_goose_game;
            string title = "Rules of the game";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(rules, title, buttons);
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GameView_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

        }

        private void buttonRollDice_Click(object sender, EventArgs e)
        {

        }
    }
}
