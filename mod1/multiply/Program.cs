Console.WriteLine(Opgave4.Multiply(50, 6));

class Opgave4
{
    public static int Multiply(int a, int b)
    {
        if(b == 1){
            return a;
        }
        else{
            return a + Multiply(a,b-1);
        }
    }
}