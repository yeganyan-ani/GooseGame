using System;
namespace GooseGame.Model
{
    public abstract class Square
    {
        private int _NumofSquares; //number of squares

        public Square(int id)
        {
            _NumofSquares = id;
        }//end 

        //method that returns the square number
        public int idSquares
        {
            get { return _NumofSquares; }
        }

        /*
         *Method extracted effect of the checker.
         * The table instance, the pawn that invokes the effect, is passed to the method
         * and the applied effect event that informs the controller that the effect is applied
         */
        public abstract void effect(GameBoard t, Pawn p, EventHandler<ArgEvent<Pawn>> _event);
    }
}
