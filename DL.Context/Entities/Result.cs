using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Context.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int AmountElements { get; set; }
        public double JSONFind { get; set; }
        public double JSONBFind { get; set; }
        public double StringFind { get; set; }
        public double EntityFind { get; set; }        
    }
}
