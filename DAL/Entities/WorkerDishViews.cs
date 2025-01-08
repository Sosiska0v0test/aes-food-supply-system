using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class WorkerDishViews
    {
        public int ViewID { get; set; }
        public int WorkerID { get; set; }
        public int DishID { get; set; }
        public DateTime ViewDateTime { get; set; }

    }
}
