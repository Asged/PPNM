using System.IO;
class main {
    static void Main() {
        double[] x = new double[10];
        double[] y = new double[10];
        splines splines = new splines();
        for (int i = 0; i < 10; i++) {
            x[i] = i;
            y[i] = System.Math.Cos(i);
        }
        using (StreamWriter writer = new StreamWriter("dataPoints.txt"))
        {
            for (int i = 0; i < x.Length; i++)
            {
                writer.WriteLine($"{x[i]}\t{y[i]}");
            }
        }

        var interpolated_data = new StreamWriter("interpolated.txt");
        for (double z = x[0]; z < x[x.Length-1]; z+=0.01) {    
            interpolated_data.WriteLine($"{z}\t{splines.linterp(x,y,z)}\t{splines.linterpInteg(x,y,z)}");
        }
    }
    
}