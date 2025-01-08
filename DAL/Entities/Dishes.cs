using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Dishes
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
