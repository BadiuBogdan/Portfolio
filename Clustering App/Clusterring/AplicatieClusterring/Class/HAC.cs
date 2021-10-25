using System;
using System.Collections.Generic;
using AplicatieClusterring.Class;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieClusterring
{
    class HAC
    {
        private double[,] distanceMatrix;
        public HAC(ref double[,] distanceMatrix)
        {
            this.distanceMatrix = distanceMatrix;
        }
        public void ImplementationSingleLink(out List<Data> dataList, double eps)
        {
            dataList = new List<Data>();//lista care contine id/val liniei de la fiecare linie din mat/document

            //creaza o lista cu toate dic dn matrice si il marcheaza ca fiind cluster unic
            for (var i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                dataList.Add(new Data(i, i));
            }
            Tuple<int, int, double> subCluster = Min();
            double min = subCluster.Item3;
            while (min <= eps)
            {
                if (subCluster.Item1 > subCluster.Item2)
                {
                    subCluster = new Tuple<int, int, double>(subCluster.Item2, subCluster.Item1, subCluster.Item3);

                }
                foreach (var item in dataList)
                {
                    if (item.ClusterId == subCluster.Item2)
                    {
                        item.ClusterId = subCluster.Item1;
                    }
                }

                for (int i = 0; i < distanceMatrix.GetLength(0); i++)
                {
                    if (distanceMatrix[i, subCluster.Item1] > distanceMatrix[i, subCluster.Item2])
                    {
                        distanceMatrix[i, subCluster.Item1] = distanceMatrix[i, subCluster.Item2];
                    }
                    distanceMatrix[i, subCluster.Item2] = 9999999999;
                }
                for (int j = 0; j < distanceMatrix.GetLength(1); j++)
                {
                    if (distanceMatrix[subCluster.Item1, j] > distanceMatrix[subCluster.Item2, j])
                    {
                        distanceMatrix[subCluster.Item1, j] = distanceMatrix[subCluster.Item2, j];
                    }
                    distanceMatrix[subCluster.Item2, j] = 9999999999;
                }
                subCluster = Min();
                min = subCluster.Item3;
            }
        }

        public void ImplementationCompleteLink(out List<Data> dataList, double eps)
        {
            dataList = new List<Data>();//lista care contine id/val liniei de la fiecare linie din mat/document

            //creaza o lista cu toate dic dn matrice si il marcheaza ca fiind cluster unic
            for (var i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                dataList.Add(new Data(i, i));
            }
            Tuple<int, int, double> subCluster = Max();
            double max = subCluster.Item3;
            while (max >= eps)
            {
                if (subCluster.Item1 > subCluster.Item2)
                {
                    subCluster = new Tuple<int, int, double>(subCluster.Item2, subCluster.Item1, subCluster.Item3);

                }
                foreach (var item in dataList)
                {
                    if (item.ClusterId == subCluster.Item2)
                    {
                        item.ClusterId = subCluster.Item1;
                    }
                }
                for (int i = 0; i < distanceMatrix.GetLength(0); i++)
                {
                    if ((distanceMatrix[i, subCluster.Item1] < distanceMatrix[i, subCluster.Item2])
                       && (distanceMatrix[i, subCluster.Item1] != 0) && (distanceMatrix[i, subCluster.Item2] != 0))
                    {
                        distanceMatrix[i, subCluster.Item1] = distanceMatrix[i, subCluster.Item2];
                    }
                    distanceMatrix[i, subCluster.Item2] = -9999999999;
                }
                for (int j = 0; j < distanceMatrix.GetLength(1); j++)
                {
                    if ((distanceMatrix[subCluster.Item1, j] < distanceMatrix[subCluster.Item2, j])
                        && (distanceMatrix[subCluster.Item1, j] != 0) && (distanceMatrix[subCluster.Item2, j] != 0))
                    {
                        distanceMatrix[subCluster.Item1, j] = distanceMatrix[subCluster.Item2, j];
                    }
                    distanceMatrix[subCluster.Item2, j] = -9999999999;
                }
                subCluster = Max();
                max = subCluster.Item3;
            }
        }
        private Tuple<int, int, double> Min()
        {
            double min = Double.MaxValue;
            int indexI = -1;
            int indexJ = -1;
            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < distanceMatrix.GetLength(1); j++)
                {
                    if ((min > distanceMatrix[i, j]))
                    {
                        min = distanceMatrix[i, j];
                        indexI = i;
                        indexJ = j;
                    }
                }
            }
            return new Tuple<int, int, double>(indexI, indexJ, min);
        }

        private Tuple<int, int, double> Max()
        {
            double max = Double.MinValue;
            int indexI = -1;
            int indexJ = -1;
            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < distanceMatrix.GetLength(1); j++)
                {
                    if ((max < distanceMatrix[i, j]))
                    {
                        max = distanceMatrix[i, j];
                        indexI = i;
                        indexJ = j;
                    }
                }
            }
            return new Tuple<int, int, double>(indexI, indexJ, max);
        }
    }
}
