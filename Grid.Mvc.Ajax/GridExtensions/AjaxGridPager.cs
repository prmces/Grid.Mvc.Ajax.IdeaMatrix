using System;
using System.Linq;
using GridMvc;
using GridMvc.Pagination;

namespace Grid.Mvc.Ajax.GridExtensions
{
    public class AjaxGridPager : IGridPager, IAjaxGridPager
    {
        private readonly IGrid _grid;
        public int PagePartitionSize { get; set; }

        public AjaxGridPager(IGrid grid)
        {
            _grid = grid;
        }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public string TemplateName
        {
            get
            {
                //Custom view name to render this pager
                return "_AjaxGridPager";
            }
        }

        /// <summary>
        ///     Returns true if the pager has pages
        /// </summary>
        public bool HasPages
        {
            get
            {
                return _grid.ItemsToDisplay.Count() > PageSize;
            }
        }

        public int Pages { get; protected set; }

        public void Initialize<T>(IQueryable<T> items)
        {
            int count = items.Count();
            Pages = count/PageSize;
            if (count%PageSize > 0)
                Pages++;
        }
    }
}