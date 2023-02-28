Console.WriteLine(Opgave4.Reverse("banankage"));

class Opgave4
{
    public static string Reverse(string s)
    {
        if (s.Length == 1)
        {
            return s;
        }
        else
        {
            return Reverse(s.Substring(1)) + s[0];
        }
    }
}