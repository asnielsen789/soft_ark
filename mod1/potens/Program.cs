Console.WriteLine(Opgave4.Potens(10, 3));

class Opgave4
{
    public static int Potens(int n, int p)
    {
        if(p == 1){
            return n;
        }
        else if(p == 0){
            return 1;
        }
        else{
            return n * Potens(n,p-1);
        }
    }
}