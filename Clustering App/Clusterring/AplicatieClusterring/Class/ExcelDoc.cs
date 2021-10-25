using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System.Collections.Generic;
using System.IO;
using AplicatieClusterring.Class;

namespace AplicatieClusterring
{
    class ExcelDoc
    {
        private FileInfo excelFile;
        public ExcelDoc(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            excelFile = new FileInfo(@"./../../FisiereExcelRaport/" + fileName+".xlsx");

        }
        public void SaveExcelFileDBSCAN(MetriciExterne met,List<string> zones,  double procentDist,  double distMax, int nrMinDocCluster, string fileName)
        {
            DeletFileIfExist(excelFile);
            var pack = new ExcelPackage(excelFile);

            var ws = pack.Workbook.Worksheets.Add("Metrici Externe");
          
                ws.Cells["A1"].Value = "Analiza Metrici Algoritmul DBSCAN fisier: \" " + fileName + " \"";
                ws.Cells["A1:I1"].Merge = true;
                ws.Cells["A2"].Value = "Distanta Maxima";
                ws.Cells["A3"].Value = "Procenet distanta maxima";
                ws.Cells["A4"].Value = "Distanta minima intre 2 puncte";
                ws.Cells["A5"].Value = "Nr minim de puncte din cluster";
                ws.Cells["B2"].Value = distMax;
                ws.Cells["B3"].Value = procentDist;
                ws.Cells["B4"].Value = (distMax * (procentDist / 100.0));
                ws.Cells["B5"].Value = nrMinDocCluster;

                //Formatare Excel
                ws.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Row(1).Style.Font.Size = 24;
                ws.Row(1).Style.Font.Bold = true;

                for (int i = 1; i <= 9; i++)
                {
                    if (i == 1)
                    {
                        ws.Column(i).Width = 30;
                    }
                    else
                    {
                        ws.Column(i).Width = 20;
                    }
                    
                }

                //Scrierea valorilor in fisierul excel
                List<List<double>> metriciPerClass = met.MetriciPerClass;

                ws.Cells["A7"].Value = "";
                ws.Cells["B7"].Value = "Acuratete";
                ws.Cells["C7"].Value = "Precizie";
                ws.Cells["D7"].Value = "Recall";
                for (int i = 0; i < metriciPerClass.Count; i++)
                {
                    ws.Cells[i + 8,1].Value ="Clasa \""+ zones[i]+" \"";
                    for (int j = 0; j < metriciPerClass[i].Count; j++)
                    {
                        ws.Cells[i + 8, j + 2].Value = metriciPerClass[i][j] ;
                    }
                }

                ws.Cells[metriciPerClass.Count+8, 1].Value = "Media Aritmetica";
                ws.Cells[metriciPerClass.Count + 8, 2].Value = met.Accuracy;
                ws.Cells[metriciPerClass.Count + 8, 3].Value = met.Precision;
                ws.Cells[metriciPerClass.Count + 8, 4].Value = met.Recall;


            pack.Save();


        }
        public void SaveExcelFileHAC(MetriciExterne met, List<string> zones, double procentDist, double distMax, string tipSimilaritate, string fileName)
        {
            DeletFileIfExist(excelFile);
            var pack = new ExcelPackage(excelFile);

            var ws = pack.Workbook.Worksheets.Add("Metrici Externe");



            ws.Cells["A1"].Value = "Analiza Metrici Algoritmul HAC fisier: \" " + fileName + " \"";
            ws.Cells["A1:I1"].Merge = true;

            ws.Cells["A2"].Value = "Distanta Maxima";
            ws.Cells["A3"].Value = "Procenet distanta maxima";
            ws.Cells["A4"].Value = "Prag";
            ws.Cells["A5"].Value = "Tipul de similaritate ]ntre clusteri";
            ws.Cells["B2"].Value = distMax;
            ws.Cells["B3"].Value = procentDist;
            ws.Cells["B4"].Value = (distMax * (procentDist / 100.0));
            ws.Cells["B5"].Value = tipSimilaritate;

            //Formatare Excel
            ws.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.Font.Size = 24;
            ws.Row(1).Style.Font.Bold = true;

            for (int i = 1; i <= 9; i++)
            {
                if (i == 1)
                {
                    ws.Column(i).Width = 30;
                }
                else
                {
                    ws.Column(i).Width = 20;
                }

            }

            //Scrierea valorilor in fisierul excel
            List<List<double>> metriciPerClass = met.MetriciPerClass;

            ws.Cells["A7"].Value = "";
            ws.Cells["B7"].Value = "Acuratete";
            ws.Cells["C7"].Value = "Precizie";
            ws.Cells["D7"].Value = "Recall";
            for (int i = 0; i < metriciPerClass.Count; i++)
            {
                ws.Cells[i + 8, 1].Value = "Clasa \"" + zones[i] + " \"";
                for (int j = 0; j < metriciPerClass[i].Count; j++)
                {
                    ws.Cells[i + 8, j + 2].Value = metriciPerClass[i][j];
                }
            }

            ws.Cells[metriciPerClass.Count + 8, 1].Value = "Total";
            ws.Cells[metriciPerClass.Count + 8, 2].Value = met.Accuracy;
            ws.Cells[metriciPerClass.Count + 8, 3].Value = met.Precision;
            ws.Cells[metriciPerClass.Count + 8, 4].Value = met.Recall;

            pack.Save();


        }
        private void DeletFileIfExist(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
