Author:
Ani Yeganyan [280570]

Project title: "Goose Game"

Specification:
Creating a desktop application that simulates the classic game of the goose using
the C# OOP language and Windows Forms; in particular the program is based on the
following rules:
It is played on a board on which a spiral path made up of 63 squares is drawn
(sometimes this number goes up to 90), marked with numbers or other symbols. The
players start with a marker in the starting square and, in turn, proceed along the path
of a number of squares obtained by rolling a pair of dice. The aim of the game is
reach the central square of the spiral.
Some arrival boxes have a special effect; in the traditional version, the boxes that
represent geese (hence the name of the game) allow you to immediately move forward
one number of squares equal of those covered by the movement just made. These
boxes are placed every nine starting from boxes 5 and 9 (a consequence of this
arrangement is that a initial roll of 9 immediately brings the player to the final square
and therefore to victory).
 The other special boxes are the followings:
• square 6 "the bridge" the movement is repeated as in the boxes with geese;
• square 19 "house" or "inn" remaining stationary for three turns;
• squares 31 "water well" and 52 "prison" remaining stationary until another pawn
reach the same square, which is ‘’imprisoned’’;
• square 42 "labyrinth" returns to number 39;
• square 58 "skeleton" returns to number 1.
The finish square (63 or 90) must be reached with an exact roll of the dice
otherwise, when you reach the bottom, you move back some points in excess.
