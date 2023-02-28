var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

List<Task> tasks = new List<Task>{
    new Task(1, "handle ind", false),
    new Task(2, "vaske op", false),
    new Task(3, "lave mad", false)
};

app.MapGet("/api/tasks", () => tasks);
app.MapGet("/api/tasks/{id}", (int id) => tasks.Find(x => x.id == id));

app.MapPost("/api/tasks", (Task task) =>
{
    int max = tasks.Max(x => x.id);
    tasks.Add(new Task(++max, task.text, task.done));
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
});

app.Run();

record Task(int id, string text, bool done);