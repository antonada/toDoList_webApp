using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toDoList.Models;
using toDoList.Services;

namespace toDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITodoService _service;

        public IEnumerable<TodoItem> Items { get; private set; } = Enumerable.Empty<TodoItem>();

        [BindProperty]
        public string NewTitle { get; set; } = string.Empty;

        public IndexModel(ITodoService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Items = _service.GetAll();
        }

        public IActionResult OnPostAdd()
        {
            if (!string.IsNullOrWhiteSpace(NewTitle))
            {
                _service.Add(NewTitle.Trim());
            }
            return RedirectToPage();
        }

        public IActionResult OnPostToggle(int id)
        {
            _service.Toggle(id);
            return RedirectToPage();
        }
        public IActionResult OnPostDelete(int id)
        {
            _service.Remove(id);
            return RedirectToPage();
        }
    }
}

