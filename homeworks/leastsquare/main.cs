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

        
        x.print("Vector x:");
        y.print("Vector y:");
        dy.print("Vector dy:");
        for(int i=0; i<noOfDataPoints;i++){
            y[i] = Math.Log(y[i]);
            dy[i] /= y[i];
        }

        var fs = new Func<double,double>[] {z => 1.0, z => -z};
        leastsquares ls = new leastsquares();
        vector res = ls.lsfit(fs, x, y, dy);
        System.Console.WriteLine(res);
    }
}