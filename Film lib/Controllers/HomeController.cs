using Film_lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Film_lib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Settings _settings;

        public HomeController(ILogger<HomeController> logger, IOptions<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            try {
                // Получение значения переменной окружения через метод
                var tmdbApiKey = _settings.GetTmdbApiKey();

                // Логирование значения переменной окружения
                _logger.LogInformation("TMDB_API_KEY: {TmdbApiKey}", tmdbApiKey);

                // Передача значения во View
                ViewBag.TmdbApiKey = tmdbApiKey;
            } catch (InvalidOperationException ex) {
                _logger.LogError(ex, "Ошибка при получении TMDB_API_KEY");
                ViewBag.TmdbApiKey = "Ошибка: ключ не установлен";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}