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
	
	public static vector solve(matrix Q, matrix R, vector b){ //Solve for vector x using Rx = Q_transposed*b
		int n = Q.size1;
		vector QTb = Q.transpose() * b;  // Q_transposed * b
		for(int i = n-1; i>=0;i--){
			double sum = 0;
			for(int j = i+1; j<n; j++){
				sum += R[i,j] * QTb[j];
			}
			QTb[i] = (QTb[i] - sum)/R[i,i];
		}

		
		return QTb;
	}//solve

	public static double det(matrix R){ //Solves determinant for R matrix
		double determinant = 1.0; 
		for (int i = 0; i<R.size1; i++){
			determinant *= R[i,i];
		}
		return determinant;
	}//det

	public static matrix inverse(matrix A){
		int n = A.size1;
		matrix inverseA = new matrix(n,n);
		for(int i = 0; i<n;i++){
			vector e = new vector(n);
			for (int j = 0;j<n;j++) if(i==j) e[i]=1; else e[j]=0; //Creates unit vectors
			(matrix Q, matrix R) = decomp(A);
			inverseA[i] = solve(Q,R,e);
		}
		return inverseA;
	}//inverse
}//QRGS