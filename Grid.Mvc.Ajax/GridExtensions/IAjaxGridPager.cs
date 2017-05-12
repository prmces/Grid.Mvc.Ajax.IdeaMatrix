namespace Grid.Mvc.Ajax.GridExtensions
{
    public interface IAjaxGridPager
    {
        int Pages { get; }
        int PagePartitionSize { get; set; }
    }
}