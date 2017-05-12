using System.Web.Mvc;

namespace Grid.Mvc.Ajax.Helpers
{
    public interface IHtmlHelpers
    {
        string RenderPartialViewToString(string viewName, object model, Controller controller);
    }
}
