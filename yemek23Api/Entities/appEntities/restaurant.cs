using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemek23Api.Entities.appEntities
{
    internal class restaurant
    {
        public int restaurant_id {  get; set; }
        public int restaurant_name { get; set; }
        public int restaurant_score { get; set; }
        public string restaurant_location { get; set; }
        public int restaurant_employee_count { get; set; }
        public int restaurant_table_count { get; set; }

    }
}
