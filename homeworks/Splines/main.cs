class main{
    static void Main(){

    }//Main
}//main

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

    double linterpInteg(double[] x, double[] y, double z){
        int i=binsearch(x,z);
        double dx=x[i+1]-x[i]; 
        if(!(dx>0)) throw new System.Exception("uups..."); //x is only increasing
        double dy=y[i+1]-y[i];
        return y[i]*(z-x[i])+dy/dx*System.Math.Pow(z-x[i], 2)/2;
    }

    
}//splines