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
        double step = 0.0001;
        int nPoints = (int)((x[x.Length - 1] - x[0]) / step) + 1;
        double[] z = new double[nPoints];
        double[] interpolatedValues = new double[nPoints];
        double[] integralValues = new double[nPoints];
        for (int i = 0; i < nPoints; i++) {
            z[i] = x[0] + i * step;
            interpolatedValues[i] = splines.linterp(x, y, z[i]);
            integralValues[i] = splines.linterpInteg(x, y, z[i]);
        }
        
        using (StreamWriter writer = new StreamWriter("linData.txt"))
        {
            writer.WriteLine("z\tInterpolated\tIntegral");
            for (int i = 0; i < nPoints; i++)
            {
                writer.WriteLine($"{z[i]}\t{interpolatedValues[i]}\t{integralValues[i]}");
            }
        }
    }
    
}