using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationContract_GB_.Entitys
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public int c_status_task { get; set; }
        public int id_contract { get; set; }
    }
}
