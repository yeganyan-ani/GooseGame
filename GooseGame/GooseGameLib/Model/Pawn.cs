using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Model
{
    public class Pawn
    {
        //identifying attributes
        private int _idPlayers;     //number of players [1-6]
        private int _NumofSquares;  //number ofsquares
        private string _typePawn;   //is a player or a bot

        // state attributes
        private int _actualPosition;        //position of the pawn
        private int _shotPreviously;        //shot previously
        private int _numTurnHold;           //number of turns to wait
        private bool _onHold;               //is in the Inn?
        private bool _inPrison;             //is in prison?
        private bool _inWaterWell;          //is in water well?
        private bool _winner;               //is in the last square?

        public Pawn(int id, int numSq, string typePawn)
        {
            _idPlayers = id;
            _NumofSquares = numSq;
            _typePawn = typePawn;

            _actualPosition = 0; //the squares start from the box number 0
            _shotPreviously = 0;
            _numTurnHold = 0;
            _winner = false;
            _onHold = false;
            _inPrison = false;
            _inWaterWell = false;
        }//end 

        //Property
        //returns the player's id
        public int idPlayers
        {
            get { return _idPlayers; }
        }
        //returns a string indicating whether the pawn
        // is PLAYER or BOT
        public string typePawn
        {
            get { return _typePawn; }
        }

        //return the previously rolled shot
        public int shotPreviously
        {
            get { return _shotPreviously; }
        }

        // returns the current position of the piece
        public int position
        {
            get { return _actualPosition; }
        }
        //returns a Boolean value indicating whether the
        // The pawn is waiting
        public bool onHold
        {
            get { return _onHold; }
        }
        //returns a Boolean value indicating whether the
        // The pawn is in prison
        public bool inPrison
        {
            get { return _inPrison; }
            set { _inPrison = value; }
        }
        // returns a Boolean value indicating whether the
        // The pawn is in the water well
        public bool inWaterWell
        {
            get { return _inWaterWell; }
            set { _inWaterWell = value; }
        }
        // returns a Boolean value indicating whether the
        // The pawn is the winner
        public bool winner
        {
            get { return _winner; }
            set { _winner = value; }
        }
        /*
		*the method takes an integer as input (outcome of the roll of the dice)
        * and returns an integer (box to move to)
        * be careful because the returned position ranges from 1 to number of boxes
        */
        public int move(int shot)
        {
            _shotPreviously = shot;
            //if in the Inn
            if (_numTurnHold != 0)
                //decrease the waiting shifts by one
                _numTurnHold--;
            // otherwise if is not in the inn and is not in the water well or the prison
            else if (_inWaterWell == false && _inPrison == false)
            {
                //update the position
                _actualPosition += shot;

                // If passed the end with the shot,  have to go back
                if (_actualPosition > _NumofSquares)
                    _actualPosition = _NumofSquares - (_actualPosition - _NumofSquares);

                // check if the pawn has arrived in the last square
                if (_actualPosition == _NumofSquares)
                    _winner = true;
            }
            return _actualPosition;
        }//end move

        /*
         * Method of putting the pawn on hold when it ends up in the inn.
         * I check if the pawn is on hold and in case I put it on hold e
         * I set the waiting shifts otherwise if the number of waiting shifts is
         * 0 I must not be on hold.
         */
        public void await(int numTurnHold)
        {
            if (!_onHold)
            {
                _onHold = true;
                _numTurnHold = numTurnHold;
            }
            else if (_numTurnHold == 0)
                _onHold = false;
        }//end wait
    }
}



