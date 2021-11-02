using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationContract_GB_.Entitys
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public int c_status_contract { get; set; }
        public int id_client { get; set; }
    }
}
