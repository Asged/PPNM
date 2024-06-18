using System;
using static System.Math;
public static class main{ 
    public static void Main(){
    System.Func<double, vector, vector> func = (double x, vector y) => {
    vector v = new vector(y.size);
    v[0] = y[1];
    v[1] = -y[0];
    return v;
};


        (double start, double end) interval = (0, 10);
        vector y_ode = new vector(2);
        y_ode[0] = 5;
        y_ode[1] = 0;

        var res = ODE.driver(func, interval, y_ode);
        for(int i = 0; i < res.Item1.Count; i++) {
            System.Console.WriteLine($"{res.Item1[i]} {res.Item2[i][0]}");
        }

        //Oscillator with friction

        System.Func<double, vector, vector> func_osc = (double x, vector y) => {
        vector v = new vector(y.size);
        double b = 0.25;
        double c = 5;
        v[0] = y[1];
        v[1] = -b*y[1] - c*Sin(y[0]);
        return v;
        };
        vector y_osc = new vector(2);
        y_osc[0] = PI - 0.1;
        interval = (0, 10);
        var res2 = ODE.driver(func_osc, interval, y_osc);

        for(int i = 0; i < res2.Item1.Count; i++) {
            var outfile = new System.IO.StreamWriter("osc.txt", append:true);
            outfile.WriteLine($"{res2.Item1[i]} {res2.Item2[i][0]}");
            outfile.Close();

            outfile = new System.IO.StreamWriter("osc2.txt", append:true);
            outfile.WriteLine($"{res2.Item1[i]} {res2.Item2[i][1]}");
            outfile.Close();
        }

}
}