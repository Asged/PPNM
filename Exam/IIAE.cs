
public class IIAE{
    public static (double, vector) inverse_iteration(matrix A, double s, vector x0=null, double acc = 1e-6)
{
    int n = A.size1;
    var rnd = new System.Random();

    if (x0 == null)
    {
        x0 = new vector(n);
        for (int i = 0; i < n; i++)
        {
            x0[i] = rnd.NextDouble();
        }
    }

    vector x1 = x0;
    double lambda0 = s;
    double lambda1 = s;
    int it = 0;
    System.Console.WriteLine(x0.dot(x0));
    do
    {
        x0 = x1;
        (matrix Q, matrix R) = QRGS.decomp(A - lambda1 * matrix.id(n));
        x1 = QRGS.solve(Q, R, x0);

        double x1_norm = 0;
        for(int i = 0; i<n;i++) x1_norm += System.Math.Pow(x1[i],2); // Normalize x1
        x1_norm = System.Math.Sqrt(x1_norm);

        x1 = x1 / x1_norm; //x1 = x1 / System.Math.Sqrt(System.Math.Pow(x1, 2));
        
        lambda0 = lambda1;
        lambda1 = x1.dot(A * x1) / x1.dot(x1);
        System.Console.WriteLine(x1.dot(x0));
        System.Console.WriteLine($"Current eigenvalue: {lambda1}");
        x1.print("Current eigenvector: ");
        it++; 
    } while (System.Math.Abs((lambda1 - lambda0) / lambda1) > acc && it < 1000);

    return (lambda1, x1); // Eigenvalue and associated eigenvector
}

}