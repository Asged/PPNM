public class main{
    public static void Main(){   
        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("This project implements the inverse iteration algorithm to find eigenvalues and eigenvectors");
        System.Console.WriteLine("Below testing starts out with analytically solved systems, then comparing them to the results of the algorithm, also checking what happens when we use large numbers for guesses");
        System.Console.WriteLine("#####################################");

        int n = 3;
        matrix A = new matrix(n); //Analytically solved 3 by 3 matrix
        A[0,0] = 1;
        A[0,1] = 2;
        A[0,2] = 3;
        A[1,0] = 1;
        A[1,1] = 2;
        A[1,2] = 1;
        A[2,0] = 3;
        A[2,1] = 2;
        A[2,2] = 1;
        A.print("Matrix A");

        vector x0 = new vector(n);
        x0[0] = 1;
        x0[1] = 1;
        x0[2] = 1;
        

        double s = 5;
        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("The analytical solutions for this matrix are eigenvalue = 5.23606, and the eigenvector = 0.64676, 0.40045, 0.64793");
        IIAE.inverse_iteration(A, s, x0);
        
        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("Test for same matrix this time not providing an initial guess for the eigenvector instead letting implementation generate a random one");
        s = 5;
        IIAE.inverse_iteration(A, s);
        
        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("Test for same matrix this time finding a guess for the eigenvalue that makes the algorithm fail");
        s = 1e162;
        IIAE.inverse_iteration(A, s, x0);

        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("Test for same matrix this time finding a guess for the eigenvector that makes the algorithm fail");
        x0[0] = 1e160;
        x0[1] = 1e160;
        x0[2] = 1e160;
        s = 5;
        IIAE.inverse_iteration(A, s, x0);

        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("Test for same matrix this time making an eigenvector and eigenvalue guess that is far off");
        s = 1e162;
        IIAE.inverse_iteration(A, s, x0);
        System.Console.WriteLine("When very large numbers are used, however if both the guess for eigenvector and eigenvalue or large then there it still works suggesting a proportionality");
        
        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("New matrix, with real and complex solutions");
        System.Console.WriteLine("I will not dive into how it handles big numbers again. Instead here check that it finds the correct values first, then check how it handles the real part of imaginary numbers");
        System.Console.WriteLine("#####################################");
        
        n = 4;
        matrix B = new matrix(n); //Analytically solved 4 by 4 matrix
        B[0,0] = 1;
        B[0,1] = 5;
        B[0,2] = 2;
        B[0,3] = 1;
        B[1,0] = 3;
        B[1,1] = 2;
        B[1,2] = 1;
        B[1,3] = 6;
        B[2,0] = 9;
        B[2,1] = 8;
        B[2,2] = 5;
        B[2,3] = 4;
        B[3,0] = 1;
        B[3,1] = 6;
        B[3,2] = 5;
        B[3,3] = 6;
        B.print("Matrix B");

        vector x = new vector(n);
        x[0] = 1;
        x[1] = 1;
        x[2] = 1;
        x[3] = 1;
        

        s = 5;
        IIAE.inverse_iteration(B, s, x);
         
        x[0] = -0.74;
        x[1] = 0.27;
        x[2] = -1.13;
        x[3] = 1;
        s = 1.22222;
        IIAE.inverse_iteration(B, s, x);
        System.Console.WriteLine("Here i guessed the real part of the complex solutions, interestingly it finds the correct solutions for the real part, we can however still see from the number of iterations compared to the solutions from matrix A with only real solutions that the computation time increases significantly");

        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("New matrix, with complex solution containing no real part");
        System.Console.WriteLine("Here i test for how the algorithm handles no real solutions");
        System.Console.WriteLine("#####################################");
        n = 2;
        matrix IM = new matrix(n);
        IM[0,0] = 0;
        IM[0,1] = -1;
        IM[1,0] = 1;
        IM[1,1] = 0;
        IM.print("Matrix for no real solution");

        vector im = new vector(n);
        x[0] = 1;
        x[1] = 1;

        s = 1;
        IIAE.inverse_iteration(IM, s, im);
        System.Console.WriteLine("Algorithm was never supposed to handle complex solutions, the complex solutions contain no real part so it makes sense that it would fail");

        System.Console.WriteLine("#####################################");
        System.Console.WriteLine("5 new matrices, 10x10, 15x15, 20x20, 25x25, 30x30");
        System.Console.WriteLine("Here i test how the program handles large matrices");
        System.Console.WriteLine("#####################################");

        var rnd = new System.Random();
        
        System.Console.WriteLine("10x10 matrix");
        n = 10;
        matrix D10 = new matrix(n);
        for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) D10[i,j] = rnd.Next(9);
        IIAE.inverse_iteration(D10, s);

        System.Console.WriteLine("15x15 matrix");
        n = 15;
        matrix D15 = new matrix(n);
        for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) D15[i,j] = rnd.Next(9);
        IIAE.inverse_iteration(D15, s);    
        System.Console.WriteLine("The algorithm still works with large matrices in a few steps, when testing the amount of iterations where it encounters complex numbers are still high but vary in amount of iterations");
    }
}