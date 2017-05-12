using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grid.Mvc.Demo.Models
{
    public class GridFilter
    {
        [Required]
        public uint? Year { get; set; }

        public string CarMake { get; set; }
    }
}