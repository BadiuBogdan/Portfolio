using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace AplicatieClusterring.Class
{
    class Distante
    {
        private double distMax = -1;

        public double DistMax { get => distMax; set => distMax = value; }

        public double[,] GetDistanceMatrix(ref double[,] normalizedData, int tipDistanta)
        {
            Stopwatch sw = new Stopwatch();

            double[,] distanceMatrix = new double[normalizedData.GetLength(0), normalizedData.GetLength(0)];
            sw.Start();

            double[] firstPoint = new double[normalizedData.GetLength(1)];
            double[] secondPoint = new double[normalizedData.GetLength(1)];
            int nrCol = normalizedData.GetLength(1);
            double tempDist = 0;
            if (tipDistanta == -1)
            {
                for (int i = 0; i < distanceMatrix.GetLength(0); i++)
                {
                    System.Buffer.BlockCopy(normalizedData, sizeof(double) * nrCol * i, firstPoint, 0, sizeof(double) * nrCol);
                    for (int j = i + 1; j < distanceMatrix.GetLength(0); j++)
                    {
                        System.Buffer.BlockCopy(normalizedData, sizeof(double) * nrCol * j, secondPoint, 0, sizeof(double) * nrCol);
                        tempDist = DistantaCosinus(firstPoint, secondPoint);
                        distanceMatrix[i, j] = tempDist;
                        distanceMatrix[j, i] = tempDist;
                        if (distMax < distanceMatrix[i, j])
                        {
                            distMax = distanceMatrix[i, j];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < normalizedData.GetLength(0); i++)
                {

                    System.Buffer.BlockCopy(normalizedData, sizeof(double) * nrCol * i, firstPoint, 0, sizeof(double) * nrCol);
                    for (int j = i + 1; j < normalizedData.GetLength(0); j++)
                    {
                        
                        System.Buffer.BlockCopy(normalizedData, sizeof(double) * nrCol * j, secondPoint, 0, sizeof(double) * nrCol);

                        
                        tempDist = DistantaMinkowski(tipDistanta, firstPoint, secondPoint);
                        distanceMatrix[i, j] = tempDist;
                        distanceMatrix[j, i] = tempDist;
                        if (distMax < distanceMatrix[i, j])
                        {
                            distMax = distanceMatrix[i, j];
                        }
                    }
                }
            }
            sw.Stop();

            Console.WriteLine("Matrice Distanta Run Time: {0}", sw.Elapsed);

            return distanceMatrix;
        }
        private double DistantaMinkowski(int order, double[] firstPoint, double[] secondPoint)
        {
            double sum = 0;
            int dimension = firstPoint.Length;
            for (var i = 0; i < dimension; i++)
            {

                sum += Math.Pow(Math.Abs(firstPoint[i] - secondPoint[i]), order);
            }

            return Math.Pow(sum, (double)1 / order);
        }
        private double DistantaCosinus(double[] firstPoint, double[] secondPoint)
        {
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            int dimension = firstPoint.Length;
            for (var i = 0; i < dimension; i++)
            {
                sum1 += firstPoint[i] * secondPoint[i];
                sum2 += Math.Pow(firstPoint[i], 2);
                sum3 += Math.Pow(secondPoint[i], 2);
            }
            sum2 = Math.Sqrt(sum2);
            sum3 = Math.Sqrt(sum3);
            sum1 = sum1 / (sum2 * sum3);

            if ((sum1 < -0.001) || (sum1 > 1.1))
            {
                MessageBox.Show("Error");
            }

            return 1 - sum1;
        }

        private double[] GetRow(double[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

    }
}
