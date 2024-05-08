class main{
    static void Main(string[] args){
        int rmax = 0;
        double dr = 0.0;
        foreach(string arg in args){ //Parsing rmax and dr to numbers
            string[] values = arg.Split(':');
                string key = values[0];
                string value = values[1];
                if(key=="-rmax"){
                    int.TryParse(value, out int rmaxVal);
                    rmax = rmaxVal;
                }

                else if(key=="-dr"){
                    double.TryParse(value, out double drVal);
                    dr = drVal;
                }   
            
        }
        System.Console.WriteLine($"rmax: {rmax}, dr: {dr}");
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
        vector wH; //Vector with eigenvalues
        matrix DH; //Diagonalized H
        matrix VH; //Matrix with eigenvectors for H
        (wH,DH,VH) = jacobi.cyclic(H);
        DH.print();
        
        //Writing calculations to txt files
        var outfile = "";
        outfile.WriteLine($"{x}");
        outfile.Close(); /* do not forget this! */
    }
}