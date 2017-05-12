using System.Linq;

namespace Grid.Mvc.Ajax.GridExtensions
{
    public interface IAjaxGridFactory
    {
        IAjaxGrid CreateAjaxGrid<T>(IQueryable<T> gridItems, int page, bool renderOnlyRows, int pagePartitionSize = 0)
            where T : class;
    }
}