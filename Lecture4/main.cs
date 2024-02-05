using System;
using static System.Console;

class main {
	static int Main(){
		int i=1;
		while(i+1>i){
			i++;
		}
		Write("my max int = {0}\n",i);
		
		 while(i-1<i){
                        i++;
                }
                Write("my min int = {0}\n",i);
		
		double x=1; 
		while(1+x!=1){
			x/=2;
		} 
		x*=2;		
		Write("smallest epsilon using double {0}\n", x);
		
		float y=1F; 
		while((float)(1F+y) != 1F){
			y/=2F;
		} 
		y*=2F;
		 Write("smallest epsilon using float {0}\n", y);
		return 0;
	}
}
