using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeDomain.Models
{
    public class Filliale
    {
        public Guid FillialeId { get; set; }
        public string FillialeName { get; set; }
        public Guid FillialeCode { get; set;}
    }
}
