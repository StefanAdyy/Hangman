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
using WpfApplication1.Services;
using WpfApplication1.ViewModels;
using WpfApplication1.Views;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        private PlayerManagement _playerManagement;
        public FirstWindow()
        {
            InitializeComponent();
            _playerManagement = new PlayerManagement(new FirstWindowVM().PlayerList);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow(_playerManagement);
            newUserWindow.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string playerName = _playerManagement.ReturnPlayer(UserGrid.SelectedIndex).Name;
            _playerManagement.DeletePlayer(playerName);
            FirstWindow firstWindow = new FirstWindow();
            firstWindow.Show();
            this.Close();
        }

        private void ItemDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            Player player = _playerManagement.ReturnPlayer(UserGrid.SelectedIndex);
            PlayerWindow playerWindow = new PlayerWindow(player);
            playerWindow.Show();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            GameView gameView = new GameView(_playerManagement.ReturnPlayer(UserGrid.SelectedIndex), _playerManagement);
            gameView.Show();
            this.Close();
        }
    }
}
