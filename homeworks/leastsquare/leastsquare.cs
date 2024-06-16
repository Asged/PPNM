using System;

public static class leastsquares{
    static vector lsfit (Func<double, double>[] fs, vector x, vector y, vector dy){
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
        
        //QR decomposition
        (matrix Q, matrix R) = QRGS.decomp(A);
        vector c = QRGS.solve(Q, R, b);

        return c;
    }
}