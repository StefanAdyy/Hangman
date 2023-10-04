using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModels
{

    class PlayerVM
    {
        //se mapeaza obiectul Student din Model pe obiectul StudentVM din ViewModel
        private Player player;
        public PlayerVM(Player player)
        {
            this.player = player;
        }
        public string Name
        {
            get
            {
                return player.Name;
            }
            set
            {
                player.Name = value;
            }
        }

        public string ToDisplay
        {
            get
            {
                return player.ToString();
            }
        }
    }


}
