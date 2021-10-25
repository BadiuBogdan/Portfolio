using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AplicatieClusterring.Class
{
    class Normalizare
    {
        public double[,] NormalizareBinara(Int16[,] inputData)
        {
            double[,] returnMatrix = new double[inputData.GetLength(0), inputData.GetLength(1)];

            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    if (inputData[i, j] == 0)
                    {
                        returnMatrix[i, j] = 0;
                    }
                    else
                    {
                        returnMatrix[i, j] = 1;
                    }
                }

            }

            return returnMatrix;
        }

        public double[,] NormalizareSumaUnu(Int16[,] inputData, int ajustare)
        {
            double[,] returnMatrix = new double[inputData.GetLength(0), inputData.GetLength(1)];
            int sum = 0;
            List<int> vectorSuma = new List<int>();
            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    
                    sum += (inputData[i, j]+ajustare);
                }
                vectorSuma.Add(sum);
                sum = 0;
            }

            double testSum = 0;
            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    returnMatrix[i, j] = (double)(inputData[i, j]+ajustare) / (double)vectorSuma[i];
                    testSum += returnMatrix[i, j];
                }
                double test = testSum;
                testSum = 0;
            }
            double test1 = GetMaxValueFromMatrix(returnMatrix);
            double test2 = GetMinValueFromMatrix(returnMatrix);

            MessageBox.Show("Maximul dupa normalizare este: " + test1.ToString() + "\nMinimul dupa normalizare este: " + test2.ToString());
            return returnMatrix;
        }

        public double[,] NormalizareNominala(Int16[,] inputData, int ajustare)
        {
            double[,] returnMatrix = new double[inputData.GetLength(0), inputData.GetLength(1)];
            List<int> dataDocument = new List<int>();
            List<int> listMaxDocument = new List<int>();
            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    dataDocument.Add((inputData[i, j]+ajustare));
                }
                listMaxDocument.Add(GetMaxValueFromList(dataDocument));
                dataDocument.Clear();
            }
            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    returnMatrix[i, j] = (double)(inputData[i, j]+ajustare) / (double)listMaxDocument[i];
                }
            }
            double test1 = GetMaxValueFromMatrix(returnMatrix);
            double test2 = GetMinValueFromMatrix(returnMatrix);

            MessageBox.Show("Maximul dupa normalizare este: " + test1.ToString() + 
                            "\nMinimul dupa normalizare este: " + test2.ToString());
            return returnMatrix;
        }
        public double[,] NormalizareMinMax(Int16[,] inputData, Int16 newMin, Int16 newMax)
        {
            double[,] returnMatrix = new double[inputData.GetLength(0), inputData.GetLength(1)];

            Int16 maxData = GetMaxValueFromMatrix(inputData);
            Int16 minData = GetMinValueFromMatrix(inputData);

            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    returnMatrix[i, j] = (((double)(inputData[i, j] - minData)) / 
                                         ((double)maxData - minData)) * ((double)(newMax - newMin)) + newMin;
                }
            }

            double test1 = GetMaxValueFromMatrix(returnMatrix);
            double test2 = GetMinValueFromMatrix(returnMatrix);

            MessageBox.Show("Maximul dupa normalizare este: " + test1.ToString() +
                            "\nMinimul dupa normalizare este: " + test2.ToString());
            return returnMatrix;
        }

        //???????????Cornel-Smart nu merge pe 2D deoarece avem cordonate negative si calcului logatimic da NaN??????
        public double[,] NormalizareCornel_Smart(Int16[,] inputData,int ajustare)
        {
            double[,] returnMatrix = new double[inputData.GetLength(0), inputData.GetLength(1)];

            for (var i = 0; i < inputData.GetLength(0); i++)
            {
                for (var j = 0; j < inputData.GetLength(1); j++)
                {
                    if (inputData[i, j] == 0)
                    {
                        returnMatrix[i, j] = 0;
                    }
                    else
                    {
                        returnMatrix[i, j] = (double)1 + Math.Log((double)1 + Math.Log((inputData[i, j]+ajustare), 10), 10);
                    }

                }
            }

            double test1 = GetMaxValueFromMatrix(returnMatrix);
            double test2 = GetMinValueFromMatrix(returnMatrix);

            MessageBox.Show("Maximul dupa normalizare este: " + test1.ToString() + 
                            "\nMinimul dupa normalizare este: " + test2.ToString());
            return returnMatrix;
        }
        //???????????????????????????????????????????????????????????????????????????

        //-------------Metode suplimentare-----------
        public int GetMaxValueFromList(List<int> list)
        {
            int maxValue = int.MinValue;
            foreach (var i in list)
            {
                if (i > maxValue)
                {
                    maxValue = i;
                }
            }
            return maxValue;
        }

        public Int16 GetMaxValueFromMatrix(Int16[,] matrix)
        {
            Int16 maxValue = Int16.MinValue;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }
            }
            return maxValue;
        }

        public Int16 GetMinValueFromMatrix(Int16[,] matrix)
        {
            Int16 minValue = Int16.MaxValue;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                    }
                }
            }
            return minValue;
        }

        public double GetMaxValueFromMatrix(double[,] matrix)
        {
            double maxValue = double.MinValue;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }
            }
            return maxValue;
        }

        public double GetMinValueFromMatrix(double[,] matrix)
        {
            double minValue = double.MaxValue;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                    }
                }
            }
            return minValue;
        }

        //------------------------------------
    }
}
