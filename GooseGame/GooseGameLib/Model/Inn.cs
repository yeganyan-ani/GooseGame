using System;
namespace GooseGame.Model
{
    public class Inn : Square
    {
        private const int NUM_SQUARE = 19;
        private const int NUM_TURN_HOLD = 3;

        public Inn() : base(NUM_SQUARE)
        {
        }

        public override void effect(GameBoard t, Pawn p, EventHandler<ArgEvent<Pawn>> _event)
        {
            // put the pawn on hold for three turns
            p.await(NUM_TURN_HOLD);
            _event.Invoke(this, new ArgEvent<Pawn>(p));
        }
    }
}

