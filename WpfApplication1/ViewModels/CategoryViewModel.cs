using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }

        public CategoryViewModel()
        {
            Categories = GetCategoriesFromFile();
        }

        private List<Category> GetCategoriesFromFile()
        {
            List<Category> categories = new List<Category>();
            XDocument document = XDocument.Load("categories.xml");

            foreach (var category in document.Descendants("category"))
            {
                Category newCategory = new Category();
                newCategory.Name = category.Element("name").Value.ToString();
                newCategory.Words = category.Element("words").Value.ToString().Split(' ').ToList();

                categories.Add(newCategory);
            }

            return categories;
        }
    }
}
