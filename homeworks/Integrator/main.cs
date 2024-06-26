using static System.Math;
using System;
public static class main{
    public static void Main(){
        double acc = 0.001;
        double eps = 0.001;

        Func<double, double> func = x => Sqrt(x);
        // Define the integration limits
        double a = 0;
        double b = 1;

        double res = integrator.integrate(func, a, b);
        Console.WriteLine($"The integral of sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-2.0/3.0)<=acc && Abs((res - (2.0/3.0)) / (2.0/3.0)) <= eps}");

        //1/sqrt(x)
        func = x => 1/Sqrt(x);
        res = integrator.integrate(func, a, b);
        Console.WriteLine($"The integral of sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-2)<=acc && Abs((res - (2.0)) / (2.0)) <= eps}");

        //4Sqrt(1-x^2)
        func = x => 4*Sqrt(1-x*x);
        res = integrator.integrate(func, a, b);
        Console.WriteLine($"The integral of sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-PI)<=acc && Abs((res - (PI)) / (PI)) <= eps}");

        //ln(x)/sqrt(x)
        func = x => Log(x)/Sqrt(x);
        res = integrator.integrate(func, a, b);
        Console.WriteLine($"The integral of sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-(-4))<=acc && Abs((res - (-4)) / (-4)) <= eps}");

        var errorfile = new System.IO.StreamWriter("Errorfunc.txt", append: true);
        for(double x = -5; x<=5; x+=0.001) errorfile.WriteLine($"{x} {Errorfunc(x)}");
        errorfile.Close();
    }

    public static double Errorfunc(double z, double acc = 0.001, double eps = 0.001)
    {
        if (z < 0) return -Errorfunc(-z);

        Func<double, double> f1 = t => Exp(-Pow(t, 2));
        if (z <= 1 && z <= 1) return 2 / Sqrt(PI) * integrator.integrate(f1, 0, z, acc, eps);

        Func<double, double> f2 = t => Exp(-Pow(z + (1 - t)/t, 2))/t/t;
        if (z > 1) return 1 - 2 / Sqrt(PI) * integrator.integrate(f2, 0, 1, acc, eps);
        else throw new Exception($"The argument for the error function is false. Argument: {z}");
    }
}