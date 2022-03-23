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
        public String English { get; private set; }
        public char[] LastRow
        {
            get
            {
                return GameBoard[LastIndex / 5];
            }
        }

        public static int BOARD_SIZE = 25;

        public int LastIndex { get; private set; } = 0;

        public WinTypes WinStatus { get; private set; } = WinTypes.PLAYING;

        private int boardIndex;
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
            var russianWords = ReadWords.ReadRussian();
            var englishWords = ReadWords.ReadEnglish();

            var random = new Random();
            var randomNum = random.Next(0, russianWords.Length);

            Answer = russianWords[randomNum];
            English = englishWords[randomNum]; 


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
            if (boardIndex == 1 || boardIndex > LastIndex + 1)
            {
                boardIndex--;
                GameBoard[boardIndex / 5][boardIndex % 5] = ' ';
                permissionToMoveNextRow = true;
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
    }
}
