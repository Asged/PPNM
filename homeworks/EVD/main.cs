class main{
    static void Main(){
        //Testing with timesJ and JTimes with non random matrices
        matrix A = new matrix(3,3);
        A[0,0] = 1;
        A[0,1] = 2;
        A[0,2] = 3;
        A[1,0] = 4;
        A[1,1] = 5;
        A[1,2] = 6;
        A[2,0] = 7;
        A[2,1] = 8;
        A[2,2] = 9;
        A.print();

        jacobi.timesJ(A,0,1,System.Math.PI/4);
        A.print();
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
	/* run Jacobi rotations on A and update V */
	/* copy diagonal elements into w */
	return (w,V);
	}
}

public class EVD{
public vector w;
public matrix V;
public static void timesJ(matrix A, int p, int q, double theta){/*...*/}
public static void Jtimes(matrix A, int p, int q, double theta){/*...*/}
public EVD(matrix M){
	matrix A=M.copy();
	V=matrix.id(M.size1);
	w=new vector(M.size1);
	/* run Jacobi rotations on A and update V */
	/* copy diagonal elements into w */
	}
}