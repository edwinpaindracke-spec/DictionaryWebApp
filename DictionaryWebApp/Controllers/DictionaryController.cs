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

        public IActionResult Index(string? word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return View(null);   // no search yet

            var result = _service.Search(word);

            if (result == null)
                ViewBag.NotFound = true;  // tell the view the word is missing

            return View(result);
        }

    }
}
