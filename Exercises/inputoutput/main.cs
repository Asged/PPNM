static class main{
	public static void Main(string[] args){
		char[] split_delimiters = {' ', '\t', '\n'};
		var split_options = System.StringSplitOptions.RemoveEmptyEntries;
		for(string line = System.Console.ReadLine(); line !=null; line = System.Console.ReadLine()){
			var numbers = line.Split(split_delimiters,split_options);
			foreach(var number in numbers){
				double x = double.Parse(number);
				System.Console.WriteLine($"x={x}, Sin(x)={System.Math.Sin(x)}, Cos(x)={System.Math.Cos(x)}");
			}
		}			
	}//Main
}//main
