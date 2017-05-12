using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grid.Mvc.Demo.Models
{
    public class GridDataRow
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public uint Year { get; set; }
        public string Condition { get; set; }
    }
}