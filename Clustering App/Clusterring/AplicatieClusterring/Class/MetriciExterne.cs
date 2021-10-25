using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieClusterring.Class
{
    public class MetriciExterne
    {
        List<List<double>> metriciPerClass;
        double accuracy;
        double precision;
        double recall;


        public MetriciExterne()
        {
            this.accuracy = 0;
            this.precision = 0;
            this.recall = 0;
        }
        public void Calc(ref List<ConfusionMatrixData> confusionMatrixDatas,bool isNoise)
        {
            metriciPerClass = new List<List<double>>();
            int index = 0;
            if (!isNoise)
            {
                foreach (var elem in confusionMatrixDatas)
                {
                    metriciPerClass.Add(new List<double>());
                    double tempAcc = Convert.ToDouble(elem.TP + elem.TN) / Convert.ToDouble(elem.TP + elem.TN + elem.FP + elem.FN);
                    double tempPrec = 0;
                    double tempRec = 0;

                    //Verificam daca numitorul este 0 
                    if (Convert.ToDouble(elem.TP + elem.FP) != 0)
                    {
                        tempPrec = Convert.ToDouble(elem.TP) / Convert.ToDouble(elem.TP + elem.FP);
                    }
                    else
                    {
                        tempPrec = 0;
                    }

                    //Verificam daca numitorul este 0 
                    if (Convert.ToDouble(elem.TP + elem.FN) != 0)
                    {
                        tempRec = Convert.ToDouble(elem.TP) / Convert.ToDouble(elem.TP + elem.FN);
                    }
                    else
                    {
                        tempPrec = 0;
                    }


                    accuracy += tempAcc;
                    precision += tempPrec;
                    recall += tempRec;

                    metriciPerClass[index].Add(tempAcc);
                    metriciPerClass[index].Add(tempPrec);
                    metriciPerClass[index].Add(tempRec);
                    index++;
                }

                accuracy = accuracy / Convert.ToDouble(index);
                precision = precision / Convert.ToDouble(index);
                recall = recall / Convert.ToDouble(index);
            }
            else
            {
                
                for (int i = 0; i < confusionMatrixDatas.Count-1; i++)
                {
                    metriciPerClass.Add(new List<double>());
                    double tempAcc = Convert.ToDouble(confusionMatrixDatas[i].TP + confusionMatrixDatas[i].TN) / Convert.ToDouble(confusionMatrixDatas[i].TP + confusionMatrixDatas[i].TN + confusionMatrixDatas[i].FP + confusionMatrixDatas[i].FN);
                    double tempPrec = 0;
                    double tempRec = 0;

                    //Verificam daca numitorul este 0 
                    if (Convert.ToDouble(confusionMatrixDatas[i].TP + confusionMatrixDatas[i].FP) != 0)
                    {
                        tempPrec = Convert.ToDouble(confusionMatrixDatas[i].TP) / Convert.ToDouble(confusionMatrixDatas[i].TP + confusionMatrixDatas[i].FP);
                    }
                    else
                    {
                        tempPrec = 0;
                    }

                    //Verificam daca numitorul este 0 
                    if (Convert.ToDouble(confusionMatrixDatas[i].TP + confusionMatrixDatas[i].FN) != 0)
                    {
                        tempRec = Convert.ToDouble(confusionMatrixDatas[i].TP) / Convert.ToDouble(confusionMatrixDatas[i].TP + confusionMatrixDatas[i].FN);
                    }
                    else
                    {
                        tempPrec = 0;
                    }


                    accuracy += tempAcc;
                    precision += tempPrec;
                    recall += tempRec;

                    metriciPerClass[index].Add(tempAcc);
                    metriciPerClass[index].Add(tempPrec);
                    metriciPerClass[index].Add(tempRec);
                    index++;
                }

                accuracy = accuracy / Convert.ToDouble(index);
                precision = precision / Convert.ToDouble(index);
                recall = recall / Convert.ToDouble(index);
            }
        }
        public double Accuracy { get => accuracy; set => accuracy = value; }
        public double Precision { get => precision; set => precision = value; }
        public double Recall { get => recall; set => recall = value; }
        public List<List<double>> MetriciPerClass { get => metriciPerClass; set => metriciPerClass = value; }
    }
}
