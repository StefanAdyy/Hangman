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
using WpfApplication1.Models;
using WpfApplication1.Services;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        private bool newGame;
        private bool openSavedGame;
        private bool gameStarted;
        private bool gameEnded;
        private string word;
        private PlayerManagement _playerManagement;
        private CategoryManagement _categoryManagement;
        private GameManagement _gameManagement;

        public Player Player { get; set; }
        public Game Game { get; set; }
        public List<string> HangImages = new List<string>();

        public GameView(Player player, PlayerManagement playerManagement)
        {
            InitializeComponent();
            this.DataContext = this;

            newGame = false;
            openSavedGame = false;
            gameStarted = false;
            gameEnded = false;
            word = String.Empty;
            Player = player;
            Game = new Game();
            Game.Name = player.Name;
            _playerManagement = playerManagement;
            _categoryManagement = new CategoryManagement(new CategoryViewModel().Categories);
            _gameManagement = new GameManagement(new GameViewModel().games);

            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng1.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng2.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng3.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng4.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng5.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng6.png");

            ActualHangImage.Source = new BitmapImage(new Uri(HangImages[Game.Mistakes % 6]));
            UpdateLifes();
            ResetLettersVisibility();
        }

        public GameView(Player player, PlayerManagement playerManagement, Game savedGame)
        {
            InitializeComponent();
            this.DataContext = this;

            newGame = false;
            openSavedGame = false;
            gameStarted = false;
            gameEnded = false;
            word = String.Empty;
            Player = player;
            Game = savedGame;
            Game.Name = player.Name;
            _playerManagement = playerManagement;
            _categoryManagement = new CategoryManagement(new CategoryViewModel().Categories);
            _gameManagement = new GameManagement(new GameViewModel().games);
            
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng1.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng2.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng3.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng4.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng5.png");
            HangImages.Add(@"C:\Users\stefa\Desktop\Projects\Hangman\Pics\hng6.png");

            ActualHangImage.Source = new BitmapImage(new Uri(HangImages[Game.Mistakes % 6]));
            UpdateLifes();
            ResetLettersVisibility();
        }

        private void ResetLettersVisibility()
        {
            letters.Children.Clear();

            Q.Visibility = Visibility.Visible;
            W.Visibility = Visibility.Visible;
            E.Visibility = Visibility.Visible;
            R.Visibility = Visibility.Visible;
            T.Visibility = Visibility.Visible;
            Y.Visibility = Visibility.Visible;
            I.Visibility = Visibility.Visible;
            O.Visibility = Visibility.Visible;
            P.Visibility = Visibility.Visible;
            U.Visibility = Visibility.Visible;
            A.Visibility = Visibility.Visible;
            S.Visibility = Visibility.Visible;
            D.Visibility = Visibility.Visible;
            F.Visibility = Visibility.Visible;
            G.Visibility = Visibility.Visible;
            H.Visibility = Visibility.Visible;
            J.Visibility = Visibility.Visible;
            K.Visibility = Visibility.Visible;
            L.Visibility = Visibility.Visible;
            Z.Visibility = Visibility.Visible;
            X.Visibility = Visibility.Visible;
            C.Visibility = Visibility.Visible;
            V.Visibility = Visibility.Visible;
            B.Visibility = Visibility.Visible;
            N.Visibility = Visibility.Visible;
            M.Visibility = Visibility.Visible;
        }

        private void OnWindowUnload(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (newGame == false)
            {
                if (MessageBox.Show($"Would you like to leave?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (gameStarted && !gameEnded)
                    {
                        Player.PlayedGames++;
                    }

                    _playerManagement.DeletePlayer(Player.Name);
                    _playerManagement.AddPlayerToPlayersFile(Player);
                    FirstWindow firstWindow = new FirstWindow();
                    firstWindow.Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void UpdateLifes()
        {
            if (Game.Mistakes == 1)
            {
                life1.Background = new SolidColorBrush(Colors.Red);
            }
            if (Game.Mistakes == 2)
            {
                life1.Background = new SolidColorBrush(Colors.Red);
                life2.Background = new SolidColorBrush(Colors.Red);
            }
            if (Game.Mistakes == 3)
            {
                life1.Background = new SolidColorBrush(Colors.Red);
                life2.Background = new SolidColorBrush(Colors.Red);
                life3.Background = new SolidColorBrush(Colors.Red);
            }
            if (Game.Mistakes == 4)
            {
                life1.Background = new SolidColorBrush(Colors.Red);
                life2.Background = new SolidColorBrush(Colors.Red);
                life3.Background = new SolidColorBrush(Colors.Red);
                life4.Background = new SolidColorBrush(Colors.Red);
            }
            if (Game.Mistakes == 5)
            {
                life1.Background = new SolidColorBrush(Colors.Red);
                life2.Background = new SolidColorBrush(Colors.Red);
                life3.Background = new SolidColorBrush(Colors.Red);
                life4.Background = new SolidColorBrush(Colors.Red);
                life5.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            var letter = ((Button)sender).Content.ToString();

            if (Game.CurrentWord.Contains(letter))
            {
                letters.Children.Add(new Button()
                {
                    Background = new SolidColorBrush(Colors.Green),
                    Content = letter,
                    Margin = new Thickness(10),
                    Width = 30,
                    Height = 30,
                });

                Game.CurrentWord = ReplaceFirstOccurrence(Game.CurrentWord, letter, "");

                if (!Game.CurrentWord.Contains(letter))
                {
                    (sender as Button).Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                Game.Mistakes += 1;
                (sender as Button).Visibility = Visibility.Collapsed;
            }
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow playerWindow = new PlayerWindow(Player);
            playerWindow.Show();
        }

        public static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _gameManagement.DeleteGame(Player.Name);
            _gameManagement.UpdateGame(Game);
        }

        private async void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            int maxTime = 30;
            ResetLettersVisibility();

            if (Game.Category != "Select Category")
            {
                gameStarted = true;
                gameEnded = false;

                List<string> wordsToGuess;

                if (Game.Category == "AllCategories")
                {
                    wordsToGuess = GetWordsFromAllCategories(Game.Category);
                }
                else
                {
                    wordsToGuess = GetWordsFromCategory(Game.Category);
                }

                Game.CurrentWord = wordsToGuess[0].ToUpper();
                wordsToGuess.RemoveAt(0);

                do
                {
                    UpdateLifes();
                    await Task.Delay(1000);
                    countdown.Content = 30 - ++Game.ElapsedTime;
                    ActualHangImage.Source = new BitmapImage(new Uri(HangImages[Game.Mistakes % 6]));

                    if (wordsToGuess.Count > 0)
                    {
                        if (Game.CurrentWord.Length == 0)
                        {
                            Game.CurrentWord = wordsToGuess[0].ToUpper();
                            wordsToGuess.RemoveAt(0);
                            Game.Level++;
                            ResetLettersVisibility();
                            Game.ElapsedTime = 0;
                        }
                    }
                    else
                    {
                        gameEnded = true;
                        break;
                    }

                } while (Game.ElapsedTime < maxTime && gameEnded == false && Game.Mistakes < 5);

                if (Game.ElapsedTime >= maxTime || Game.Mistakes >= 5)
                {
                    UpdateLifes();
                    gameEnded = true;
                    MessageBox.Show("You lost!");
                    Player.PlayedGames++;

                    _playerManagement.DeletePlayer(Player.Name);
                    _playerManagement.AddPlayerToPlayersFile(Player);

                    GameView gameView = new GameView(Player, _playerManagement);
                    gameView.Show();
                    newGame = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You won!");
                    gameEnded = true;
                    Player.WonGames++;
                    Player.PlayedGames++;

                    _playerManagement.DeletePlayer(Player.Name);
                    _playerManagement.AddPlayerToPlayersFile(Player);

                    GameView gameView = new GameView(Player, _playerManagement);
                    gameView.Show();
                    newGame = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You must select a category first!");
            }
        }

        private List<string> GetWordsFromCategory(string category)
        {
            List<string> words = new List<string>();

            var rand = new Random();

            foreach (var _category in _categoryManagement.Categories)
            {
                if (_category.Name == category)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        words.Add(_category.Words[rand.Next(_category.Words.Count)]);
                    }
                    break;
                }
            }

            return words;
        }

        private List<string> GetWordsFromAllCategories(string category)
        {
            List<string> allWords = new List<string>();
            foreach (var _category in _categoryManagement.Categories)
            {
                for (int i = 0; i < _category.Words.Count; i++)
                {
                    allWords.Add(_category.Words[i]);
                }
            }

            var rand = new Random();

            List<string> randomWords = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                randomWords.Add(allWords[rand.Next(allWords.Count)]);
            }

            return randomWords;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (!openSavedGame)
            {
                if (_gameManagement.PlayerHasSavedGame(Player.Name))
                {
                    if (MessageBox.Show($"Would you like to open a saved game?", "Open game", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        if (gameStarted == true && gameEnded == false)
                        {
                            Player.PlayedGames++;
                        }

                        _playerManagement.DeletePlayer(Player.Name);
                        _playerManagement.AddPlayerToPlayersFile(Player);

                        GameView gameView = new GameView(Player, _playerManagement, _gameManagement.Games[_gameManagement.GetGameIndex(Player.Name)] as Game);
                        gameView.Show();
                        newGame = true;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show($"You have no saved games!");
                }
            }
            else
            {
                MessageBox.Show("The saved game has already been open!");
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Would you like to leave?", "Exit game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (gameStarted && !gameEnded)
                {
                    Player.PlayedGames++;
                }

                _playerManagement.DeletePlayer(Player.Name);
                _playerManagement.AddPlayerToPlayersFile(Player);
                //FirstWindow firstWindow = new FirstWindow();
                //firstWindow.Show();
                GameView gameView = new GameView(Player, _playerManagement);
                gameView.Show();
                newGame = true;
                this.Close();
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Would you like to leave?", "Exit game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (gameStarted && !gameEnded)
                {
                    Player.PlayedGames++;
                }

                _playerManagement.DeletePlayer(Player.Name);
                _playerManagement.AddPlayerToPlayersFile(Player);
                FirstWindow firstWindow = new FirstWindow();
                firstWindow.Show();
                this.Close();
            }
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            Game.Category = ((MenuItem)sender).Name.ToString();
            SelectedCategory.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Universitatea Transilvania\n Facultatea de Matematica si Informatica\n Specializarea Informatica-Aplicata\n Grupa 10L302", "Morariu Adrian Stefan", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
