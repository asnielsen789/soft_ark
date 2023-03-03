using Microsoft.EntityFrameworkCore;
using Models;

/// builder+app setup

var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContextSQLite")));

var app = builder.Build();
app.UseCors(AllowCors);

/// code
/*using (var db = new TaskContext())
{
    db.Add(new User("Asger", "asn@mail.dk"));
    db.Add(new TodoTask("handle ind", "hverdag", db.Users.First(), false));
    db.Add(new TodoTask("vaske op", "hverdag", db.Users.First(), false));
    db.Add(new TodoTask("lave mad", "hverdag", db.Users.First(), false));

    db.SaveChanges();
}*/

app.MapGet("/api/tasks", (TaskContext db) => db.Tasks);
/*app.MapGet("/api/tasks/{id}", (int id) => db.Tasks.Find(x => x.id == id));

app.MapPost("/api/tasks", (Task task) =>
{
    int max = db.Tasks.Max(x => x.id);
    db.Tasks.Add(new Task(++max, task.text, task.done));
    return tasks.ToArray();
});

app.MapPut("/api/tasks/{id}", (int id, Task task) =>
{
    tasks[tasks.FindIndex(x => x.id == id)] = (new Task(id, task.text, task.done));
    return tasks.ToArray();
});

app.MapDelete("/api/tasks/{id}", (int id) =>
{
    tasks.Remove(tasks.Find(x => x.id == id));
    return tasks.ToArray();
});*/


app.Run();

record Task(int id, string text, bool done);