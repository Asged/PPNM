using System;
using System.IO;

public class main{
    static void Main(){
        System.Console.WriteLine("QR for tall matrix");
        matrix A = new matrix(50,5);
        var rand = new Random();
        for (int i = 0; i<50; i++) for (int j = 0; j < 5; j++) {
            A[i, j] = rand.NextDouble();
        }
        A.print("tall matrix A");
        (matrix Q, matrix R) = QRGS.decomp(A);
        R.print("Matrix R");
        System.Console.WriteLine($"Q^T*Q = 1 is tested {(Q.transpose()*Q).approx(matrix.id(5))}");
        System.Console.WriteLine($"QR = A is tested {(Q*R).approx(A)}");
        
        int noOfDataPoints = 9;
        vector x = new vector(noOfDataPoints);
        vector y = new vector(noOfDataPoints);
        vector dy = new vector(noOfDataPoints);
        string filename = "radData.txt";
        string[] lines = File.ReadAllLines(filename);

        for(int i=0; i<noOfDataPoints; i++){
            string[] parts = lines[i].Split(' ');
            x[i] = int.Parse(parts[0]);
            y[i] = double.Parse(parts[1]);
            dy[i] = int.Parse(parts[2]);
        }

        for(int i=0; i<noOfDataPoints;i++){
            y[i] = Math.Log(y[i]);
            dy[i] /= y[i];
        }

        var fs = new Func<double,double>[] {z => 1.0, z => -z};
        leastsquares ls = new leastsquares();
        (vector res, matrix cov) = ls.lsfit(fs, x, y, dy);
        double halflife = Math.Log(2) / res[1];
        System.Console.WriteLine($"Half life is: {halflife}, Wikipedia table tells us it is 3.63 days");
        cov.print("Covariance matrix");

        double uncer1 = Math.Sqrt(cov[0,0]);
        double uncer2 = Math.Sqrt(cov[1,1]);
        System.Console.WriteLine($"Fitting parameters uncertainties: {uncer1}, {uncer2}");
        double halflifeuncer = System.Math.Log(2)*uncer2 / res[1];
        System.Console.WriteLine($"Uncertainty in halflife is: {halflifeuncer}, this means that it does not agree with modern results");

    
    }
}