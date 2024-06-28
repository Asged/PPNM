using System;
public static class minimization{
public static (vector, int) newton(Func<vector, double> phi, vector x, double acc = 1e-3, int maxSteps = 1000)
    {
        int stepsTaken = 0; // Initialize steps counter

        for (int step = 0; step < maxSteps; step++)
        {
            stepsTaken++; // Update steps counter

            vector gradPhi = gradient(phi, x);
            if (gradPhi.norm() < acc) break; // Job done

            matrix H = hessian(phi, x);
            (matrix Q, matrix R) = QRGS.decomp(H); // QR decomposition using QRGS class
            vector dx = QRGS.solve(Q, R, -gradPhi);

            double lambda = 1;
            double phiX = phi(x);
            bool improved = false;
            do
            {
                if (phi(x + lambda * dx) < phiX)
                {
                    improved = true;
                    break; // Good step: accept
                }
                lambda /= 2;
            } while (lambda > Math.Pow(10, -16)); // Minimum lambda for numerical stability

            if (!improved)
            {
                Console.WriteLine("Convergence failed after {0} steps", stepsTaken);
                break;
            }

            x += lambda * dx;
        }
        return (x, stepsTaken);
}

public static vector gradient(Func<vector, double> phi, vector x) {
    vector gradPhi = new vector(x.size);
    double phiX = phi(x);

    for (int i = 0; i < x.size; i++) {
        double dx = Math.Max(Math.Abs(x[i]), 1) * Math.Pow(2, -26);
        x[i] += dx;
        gradPhi[i] = (phi(x) - phiX) / dx;
        x[i] -= dx;
    }
    return gradPhi;
}

public static matrix hessian(Func<vector, double> phi, vector x) {
    matrix H = new matrix(x.size);
    vector gradPhiX = gradient(phi, x);

    for (int j = 0; j < x.size; j++) {
        double dx = Math.Max(Math.Abs(x[j]), 1) * Math.Pow(2, -13);
        x[j] += dx;
        vector dGradPhi = gradient(phi, x) - gradPhiX;
        for (int i = 0; i < x.size; i++) {
            H[i, j] = dGradPhi[i] / dx;
        }
        x[j] -= dx;
    }

    // Averaging for better numerical stability
    return (H + H.transpose()) / 2;
}}