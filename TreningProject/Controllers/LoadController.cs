using Microsoft.AspNetCore.Mvc;
using TreningProject.Abstractions.Services;
using TreningProject.Helpers;

namespace TreningProject.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с страницей загрузчиком
    /// </summary>
    public class LoadController : Controller
    {
        private IWebHostEnvironment _enviroment;
        private ILogger<LoadController> _logger;
        private IWeatherConditionService _db;
        private string _tempFolder;

        public LoadController(ILogger<LoadController> logger, 
                              IWeatherConditionService db,
                              IWebHostEnvironment enviroment)
        {
            _logger = logger;
            _db = db;
            _enviroment = enviroment;
            _tempFolder = Path.Combine(_enviroment.WebRootPath, "temp");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm]IFormFile file)
        {
            try
            {
                var zipPath = await FileHelper.SaveFileAsync(file, _tempFolder);
                var excelPathes = ZipHelper.Unzip(zipPath, _tempFolder);
                var weatherConditions = ExcelHelper.GetWeatherConditions(excelPathes);
                await _db.AddWeathersAsync(weatherConditions);
                FileHelper.DeleteFile(zipPath);
                FileHelper.DeleteFiles(excelPathes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View();
        }
    }
}
