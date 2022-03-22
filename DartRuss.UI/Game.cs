using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartRuss.UI
{
    public class Game
    {
        public String Answer { get; private set; }

        public static int BOARD_SIZE = 25;

        public int LastIndex { get; private set; } = 0;

        public WinTypes WinStatus { get; private set; } = WinTypes.PLAYING;

        private int boardIndex;
        //private int row;
        //private int column;
        public char[][] GameBoard { get; private set; } =
        {
            new char[] {' ', ' ', ' ', ' ', ' ' },
            new char[] {' ', ' ', ' ', ' ', ' ' },
            new char[] {' ', ' ', ' ', ' ', ' ' },
            new char[] {' ', ' ', ' ', ' ', ' ' },
            new char[] {' ', ' ', ' ', ' ', ' ' }
        };
        private bool permissionToMoveNextRow;

        public Game()
        {
            var words = ReadWords.ReadXML();
            var random = new Random();
            Answer = words[random.Next(0, words.Length)];

            boardIndex = 0;
            permissionToMoveNextRow = false;
        }
        private bool SquareAvailable() => boardIndex == 0 || ((boardIndex / 5) < 5 && (boardIndex % 5) != 0);

        public void FillSquare(char guess)
        {
            if (SquareAvailable() || permissionToMoveNextRow)
            {
                GameBoard[boardIndex / 5][boardIndex % 5] = guess;
                permissionToMoveNextRow = false;
                boardIndex++;
            }
        }

        public void RemoveSquare()
        {
            if (boardIndex >= 0)
            {
                boardIndex--;
                GameBoard[boardIndex / 5][boardIndex % 5] = ' ';
                
            }
        }
        public GuessEnum[] Check()
        {
            var toReturn = new GuessEnum[]
                {
                    GuessEnum.INCORRECT,
                    GuessEnum.INCORRECT,
                    GuessEnum.INCORRECT,
                    GuessEnum.INCORRECT,
                    GuessEnum.INCORRECT
                };

            if (!SquareAvailable())
            {
                var row = (boardIndex / 5) - 1;

                var correctCount = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (GameBoard[row][i] == Answer[i])
                    {
                        toReturn[i] = GuessEnum.CORRECTSPOT;
                        correctCount++;
                    }
                    else if (Answer.Contains(GameBoard[row][i]))
                    {
                        toReturn[i] = GuessEnum.WRONGSPOT;
                    }
                }

                LastIndex = boardIndex - 1;
                permissionToMoveNextRow = true;

                if (correctCount == 5) WinStatus = WinTypes.WON;
                if (row == 4) WinStatus = WinTypes.LOST;
            }
            

            return toReturn;
        }

        public bool CheckAvaliable() => !SquareAvailable();

        /**
         * returns: int of the current square being modified
         */
        /* public int Guess(char guess)
         {

             if (SquareIndex < 25)
             {
                 gameBoard[SquareIndex / 5][SquareIndex % 5] = guess;
                 SquareIndex++;
             }

             /*if (SquareIndex >= 24)
             {
                 gameBoard[4][4] = guess;
             } 
             else
             {
                 gameBoard[SquareIndex / 5][SquareIndex % 5] = guess;
                 SquareIndex++;
             } */

        // return SquareIndex;
        //}
        /*
        public void RemoveGuess()
        {
            if (SquareIndex == 0) return;

            if (SquareIndex < 25) 
            { 
                gameBoard[SquareIndex / 5][SquareIndex % 5] = '\0';
                SquareIndex--;
            }

            /*if (SquareIndex == 24)
            {
                gameBoard[4][4] = '\0';
            }
            else
            {
                gameBoard[SquareIndex / 5][SquareIndex % 5] = '\0';
            }*/


        //} */

        /*public GuessEnum[] CheckRow()
        {
            // if ()



            //var column = SquareIndex / 5 == 5 ? true : SquareIndex % 5;
            //var row = SquareIndex / 5 == 5 ? 4 : SquareIndex / 5;
            /*if (column == 0 && SquareIndex != 0) // If at end of row and not at the start...
            {
                var toReturn = new GuessEnum[] { GuessEnum.INCORRECT, GuessEnum.INCORRECT, GuessEnum.INCORRECT, GuessEnum.INCORRECT, GuessEnum.INCORRECT };

                for (int i = 0; i < 5; i++)
                {
                    
                }
            } 
            
            return null; */
        // return null;
        // }

    }
}
