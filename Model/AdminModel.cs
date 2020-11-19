using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AdminModel
    {
        public int eid {get;set;}
        public int pid { get;set;}
        public int jid { get;set;}
        public string ename { get;set;}
        public string epsw { get;set;}
        public string erealname { get;set; }
        public string etel { get;set; }
        public string eaddress { get;set; }
        public string eflag { get;set; }
        public string eremark { get;set; }
    }
}
