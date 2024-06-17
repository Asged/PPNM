using System;

public class leastsquares{
    public vector lsfit (Func<double, double>[] fs, vector x, vector y, vector dy){
        int n = x.size, m = fs.Length;
        matrix A = new matrix(n,m);
        vector b = new vector(n);

        for(int i=0;i<n;i++)
        {
            b[i] = y[i]/dy[i];
            for(int k=0;k<m;k++)
                {
                    A[i,k]= fs[k] (x[i])/dy[i];
                }
        }
        
        Console.WriteLine(A.size1);
        Console.WriteLine(A.size2);
        Console.WriteLine(b.size);
        A.print("A");
        b.print("b");

        (matrix Q, matrix R) = QRGS.decomp(A);
        Q.print("Q");
        R.print("R");
        vector c = QRGS.solve(Q, R, b);
        c.print();

        return null;
    }
}