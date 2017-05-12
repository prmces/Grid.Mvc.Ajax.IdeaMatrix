using System;
using System.Web.Mvc;

namespace Grid.Mvc.Ajax.GridExtensions
{
    public interface IAjaxGrid : GridMvc.IGrid
    {
        string ToJson(string gridPartialViewName, Controller controller);
        string ToJson(string gridPartialViewName, Object model, Controller controller);
        bool HasItems { get; }
    }
}