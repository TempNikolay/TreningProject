using Microsoft.AspNetCore.Mvc;
using TreningProject.Abstractions;
using TreningProject.Abstractions.Services;
using TreningProject.ViewModel;

namespace TreningProject.Controllers
{
    /// <summary>
    /// Контроллер для обзора погодных условий
    /// </summary>
    public class ReviewController : Controller
    {
        private ILogger<ReviewController> _logger;
        private IWeatherConditionService _db;
        private int _take = 20;

        public ReviewController(ILogger<ReviewController> logger, 
                              IWeatherConditionService db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index(Grouping? grouping = null, int currentPage = -1)
        {
            var model = new PaginationModel();

            try
            {
                IEnumerable<int> pages = null;
                Func<WeatherCondition, bool> filter = null;

                if (grouping.HasValue && grouping.Value == Grouping.ByMonths)
                {
                    pages = await _db.GetGroupKeys(w => w.DateTime.Month);
                    filter = w => w.DateTime.Month == currentPage;
                }
                else
                {
                    grouping = Grouping.ByYears;
                    pages = await _db.GetGroupKeys(w => w.DateTime.Year);

                    if (currentPage == -1)
                        currentPage = pages.First();

                    filter = w => w.DateTime.Year == currentPage;
                }

                var weatherConditions = await _db.GetByFilterAsync(filter, 0, _take);

                if (weatherConditions != null)
                {
                    model.Grouping = grouping.Value;
                    model.CurrentPage = currentPage;
                    model.Pages = pages;
                    model.WeatherConditions = weatherConditions;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View(model);
        }

        public async Task<IActionResult> LoadMore(Grouping? grouping = null, int currentPage = -1, int skip = 0)
        {
            Func<WeatherCondition, bool> filter = null;

            if (grouping.Value == Grouping.ByMonths)
            {
                filter = w => w.DateTime.Month == currentPage;
            }
            else
            {
                filter = w => w.DateTime.Year == currentPage;
            }

            var weatherConditions = await _db.GetByFilterAsync(filter, skip, _take);

            return Json(weatherConditions);
        }
    }
}
