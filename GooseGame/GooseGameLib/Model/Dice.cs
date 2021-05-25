using System;
namespace GooseGame.Model
{
    public class Dice
    {
        private Random _rnd;

        public Dice(int seed)
        {
            _rnd = new Random(DateTime.Now.Millisecond + seed);
        }//end 

        //method that simulates the rolling of a dice randomly 
        //extracting a number
        public int rollingDice()
        {
            return _rnd.Next(1, 7);
        }
    }
}