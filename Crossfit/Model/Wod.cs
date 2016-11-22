using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossfit.Model
{
    public class Wod
    {
        public string WodName { get; set; }
        public string Description { get; set; }
        public string Movement1 { get; set; }
        public string Movement2 { get; set; }
   


        public override string ToString()
        {
            return WodName + " \n " + Description + "\n  " + Movement1 + "\n  " + Movement2 + " \n ";
        }
    }
}
