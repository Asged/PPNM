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
		System.Console.Write($"a==b ? {a==b}\n");
		System.Console.Write($"a>1 ? {a>1}\n");
		System.Console.Write($"b>1 ? {b>1}\n");
		System.Console.WriteLine(tiny);
		System.Console.WriteLine(a);
		System.Console.WriteLine(b);
		return 0;
	}
}
