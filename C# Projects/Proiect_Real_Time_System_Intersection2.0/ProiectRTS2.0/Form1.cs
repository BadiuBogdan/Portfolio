using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectRTS2._0
{
    public partial class fPrincipal : Form
    {
        private uint headerWhiteCar;
        private uint firWhiteCar;

        private uint headerBlackCar;
        private uint firBlackCar;

        private uint headerYellowCar;
        private uint firYellowCar;

        private uint headerRedCar;
        private uint firRedCar;

        private uint headerRedCar2;
        private uint firRedCar2;

        private uint headerPieton;
        private uint firPieton;

        private uint headerSemafor1;
        private uint firSemafor1;

        private uint headerSemafor2;
        private uint firSemafor2;

        private uint headerSemafor3;
        private uint firSemafor3;

        private uint headerSemafor4;
        private uint firSemafor4;

        private IntPtr evenimentPieton;
        private IntPtr evenimentBlackCar;
        private IntPtr evenimentYellowCar;
        private IntPtr evenimentWhiteCar;

        private IntPtr evenimentSemafor1;
        private IntPtr evenimentSemafor2;
        private IntPtr evenimentSemafor22;
        private IntPtr evenimentSemafor3;
        private IntPtr evenimentSemafor4;

        public IntPtr hMutex;
        public IntPtr hMutex2;

        private Bitmap bitmapOrizontal;
        private Bitmap bitmapVertical;
        private Bitmap bitmapIntersectie;
        private Bitmap bitmapPieton;
        private Bitmap bitmapBlackCar;
        private Bitmap bitmapRedCar;
        private Bitmap bitmapRedCar2;
        private Bitmap bitmapYellowCar;
        private Bitmap bitmapWhiteCar;

        private Bitmap bitmapSemafor1Rosu;
        private Bitmap bitmapSemafor1Galben;
        private Bitmap bitmapSemafor1Verde;

        private Bitmap bitmapSemafor2Rosu;
        private Bitmap bitmapSemafor2Galben;
        private Bitmap bitmapSemafor2Verde;

        private Bitmap bitmapSemafor3Rosu;
        private Bitmap bitmapSemafor3Galben;
        private Bitmap bitmapSemafor3Verde;

        private Bitmap bitmapSemafor4Rosu;
        private Bitmap bitmapSemafor4Galben;
        private Bitmap bitmapSemafor4Verde;

        public fPrincipal()
        {
            InitializeComponent();
        }
        public uint ThreadWhiteCar(IntPtr x)
        {

            evenimentSemafor22 = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "Semafor22");
            WinApiClass.ResetEvent(evenimentWhiteCar);
            for (var i = 0; i <= 120; i++)
            {
                Thread.Sleep(10);
                whitePb.Invoke(new Action(() => whitePb.Left += 1));
            }
            uint rezultSemafor = WinApiClass.WaitForSingleObject(evenimentSemafor22, 50000);
            if (rezultSemafor == WinApiClass.WAIT_OBJECT_0)
            {
                WinApiClass.SetEvent(evenimentWhiteCar);
                for (var i = 0; i <= 80; i++)
                {
                    Thread.Sleep(10);
                    whitePb.Invoke(new Action(() => whitePb.Left += 1));
                }


            }

            bitmapWhiteCar.RotateFlip(RotateFlipType.Rotate90FlipNone);
            whitePb.Invoke(new Action(() => whitePb.Size = new Size(bitmapWhiteCar.Width, bitmapWhiteCar.Height)));
            whitePb.Invoke(new Action(() => whitePb.Image = (Image)bitmapWhiteCar));
            whitePb.Invoke(new Action(() => whitePb.Left += 40));


            for (var i = 0; i <= 250; i++)
            {
                Thread.Sleep(10);
                whitePb.Invoke(new Action(() => whitePb.Top += 1));
            }
            return 0;
        }
        public uint ThreadPieton(IntPtr x)
        {
            WinApiClass.ResetEvent(evenimentPieton);
            for (var i = 0; i <= 170; i++)
            {
                Thread.Sleep(10);
                pietonPb.Invoke(new Action(() => pietonPb.Left -= 1));
            }
            WinApiClass.SetEvent(evenimentPieton);

            return 0;
        }
        public uint ThreadBlackCar(IntPtr x)
        {
            evenimentPieton = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "TrecereDePietoni");
            evenimentSemafor3 = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "Semafor3");
            for (var i = 0; i <= 60; i++)
            {
                Thread.Sleep(10);
                blackCarPb.Invoke(new Action(() => blackCarPb.Left -= 1));

            }
            uint rezultSemafor = WinApiClass.WaitForSingleObject(evenimentSemafor3, 50000);
            if (rezultSemafor == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 50; i++)
                {
                    Thread.Sleep(10);
                    blackCarPb.Invoke(new Action(() => blackCarPb.Left -= 1));
                }
                WinApiClass.ResetEvent(evenimentBlackCar);
                for (var i = 0; i <= 50; i++)
                {
                    Thread.Sleep(10);
                    blackCarPb.Invoke(new Action(() => blackCarPb.Left -= 1));
                }
                bitmapBlackCar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                blackCarPb.Invoke(new Action(() => blackCarPb.Size = new Size(bitmapBlackCar.Width, bitmapBlackCar.Height)));
                blackCarPb.Invoke(new Action(() => blackCarPb.Image = (Image)bitmapBlackCar));
                blackCarPb.Invoke(new Action(() => blackCarPb.Left += 20));

                for (var i = 0; i <= 30; i++)
                {
                    Thread.Sleep(10);
                    blackCarPb.Invoke(new Action(() => blackCarPb.Top -= 1));

                }

                uint rezult = WinApiClass.WaitForSingleObject(evenimentPieton, 50000);
                if (rezult == WinApiClass.WAIT_OBJECT_0)
                {
                    for (var i = 0; i <= 30; i++)
                    {
                        Thread.Sleep(10);
                        blackCarPb.Invoke(new Action(() => blackCarPb.Top -= 1));

                    }
                    WinApiClass.SetEvent(evenimentBlackCar);
                    for (var i = 0; i <= 420; i++)
                    {
                        Thread.Sleep(10);
                        blackCarPb.Invoke(new Action(() => blackCarPb.Top -= 1));

                    }
                }

            }


            return 0;
        }
        public uint ThreadRedCar(IntPtr x)
        {
            evenimentPieton = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "TrecereDePietoni");
            evenimentSemafor1 = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "Semafo1");
            for (var i = 0; i <= 80; i++)
            {
                Thread.Sleep(10);
                redCarPb.Invoke(new Action(() => redCarPb.Top += 1));
            }
            uint rezult = WinApiClass.WaitForSingleObject(evenimentPieton, 50000);
            if (rezult == WinApiClass.WAIT_OBJECT_0)
            {

                for (var i = 0; i <= 100; i++)
                {
                    Thread.Sleep(10);
                    redCarPb.Invoke(new Action(() => redCarPb.Top += 1));
                }
            }

            uint rezultSemafor = WinApiClass.WaitForSingleObject(evenimentSemafor1, 50000);
            if (rezultSemafor == WinApiClass.WAIT_OBJECT_0)
            {
                bitmapRedCar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                redCarPb.Invoke(new Action(() => redCarPb.Size = new Size(bitmapRedCar.Width, bitmapRedCar.Height)));
                redCarPb.Invoke(new Action(() => redCarPb.Image = (Image)bitmapRedCar));
                redCarPb.Invoke(new Action(() => redCarPb.Top += 50));


                for (var i = 0; i <= 450; i++)
                {
                    Thread.Sleep(10);
                    redCarPb.Invoke(new Action(() => redCarPb.Left -= 1));
                }

            }

            return 0;
        }
        public uint ThreadRedCar2(IntPtr x)
        {
            evenimentYellowCar = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "YellowCar");
            evenimentWhiteCar = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "WhiteCar");
            evenimentSemafor2 = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "Semafor2");
            for (var i = 0; i <= 180; i++)
            {
                Thread.Sleep(10);
                redCar2Pb.Invoke(new Action(() => redCar2Pb.Left += 1));
            }

            uint rezultWhite = WinApiClass.WaitForSingleObject(evenimentWhiteCar, 50000);
            if (rezultWhite == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 100; i++)
                {
                    Thread.Sleep(10);
                    redCar2Pb.Invoke(new Action(() => redCar2Pb.Left += 1));
                }
            }
            uint rezultSemafor2 = WinApiClass.WaitForSingleObject(evenimentSemafor2, 50000);
            if (rezultSemafor2 == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 80; i++)
                {
                    Thread.Sleep(10);
                    redCar2Pb.Invoke(new Action(() => redCar2Pb.Left += 1));

                }
            }
            uint rezult1 = WinApiClass.WaitForSingleObject(evenimentYellowCar, 50000);
            if (rezult1 == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 370; i++)
                {
                    Thread.Sleep(10);
                    redCar2Pb.Invoke(new Action(() => redCar2Pb.Left += 1));

                }
            }
            return 0;
        }

        public uint ThreadYellowCar(IntPtr x)
        {
            evenimentBlackCar = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "BlackCar");
            evenimentPieton = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "TrecereDePietoni");
            evenimentSemafor4 = WinApiClass.CreateEvent(IntPtr.Zero, true, true, "Semafor4");

            for (var i = 0; i <= 60; i++)
            {
                Thread.Sleep(10);
                yellowCarPb.Invoke(new Action(() => yellowCarPb.Top -= 1));
                

            }
            uint rezultSemafor4 = WinApiClass.WaitForSingleObject(evenimentSemafor4, 50000);
            if (rezultSemafor4 == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 130; i++)
                {
                    Thread.Sleep(10);
                    yellowCarPb.Invoke(new Action(() => yellowCarPb.Top -= 1));
                   

                }
            }
            WinApiClass.ResetEvent(evenimentYellowCar);
            uint rezult = WinApiClass.WaitForSingleObject(evenimentBlackCar, 50000);
            if (rezult == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 100; i++)
                {
                    Thread.Sleep(10);
                    yellowCarPb.Invoke(new Action(() => yellowCarPb.Top -= 1));

                }
                WinApiClass.SetEvent(evenimentYellowCar);
            }

            uint rezultPieton = WinApiClass.WaitForSingleObject(evenimentPieton, 50000);
            if (rezultPieton == WinApiClass.WAIT_OBJECT_0)
            {
                for (var i = 0; i <= 480; i++)
                {
                    Thread.Sleep(10);
                    yellowCarPb.Invoke(new Action(() => yellowCarPb.Top -= 1));
                }
            }

            return 0;
        }

        public uint ThreadSemafor1(IntPtr x)
        {

            while (true)
            {
                uint rez = WinApiClass.WaitForSingleObject(hMutex, 1000);
                if (rez == WinApiClass.WAIT_OBJECT_0)
                {
                    WinApiClass.SetEvent(evenimentSemafor1);
                    pbSemafor1.Invoke(new Action(() => pbSemafor1.Image = (Image)bitmapSemafor1Verde));
                    Thread.Sleep(1000);
                    WinApiClass.ReleaseMutex(hMutex);
                }
                else
                {
                    WinApiClass.ResetEvent(evenimentSemafor1);
                    pbSemafor1.Invoke(new Action(() => pbSemafor1.Image = (Image)bitmapSemafor1Rosu));
                    Thread.Sleep(1000);
                    
                }

            }
            return 0;
        }

        public uint ThreadSemafor2(IntPtr x)
        {
            while (true)
            {
                uint rez = WinApiClass.WaitForSingleObject(hMutex, 1000);
                if (rez == WinApiClass.WAIT_OBJECT_0)
                {
                    WinApiClass.SetEvent(evenimentSemafor2);
                    WinApiClass.SetEvent(evenimentSemafor22);
                    pbSemafor2.Invoke(new Action(() => pbSemafor2.Image = (Image)bitmapSemafor2Verde));
                    Thread.Sleep(1000);
                    WinApiClass.ReleaseMutex(hMutex);
                }
                else
                {
                    WinApiClass.ResetEvent(evenimentSemafor2);
                    WinApiClass.ResetEvent(evenimentSemafor22);
                    pbSemafor2.Invoke(new Action(() => pbSemafor2.Image = (Image)bitmapSemafor2Rosu));
                    Thread.Sleep(1000);
                }

            }

            return 0;
        }

        public uint ThreadSemafor3(IntPtr x)
        {
            while (true)
            {
                uint rez = WinApiClass.WaitForSingleObject(hMutex, 1000);
                if (rez == WinApiClass.WAIT_OBJECT_0)
                {
                    WinApiClass.SetEvent(evenimentSemafor3);
                    pbSemafor3.Invoke(new Action(() => pbSemafor3.Image = (Image)bitmapSemafor3Verde));
                    Thread.Sleep(1000);
                    WinApiClass.ReleaseMutex(hMutex);
                }
                else
                {
                    WinApiClass.ResetEvent(evenimentSemafor3);
                    pbSemafor3.Invoke(new Action(() => pbSemafor3.Image = (Image)bitmapSemafor3Rosu));
                    Thread.Sleep(1000);
                }

            }
            return 0;
        }

        public uint ThreadSemafor4(IntPtr x)
        {
            while (true)
            {
                uint rez = WinApiClass.WaitForSingleObject(hMutex, 1000);
                if (rez == WinApiClass.WAIT_OBJECT_0)
                {
                    WinApiClass.SetEvent(evenimentSemafor4);
                    pbSemafor4.Invoke(new Action(() => pbSemafor4.Image = (Image)bitmapSemafor4Verde));
                    Thread.Sleep(1000);
                    WinApiClass.ReleaseMutex(hMutex);
                }
                else
                {
                    WinApiClass.ResetEvent(evenimentSemafor4);
                    pbSemafor4.Invoke(new Action(() => pbSemafor4.Image = (Image)bitmapSemafor4Rosu));
                    Thread.Sleep(1000);
                }

            }
            return 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            headerWhiteCar = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadWhiteCar, IntPtr.Zero, 0, out firWhiteCar);
            headerBlackCar = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadBlackCar, IntPtr.Zero, 0, out firBlackCar);
            headerYellowCar = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadYellowCar, IntPtr.Zero, 0, out firYellowCar);
            headerRedCar = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadRedCar, IntPtr.Zero, 0, out firRedCar);
            headerRedCar2 = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadRedCar2, IntPtr.Zero, 0, out firRedCar2);
        }

        private void fPrincipal_Load(object sender, EventArgs e)
        {
            //---------Declarare bitmap----------------------------------------
            bitmapOrizontal = new Bitmap(@"./../../Images/Drum_Orizontal.png");
            bitmapVertical = new Bitmap(@"./../../Images/Drum_Vertical.png");
            bitmapIntersectie = new Bitmap(@"./../../Images/Intersectie.png");
            bitmapPieton = new Bitmap(@"./../../Images/pieton.png");
            bitmapBlackCar = new Bitmap(@"./../../Images/blackCar.png");
            bitmapRedCar = new Bitmap(@"./../../Images/redCar.png");
            bitmapRedCar2 = new Bitmap(@"./../../Images/redCar.png");
            bitmapYellowCar = new Bitmap(@"./../../Images/yellowCar.png");
            bitmapWhiteCar = new Bitmap(@"./../../Images/whiteCar.png");


            bitmapSemafor1Rosu = new Bitmap(@"./../../Images/SemaforRosu.png");
            bitmapSemafor2Rosu = new Bitmap(@"./../../Images/SemaforRosu.png");
            bitmapSemafor3Rosu = new Bitmap(@"./../../Images/SemaforRosu.png");
            bitmapSemafor4Rosu = new Bitmap(@"./../../Images/SemaforRosu.png");


            bitmapSemafor1Verde = new Bitmap(@"./../../Images/SemaforVerde.png");
            bitmapSemafor2Verde = new Bitmap(@"./../../Images/SemaforVerde.png");
            bitmapSemafor3Verde = new Bitmap(@"./../../Images/SemaforVerde.png");
            bitmapSemafor4Verde = new Bitmap(@"./../../Images/SemaforVerde.png");


            bitmapSemafor1Galben = new Bitmap(@"./../../Images/SemaforGalben.png");
            bitmapSemafor2Galben = new Bitmap(@"./../../Images/SemaforGalben.png");
            bitmapSemafor3Galben = new Bitmap(@"./../../Images/SemaforGalben.png");
            bitmapSemafor4Galben = new Bitmap(@"./../../Images/SemaforGalben.png");
            //---------End declarare bitmap----------------------------------------

            //----------------------Cars-----------------------------------------


            blackCarPb.Location = new Point(650, 310);
            blackCarPb.Size = new Size(bitmapBlackCar.Width, bitmapBlackCar.Height);
            blackCarPb.Image = (Image)bitmapBlackCar;
            Controls.Add(blackCarPb);



            yellowCarPb.Location = new Point(510, 560);
            yellowCarPb.Size = new Size(bitmapYellowCar.Width, bitmapYellowCar.Height);
            yellowCarPb.Image = (Image)bitmapYellowCar;
            Controls.Add(yellowCarPb);


            bitmapRedCar.RotateFlip(RotateFlipType.Rotate180FlipNone);
            redCarPb.Location = new Point(450, 60);
            redCarPb.Size = new Size(bitmapRedCar.Width, bitmapRedCar.Height);
            redCarPb.Image = (Image)bitmapRedCar;
            Controls.Add(redCarPb);

            bitmapRedCar2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            redCar2Pb.Location = new Point(40, 350);
            redCar2Pb.Size = new Size(bitmapRedCar2.Width, bitmapRedCar2.Height);
            redCar2Pb.Image = (Image)bitmapRedCar2;
            Controls.Add(redCar2Pb);



            bitmapWhiteCar.RotateFlip(RotateFlipType.Rotate90FlipNone);
            whitePb.Location = new Point(210, 360);
            whitePb.Size = new Size(bitmapWhiteCar.Width, bitmapWhiteCar.Height);
            whitePb.Image = (Image)bitmapWhiteCar;
            Controls.Add(whitePb);
            //----------------------End cars--------------------------------------

            //-----------------Pieton----------------------------------------

            pietonPb.Location = new Point(570, 180);
            pietonPb.Size = new Size(bitmapPieton.Width, bitmapPieton.Height);
            pietonPb.Image = (Image)bitmapPieton;
            Controls.Add(pietonPb);
            //-----------------End pieton----------------------------------------

            //-----------------Semafoare----------------------------------------

            pbSemafor1.Location = new Point(400, 250);
            pbSemafor1.Size = new Size(bitmapSemafor1Galben.Width, bitmapSemafor1Galben.Height);
            pbSemafor1.Image = (Image)bitmapSemafor1Galben;
            Controls.Add(pbSemafor1);

            bitmapSemafor2Rosu.RotateFlip(RotateFlipType.Rotate270FlipNone);
            bitmapSemafor2Verde.RotateFlip(RotateFlipType.Rotate270FlipNone);
            bitmapSemafor2Galben.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pbSemafor2.Location = new Point(380, 400);
            pbSemafor2.Size = new Size(bitmapSemafor2Galben.Width, bitmapSemafor2Galben.Height);
            pbSemafor2.Image = (Image)bitmapSemafor2Galben;
            Controls.Add(pbSemafor2);


            bitmapSemafor3Rosu.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bitmapSemafor3Verde.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bitmapSemafor3Galben.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbSemafor3.Location = new Point(580, 280);
            pbSemafor3.Size = new Size(bitmapSemafor3Galben.Width, bitmapSemafor3Galben.Height);
            pbSemafor3.Image = (Image)bitmapSemafor3Galben;
            Controls.Add(pbSemafor3);


            bitmapSemafor4Rosu.RotateFlip(RotateFlipType.Rotate180FlipNone);
            bitmapSemafor4Verde.RotateFlip(RotateFlipType.Rotate180FlipNone);
            bitmapSemafor4Galben.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pbSemafor4.Location = new Point(580, 400);
            pbSemafor4.Size = new Size(bitmapSemafor4Galben.Width, bitmapSemafor4Galben.Height);
            pbSemafor4.Image = (Image)bitmapSemafor4Galben;
            Controls.Add(pbSemafor4);
            //-----------------End semafoare----------------------------------------

            //--------------------------------------Strada---------------------------------

            PictureBox drumPb = new PictureBox();
            drumPb.Location = new Point(150, 270);
            drumPb.Size = new Size(bitmapOrizontal.Width, bitmapOrizontal.Height);
            drumPb.Image = (Image)bitmapOrizontal;
            Controls.Add(drumPb);

            PictureBox drum5Pb = new PictureBox();
            drum5Pb.Location = new Point(0, 270);
            drum5Pb.Size = new Size(bitmapOrizontal.Width, bitmapOrizontal.Height);
            drum5Pb.Image = (Image)bitmapOrizontal;
            Controls.Add(drum5Pb);

            PictureBox drum2Pb = new PictureBox();
            drum2Pb.Location = new Point(630, 270);
            drum2Pb.Size = new Size(bitmapOrizontal.Width, bitmapOrizontal.Height);
            drum2Pb.Image = (Image)bitmapOrizontal;
            Controls.Add(drum2Pb);

            PictureBox intersectiePb = new PictureBox();
            intersectiePb.Location = new Point(350, 200);
            intersectiePb.Size = new Size(bitmapIntersectie.Width, bitmapIntersectie.Height);
            intersectiePb.Image = (Image)bitmapIntersectie;
            Controls.Add(intersectiePb);

            PictureBox drum3Pb = new PictureBox();
            drum3Pb.Location = new Point(397, 0);
            drum3Pb.Size = new Size(bitmapVertical.Width, bitmapVertical.Height);
            drum3Pb.Image = (Image)bitmapVertical;
            Controls.Add(drum3Pb);

            PictureBox drum4Pb = new PictureBox();
            drum4Pb.Location = new Point(397, 390);
            drum4Pb.Size = new Size(bitmapVertical.Width, bitmapVertical.Height);
            drum4Pb.Image = (Image)bitmapVertical;
            Controls.Add(drum4Pb);
            //---------------------------------End strada------------------------------------------------------
        }

        private void btnPieton_Click(object sender, EventArgs e)
        {
            btnStartPedestrian.Enabled = false;
            headerPieton = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadPieton, IntPtr.Zero, 0, out firPieton);
        }

        private void btnStartTrafficLights_Click(object sender, EventArgs e)
        {
            btnStartTrafficLights.Enabled = false;

            hMutex = WinApiClass.CreateMutex(IntPtr.Zero, false, "Semafor1Mutex");

            headerSemafor1 = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadSemafor1, IntPtr.Zero, 0, out firSemafor1);
            headerSemafor2 = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadSemafor2, IntPtr.Zero, 0, out firSemafor2);
            headerSemafor3 = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadSemafor3, IntPtr.Zero, 0, out firSemafor3);
            headerSemafor4 = WinApiClass.CreateThread(IntPtr.Zero, 0, ThreadSemafor4, IntPtr.Zero, 0, out firSemafor4);
        }

        private void btnResumeRedCar1_Click(object sender, EventArgs e)
        {
            btnResumeRedCar1.Enabled = false;
            btnSuspendRedCar1.Enabled = true;
            WinApiClass.ResumeThread((IntPtr)headerRedCar);
        }

        private void btnSuspendRedCar1_Click(object sender, EventArgs e)
        {
            btnResumeRedCar1.Enabled = true;
            btnSuspendRedCar1.Enabled = false;
            WinApiClass.SuspendThread((IntPtr)headerRedCar);
        }

        private void btnResumeRedCar2_Click(object sender, EventArgs e)
        {
            btnResumeRedCar2.Enabled = false;
            btnSuspendRedCar2.Enabled = true;
            WinApiClass.ResumeThread((IntPtr)headerRedCar2);
        }

        private void btnSuspendRedCar2_Click(object sender, EventArgs e)
        {
            btnResumeRedCar2.Enabled = true;
            btnSuspendRedCar2.Enabled = false;
            WinApiClass.SuspendThread((IntPtr)headerRedCar2);
        }

        private void btnResumeBlackCar_Click(object sender, EventArgs e)
        {
            btnResumeBlackCar.Enabled = false;
            btnSuspendBlackCar.Enabled = true;
            WinApiClass.ResumeThread((IntPtr)headerBlackCar);
        }

        private void btnSuspendBlackCar_Click(object sender, EventArgs e)
        {
            btnResumeBlackCar.Enabled = true;
            btnSuspendBlackCar.Enabled = false;
            WinApiClass.SuspendThread((IntPtr)headerBlackCar);
        }

        private void btnResumeWhiteCar_Click(object sender, EventArgs e)
        {
            btnResumeWhiteCar.Enabled = false;
            btnSuspendWhiteCar.Enabled = true;
            WinApiClass.ResumeThread((IntPtr)headerWhiteCar);
        }

        private void btnSuspendWhiteCar_Click(object sender, EventArgs e)
        {
            btnResumeWhiteCar.Enabled = true;
            btnSuspendWhiteCar.Enabled = false;
            WinApiClass.SuspendThread((IntPtr)headerWhiteCar);
        }

        private void btnResumeYellowCar_Click(object sender, EventArgs e)
        {
            btnResumeYellowCar.Enabled = false;
            btnSuspendYellowCar.Enabled = true;
            WinApiClass.ResumeThread((IntPtr)headerYellowCar);
        }

        private void btnSuspendYellowCar_Click(object sender, EventArgs e)
        {
            btnResumeYellowCar.Enabled = true;
            btnSuspendYellowCar.Enabled = false;
            WinApiClass.SuspendThread((IntPtr)headerYellowCar);
        }

        private void btnResumePedestrian_Click(object sender, EventArgs e)
        {

            btnResumePedestrian.Enabled = false;
            btnSuspendPedestrian.Enabled = true;

            WinApiClass.ResumeThread((IntPtr)headerPieton);
        }

        private void btnSuspendPedestrian_Click(object sender, EventArgs e)
        {

            btnResumePedestrian.Enabled = true;
            btnSuspendPedestrian.Enabled = false;
            WinApiClass.SuspendThread((IntPtr)headerPieton);
        }

        private void btnResumeTrafficLights1_Click(object sender, EventArgs e)
        {

            btnResumeTrafficLights1.Enabled = false;
            btnSuspendTrafficLights1.Enabled = true;
            WinApiClass.ResumeThread((IntPtr)headerSemafor1);
        }

        private void btnSuspendTrafficLights1_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights1.Enabled = true;
            btnSuspendTrafficLights1.Enabled = false;

            WinApiClass.SuspendThread((IntPtr)headerSemafor1);
        }

        private void btnResumeTrafficLights2_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights2.Enabled = false;
            btnSuspendTrafficLights2.Enabled = true;

            WinApiClass.ResumeThread((IntPtr)headerSemafor2);
        }

        private void btnSuspendTrafficLights2_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights2.Enabled = true;
            btnSuspendTrafficLights2.Enabled = false;

            WinApiClass.SuspendThread((IntPtr)headerSemafor2);
        }

        private void btnResumeTrafficLights3_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights3.Enabled = false;
            btnSuspendTrafficLights3.Enabled = true;

            WinApiClass.ResumeThread((IntPtr)headerSemafor3);
        }

        private void btnSuspendTrafficLights3_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights3.Enabled = true;
            btnSuspendTrafficLights3.Enabled = false;

            WinApiClass.SuspendThread((IntPtr)headerSemafor3);
        }

        private void btnResumeTrafficLights4_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights4.Enabled = false;
            btnSuspendTrafficLights4.Enabled = true;

            WinApiClass.ResumeThread((IntPtr)headerSemafor4);
        }

        private void btnSuspendTrafficLights4_Click(object sender, EventArgs e)
        {
            btnResumeTrafficLights4.Enabled = true;
            btnSuspendTrafficLights4.Enabled = false;

            WinApiClass.SuspendThread((IntPtr)headerSemafor4);
        }
    }
}
