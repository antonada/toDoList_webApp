using toDoList.Models;
using toDoList.Services;

namespace toDoList.Services;

public class TodoService : ITodoService
{
    private readonly List<TodoItem> _items = new();
    private int _nextId = 1;                    

    public IEnumerable<TodoItem> GetAll() => _items.OrderByDescending(t => t.Id);

    public TodoItem Add(string title)
    {
        var item = new TodoItem { Id = _nextId++, Title = title };
        _items.Add(item);
        return item;
    }

    public void Toggle(int id)
    {
        var item = _items.FirstOrDefault(t => t.Id == id);
        if (item != null)
            item.IsDone = !item.IsDone;
    }

    public void Remove(int id)
    {
        var item = _items.FirstOrDefault(t => t.Id == id);
        if (item != null)
            _items.Remove(item);
    }
}

