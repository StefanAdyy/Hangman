using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace WpfApplication1.Services
{
    public class PlayerManagement : INotifyPropertyChanged
    {
        public ObservableCollection<Player> Players { get; set; }
        public PlayerManagement(ObservableCollection<Player> players)
        {
            this.Players = players;
        }

        public bool AddPlayer(Player player)
        {
            if (player.Name.Length > 0)
            {
                if (UniqueName(player.Name))
                {
                    Players.Add(player);
                    AddPlayerToPlayersFile(player);
                    return true;
                }
                else
                {
                    MessageBox.Show("Player name already taken");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You must enter a name");
                return false;
            }
        }

        public void AddPlayerToPlayersFile(Player player)
        {
            if (!File.Exists("players.xml"))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;

                using (XmlWriter writer = XmlWriter.Create("players.xml", xmlWriterSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("players");
                    writer.WriteStartElement("player");
                    writer.WriteElementString("name", player.Name);
                    writer.WriteElementString("avatarPath", player.AvatarPath);
                    writer.WriteElementString("rank", player.Rank.ToString());
                    writer.WriteElementString("wonGames", player.WonGames.ToString());
                    writer.WriteElementString("playedGames", player.PlayedGames.ToString());
                    writer.WriteEndElement();
                    writer.Flush();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load("players.xml");
                XElement root = xDocument.Element("players");
                IEnumerable<XElement> rows = root.Descendants("player");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(new XElement("player",
                       new XElement("name", player.Name),
                       new XElement("avatarPath", player.AvatarPath),
                       new XElement("rank", player.Rank),
                       new XElement("wonGames", player.WonGames),
                       new XElement("playedGames", player.PlayedGames)));

                xDocument.Save("players.xml");
            }
        }

        internal void DeletePlayer(string playerName)
        {
            if (playerName != "DoNotDisplay")
            {
                XDocument document = XDocument.Load(@"players.xml");

                document.Root
                    .Elements("player")
                    .Where(ws => (string)ws.Element("name") == playerName)
                    .Remove();

                document.Save(@"players.xml");

                int playerIndex = GetPlayerIndex(playerName);

                if (playerIndex >= 0)
                {
                    Players.RemoveAt(playerIndex);
                }
            }

        }

        private int GetPlayerIndex(string playerName)
        {
            for (int index = 0; index < Players.Count; index++)
            {
                if (Players[index].Name == playerName)
                {
                    return index;
                }
            }

            return -1;
        }

        public bool UniqueName(string name)
        {
            foreach (Player player in Players)
            {
                if (player.Name == name)
                {
                    return false;
                }
            }
            return true;
        }

        public Player ReturnPlayer(int index)
        {
            return Players[index];
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
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
