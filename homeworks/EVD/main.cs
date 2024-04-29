class main{
    static void Main(string[] args){
        int rmax = 0;
        double dr = 0.0;

        foreach(string arg in args){ //Parsing rmax and dr to numbers
            string[] values = arg.Split(':');
                string key = values[0];
                string value = values[1];
                System.Console.WriteLine(key);
                System.Console.WriteLine(value);
                if(key=="-rmax"){
                    int.TryParse(value, out int rmaxVal);
                    rmax = rmaxVal;
                    System.Console.WriteLine(rmaxVal);
                }

                else if(key=="-dr"){
                    double.TryParse(value, out double drVal);
                    dr = drVal;
                    System.Console.WriteLine(drVal);
                }   
            
        }
        System.Console.WriteLine($"rmax: {rmax}, dr: {dr}");
        
        
        //Testing with timesJ and JTimes with non random matrices
        matrix A = new matrix(5,5);
        var rnd = new System.Random(1);

        for(int i = 0; i < A.size1; i++){
            for(int j = i; j < A.size1; j++){
                A[i,j] = rnd.NextDouble(); // Upper triangular matrix is created
                A[j,i] = A[i,j]; // Upper triangular part is copied to lower part
            }
        }
        System.Console.Write("Random matrix A");
        A.print();

        vector w;
        matrix V;
        matrix D;
        (w,D,V) = jacobi.cyclic(A);
        
        System.Console.Write("Matrix V consisting of eigenvectors");
        V.print();
        System.Console.WriteLine();

        System.Console.WriteLine("Vector w consisting of eigenvalues");
        w.print();

        System.Console.WriteLine("Diagonal Matrix D");
        D.print();
        System.Console.WriteLine("");

        System.Console.WriteLine("Does V_transpose*A*V=D");
        System.Console.WriteLine((V.transpose()*A*V).approx(D)); //Output is true
        System.Console.WriteLine("");

        System.Console.WriteLine("Does V*D*V_transpose=A");
        System.Console.WriteLine((V*D*V.transpose()).approx(A)); //Output is true
        System.Console.WriteLine("");

        matrix id = matrix.id(5);
        System.Console.WriteLine("Does V*V_transpose=IdMatrix");
        System.Console.WriteLine((V*V.transpose()).approx(id)); //Output is true
        System.Console.WriteLine("");

        System.Console.WriteLine("Does V_transpose*V=IdMatrix");
        System.Console.WriteLine((V.transpose()*V).approx(id)); //Output is true

        /*
        //Part B
        //Building  Hamiltonian  matrix
        int npoints = (int)(rmax/dr)-1;
        vector r = new vector(npoints); //Initializing vector and matrix
        matrix H = new matrix(npoints,npoints);
        for(int i=0;i<npoints;i++){ //Populating r
            r[i]=dr*(i+1);
        }
        
        for(int i=0;i<npoints-1;i++){ //Populating H
            H[i,i]  =-2*(-0.5/dr/dr);
            H[i,i+1]= 1*(-0.5/dr/dr);
            H[i+1,i]= 1*(-0.5/dr/dr);
        }

        H[npoints-1,npoints-1]=-2*(-0.5/dr/dr);
        for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
        H.print();
        System.Console.WriteLine(H[0,0]);

        //Diagonalizing H
        matrix VH;
        vector wH;
        (wH,VH) = jacobi.cyclic(H);
        matrix HD = VH.transpose()*H*VH;
        HD.print();
        */
    }
}

public static class jacobi{

public static void timesJ(matrix A, int p, int q, double theta){
    double c = System.Math.Cos(theta);
    double s = System.Math.Sin(theta);
    for(int i = 0; i<A.size1; i++){
        double aip = A[i,p];
        double aiq = A[i,q];
        A[i,p] = c*aip - s*aiq; 
        A[i,q] = s*aip + c*aiq; 
    }
    }
public static void Jtimes(matrix A, int p, int q, double theta){
    double c = System.Math.Cos(theta);
    double s = System.Math.Sin(theta);
    for(int j = 0; j<A.size1; j++){
        double apj = A[p,j];
        double aqj = A[q,j];
        A[p,j] = c*apj + s*aqj;
        A[q,j] = -s*apj + c*aqj; 
    }
    }
public static (vector,matrix, matrix) cyclic(matrix M){
	matrix A=M.copy();
	matrix V=matrix.id(M.size1);
	vector w=new vector(M.size1);
    int n = M.size1;
	bool changed;
    do{
	changed=false;
    const double epsilon = 1e-6;
	for(int p=0;p<n-1;p++){
	    for(int q=p+1;q<n;q++){
		    double apq=A[p,q], app=A[p,p], aqq=A[q,q];
		    double theta=0.5*System.Math.Atan2(2*apq,aqq-app); // Finding theta
		    double c=System.Math.Cos(theta),s=System.Math.Sin(theta); //Cos and Sin of theta
		    double new_app=c*c*app-2*s*c*apq+s*s*aqq; //A'_pp
		    double new_aqq=s*s*app+2*s*c*apq+c*c*aqq; //A'_qq
		    if (System.Math.Abs(new_app - app) > epsilon || System.Math.Abs(new_aqq - aqq) > epsilon) // do rotation
			    {
			    changed=true;
			    timesJ(A,p,q, theta); // A←A*J 
			    Jtimes(A,p,q,-theta); // A←JT*A 
			    timesJ(V,p,q, theta); // V←V*J
			    }
            
	    }
    }
    }while(changed);
    for (int i = 0; i<n;i++) w[i] = A[i,i]; //copies eigenvalues to vector w
	return (w,A,V); //w=vector with eigenvalues, A=matrix with only diagonal elements, V=matrix with eigenvectors
	}
}
