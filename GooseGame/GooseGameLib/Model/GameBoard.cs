using System;
using System.Collections.Generic;

namespace GooseGame.Model
{
    public class GameBoard
    {
        // symbolic constants to identify the type of pawn
        private const string PLAYER = "PLAYER";
        private const string BOT = "BOT";
        //attributes of the class
        private int _NumofSquares;        //number of squares
        private int _NumofPlayers;       //number of players
        //main objects 
        private List<Square> _squares;  //list of the squares
        private List<Pawn> _pawn;       //list of the pawn
        private Dice _dice1;            //dice number 1
        private Dice _dice2;            //dice number 2

        private bool _winner;      //pawn that has won the game
        private Pawn _inPrison;    //pawn inside the prison
        private Pawn _inWaterWell; //pawn inside the water well
        private bool _replay;      //indicates if the player wants to replay the game

        //eventi 
        public EventHandler<ArgEvent<Pawn>> OnEffect_Applied;       //invoked when the effect is applied
        public EventHandler<ArgEvent<int>> OnValueDice_Updated;     //invoked each time the dice is rolled
        public EventHandler<ArgEvent<Pawn>> OnPosition_Updated;     //invoked when a pawn's position changes 
        public EventHandler<ArgEvent<Pawn>> OnVictory;              //invoked when a pawn comes to an end

        /*
         * the number of boxes [63-90]and the number of players [2-6]
         * are passed to the constructor of the class in order to create
         * lists containing the right number of elements
         */
        public GameBoard(int NumofSquares, int NumofPlayers)
        {
            _NumofSquares = NumofSquares;
            _NumofPlayers = NumofPlayers;
            _dice1 = new Dice(7);
            _dice2 = new Dice(25);
            _replay = false;
            _winner = false;
            inizialize();
        }//end 

        //Property 
        //return and set the replay value
        public bool replay
        {
            get { return _replay; }
            set { _replay = value; }
        }
        //return and set the pawn currently in prison
        public Pawn inPrison
        {
            get { return _inPrison; }
            set { _inPrison = value; }
        }
        //return and set the piece currently in the water well
        public Pawn inWaterWell
        {
            get { return _inWaterWell; }
            set { _inWaterWell = value; }
        }

        /*
* The method play is the main one and manages everyone's turn
* the players, both the user and the bots. * If there is no winner, for each pawn I execute
* the turn of the player or the bot depending on the type,
* then I check if he has won and, if so, I decide the winner.
* I then check that the game is not stalled (two players
* both stopped in a square StayStill), in this case I finish
* the game in parity.
*/
        public void play()
        {
            if (_winner == false)
            {
                foreach (Pawn p in _pawn)
                {
                    if (_replay == false)
                    {
                        if (p.typePawn == PLAYER)
                            turnPlayer(p);
                        else if (p.typePawn == BOT)
                            turnBot(p);
                        if (p.winner)
                        {
                            _winner = true;
                            OnVictory.Invoke(this, new ArgEvent<Pawn>(p));
                        }
                    }
                }
                if (_NumofPlayers == 2 && _inWaterWell != null && _inPrison != null)
                    OnVictory.Invoke(this, new ArgEvent<Pawn>(null));
                _replay = false;
            }
        }
        //method to manage the user's turn
        private void turnPlayer(Pawn p)
        {
            int shot = 0;
            // if the token is not on hold or in prison
            // I roll the dice, otherwise I pass 0 as a roll
            if (!p.onHold && _inPrison != p && _inWaterWell != p)
                shot = rollingDice();
            OnValueDice_Updated.Invoke(this, new ArgEvent<int>(shot));
            move(p, p.move(shot));
            OnPosition_Updated.Invoke(this, new ArgEvent<Pawn>(p));
        }//end turnPlayer

        //method to manage the turn of the bots
        private void turnBot(Pawn p)
        {
            int shot = rollingDice();
            move(p, p.move(shot));
            OnPosition_Updated.Invoke(this, new ArgEvent<Pawn>(p));
        }//end turnBot

        //metod to move the pawn
        public void move(Pawn p, int position)
        {
            _squares[position].effect(this, p, OnEffect_Applied);
        }

        //method that simulates the rolling of the dice
        private int rollingDice()
        {
            return (_dice1.rollingDice() + _dice2.rollingDice());
        }//end rollingDice

        //methods to instantiate lists of boxes and pawns
        private void popPawn()
        {
            for (int i = 0; i < _NumofPlayers; i++)
            {
                if (i == 0)
                    _pawn.Add(new Pawn(i, _NumofSquares, PLAYER));
                else
                    _pawn.Add(new Pawn(i, _NumofSquares, BOT));
            }
        }

        private void popSquares()
        {
            for (int i = 0; i <= _NumofSquares; i++)
            {
                //instantiate the Goose boxes and the Bridge box
                if ((i == 6 || i % 9 == 0 || i % 9 == 5) && i != _NumofSquares && i != 0)
                    _squares.Add(new MoveForward(i));
                //instantiate the Inn box
                else if (i == 19)
                    _squares.Add(new Inn());
                //instantiate the Water Well box
                else if (i == 31 || i == 52)
                    _squares.Add(new StayStill(i));
                //instantiate the Labyrith and Skeleton boxes
                else if (i == 42 || i == 58)
                    _squares.Add(new MoveBack(i, (i == 42) ? 39 : 1));
                //istanzio le caselle Normali
                else
                    _squares.Add(new Normal(i));
            }

        }

        //method that initializes the main variables
        public void inizialize()
        {
            _squares = new List<Square>();
            _pawn = new List<Pawn>();
            _winner = false;
            _inPrison = null;
            _inWaterWell = null;

            popSquares();
            popPawn();
        }//end load
    }
}//end class


