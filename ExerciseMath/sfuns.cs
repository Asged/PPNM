using System;
	static class sfuns{
		static double gamma(double x){
        	        ///single precision gamma function (formula from Wikipedia)
                	if(x<0)return Math.PI/Math.Sin(Math.PI*x)/gamma(1-x); // Euler's reflection formula
                	if(x<9)return gamma(x+1)/x; // Recurrence relation
                	double lngamma=x*Math.Log(x+1/(12*x-1/x/10))-x+Math.Log(2*Math.PI/x)/2;
                	return Math.Exp(lngamma);
        }
}
