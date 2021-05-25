using System;
using GooseGame.Model;
using GooseGame.View;

namespace GooseGame.Controller
{
    public class Controller
    {
        private GameBoard _board;
        private GameView _view;

        public Controller(GameView view, GameBoard board)
        {
            _view = view;
            _board = board;

            //events
            _board.OnEffect_Applied += UpdatePosition;
            _board.OnValueDice_Updated += PrintDice;
            _board.OnPosition_Updated += UpdatePosition;
            _board.OnVictory += VictoryofOnePlayer;
            _view.getButtonRollDice.Click += View_Click_RollDice;
            _view.OnReplay_Clicked += View_Click_Replay;
            _view.getButtonReset.Click += View_Click_Replay;
        }//end 

        //method used to replay the game
        private void View_Click_Replay(object sender, EventArgs e)
        {
            //set to true the replay field of the board so  
            //to block the players who have not won 
            _board.replay = true;
            //riinizializzo tutti gli elementi del tavolo e della vista
            _board.inizialize();
            _view.inizialize();
        }
        //method executed when a player wins
        private void VictoryofOnePlayer(object sender, ArgEvent<Pawn> e)
        {
            if (e.getValue != null)
                _view.announceWinner(e.getValue.idPlayers.ToString());
            else
                _view.announceWinner();
        }
        //method executed each time the pawn updates its position or a square effect is applied
        private void UpdatePosition(object sender, ArgEvent<Pawn> e)
        {
            _view.movePawn(e.getValue.position, e.getValue.idPlayers);
        }
        //method executed at the click of the Roll Dice button
        private void View_Click_RollDice(object sender, EventArgs e)
        {
            _board.play();
        }

        //method executed every time the dice are rolled; print their value
        private void PrintDice(object sender, ArgEvent<int> e)
        {
            _view.setLabelRollingDice = e.getValue.ToString();
        }
    }
}
