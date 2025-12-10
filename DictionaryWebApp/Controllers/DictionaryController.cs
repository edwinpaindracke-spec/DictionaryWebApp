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

        public async Task<IActionResult> Index(string? word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return View(null);

            var result = await _service.SearchAsync(word);

            if (result == null)
                ViewBag.NotFound = true;

            return View(result);
        }


    }
}
