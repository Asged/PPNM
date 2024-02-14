class main{

	static double a=1;
	public static System.Func<double,double> make_power(int i){
		//System.Func<double,double> f = delegate(double x){return System.Math.Pow(a,i);};
		System.Func<double,double> f = delegate(double x){return a;};
		return f;
	}

	public static int Main(){
		genlist<double> list = new genlist<double>();
		list.add(1.2);
		list.add(2.0);
		list.add(3.0);
		for(int i=0;i<list.size;i++)System.Console.WriteLine(list[i]);
		list[0]=0;
		list[1]=0;
		for(int i=0;i<list.size;i++)System.Console.WriteLine(list[i]);
		double x=10;
		System.Func<double,double> f= delegate(double tmp){return a*x;};
		a=9;
		System.Console.WriteLine($"f({x})={f(x)}");
		var flist = new genlist<System.Func<double,double>>();
		flist.add(f);
		flist.add(System.Math.Sin);
		flist.add(System.Math.Cos);
		a=1;
		var f1 = make_power(1);
		flist.add(f1);
		a=2;
		var f2 = make_power(2);
		flist.add(f2);
		a=666;
		for(int i =0;i<flist.size;i++)System.Console.WriteLine($"f({x})={flist[i](x)}");
		return 0;	
	}
}

