public class splines{
    public static double linterp(double[] x, double[] y, double z){
        int i=binsearch(x,z);
        double dx=x[i+1]-x[i]; if(!(dx>0)) throw new System.Exception("uups...");
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
    }

    public static int binsearch(double[] x, double z)
	{/* locates the interval for z by bisection */ 
	    if( z<x[0] || z>x[x.Length-1] ) throw new System.Exception("binsearch: bad z");
	    int i=0, j=x.Length-1;
	    while(j-i>1){
		    int mid=(i+j)/2;
		    if(z>x[mid]) i=mid; else j=mid;
		}
	    return i;
	}

    public double linterpInteg(double[] x, double[] y, double z){
        int k = binsearch(x,z);
        double integral = 0;
        int i = 0;
        while(i < k
        ){
            double cont = y[i] * (x[i+1] - x[i]) + (y[i+1] - y[i])/(x[i+1] - x[i]) * System.Math.Pow(x[i+1] - x[i], 2)/2;
            integral += cont;
            i++;
        }
        double restIntegral = y[i]*(z-x[i])+(y[i+1]-y[i])/(z-x[i])*System.Math.Pow((z-x[i]),2)/2;
        integral += restIntegral;
        return integral;
    }
}//splines