Console.WriteLine(Opgave4.Euclids(3087500, 59928));

class Opgave4
{
    public static int Euclids(int a, int b)
    {
        if (b <= a && a % b == 0)
        {
            return b;
        }
        else if (a < b)
        {
            return Euclids(b, a);
        }
        else
        {
            return Euclids(b, a % b);
        }
    }
}