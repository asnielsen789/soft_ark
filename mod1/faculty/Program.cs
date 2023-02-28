Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
Console.WriteLine("done");

class Opgave3
{
    public static int Faculty(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Faculty(n - 1);
        }
    }
}