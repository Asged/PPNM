class main{
    static void Main(){
        //Testing with timesJ and JTimes with non random matrices
        matrix A = new matrix(5,5);
        var rnd = new System.Random(1);

        for(int i = 0; i < A.size1; i++){
            for(int j = i; j < A.size1; j++){
                A[i,j] = rnd.NextDouble(); // Upper triangular matrix is created
                A[j,i] = A[i,j]; // Upper triangular part is copied to lower part
            }
        }
        A.print();
        jacobi.timesJ(A,0,1,System.Math.PI/4);
        jacobi.Jtimes(A,0,1,System.Math.PI/4);
        A.print(); // J^T(A)J

        //jacobi.cyclic(A);
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
public static (vector,matrix) cyclic(matrix M){
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
	return (w,V);
	}
}
