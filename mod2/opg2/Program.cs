Person[] people = new Person[]
{
    new Person ( Name: "Jens Hansen", Age: 45, Phone: "+4512345678" ),
    new Person ( Name: "Jane Olsen", Age: 22, Phone: "+4543215687" ),
    new Person ( Name: "Tor Iversen", Age: 35, Phone: "+4587654322" ),
    new Person ( Name: "Sigurd Nielsen", Age: 31, Phone: "+4512345673" ),
    new Person ( Name: "Viggo Nielsen", Age: 28, Phone: "+4543217846" ),
    new Person ( Name: "Rosa Jensen", Age: 23, Phone: "+4543217846" ),
};

//Find og udskriv personen med mobilnummer “+4543215687”.
Console.WriteLine(people.First(person => person.Phone == "+4543215687").Name);

//Vælg alle som er over 30 og udskriv dem.
Console.WriteLine(string.Join(", ", people.Where(person => person.Age >= 30).ToList().Select(person => person.Name)));

//Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
//Console.WriteLine(string.Join(" ,", people.Select(person => new Person (person.Name, person.Age, person.Phone.Substring(3))).ToList().Select(person => person.Name + ": " + person.Phone)));
Console.WriteLine(string.Join(" ,", people.Select(person => new Person {Name = person.Name, Age = person.Age, Phone = person.Phone.Substring(3)}).ToList().Select(person => person.Name + ": " + person.Phone)));

//Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma
Console.WriteLine(string.Join(", ", people.Where(person => person.Age < 30).ToList().Select(person => $"{person.Name}: {person.Phone}")));

class Person {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }

    public Person(string Name = "", int Age = 0, string Phone = "")
    {
        this.Name = Name;
        this.Age = Age;
        this.Phone = Phone;
    }
}