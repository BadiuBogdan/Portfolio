//---------------------------------------------------------------------------


#pragma hdrstop

#include "Init_Pozitie.h"
#include "USah.h"
POZITIA_PIESELOR::POZITIA_PIESELOR()
{
    int matrice[DIM][DIM] =
                        {
                          {-2,-3,-4,-5,-6,-4,-3,-2},
                          {-1,-1,-1,-1,-1,-1,-1,-1},
                          { 0, 0, 0, 0, 0, 0, 0, 0},
                          { 0, 0, 0, 0, 0, 0, 0, 0},
                          { 0, 0, 0, 0, 0, 0, 0, 0},
                          { 0, 0, 0, 0, 0, 0, 0, 0},
                          { 1, 1, 1, 1, 1, 1, 1, 1},
                          { 2, 3, 4, 5, 6, 4, 3, 2}
                           };
                           for(int i=0;i<DIM;i++)
                           {
                           for(int j=0;j<DIM;j++)
                           {
                                this->pozitie[i][j]=matrice[i][j];
                           }
                           }

                         y=Cord;
                         x=Cord;


 }
//---------------------------------------------------------------------------

#pragma package(smart_init)
