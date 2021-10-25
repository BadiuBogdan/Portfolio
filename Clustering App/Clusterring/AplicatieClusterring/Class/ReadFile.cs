using System;
using System.Collections.Generic;
using System.IO;

namespace AplicatieClusterring
{
    class ReadFile
    {

        public void Read2DFile(out Int16[,] values, out String[] initialCluster, string filePath)
        {
            string line;
            List<(string x, string y, string z)> lines = new List<(string, string, string)>();
            StreamReader file = new StreamReader(filePath);

            line = file.ReadLine();//citesc prima linie si dupa o sterg
            line = "";

            int numberOfLines = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] temp = line.Split(',');
                lines.Add((temp[0], temp[1], temp[2]));
                numberOfLines++;
            }
            values = new Int16[numberOfLines, 2];
            initialCluster = new String[numberOfLines];

            for (var i = 0; i < numberOfLines; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        values[i, j] = Convert.ToInt16(lines[i].x);
                    }

                    else if (j == 1)
                    {
                        values[i, j] = Convert.ToInt16(lines[i].y);
                    }
                    else
                    {
                        initialCluster[i] = lines[i].z;
                    }
                }

            }


        }
        public void ReadNDFile(out Int16[,] matrix, out String[] initialCluster, string filePath)
        {
            string line;
            List<string> lines = new List<string>(); //fiecare linie din string
            StreamReader file = new StreamReader(filePath);

            #region Citeste numaurl de lini si de coloane din fisier

            string line1 = file.ReadLine();
            string line2 = file.ReadLine();

            string[] vectorLine1 = line1.Split(' ');
            string[] vectorLine2 = line2.Split(' ');

            int numberOfLines = Convert.ToInt32(vectorLine1[1]);
            int numberOfColumns = Convert.ToInt32(vectorLine2[1]);
            #endregion

            while ((line = file.ReadLine()) != null)
            {
                if ((line.StartsWith("@")) || (line.StartsWith("#")) || (line == ""))
                {
                    //Nu fa nimic, nu imi introdu in lista de string
                }
                else
                {
                    int indexSpecificChar = line.IndexOf("#");
                    string tempLine = line.Substring(0, indexSpecificChar);

                    string clust = line.Substring(indexSpecificChar + 2, ((line.Length - tempLine.Length) - 2));
                    int indexCharForCluster = clust.IndexOf(' ');
                    string tempClust = clust.Substring(0, indexCharForCluster);

                    tempLine = tempLine + " " + tempClust;
                    lines.Add(tempLine);
                }
            }
            Tuple<Int16[,], String[]> temp= CreateDataMatrixAndClustersVector(lines, numberOfLines, numberOfColumns);
            matrix = temp.Item1;
            initialCluster = temp.Item2;
        }

        //Functia aceasta creaza matricea de marime NxN cu valorile citite din fisier si vectorul de clustere din fisier
        public Tuple<Int16[,], String[]> CreateDataMatrixAndClustersVector(List<string> lines, int numberOfLines, int numberOfColumns)
        {
            Int16[,] matrix = new Int16[numberOfLines, numberOfColumns];
            String[] vector = new String[numberOfLines];

            for (var indexLine = 0; indexLine < lines.Count; indexLine++)
            {
                string[] lineSplit = lines[indexLine].Split(' ');
                vector[indexLine] = lineSplit[lineSplit.Length - 1];
                for (var indexLineSplit = 0; indexLineSplit < lineSplit.Length - 2; indexLineSplit++)
                {
                    string[] valueSplit = lineSplit[indexLineSplit].Split(':');
                    int key = Convert.ToInt32(valueSplit[0]);
                    Int16 value = Convert.ToInt16(valueSplit[1]);

                    matrix[indexLine, key] = value;
                }
            }

            return Tuple.Create(matrix,vector);
        }
    }
}


