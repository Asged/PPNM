using System;
using static System.Console;
using static System.Math;
class main{
	static double x=1.0;
	static int i;
	static string hello = $"hello, x={x}\n";	
	static double times2(double y){
		{double x=9;}
		double z=7;
		WriteLine(x);
		return y*2;
	}	
static int Main(){
	double sqrtsqrt2 = Sqrt(Sqrt(2));
	double sqrt215 = Sqrt(Pow(2, 1/5));
	double sqrtepi = Sqrt(Pow(E, PI));
	double sqrtpie = Sqrt(Pow(PI, E));

	Write($"sqrtsqrt2 = {sqrtsqrt2}\n");
	Write($"sqrt2¹/5  = {sqrt215}\n");
	Write($"sqrte^pi = {sqrtepi}\n");
	Write($"sqrtpi^e = {sqrtpie}\n");

	Write($"x={x} Sin(x)={Sin(x)}\n");
	double prod = 1;
	for (double x=1;x<10;x++){
		Write($"fgamma({x})={sfuns.fgamma(x)}\n {x-1}! = {prod}\n");
		prod*=x;
	}
	
	return 0;
}

}
