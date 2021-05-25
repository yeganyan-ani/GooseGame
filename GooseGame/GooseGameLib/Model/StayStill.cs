using System;

namespace GooseGame.Model
{
    public class StayStill : Square
    {
        private const int WATERWELL = 31;
        private const int PRISON = 52;
        private int _idSquares;

        public StayStill(int idSquares) : base(idSquares)
        {
            _idSquares = idSquares;
        }

        public override void effect(GameBoard t, Pawn p, EventHandler<ArgEvent<Pawn>> _event)
        {
            //if the box is the water well
            if (_idSquares == WATERWELL)
            {
                //check if there is noone in the water well
                if (t.inWaterWell != null && t.inWaterWell != p)
                    //if there is another pawn I free it
                    t.inWaterWell.inWaterWell = false;
                //then I take the seat in the water well
                p.inWaterWell = true;
                t.inWaterWell = p;
            }
            // otherwise if the box is the prison
            else if (_idSquares == PRISON)
            {
                //check if there is noone in the prison
                if (t.inPrison != null && t.inPrison != p)
                    //if there is another pawn I free it
                    t.inPrison.inPrison = false;

                //then I take the seat in the prison 
                p.inPrison = true;
                t.inPrison = p;
            }
            _event.Invoke(this, new ArgEvent<Pawn>(p));
        }
    }
}
