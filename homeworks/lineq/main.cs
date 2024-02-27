class main{
	static void Main(){
		vector ve;
		ve=new vector(n:1); ve.print("ve=");
		ve=new vector(1,2,3); ve.print("ve=");
		ve=new vector(7,8,9,8,7); ve.print("ve=");
		var ma=new matrix("1 2 ; 5 6");
		ma.print();
		(ma+ma.T).print();
		(matrix.id(2)).print();
	}
}

public static class QRGS{
	public static (matrix,matrix) decomp (matrix A){
		matrix Q = A.copy(); //creates a copy of A and saves in Q, useful since the colums of q_i = a_i / norm of a_i
		matrix R = new matrix(A.size2,A.size2); //create a new square matrix
		for(int i = 0; i < A.size2; i++){ //definitions of R_ii, q_i, R_ij and a_j are in page 3 of "lineq.pdf"
			R[i,i] = Q[i].norm(); //Using R_ii definition to generate diagonal entry
			Q[i] /= R[i,i]; //Using q_i definition
			for(int j = i + 1; j<A.size2; j++){
				R[i,j] = Q[i].dot(Q[j]); //Using R_ij definition to generate row
				Q[j] -= Q[i] * R[i,j];  //Using a_j definition
			}
		}
		return (Q,R);
	}//decomp
	public static vector solve(matrix Q, matrix R, vector b){
		n = Q.size1; //no. of rows
		vector x = new vector(n); //vector x
			for(int i = n - 1; i >= 0; i--){ //loop for backwards substitution starting at bottom row
			
			}

		return null;	
	}//solve
	public static double det(){
		return 0;
	}//det
	public static matrix inverse(){
		return null;
	}//inverse
}//QRGS
