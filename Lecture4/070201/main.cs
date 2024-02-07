using System;
using static System.Console;

class main {
	static int Main(string[] args) {
		double x = 2, y=1;
		if (x>y){
			Write("x>y\n");
		}
		/*
		else {
			Write("y<=x\n");
		}
		int i;
		for(i=1; i<10;++i)Write($"i={i}");
		i=0;
		do{Write($"i={i}"); i++;} while(i<10);
		i=0;
		while(i<10) {Write($"i={i}"); i++;}
		*/

		int n = 5;
		double[] a = new double[n];
		for (int i=0;i<n;i++)a[i]=i+1;
		for (int i=0;i<n;i++)Write($"a[{i}]={a[i]}\n");
		foreach(var ai in a)Write($"ai={ai}\n");
		foreach(var arg in args)Write($"arg={arg}\n");
		return 0;
	}//main
}//class main
