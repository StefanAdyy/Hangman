using Microsoft.Win32;
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

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        PlayerManagement _playerManagement;
        public NewUserWindow(PlayerManagement playerManagement)
        {
            InitializeComponent();
            _playerManagement = playerManagement;
        }


        private void AvatarBrowseBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                avatar.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                avatarPath.Text = openFileDialog.FileName;
            }
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            player.Name = playerName.Text;
            player.AvatarPath = avatarPath.Text;
            if (_playerManagement.AddPlayer(player))
            {
                FirstWindow firstWindow = new FirstWindow();
                firstWindow.Show();
                this.Close();
            }

        }
        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            FirstWindow firstWindow = new FirstWindow();
            firstWindow.Show();
            this.Close();
        }
    }
}
