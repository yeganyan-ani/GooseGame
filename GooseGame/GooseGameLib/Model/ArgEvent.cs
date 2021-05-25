using System;

namespace GooseGame.Model
{
    public class ArgEvent<T> : EventArgs
    {
        private T _value;

        public ArgEvent(T value)
        {
            _value = value;
        }//end 

        //property to get the pawn
        public T getValue
        {
            get { return _value; }
        }
    }
}



