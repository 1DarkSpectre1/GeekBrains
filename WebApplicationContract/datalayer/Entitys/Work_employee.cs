using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationContract_GB_.Entitys
{
    public class Work_employee
    {
        public int Id { get; set; }
        public int id_task { get; set; }
        public int id_employee { get; set; }
        public DateTime DateCreate { get; set; }
        public float Timework { get; set; }
    }
}
