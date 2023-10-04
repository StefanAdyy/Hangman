using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Models;

namespace WpfApplication1.Services
{
    public class CategoryManagement
    {
        public List<Category> Categories{ get; set; }

        public CategoryManagement(List<Category> categories)
        {
            Categories = categories;
        }

        public List<string> GetCategoryWords(string categoryName)
        {
            List<string> words = new List<string>();

            if (categoryName!= "AllCategories")
            {
                for (int i = 0; i < Categories.Count; i++)
                {
                    if (Categories[i].Name == categoryName)
                    {
                        return Categories[i].Words;
                    }
                }
            }
            else
            {
                List<string> categoryWords= new List<string>();

                var rand = new Random();

                foreach (var category in Categories)
                {
                    for (int i = 0; i < category.Words.Count; i++)
                    {
                        categoryWords.Add(category.Words[i]);
                    }
                }

                List<string> randomWords = new List<string>();

                for (int i = 0; i < 5; i++)
                {
                    randomWords.Add(categoryWords[rand.Next(categoryWords.Count)]);
                }

                return randomWords;
            }

            return words;
        }
    }
}
