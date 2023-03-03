public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(int userId, string name, string email)
    {
        UserId = userId;
        Name = name;
        Email = email;
    }
}