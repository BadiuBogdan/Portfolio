using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicatieClusterring.Class
{
    class DBSCAN
    {
       
        private int distanceType;
        private double[,] distanceMatrix;

        public int DistanceType { get => distanceType; set => distanceType = value; }

        public DBSCAN()
        {
           
        }

        public DBSCAN(ref double[,] distanceMatrix)
        {
            this.distanceMatrix = distanceMatrix;
        }

        public void Implementation(out List<Data> dataList,  double eps, int minPts)
        {

             dataList = new List<Data>();//lista care contine id/val liniei de la fiecare linie din mat/document


            int numberOfDocumnet = distanceMatrix.GetLength(0); //aceasta linie intoarce numarul de linii din matrice

            //creaza o lista cu toate dic dn matrice si il marcheaza ca fiind neclasterizat
            for (var i = 0; i < numberOfDocumnet; i++)
            {
                dataList.Add(new Data(i));
            }

            GetClusters(dataList, eps, minPts);

        }
        private void GetClusters(List<Data> dataList, double eps, int minPts)
        {
            Random rand = new Random();
            List<int> indexList = new List<int>();

            int clusterId = 1;//Initializez prima valuare a clusterului, adica primul cluster

            //Aici se amesteca lista de index de mai sus
            indexList = Enumerable.Range(0, dataList.Count).OrderBy(c => rand.Next()).ToList();

            foreach (var i in indexList)
            {
                Data p = dataList[i];
                if (p.ClusterId == DataProperties.UNCLUSTERED)
                {
                    if (ExpandCluster(dataList, p, clusterId, eps, minPts)) clusterId++;
                }
            }
        }
        private bool ExpandCluster(List<Data> dataList, Data p, int clusterId, double eps, int minPts)
        {
            List<Data> seeds = GetRegion(dataList, p, eps);
            if (seeds.Count < minPts) // no core point
            {
                foreach (var i in seeds)
                {
                    i.ClusterId = DataProperties.NOISE;
                }
                return false;
            }
            else // all points in seeds are density reachable from point 'p'
            {
                for (int i = 0; i < seeds.Count; i++) seeds[i].ClusterId = clusterId;
                seeds.Remove(p);
                while (seeds.Count > 0)
                {
                    Data currentData = seeds[0];
                    List<Data> result = GetRegion(dataList, currentData, eps);
                    if (result.Count >= minPts)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            Data resultP = result[i];
                            if (resultP.ClusterId == DataProperties.UNCLUSTERED || resultP.ClusterId == DataProperties.NOISE)
                            {
                                if (resultP.ClusterId == DataProperties.UNCLUSTERED) seeds.Add(resultP);
                                resultP.ClusterId = clusterId;
                            }
                        }
                    }
                    seeds.Remove(currentData);
                }
                return true;
            }
        }
        private List<Data> GetRegion(List<Data> dataList, Data p, double eps)
        {
            List<Data> region = new List<Data>();
            //double[] fistData = GetRow(distanceMatrix, p.DocId);

            for (int i = 0; i < dataList.Count; i++)
            {
                //double[] secondData = GetRow(distanceMatrix, dataList[i].DocId);
                double distSquared = distanceMatrix[p.DocId,dataList[i].DocId];
                
                if (distSquared <= eps) region.Add(dataList[i]);
            }
            return region;
        }

        public double[] GetRow(double[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
