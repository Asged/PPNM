using System;

using static System.Math;
public static class main{
    public static void Main()
    {
        Func<vector, double> func = r => r[0];
        vector a = new vector(2); //lower bounds
        a[0] = 0;
        a[1] = 0;
        vector b = new vector(2); //upper bounds
        b[0] = 1;
        b[1] = 2*PI;
        int N = 10000; //Number of random points

        double res; double unc;
        (res, unc) = mc.plainmc(func, a, b, N);
        System.Console.WriteLine($"Calculacting area of unit circle. Result from integration: {res} \t Uncertainty in calculation: {unc}");

        var data = new System.IO.StreamWriter("data.txt", append: true);
        for(int N1 = 100; N1<=100000; N1+=500) {
            (res, unc) = mc.plainmc(func, a, b, N1);
            data.WriteLine($"{N1} {res} {unc} {Abs(res - PI)}");
        }
        data.Close();

        System.Console.WriteLine("Plot data.svg seems to follow 1/sqrt(N), estimated error seems to follow it very nicely, whereas actual error has a lot of points around the 1/sqrt(N)");

        
        Func<vector, double> f2 = f => 1.0 / (Pow(PI, 3) * (1 - Cos(f[0]) * Cos(f[1]) * Cos(f[2])));
        vector a1 = new vector(3); //lower bounds
        a1[0] = 0;
        a1[1] = 0;
        a1[2] = 0;
        vector b1 = new vector(3); //upper bounds
        b1[0] = PI;
        b1[1] = PI;
        b1[2] = PI;
        (res, unc) = mc.plainmc(f2, a1, b1, N);
        System.Console.WriteLine($"Calculacting area of unit circle. Result from integration: {res} \t Uncertainty in calculation: {unc}");

        //Part B with halton
        (res, unc) = mc.haltonInt(f2, a1, b1, N);
        System.Console.WriteLine($"Calculacting area of unit circle. Result from integration: {res} \t Uncertainty in calculation: {unc}");
    }
}