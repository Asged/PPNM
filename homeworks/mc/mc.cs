using System;
using static System.Math;
public static class mc{
    public static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
        int dim=a.size; double V=1; for(int i=0;i<dim;i++)V*=b[i]-a[i]; double sum=0,sum2=0; var x=new vector(dim); var rnd=new Random();
        for(int i=0;i<N;i++){
                for(int k=0;k<dim;k++)x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
                double fx=f(x); sum+=fx; sum2+=fx*fx;
                }
        double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
        var result=(mean*V,sigma*V/Sqrt(N));
        return result;
    }

    public static double corput(int n, int b){
        double q=0; double bk=1/b;
        while(n>0) {
           q+=(n%b) * bk;
           n /= b;
           bk /= b;
        }
        return q;
    }

    public static void halton(int n, int d, vector x){
        int[] baseValues = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 };
        int maxd = baseValues.Length;
        if(baseValues.Length >= d) for (int i = 0; i < d; i++) x[i] = corput(n, baseValues[i]);
    }

    public static (double,double) haltonInt(Func<vector,double> f, vector a, vector b, int N) {
    int dim = a.size;
    double V = 1;
    for (int i = 0; i < dim; i++)
        V *= b[i] - a[i];
    double sum = 0, sum2 = 0;
    vector x = new vector(dim);
    vector x2 = new vector(dim);

    for (int i = 0; i < N; i++) {
        halton(i + 1, dim, x); // Generate Halton sequence point into x

        // Scale Halton sequence to the interval [a[k], b[k]]
        for (int k = 0; k < dim; k++)
            x[k] = a[k] + x[k] * (b[k] - a[k]);

        double fx = f(x);
        sum += fx;
        sum2 += fx * fx;
    }

    double mean = sum / N, sigma = Math.Sqrt(sum2 / N - mean * mean);
    var result = (mean * V, sigma * V / Math.Sqrt(N));
    return result;
}
}