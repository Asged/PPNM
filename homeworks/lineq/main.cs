class main{
	static void Main(){
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

		matrix QR = Q * R;
		QR.print("Matrix QR");
		System.Console.WriteLine($"A=QR: {A.approx(QR)}");

		//Generate random vector b, A is reused
		vector b = new vector(5);
		for (int m = 0; m < b.size; m++) b[m] = rnd.NextDouble();
		b.print("Vector b");

		//Solving for x vector, reusing QR from above
		vector x = QRGS.solve(Q,R,b);
		x.print("Vector x");

		//Checking x is correct
		vector b1 = A*x;
		System.Console.WriteLine($"Ax=b: {b1.approx(b)}");
		b.print("b");
		b1.print("Ax");
		vector QRx = QR*x;
		QRx.print("QRx");
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
	public static vector solve(matrix Q, matrix R, vector b){ //Solve for vector x
		int n = Q.size2; //no. of rows
		vector x = new vector(n); //vector x
			for(int i = n - 1; i >= 0; i--){ //loop for backwards substitution starting at bottom row
				double sum = 0;
				for(int j = i+1; j<n;j++){
					sum += x[j] * R[i, j];
				}
				x[i] = (b[i] - sum) / R[i, i];
			}

		return x;
	}//solve
	public static double det(matrix R){ //Solves determinant for R matrix
		double determinant = 1.0; 
		for (int i = 0; i<R.size1; i++){
			determinant *= R[i,i];
		}
		return determinant;
	}//det
	public static matrix inverse(){
		return null;
	}//inverse
}//QRGS
