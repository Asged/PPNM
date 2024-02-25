public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i];
	public genlist(){data = new T[0];}
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data, newdata,size);
		newdata[size]=item;
		data=newdata;
	}
}//genlist

static class main{
	public static void Main(){
		var list = new genlist<double[]>();
		char[] delimiters = {' ',',','\t'};
		var options = System.StringSplitOptions.RemoveEmptyEntries;
		for(string line=System.Console.ReadLine();line!=null;line = System.Console.ReadLine()){
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
			list.add(numbers);
		}
		for(int i=0;i<list.size;i++){
			var numbers = list[i];
			foreach(var number in numbers) System.Console.WriteLine($"{number : 0.00e+00;-0.00e+00}");
		}

	}
}//main
