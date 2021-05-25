using System;

namespace GooseGame.Model
{
    public class Normal : Square
    {
        public Normal(int NumofSquares) : base(NumofSquares)
        {
        }

        public override void effect(GameBoard t, Pawn p, EventHandler<ArgEvent<Pawn>> _event)
        {
            //the normal box does nothing in particular
            _event.Invoke(this, new ArgEvent<Pawn>(p));
        }
    }
}
