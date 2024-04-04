class main{
	static void Main(){
		matrix identity4 = new matrix(4);
		for (int i = 0; i<4;i++) identity4[i,i] = 1;
		//Generates random matrix A
		//int n = 5;
		//int m = 4;
		matrix A = new matrix(5,4);
		var rnd = new System.Random(1);
		for (int n = 0; n < A.size1;n++){
			for (int m = 0; m < A.size2; m++){
				A[n,m] = rnd.NextDouble();
			}
		}
		A.print("Matrix A");

		//QRGS Demoposition
		(matrix Q, matrix R) = QRGS.decomp(A);
		Q.print("Matrix Q");
		R.print("Matrix R");

		//Checks Q_transpose * Q = I
		matrix I = Q.transpose() * Q;
		I.print("Matrix I");
		System.Console.WriteLine($"{(I).approx(identity4)}");

		matrix QR = Q * R;
		QR.print("Matrix QR");
		System.Console.WriteLine($"A=QR: {A.approx(QR)}");
		matrix identity5 = new matrix(5);
		for (int i = 0; i<5;i++) identity5[i,i] = 1;
		//Random square matrix and vector
		matrix squareA = new matrix(5,5);
		squareA.print("Square A matrix");
		vector b = new vector(5);
		for (int i = 0; i<squareA.size1; i++){
			for (int j = 0; j<squareA.size2; j++){
				squareA[i,j] = rnd.NextDouble();
			}
		}		
		for (int i = 0; i<b.size; i++){
			b[i] = rnd.NextDouble();
		}
		squareA.print("Square A matrix");
		b.print("b Vector");

		//QR-decomposition
		(matrix squareQ, matrix squareR) = QRGS.decomp(squareA);
		squareQ.print("Square Q matrix");
		squareR.print("Square R matrix");

		//Solve for x
		vector x = QRGS.solve(squareQ,squareR,b);
		vector Ax = squareA*x;
		Ax.print("Ax");
		System.Console.WriteLine($"{Ax.approx(b)}");

		//Square matrix from before is reused
		matrix inverseA = QRGS.inverse(squareA);
		inverseA.print("Inverse of square A");
		matrix squinvA = squareA*inverseA;
		squinvA.print("A*A^-1");
		System.Console.WriteLine($"{(squareA*inverseA).approx(identity5)}");
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
