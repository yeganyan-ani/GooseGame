using System;
using System.Windows.Forms;
using GooseGame.Model;
using GooseGame.View;
using GooseGame.Controller;

namespace GooseGame
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int NumofSquares;
            int NumofPlayers;

            Menu menu;                           //the start menu
            GameView view;                       //the view of the game
            GameBoard board;                     //the board of the game
            Controller.Controller controller;               //the controller

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            menu = new Menu();
            Application.Run(menu);

            NumofPlayers = menu.getPlayers;
            NumofSquares = menu.getSquares;

            //if the number of squares and pawns has been set
            //start the main view
            if (NumofSquares != 0 && NumofPlayers != 0)
            {
                view = new GameView(NumofSquares, NumofPlayers);
                board = new GameBoard(NumofSquares, NumofPlayers);
                controller = new Controller.Controller(view, board);               //il controller
                Application.Run(view);
            }
        }
    }
}
