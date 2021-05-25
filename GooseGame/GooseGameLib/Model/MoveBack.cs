using System;

namespace GooseGame.Model
{
    public class MoveBack : Square
    {
        private int _destination;

        public MoveBack(int idSquares, int destination) : base(idSquares)
        {
            _destination = destination;
        }//end 

        /*
         * Overriding the effect method.
         * The method moves the pawn to a given position (destination) passed
         * at the time of creation 
         */
        public override void effect(GameBoard t, Pawn p, EventHandler<ArgEvent<Pawn>> _event)
        {
            int shot = p.move(_destination - p.position);
            t.move(p, shot);
            _event.Invoke(this, new ArgEvent<Pawn>(p));
        }
    }
}
