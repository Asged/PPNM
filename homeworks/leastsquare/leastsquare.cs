using System;

public static class leastsquare{
    static vector lsfit (Func<double, double>[] fs, vector x, vector y, vector dy){
        int n = x.size, m = fs.Length;
        var A = new matrix(n,m);
        var b = new vector(n);
        for(int i=0;i<m;i++){
            b[i] = y[i]/dy[i];
            for(int k=0;k<m;k++)A[i,k]= fs[k] (x[i])/dy[i] ;
        }
        
        //QRSG for construced A matrix
        QRGS QR_A = QRGS.solve(A);
        vector c = QR_A.solve(b);

        return (c);
    }
}