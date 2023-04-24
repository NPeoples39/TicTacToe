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
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow _parentWindow;
        public Window1(MainWindow parentWindow )
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        public void ShowWindow()
        {
            this.Visibility = Visibility.Visible;
        }

        private void onePlayer_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show();
            this.Hide();
            _parentWindow.PlayerNum = 1;
            _parentWindow.NewGame();
        }

        private void twoPlayer_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show();
            this.Hide();
        }
        
    }
    
}
