using toDoList.Models;

namespace toDoList.Services;

public interface ITodoService
{
    IEnumerable<TodoItem> GetAll();
    TodoItem Add(string title);
    void Toggle(int id); 
    void Remove(int id);
}

