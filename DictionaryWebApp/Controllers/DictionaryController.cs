using Microsoft.AspNetCore.Mvc;
using DictionaryWebApp.Services;

namespace DictionaryWebApp.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly DictionaryService _service;

        public DictionaryController(DictionaryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? word, string? language = "en")
        {
            if (string.IsNullOrWhiteSpace(word))
                return View(null);

            var result = await _service.SearchAsync(word, language);

            if (result == null)
                ViewBag.NotFound = true;

            ViewBag.SelectedLanguage = language;

            return View(result);
        }


    }
}
