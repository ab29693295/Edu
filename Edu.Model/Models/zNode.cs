using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Models
{
    public class zNode
    {
        public int id { get; set; }
        public int pId { get; set; }
        public string name { get; set; }
        public string funcID { get; set; }
        public bool chk { get; set; }
        public bool open { get; set; }

    }
    public class zNodeFun
    {
        public int oid { get; set; }
        public string id { get; set; }
        public string pId { get; set; }
        public string name { get; set; }
        public bool chk { get; set; }
        public bool open { get; set; }

    }
}
