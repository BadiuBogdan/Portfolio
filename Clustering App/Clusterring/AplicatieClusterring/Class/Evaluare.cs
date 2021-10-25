using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieClusterring.Class
{
    class Evaluare
    {
        private List<Data> data;
        private String[] initialClass;
        private double[,] distanceMatrix;

        private List<Element> combinatiaMaxima;
        private int[,] correspondenceMatrix;
        private int[,] confusionMatrix;
        private Dictionary<int, string> clustersClass;
        private List<string> zones;
        private List<int> indexClusters;
        private List<String> docPerClass;

        private CombinatiaMaxima classCombinatiaMaxima;

        private MetriciExterne metriciExterne;

        private bool isNoise;

        #region Dictionar local Test centroizi
        Dictionary<int, int> medoizi;

        public Dictionary<int, int> Medoizi { get => medoizi; set => medoizi = value; }
        public List<int> IndexClusters { get => indexClusters; set => indexClusters = value; }
        public List<string> FunDocPerClass { get => docPerClass; set => docPerClass = value; }
        public List<string> Zones { get => zones; set => zones = value; }
        internal MetriciExterne MetriciExterne { get => metriciExterne; set => metriciExterne = value; }
        #endregion

        public Evaluare(ref List<Data> data, ref String[] initialClass, ref double[,] distanceMatrix)
        {
            this.data = data;
            this.initialClass = initialClass;
            this.distanceMatrix = distanceMatrix;
            isNoise = false;
        }
        #region Calcul Matrice de corespondenta
        private void CreateCorrespondenceMatrix()
        {
            clustersClass = new Dictionary<int, string>();
            zones = new List<string>();
            for (var i = 0; i < initialClass.Length; i++)
            {
                if (!zones.Contains(initialClass[i]))
                {
                    zones.Add(initialClass[i]);
                }
            }
            
            indexClusters = new List<int>();
            foreach (var d in data)
            {
                if (!indexClusters.Contains(d.ClusterId))
                {
                    indexClusters.Add(d.ClusterId);
                }
            }
            //indexClusters.Sort((a, b) => b.CompareTo(a));//Sortare descrescatoare a listei folosind lambda
                                                         //sortam descrescator pentru a avea zgomotul ca ultima linie din matrice


            correspondenceMatrix = new int[indexClusters.Count, zones.Count];

            //Aici se creaza matricea de corespondenta, se contorizeaza de cate ori apare 
            //fiecare clasa in fiecare cluster
            for (var i = 0; i < initialClass.Length; i++)
            {
                correspondenceMatrix[indexClusters.IndexOf(data[i].ClusterId), zones.IndexOf(initialClass[i])] = correspondenceMatrix[indexClusters.IndexOf(data[i].ClusterId), zones.IndexOf(initialClass[i])] + 1;
            }

            //Facem un dictionar in care specificam pe baza matricei de corespondeta fiecare cluster ce clasa are
            //for (int i = 0; i < indexClusters.Count; i++)
            //{
            //    int max = Int32.MinValue;
            //    int indexMax = 0;
            //    for (int j = 0; j < zones.Count; j++)
            //    {
            //        if (max < correspondenceMatrix[i, j])
            //        {
            //            max = correspondenceMatrix[i, j];
            //            indexMax = j;
            //        }
            //    }
            //    clustersClass.Add(indexClusters[i], zones[indexMax]);
            //}

            ///Teste matrice de corespondenta
            string test = "\t";
            for (int i = 0; i < zones.Count; i++)
            {
                test += "Z" + zones[i].ToString() + " ";
            }

            for (var i = 0; i < indexClusters.Count; i++)
            {
                test += "\nCluster" + indexClusters[i].ToString() + ": ";
                for (var j = 0; j < zones.Count; j++)
                {
                    test += correspondenceMatrix[i, j].ToString() + "| ";
                }
            }

            MessageBox.Show(test);

            if (indexClusters.Count>(zones.Count+1)) 
            {
                isNoise = true;
                zones.Add("noise");
            }


            classCombinatiaMaxima = new CombinatiaMaxima(ref correspondenceMatrix);
            combinatiaMaxima = classCombinatiaMaxima.GetCombinatieMaxima();

            foreach (var elem in combinatiaMaxima)
            {
                clustersClass.Add(indexClusters[elem.mIndexLinie], zones[elem.mIndexColoana]);
            }
            ////
            /// Test Dictionar corespondeta clase
            Console.WriteLine();
            foreach (var item in clustersClass)
            {
                Console.Write("{0}:{1}, ", item.Key, item.Value);
            }
            Console.WriteLine();
            ///

        }
        #endregion
        #region Functii care calculeaza clasele punctelor
        private void DocPerClass()
        {
            docPerClass = new List<string>();
            medoizi = GetMedoizi();

           
            for (int i = 0; i < data.Count; i++)
            {
                List<double> distanteDocCentroid = new List<double>();
                List<int> centroidDoc = new List<int>();
                foreach (var item in medoizi)
                {
                    distanteDocCentroid.Add(distanceMatrix[item.Value, data[i].DocId]);
                    centroidDoc.Add(item.Value);
                }

                double minDist = distanteDocCentroid.Min();
                int doc = centroidDoc[distanteDocCentroid.IndexOf(minDist)];
                if (isNoise)
                {

                    if (clustersClass.ContainsKey(data[doc].ClusterId))
                    {
                        docPerClass.Add(clustersClass[data[doc].ClusterId]);
                    }
                    else
                    {
                        docPerClass.Add("noise");
                    }
                }
                else
                {
                    docPerClass.Add(clustersClass[data[doc].ClusterId]);
                }

            }
            #region Test valorile diferite din cele 2 liste
            List<Tuple<int, string>> tempTest = new List<Tuple<int, string>>();
            for (int i = 0; i < docPerClass.Count; i++)
            {
                if (docPerClass[i] != initialClass[i])
                {
                    tempTest.Add(new Tuple<int, string>(i, docPerClass[i])); 
                }
            }

            #endregion
        }

        private Dictionary<int, int> GetMedoizi()  
        {
            Dictionary<int, int> returnCent = new Dictionary<int, int>();
            
           
            for (int k = 0; k < indexClusters.Count; k++)
            {
                if (indexClusters[k] != -1)
                {
                    List<int> docInCluster = new List<int>();
                    double Min = Double.MaxValue;
                    int indexCentru = 0;
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].ClusterId == indexClusters[k])
                        {
                            docInCluster.Add(data[i].DocId);
                        }
                    }

                    for (int i = 0; i < docInCluster.Count; i++)
                    {
                        double sum = 0;
                        for (int j = 0; j < docInCluster.Count; j++)
                        {
                            sum += distanceMatrix[docInCluster[i], docInCluster[j]];
                        }
                        if (sum < Min)
                        {
                            indexCentru = docInCluster[i];
                            Min = sum;
                        }
                    }
                    returnCent.Add(indexClusters[k], indexCentru);
                }
            }

            return returnCent; 
        }
        #endregion

        #region Confusion matrix + Calcul Metrici Interne
        private void CreateConfusionMatrix()
        {
            confusionMatrix = new int[zones.Count, zones.Count];

            for (int i = 0; i < initialClass.Length; i++)
            {
                    confusionMatrix[zones.IndexOf(docPerClass[i]), zones.IndexOf(initialClass[i])]++;
            }
        }
        private void CalculMetrici()
        {
            List<ConfusionMatrixData> confusionMatrixDatas = new List<ConfusionMatrixData>();
            metriciExterne = new MetriciExterne();

            for (int k = 0; k < zones.Count; k++)
            {
                int tP = confusionMatrix[k, k];
                int tN = 0;
                int fP = 0;
                int fN = 0;
                for (int i = 0; i < confusionMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                    {
                        if (i != k && j != k)
                        {
                            tN += confusionMatrix[i, j];
                        }
                        else if (i == k && j != k)
                        {
                            fP += confusionMatrix[i, j];
                        }

                        else if (i != k && j == k)
                        {
                            fN += confusionMatrix[i, j];
                        }
                    }

                }
                confusionMatrixDatas.Add(new ConfusionMatrixData(tP, tN, fP, fN));
            }

            metriciExterne.Calc(ref confusionMatrixDatas,isNoise);

        }
        #endregion
        public int MaxVal(int max, int val)
        {
            if (max < val)
            {
                max = val;
            }
            return max;
        }
        public void CorespondenaIntreDate()
        {
            CreateCorrespondenceMatrix();
            DocPerClass();
        }
        public void EvaluareDate()
        {
            CreateConfusionMatrix();
            CalculMetrici();
        }
    }
}
