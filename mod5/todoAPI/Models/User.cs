using Models;

public class User
{
    public long UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    //public List<TodoTask>? TodoTasks { get; set; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}