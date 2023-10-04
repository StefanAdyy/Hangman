using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApplication1.Services;

namespace WpfApplication1.ViewModels
{
    class FirstWindowVM
    {
        public ObservableCollection<Player> PlayerList
        {
            get; set;
        }

        public FirstWindowVM()
        {
            PlayerList = new ObservableCollection<Player>(GetPlayersFromPlayersFile());
        }

        private List<Player> GetPlayersFromPlayersFile()
        {
            ObservableCollection<Player> players = new ObservableCollection<Player>();
            XDocument playersDocument = XDocument.Load("players.xml");

            foreach (var user in playersDocument.Descendants("player"))
            {
                Player player = new Player();
                player.Name = user.Element("name").Value.ToString();
                player.AvatarPath = user.Element("avatarPath").Value.ToString();
                player.Rank = Int32.Parse(user.Element("rank").Value.ToString());
                player.WonGames = Int32.Parse(user.Element("wonGames").Value.ToString());
                player.PlayedGames = Int32.Parse(user.Element("playedGames").Value.ToString());

                if (player.Name != "DoNotDisplay")
                {
                    players.Add(player);
                }
            }

            return players.OrderBy(p => p.WonGames).ToList();
        }
    }
}
