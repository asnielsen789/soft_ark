using System.Web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> frugter = new List<string>
{
    "æble", "banan", "pære", "ananas"
};

Random rnd = new Random();
int num = rnd.Next();

app.MapGet("/api/frugt", () => frugter);
app.MapGet("/api/frugt/{id}", (int id) => frugter[id]);
app.MapGet("/api/frugt/random", () => frugter[rnd.Next(frugter.Count)]);

app.MapPost("/api/frugt/", (Frugt frugt) =>
{
    if (frugt == null)
    {
        throw new BadHttpRequestException("kan ikke finde frugt");
    }
    if (frugt.name == "" || frugt.name == null)
    {
        throw new BadHttpRequestException("frugt name ikke specificeret");
    }

    frugter.Add(frugt.name);

    Console.WriteLine($"Tilføjet frugt: {frugter.Last()}");

    return frugter;
});

app.Run();

record Frugt(string name);