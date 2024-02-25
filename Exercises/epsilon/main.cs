class main{
	static int Main(){
		int i=1;
		//For max int
		while(i+1>i){i++;}
		System.Console.Write($"Max int = {i}\n");
		System.Console.Write($"int.MaxValue = {int.MaxValue}\n");
		//For min int
		while(i-1<i){i--;}
                System.Console.Write($"Min int = {i}\n");
                System.Console.Write($"int.MinValue = {int.MinValue}\n");
		//double machine epsilon
		double x = 1;
		while(x+1!=1){x/=2;}
		x*=2;
		System.Console.Write($"double machine epsilon = {x}\n");
		//float machine epsilon
		float y = 1F;
		while( (float) (1F+y) != 1F){y/=2;}
		y*=2;
		System.Console.Write($"float machine epsilon = {y}\n");
		//tiny-exercise
		double epsilon=System.Math.Pow(2,-52);
		double tiny=epsilon/2;
		double a=1+tiny+tiny;
		double b=tiny+tiny+1;
		System.Console.Write($"a==b ? {a==b}\n result is due to floating point arithmetic, a=1+tiny=1, and when tiny is added again it is rounded down again, b=1+epsiloilonn, since tiny+tiny is representable as epsilon\n");
		System.Console.Write($"a>1 ? {a>1}\n result is due to arithmetic again, a is equal to exactly 1 here\n");
		System.Console.Write($"b>1 ? {b>1}\n floating point arithmetic, here b=1+epsilon\n"); //Produces true, b has value tiny+tiny
		//Comparing doubles introduction
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;
		System.Console.WriteLine($"d1={d1:e15}");
		System.Console.WriteLine($"d2={d2:e15}");
		System.Console.WriteLine($"d1==d2 ? => {d1==d2}");		
		//Comparing doubles
		System.Console.WriteLine($"d1==d2 ? => {approx(d1,d2)}, using approx function here");
		return 0;
	}//Main
	
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(System.Math.Abs(b-a) <= acc) return true;
		return false;
	}//approx
}//main
