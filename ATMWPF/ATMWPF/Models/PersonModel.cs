using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWPF.Models
{
    public class PersonModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public int ErrorTimes { get; set; }

        public bool Locked { get; set; }
        public int Money { get; set; }

    }
}
