using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class Game
    {
        private int level = 1;
        private int mistakes = 0;
        private int elapsedTime = 0;
        private int leftWords = 5;
        private string category = "Select Category";
        private string currentWord = "";
        private string currentWordState = "start";
        private string name;

        public int Level { get { return level; } set { level = value; OnPropertyChanged(nameof(Level)); } }
        public int Mistakes { get { return mistakes; } set { mistakes = value; OnPropertyChanged(nameof(Mistakes)); } }
        public int ElapsedTime { get { return elapsedTime; } set { elapsedTime = value; OnPropertyChanged(nameof(ElapsedTime)); } }
        public string CurrentWord { get { return currentWord; } set { currentWord = value; OnPropertyChanged(nameof(CurrentWord)); } }
        public string Category { get { return category; } set { category = value; OnPropertyChanged(nameof(Category)); } }
        public int LeftWords { get { return leftWords; } set { leftWords= value; OnPropertyChanged(nameof(leftWords)); } }
        public string CurrentWordState { get { return currentWordState; } set { currentWordState = value; OnPropertyChanged(nameof(CurrentWordState)); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
