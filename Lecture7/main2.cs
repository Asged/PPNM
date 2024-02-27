class main{
        public static int Main(){
                for(double x=-5; x<=5;x+=1.0/128){
                        System.Console.WriteLine($"{x} {sfuns.gamma(x)}");
                }//func
                return 0;
        }//main method
}//main class   

