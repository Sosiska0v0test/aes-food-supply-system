using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MenuDishes
    {
        public int MenuDishID { get; set; }
        public int MenuID { get; set; }
        public int DishID { get; set; }

    }
}
