public class main {
	public static int Main() {
        	vec v = new vec(1,2,3);
		vec u = new vec(3,2,1);
		vec neg_v = new vec(-1,-2,-3);
		vec neg_u = new vec(-3,-2,-1);

		System.Console.WriteLine($"v = {v.ToString()}");
		System.Console.WriteLine($"u = {v.ToString()}");
		System.Console.WriteLine($"neg_v = {neg_v.ToString()}");
		System.Console.WriteLine($"neg_u = {neg_u.ToString()}");
		
		//Testing of scalar operator
		vec result = v*2;
		System.Console.WriteLine($"v*2 = {result.ToString()}");

		result = v*2.5;
		System.Console.WriteLine($"v*2.5 = {result.ToString()}");

		result = v*-3;
		System.Console.WriteLine($"v*-3.0 = {result.ToString()}");
		
		result = neg_v*2;
		System.Console.WriteLine($"v*2.0 = {result.ToString()}");
		
		result = neg_v*2.5;
		System.Console.WriteLine($"v*2.5 = {result.ToString()}");
		
		result = v*2.5;
		System.Console.WriteLine($"v*-2.0 = {result.ToString()}");

		//Testing of plus operator

		
		return 0;
	}
}

