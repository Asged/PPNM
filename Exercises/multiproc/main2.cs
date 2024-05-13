public class main{
    public static void Main(string[] args){
        int N = 0;
        foreach(string arg in args){
            var words = arg.Split(':');
            if(words[0]=="-nterms")N=(int)double.Parse(words[1]);
        }
        
        double sum=0;
        System.Threading.Tasks.Parallel.For( 1, N+1, (int i) => sum+=1.0/i );
        System.Console.WriteLine($"Total sum{sum}");
        System.Console.WriteLine($"Number of iterations: {N}");
        System.Console.WriteLine("This process is slower, this is due to a race condition arising when initializing \"double sum=0;\" herefrom the threads will all have access to the same sum variable and might cancel each others operations");
    }
}