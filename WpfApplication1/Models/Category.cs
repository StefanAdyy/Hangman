using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class Category
    {
        private string name;
        List<string> words;

        public string Name {
            get 
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<string> Words
        {
            get
            {
                return words;
            }
            set
            {
                words = value;
            }
        }
    }
}
