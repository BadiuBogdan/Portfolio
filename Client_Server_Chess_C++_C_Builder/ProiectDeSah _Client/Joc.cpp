//---------------------------------------------------------------------------


#pragma hdrstop

#include "Joc.h"
#include "USah.h"
void JOC::Afisare_Tabla()
{
        ImTabla=new TABLA();

}
void JOC::Initializare_Piese()
{
 for(int i=0;i<DIM;i++)
        {
                for(int j=0;j<DIM;j++)
                {
                           piese[i][j]=new PIESE();
                           piese[i][j]->Muta_Piesele_pe_tabla();
                            piese[i][j]->linie_piesa=i;
                            piese[i][j]->coloana_piesa=j;
                            piese[i][j]->poza->Top=y;
                            piese[i][j]->poza->Left=x;

                         if(pozitie[i][j]==C_TURA_NEGRU)
                        {
                        piese[i][j]->poza->Picture->LoadFromFile("Imagini\\TuraNegru.bmp");

                        }
                if(pozitie[i][j]==C_CAL_NEGRU)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\CalNegru.bmp");

                        }
                if(pozitie[i][j]==C_NEBUN_NEGRU)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\NebunNegru.bmp");

                        }
                if(pozitie[i][j]==C_REGE_NEGRU)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\RegeNegru.bmp");

                        }
                if(pozitie[i][j]==C_REGINA_NEGRU)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\ReginaNegru.bmp");

                        }
                if(pozitie[i][j]==C_PION_NEGRU)
                        {
                               piese[i][j]->poza->Picture->LoadFromFile("Imagini\\PionNegru.bmp");

                        }
                if(pozitie[i][j]==C_TURA_ALB)
                        {
                        piese[i][j]->poza->Picture->LoadFromFile("Imagini\\TuraAlb.bmp");

                        }
                if(pozitie[i][j]==C_CAL_ALB)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\CalAlb.bmp");

                        }
                if(pozitie[i][j]==C_NEBUN_ALB)
                        {
                               piese[i][j]->poza->Picture->LoadFromFile("Imagini\\NebunAlb.bmp");

                        }
                if(pozitie[i][j]==C_REGE_ALB)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\RegeALb.bmp");

                        }
                if(pozitie[i][j]==C_REGINA_ALB)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\ReginaAlb.bmp");

                        }
                if(pozitie[i][j]==C_PION_ALB)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\PionAlb.bmp");

                        }

                if(pozitie[i][j]==C_PION_ALB)
                        {
                                piese[i][j]->poza->Picture->LoadFromFile("Imagini\\PionAlb.bmp");

                        }
                if(pozitie[i][j]==C_GOL)
                        {
                                piese[i][j]->poza->Picture=NULL;

                        }

                x+=Pas;//Aici se schimba linia
                }
                x=Cord; //Aici revine linia la forma initiala
                        //pentru a incepe de la inceput pe coloana urmatoare
               y+=Pas; //Se schimba coloana

                        }



}
void JOC::Piese_Luate()
{
      pune_piesele_luate=new TLabel(fSah);
      pune_piesele_luate->Parent=fSah;
      pune_piesele_luate->Top=0;
      pune_piesele_luate->Left=700;
      pune_piesele_luate->Caption="Piese Negre";
      pune_piesele_luate->Font->Size=24;
      pune_piesele_luate=new TLabel(fSah);
      pune_piesele_luate->Parent=fSah;
      pune_piesele_luate->Top=350;
      pune_piesele_luate->Left=700;
      pune_piesele_luate->Caption="Piese Albe";
      pune_piesele_luate->Font->Color=clWhite;
      pune_piesele_luate->Font->Size=24;

}


JOC::~JOC()
{
        for(int i=0;i<DIM;i++)
        {
                for(int j=0;j<DIM;j++)
                {
                        delete piese[i][j];
                }
        }
}

//---------------------------------------------------------------------------

#pragma package(smart_init)
