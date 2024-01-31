using System;

class main{
	static void Main(){
		//Calculation for Square Root of 2
		double sqrt2 = Math.Sqrt(2);
		Console.WriteLine($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
		//Calculation of Gammafunction for values 1,2,3 and 10
		Console.WriteLine("\u0393(1) = " + gamma(1));
		Console.WriteLine("\u0393(2) = " + gamma(2));
		Console.WriteLine("\u0393(3) = " + gamma(3));
		Console.WriteLine("\u0393(10) = " + gamma(10));
	}
	static double gamma(double x){
		///single precision gamma function (formula from Wikipedia)
		if(x<0)return Math.PI/Math.Sin(Math.PI*x)/gamma(1-x); // Euler's reflection formula
		if(x<9)return gamma(x+1)/x; // Recurrence relation
		double lngamma=x*Math.Log(x+1/(12*x-1/x/10))-x+Math.Log(2*Math.PI/x)/2;
		return Math.Exp(lngamma);
	}
}

