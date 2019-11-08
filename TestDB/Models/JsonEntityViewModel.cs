using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDB.Models
{
    public class JsonEntityViewModel
    {
        public IEnumerable<string> Val { get; set; }
        public bool Change { get; set; } = false;
    }
}
