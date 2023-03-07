using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool player1Turn = true;

        private bool gameOver = false;
        
        private int[,] board = new int[3, 3];
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        /// <summary>
        /// When you hit the "New Game" button
        /// </summary>
        private void NewGame()
        {
            foreach (Button b in MainGrid.Children.OfType<Button>())
            {
                if (Grid.GetRow(b) < 3)
                {
                    b.Content = "";
                }

            }
            /// <summary>
            /// The player 1 wins/ player 2 wins buttons hide themselves
            /// The x turn is visible and the o turn is hidden
            /// </summary>
            Player1Wins.Visibility = Visibility.Hidden;
            Player2Wins.Visibility = Visibility.Hidden;
            xTurn.Visibility = Visibility.Visible;
            oTurn.Visibility = Visibility.Hidden;
            board = new int[3, 3];
            player1Turn = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            if (board[row, column] == 0)
            {
                if (player1Turn)
                {
                    button.Content = "X";
                    board[row, column] = 1;
                    oTurn.Visibility = Visibility.Visible;
                    xTurn.Visibility = Visibility.Hidden;

                }
                else
                {
                    button.Content = "O";
                    board[row, column] = 2;
                    oTurn.Visibility= Visibility.Hidden;
                    xTurn.Visibility = Visibility.Visible;
                }
                
                /// <summary>
                /// Checking for winner and if player one wins the text box turns visible
                /// </summary>
                if (CheckForWinner() == 1)
                {
                    Player1Wins.Visibility = Visibility.Visible;
                    xTurn.Visibility = Visibility.Hidden;
                    oTurn.Visibility = Visibility.Hidden;
                }
                else if(CheckForWinner() == 2)
                {
                    Player2Wins.Visibility = Visibility.Visible;
                    xTurn.Visibility = Visibility.Hidden;
                    oTurn.Visibility = Visibility.Hidden;   
                }
                if(CheckForWinner() != 0)
                {
                    gameOver = true;
                }



                player1Turn = !player1Turn;

            }
        }

        private int CheckForWinner()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }

            }
            // Check Columns
            for (int d = 0; d < 3; d++)
            {
                if (board[d, 0] != 0 && board[d, 0] == board[d, 1] && board[d, 1] == board[d, 2])
                {
                    return board[d, 0];
                }
            }

            // Check Diagnal
            if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }

            if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }
            
            return 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}
