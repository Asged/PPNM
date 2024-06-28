using System;
public static class main{    
    static void Main(string[] args) {
        // Rosenbrock's valley function
        Func<vector, double> rosenbrock = (v) => {
            double x = v[0];
            double y = v[1];
            return Math.Pow(1 - x, 2) + 100 * Math.Pow(y - Math.Pow(x, 2), 2);
        };
        vector x0_rosenbrock = new vector(new double[] { 1.2, 1.0 });
        (vector min_rosenbrock, int steps) = minimization.newton(rosenbrock, x0_rosenbrock);
         Console.WriteLine("Rosenbrock's valley minimum: ({0}, {1}) in {2} steps", min_rosenbrock[0], min_rosenbrock[1], steps);

        // Himmelblau's function
        Func<vector, double> himmelblau = (v) => {
            double x = v[0];
            double y = v[1];
            return Math.Pow(Math.Pow(x, 2) + y - 11, 2) + Math.Pow(x + Math.Pow(y, 2) - 7, 2);
        };
        vector x0_himmelblau = new vector(new double[] { 10, 10 });
        (vector min_himmelblau, int steps2) = minimization.newton(himmelblau, x0_himmelblau);
        Console.WriteLine("Himmelblau's function minimum: ({0}, {1}) in {2} steps", min_himmelblau[0], min_himmelblau[1], steps2);
    }
}