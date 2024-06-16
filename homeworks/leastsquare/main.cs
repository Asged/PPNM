using System;
using System.IO;

public class main{
    static void Main(){
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
        vector res = leastsquares.lsfit(fs, x, y, dy);
        Console.WriteLine(res); 
    }
}