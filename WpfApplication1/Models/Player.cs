using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Player : INotifyPropertyChanged
    {
        private string name;
        private string avatarPath;
        private int playedGames;
        private int wonGames;
        private int rank;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        public string AvatarPath
        {
            get 
            { 
                return avatarPath; 
            }
            set
            {
                avatarPath = value;
                OnPropertyChanged(nameof(avatarPath));
            }
        }

        public int PlayedGames
        {
            get 
            { 
                return playedGames; 
            }
            set
            {
                playedGames = value;
                OnPropertyChanged(nameof(playedGames));
            }
        }

        public int WonGames
        {
            get
            {
                return wonGames;
            }
            set
            {
                wonGames = value;
                OnPropertyChanged(nameof(wonGames));
            }
        }

        public int Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
                OnPropertyChanged(nameof(rank));
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
