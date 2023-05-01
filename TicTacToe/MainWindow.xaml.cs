using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public int PlayerNum { get; set; }

        Random random = new Random();
        
        public MainWindow()
        {
            InitializeComponent();
            
            NewGame();
            Window1 w = new Window1(this);
            //MainWindow w2 = new MainWindow();
            w.Show();
            this.Hide();
            
        }

        /// <summary>
        /// When you hit the "New Game" button
        /// </summary>
        public void NewGame()
        {
            foreach (Button b in MainGrid.Children.OfType<Button>())
            {
                if (Grid.GetRow(b) < 3)
                {
                    b.Content = "";
                    
                }
                
            }
            gameOver = false;
            /// <summary>
            /// The player 1 wins/ player 2 wins buttons hide themselves
            /// The x turn is visible and the o turn is hidden
            /// </summary>
            HideWinners();
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

            Brush color1 = Brushes.Red;
            Brush color2 = Brushes.Black;


            //MessageBox.Show($"{row}{column}/n{board[row, column]}");
            if (board[row, column] == 0)
            {
                Audio.Move.Play();
                if (player1Turn)
                {

                    button.Content = "X";
                    button.Foreground = color2;
                    board[row, column] = 1;
                    oTurn.Visibility = Visibility.Visible;
                    xTurn.Visibility = Visibility.Hidden;
                    
                    
                    


                }
                else
                {
                    button.Content = "O";
                    button.Foreground = color1;
                    board[row, column] = 2;
                    oTurn.Visibility= Visibility.Hidden;
                    xTurn.Visibility = Visibility.Visible;

                    
                }
                
                /// <summary>
                /// Checking for winner and if player one wins the text box turns visible
                /// </summary>
                if (CheckForWinner() == 1)
                {
                    ShowWinner(Player1Wins);
                   
                }
                else if(CheckForWinner() == 2)
                {
                    ShowWinner(Player2Wins);
                      
                }
                if(CheckForWinner() != 0)
                {
                    gameOver = true;
                }
                if(CheckForWinner() == -1)
                {
                    ShowWinner(Tie);
                    
                }




                if (PlayerNum == 1 && player1Turn == true && gameOver == false)
                {
                    

                    int rx = random.Next(0, 3);
                    int ry = random.Next(0, 3);

                    while (board[ry, rx] != 0)
                    {
                        rx = random.Next(0, 3);
                        ry = random.Next(0, 3);
                    }
                    //MessageBox.Show($"{ry}{rx}");
                    Button b = GetButton(MainGrid, rx, ry);
                    b.Content = "O";
                    board[ry, rx] = 2;
                    b.Foreground = color1;

                }
                
                else
                {
                    player1Turn = !player1Turn;
                }

                // if 1 player game
                // and player1turn
                // do ai

                if (CheckForWinner() == 1)
                {
                    Player1Wins.Visibility = Visibility.Visible;
                    xTurn.Visibility = Visibility.Hidden;
                    oTurn.Visibility = Visibility.Hidden;
                }
                else if (CheckForWinner() == 2)
                {
                    Player2Wins.Visibility = Visibility.Visible;
                    xTurn.Visibility = Visibility.Hidden;
                    oTurn.Visibility = Visibility.Hidden;
                }
                if (CheckForWinner() != 0)
                {
                    gameOver = true;
                }






            }
        }
        public static Button GetButton(Grid g, int col, int row)
        {
            Button b = g.Children.OfType<Button>()
                .Cast<Button>()
                .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
            return b;
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
                if (board[0, d] != 0 && board[0, d] == board[1, d] && board[1, d] == board[2, d])
                {
                    return board[0, d];
                }
            }

            // Check Diagnal
            if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }

            if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[2, 0];
            }
            int plays = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] != 0)
                    {
                        plays++;
                    }

                }
            }
            if (plays == 9)
            {
                return -1;
            }

            return 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void HideWinners()
        {
            Player1Wins.Visibility = Visibility.Hidden;
            Player2Wins.Visibility = Visibility.Hidden;
            Tie.Visibility = Visibility.Hidden;
        }
        private void ShowWinner(TextBox w)
        {
            HideWinners();
            w.Visibility = Visibility.Visible;
            xTurn.Visibility = Visibility.Hidden;
            oTurn.Visibility = Visibility.Hidden;
        }
    }
}
