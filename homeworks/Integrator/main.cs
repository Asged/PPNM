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

        int i = 0;
        double res = integrator.integrate(func, a, b, ref i);
        Console.WriteLine($"The integral of sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-2.0/3.0)<=acc && Abs((res - (2.0/3.0)) / (2.0/3.0)) <= eps}");

        
        //4Sqrt(1-x^2)
        i = 0;
        func = x => 4*Sqrt(1-x*x);
        res = integrator.integrate(func, a, b, ref i);
        Console.WriteLine($"The integral of 4Sqrt(1-x^2) from {a} to {b} is: {res}, within accuracy: {Abs(res-PI)<=acc && Abs((res - (PI)) / (PI)) <= eps}");

        var errorfile = new System.IO.StreamWriter("Errorfunc.txt", append: true);
        for(double x = -5; x<=5; x+=0.001) errorfile.WriteLine($"{x} {Errorfunc(x)}");
        errorfile.Close();

        //1/sqrt(x)
        i = 0;
        func = x => 1/Sqrt(x);
        res = integrator.integrate(func, a, b, ref i);
        Console.WriteLine($"The integral of 1/sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-2)<=acc && Abs((res - (2.0)) / (2.0)) <= eps}, number of evaluations: {i}");

        i = 0;
        func = x => 1/Sqrt(x);
        res = integrator.clenshawintegrate(func, a, b, ref i);
        Console.WriteLine($"The integral of 1/Sqrt(x) using clenshaw from {a} to {b} is: {res}, within accuracy: {Abs(res-(2))<=acc && Abs((res - (2)) / (2)) <= eps}, number of integrand evaluations: {i}");
        Console.WriteLine("Evaluations from scpiy.integrate.quad: 231");

        //ln(x)/sqrt(x)
        i = 0;
        func = x => Log(x)/Sqrt(x);
        res = integrator.integrate(func, a, b, ref i);
        Console.WriteLine($"The integral of ln(x)/sqrt(x) from {a} to {b} is: {res}, within accuracy: {Abs(res-(-4))<=acc && Abs((res - (-4)) / (-4)) <= eps}, number of evaluations: {i}");

        i = 0;
        func = x => Log(x)/Sqrt(x);
        res = integrator.clenshawintegrate(func, a, b, ref i);
        Console.WriteLine($"The integral of ln(x)/sqrt(x) using clenshaw from {a} to {b} is: {res}, within accuracy: {Abs(res-(-4))<=acc && Abs((res - (-4)) / (-4)) <= eps}, number of integrand evaluations: {i}");
        Console.WriteLine("Evaluations from scpiy.integrate.quad: 315");
        Console.WriteLine("Normal integration routine is slower than python but the clenshaw implementation is faster than python");
    }

    public static double Errorfunc(double z, double acc = 0.001, double eps = 0.001)
    {
        if (z < 0) return -Errorfunc(-z);
        int i = 0;
        Func<double, double> f1 = t => Exp(-Pow(t, 2));
        if (z <= 1 && z <= 1) return 2 / Sqrt(PI) * integrator.integrate(f1, 0, z, ref i, acc, eps);
        i = 0;
        Func<double, double> f2 = t => Exp(-Pow(z + (1 - t)/t, 2))/t/t;
        if (z > 1) return 1 - 2 / Sqrt(PI) * integrator.integrate(f2, 0, 1, ref i, acc, eps);
        else throw new Exception($"The argument for the error function is false. Argument: {z}");
    }
}