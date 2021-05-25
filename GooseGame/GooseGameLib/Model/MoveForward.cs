using System;

namespace GooseGame.Model
{
    public class MoveForward : Square
    {

        public MoveForward(int idSquares) : base(idSquares)
        {
        }

        /* Override the effect method.
         * The method moves the pawn by n positions equal to the shot
         * carried out previously.
        */
        public override void effect(GameBoard t, Pawn p, EventHandler<ArgEvent<Pawn>> _event)
        {
            if (!p.winner)
            {
                int shot = p.move(p.shotPreviously);
                t.move(p, shot);
            }
            _event.Invoke(this, new ArgEvent<Pawn>(p));
        }
    }
}
