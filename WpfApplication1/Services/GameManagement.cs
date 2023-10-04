using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApplication1.Models;

namespace WpfApplication1.Services
{
    public class GameManagement
    {
        private readonly ObservableCollection<Game> _games;

        public GameManagement(ObservableCollection<Game> games)
        {
            _games=games;
        }

        public ObservableCollection<Game> Games { get { return _games; } }

        public void UpdateGame(Game game)
        {
            XDocument xDocument = XDocument.Load("games.xml");
            XElement root = xDocument.Element("games");
            IEnumerable<XElement> elements = root.Descendants("game");
            XElement firstElement = elements.First();

            firstElement.AddBeforeSelf(new XElement("game",
                   new XElement("name", game.Name),
                   new XElement("level", game.Level),
                   new XElement("mistakes", game.Mistakes),
                   new XElement("elapsedTime", game.ElapsedTime),
                   new XElement("category", game.Category),
                   new XElement("currentWord", game.CurrentWord),
                   new XElement("leftWords", game.LeftWords),
                   new XElement("currentWordState", game.CurrentWordState)));

            xDocument.Save("games.xml");
        }

        public void DeleteGame(string name)
        {
            XDocument document = XDocument.Load("games.xml");

            document.Root
                    .Elements("game")
                    .Where(ws => (string)ws.Element("name") == name)
                    .Remove();

            document.Save("games.xml");

            int index = GetGameIndex(name);
            
            if (index != -1)
            {
                _games.RemoveAt(index);
            }
        }

        public int GetGameIndex(string name)
        {
            for (int index = 0; index < _games.Count; index++)
            {
                if (_games[index].Name == name)
                {
                    return index;
                }
            }

            return -1;
        }

        public bool GameNameTaken(string name)
        {
            foreach (var game in Games)
            {
                if(game.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public bool PlayerHasSavedGame(string name)
        {
            foreach (var game in Games)
            {
                if (game.Name==name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
