using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class GameViewModel
    {
        public ObservableCollection<Game> games { get; set; }
        public Game Game { get; set; }
        public GameViewModel()
        {
            games = GetGameFromFile();
            Game = new Game();  
        }

        public ObservableCollection<Game> GetGameFromFile()
        {
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            XDocument objDoc = XDocument.Load("games.xml");

            foreach (var savedGame in objDoc.Descendants("game"))
            {
                Game tempGame = new Game();

                tempGame.Name = savedGame.Element("name").Value.ToString();
                tempGame.Level = Int32.Parse(savedGame.Element("level").Value.ToString());
                tempGame.Mistakes = Int32.Parse(savedGame.Element("mistakes").Value.ToString());
                tempGame.ElapsedTime = Int32.Parse(savedGame.Element("elapsedTime").Value.ToString());
                tempGame.Category = savedGame.Element("category").Value.ToString();
                tempGame.CurrentWord = savedGame.Element("currentWord").Value.ToString();
                tempGame.LeftWords = Int32.Parse(savedGame.Element("leftWords").Value.ToString());
                tempGame.CurrentWordState = savedGame.Element("currentWordState").Value.ToString();

                if (tempGame.Name != "default")
                {
                    games.Add(tempGame);
                }
            }

            return games;
        }
    }
}
