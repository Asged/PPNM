public class main{
    public static void Main(){   
        matrix A = new matrix(3,3);
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

        vector x0 = new vector(3);
        x0[0] = 1;
        x0[1] = 1;
        x0[2] = 1;
        x0.print("x0");

        double s = 100;
        (double eigenvalue, vector eigenvector) = IIAE.inverse_iteration(A, s, x0);
        System.Console.WriteLine($"Eigenvalue from inverse iteration: {eigenvalue}");
        eigenvector.print("Eigenvector from inverse iteration: ");
        
    }
}