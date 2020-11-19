using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DepartmenModel
    {
        public int PID { get; set; }
        public string PNAME { get; set; }
        public int PFLAG { get; set; } // 0恢复 1撤销
        public string PREMARK { get; set; }
    }
}
