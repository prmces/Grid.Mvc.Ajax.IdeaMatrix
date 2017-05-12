using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grid.Mvc.Demo.Models;
using Grid.Mvc.Ajax.GridExtensions;

namespace Grid.Mvc.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cars = Data();
            var grid = (AjaxGrid<GridDataRow>)new AjaxGridFactory().CreateAjaxGrid(cars, 1, false);

            var partitionedData = PartitionedData();
            var grid2 = (AjaxGrid<GridDataRow>)new AjaxGridFactory().CreateAjaxGrid(partitionedData, 1, false, 10);
            var filterGrid = (AjaxGrid<GridDataRow>)new AjaxGridFactory().CreateAjaxGrid(partitionedData, 1, false, 10);

            return View(new GridData() { Grid = grid, Grid2 = grid2, FilterableGrid = filterGrid});
        }

        [HttpGet]
        public ActionResult Grid(int? page)
        {
            var cars = Data();

            var grid = new AjaxGridFactory().CreateAjaxGrid(cars, page.HasValue ? page.Value : 1, page.HasValue);

            return Json(new { Html = grid.ToJson("_CarGrid", this), grid.HasItems }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Grid2(int? page)
        {
            var cars = PartitionedData();

            var grid = new AjaxGridFactory().CreateAjaxGrid(cars, page.HasValue ? page.Value : 1, page.HasValue);

            return Json(new { Html = grid.ToJson("_Grid2", this), grid.HasItems }, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<GridDataRow> Data()
        {
            var cars = new List<GridDataRow>()
                {
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Cavalier", Condition = "Poor", Year = 2002},
                    new GridDataRow() {CarMake = "Ford", CarModel = "F150", Condition = "Good", Year = 2011},
                    new GridDataRow() {CarMake = "Toyota", CarModel = "Corolla", Condition = "Excellent", Year = 2012},
                    new GridDataRow() {CarMake = "Honda", CarModel = "Civic", Condition = "Poor", Year = 2004},
                    new GridDataRow() {CarMake = "Tesla", CarModel = "Model S", Condition = "Excellent", Year = 2012},
                    new GridDataRow() {CarMake = "Ford", CarModel = "F250", Condition = "Good", Year = 2009},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "1500", Condition = "Good", Year = 2009},
                    new GridDataRow() {CarMake = "Ford", CarModel = "Raptor", Condition = "Excellent", Year = 2011},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Cavalier", Condition = "Good", Year = 2003},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Cobalt", Condition = "Excellent", Year = 2006},
                }.AsQueryable();

            return cars;
        }

        private IQueryable<GridDataRow> PartitionedData()
        {
            var cars = new List<GridDataRow>()
                {
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Cavalier", Condition = "Poor", Year = 2002},
                    new GridDataRow() {CarMake = "Ford", CarModel = "F150", Condition = "Good", Year = 2011},
                    new GridDataRow() {CarMake = "Toyota", CarModel = "Corolla", Condition = "Excellent", Year = 2012},
                    new GridDataRow() {CarMake = "Honda", CarModel = "Civic", Condition = "Poor", Year = 2004},
                    new GridDataRow() {CarMake = "Tesla", CarModel = "Model S", Condition = "Excellent", Year = 2012},
                    new GridDataRow() {CarMake = "Ford", CarModel = "F250", Condition = "Good", Year = 2009},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "1500", Condition = "Good", Year = 2009},
                    new GridDataRow() {CarMake = "Ford", CarModel = "Raptor", Condition = "Excellent", Year = 2011},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Cavalier", Condition = "Good", Year = 2003},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Cobalt", Condition = "Excellent", Year = 2006},

                    new GridDataRow() {CarMake = "Chevy", CarModel = "Corvette", Condition = "Poor", Year = 2002},
                    new GridDataRow() {CarMake = "Ford", CarModel = "F350", Condition = "Good", Year = 2011},
                    new GridDataRow() {CarMake = "Toyota", CarModel = "Tundra", Condition = "Excellent", Year = 2012},
                    new GridDataRow() {CarMake = "Honda", CarModel = "Civic EX", Condition = "Poor", Year = 2004},
                    new GridDataRow() {CarMake = "Tesla", CarModel = "Model X", Condition = "Excellent", Year = 2012},
                    new GridDataRow() {CarMake = "Ford", CarModel = "F250 Super Duty", Condition = "Good", Year = 2009},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "2500", Condition = "Good", Year = 2009},
                    new GridDataRow() {CarMake = "Ford", CarModel = "Raptor SRT", Condition = "Excellent", Year = 2011},
                    new GridDataRow() {CarMake = "Chevy", CarModel = "Traverse", Condition = "Good", Year = 2003},
                    new GridDataRow() {CarMake = "Chrysler", CarModel = "300", Condition = "Excellent", Year = 2006},
                }.AsQueryable();

            return cars;
        }

        [HttpGet]
        public ActionResult PartitionedGrid()
        {
            var cars = PartitionedData();
            var grid = (AjaxGrid<GridDataRow>)new AjaxGridFactory().CreateAjaxGrid(cars, 1, false, 5);
            return View(new GridData() { Grid = grid });
        }

        [HttpGet]
        public ActionResult PartitionedGridData(int? page)
        {
            var cars = PartitionedData();

            var grid = new AjaxGridFactory().CreateAjaxGrid(cars, page.HasValue ? page.Value : 1, page.HasValue, 5);

            return Json(new { Html = grid.ToJson("_CarGrid", this), grid.HasItems }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult FilterGrid(GridFilter gridFilter, int? page)
        {
            if (ModelState.IsValid)
            {
                var cars = PartitionedData().Where(x => (x.CarMake == gridFilter.CarMake || gridFilter.CarMake == null) && x.Year == gridFilter.Year);
                var grid = new AjaxGridFactory().CreateAjaxGrid(cars, page.HasValue ? page.Value : 1, page.HasValue, 5);
                return Json(new { Html = grid.ToJson("_FilteredGrid", this), grid.HasItems }, JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Errors(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult PreFilterForm(GridFilter gridFilter)
        {
            return Json("test");
        }
    }

    public static class ModelStateHelper
    {
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(kvp => kvp.Key,
                                               kvp => kvp.Value.Errors
                                                         .Select(e => e.ErrorMessage).ToArray())
                                 .Where(m => m.Value.Count() > 0).ToList();
            }
            return null;
        }
    }
}
