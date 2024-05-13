using System.Linq;
public class main{
    public static void Main(string[] args){
        int N = 0;
        foreach(string arg in args){
            var words = arg.Split(':');
            if(words[0]=="-nterms")N=(int)double.Parse(words[1]);
        }
        
        var sum = new System.Threading.ThreadLocal<double>( ()=>0, trackAllValues:true);
        System.Threading.Tasks.Parallel.For( 1, N+1, (int i)=>sum.Value+=1.0/i );
        double totalsum=sum.Values.Sum();
        System.Console.WriteLine($"Total sum: {totalsum}");
        System.Console.WriteLine($"Number of iterations: {N}");
        System.Console.WriteLine("This method for parallel processing seems to be about as fast as the original when it runs with higher threads, this is due to there being no race condition as opposed to the second attempt at parallel processing");
    }
}