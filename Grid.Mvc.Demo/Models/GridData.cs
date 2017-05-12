using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Grid.Mvc.Ajax.GridExtensions;

namespace Grid.Mvc.Demo.Models
{
    public class GridData
    {
        public AjaxGrid<GridDataRow> Grid { get; set; }

        public AjaxGrid<GridDataRow> Grid2 { get; set; }

        public AjaxGrid<GridDataRow> FilterableGrid { get; set; }

        public GridFilter GridFilter { get; set; }

        public GridData()
        {
            GridFilter = new GridFilter();
        }
    }
}