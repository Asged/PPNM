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
    }
}