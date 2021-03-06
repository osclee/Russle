namespace DartRuss.UI
{
    public partial class Russle : Form
    {

        private Game game;
        public Russle()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Keyboard_Press(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var guess = label.Text[0];

            game.FillSquare(guess);
            UpdateBoard();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (game.CheckAvaliable())
            {

                UpdateResults();

                if(game.WinStatus != WinTypes.PLAYING)
                {
                    if (game.WinStatus == WinTypes.WON)
                    {
                        Result.Text = $"Winner! {game.Answer} - {game.English}";
                        Result.ForeColor = Color.Green;
                    } else
                    {
                        Result.Text = $"Loser! {game.Answer} - {game.English}";
                        Result.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            game.RemoveSquare();
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            var grid = game.GameBoard;
            for (int i = 0; i < Game.BOARD_SIZE; i++)
            {
                CurrentSquareLabel(i).Text = grid[i / 5][i % 5].ToString();
            }
        }

        private void UpdateResults()
        {
            var results = game.Check();
            var startIndex = game.LastIndex - 4;
            for (int i = 0; i < 5; i++)
            {
                switch (results[i])
                {
                    case GuessEnum.INCORRECT:
                        CurrentSquareLabel(startIndex + i).BackColor = Color.DarkGray;
                        CurrentKeyboardLabel(game.LastRow[i]).BackColor = Color.DarkGray;
                        break;
                    case GuessEnum.WRONGSPOT:
                        CurrentSquareLabel(startIndex + i).BackColor = Color.Yellow;
                        CurrentKeyboardLabel(game.LastRow[i]).BackColor = Color.Yellow;
                        break;
                    case GuessEnum.CORRECTSPOT:
                        CurrentSquareLabel(startIndex + i).BackColor = Color.Green;
                        CurrentKeyboardLabel(game.LastRow[i]).BackColor = Color.Green;
                        break;
                }
            }
 
        }

        private Label CurrentKeyboardLabel(char currentKeyboard)
        {
            switch (currentKeyboard)
            {
                case 'й':
                    return l0;
                case 'ц':
                    return l1;
                case 'у':
                    return l2;
                case 'к':
                    return l3;
                case 'е':
                    return l4;
                case 'н':
                    return l5;
                case 'г':
                    return l6;
                case 'ш':
                    return l7;
                case 'щ':
                    return l8;
                case 'з':
                    return l9;
                case 'х':
                    return l10;
                case 'ъ':
                    return l11;
                case 'ф':
                    return l12;
                case 'ы':
                    return l13;
                case 'в':
                    return l14;
                case 'а':
                    return l15;
                case 'п':
                    return l16;
                case 'р':
                    return l17;
                case 'о':
                    return l18;
                case 'л':
                    return l19;
                case 'д':
                    return l20;
                case 'ж':
                    return l21;
                case 'э':
                    return l22;
                case 'я':
                    return l23;
                case 'ч':
                    return l24;
                case 'с':
                    return l25;
                case 'м':
                    return l26;
                case 'и':
                    return l27;
                case 'т':
                    return l28;
                case 'ь':
                    return l29;
                case 'б':
                    return l30;
                case 'ю':
                    return l31;
                default:
                    return l0;
            }
        }

        private Label CurrentSquareLabel(int currentSquare)
        {
            switch(currentSquare)
            {
                case 0:
                    return r0c0;
                case 1:
                    return r0c1;
                case 2:
                    return r0c2;
                case 3:
                    return r0c3;
                case 4:
                    return r0c4;
                case 5:
                    return r1c0;
                case 6:
                    return r1c1;
                case 7:
                    return r1c2;
                case 8:
                    return r1c3;
                case 9:
                    return r1c4;
                case 10:
                    return r2c0;
                case 11:
                    return r2c1;
                case 12:
                    return r2c2;
                case 13:
                    return r2c3;
                case 14:
                    return r2c4;
                case 15:
                    return r3c0;
                case 16:
                    return r3c1;
                case 17:
                    return r3c2;
                case 18:
                    return r3c3;
                case 19:
                    return r3c4;
                case 20:
                    return r4c0;
                case 21:
                    return r4c1;
                case 22:
                    return r4c2;
                case 23:
                    return r4c3;
                case 24:
                    return r4c4;
                default:
                    return l0;
            }

        } 
    }
}