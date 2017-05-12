using System.Linq;

namespace Grid.Mvc.Ajax.GridExtensions
{
    public class AjaxGridFactory : IAjaxGridFactory
    {
        public IAjaxGrid CreateAjaxGrid<T>(IQueryable<T> gridItems, int page, bool renderOnlyRows)
            where T : class
        {
            return CreateAjaxGrid(gridItems, page, renderOnlyRows, 0);
        }

        public IAjaxGrid CreateAjaxGrid<T>(IQueryable<T> gridItems, int page, bool renderOnlyRows, int pagePartitionSize)
           where T : class
        {
            var grid = new AjaxGrid<T>(gridItems, page, renderOnlyRows, pagePartitionSize);
            return grid;
        }
    }
}