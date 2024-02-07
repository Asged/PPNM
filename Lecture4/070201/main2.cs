using System;
using static System.Console;

public class my_class { public string s; }
public struct my_struct { public string s; }

class main{
	//static void set_to_7(ref double tmp){tmp=7;}
	static void set_to_7(double tmp){tmp=7;}
	static void set_to_7(double[] tmp){for(int i=0;i<tmp.Length;i++)tmp[i]=7;}
	static int Main(){
		my_class A = new my_class();
		my_struct a = new my_struct();
		A.s = "hello";
		a.s = "hello";
		WriteLine($"A.s={A.s}");
		WriteLine($"a.s={A.s}");

		my_class B = A;
		my_struct b = a;
		WriteLine($"A.s={B.s}");
                WriteLine($"a.s={b.s}");

		B.s = "new string";
		b.s = "new string";

		WriteLine($"A.s={A.s}");
                WriteLine($"a.s={a.s}");

		double x=1;
		//set_to_7(ref x);
		set_to_7(x);
		Write($"x={x}\n");

		double[] v = new double[5];
		set_to_7(v);
		foreach(var vi in v)Write(vi);
		Write("\n");
		
		return 0;
	}
}
