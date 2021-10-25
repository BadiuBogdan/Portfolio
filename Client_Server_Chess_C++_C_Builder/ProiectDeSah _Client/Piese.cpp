
#pragma hdrstop

#include "Piese.h"
#include "USah.h"
#include "Principal.h"


void PIESE::Muta_Piesele_pe_tabla() //Functia muta piesele
{

                         poza->OnMouseDown=Ia_Piesa;
                       poza->OnMouseMove=Muta_Piesa;
                        poza->OnMouseUp=Pune_Piesa;



}
//------------------------------------------------------------------
// Functii eveniment pentru drag and drop

void __fastcall PIESE ::Ia_Piesa(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{

        TImage *im=dynamic_cast<TImage *>(Sender);//Se specifica ca este pentru obiecte dinamice

                  X =im->Top  ;    //Memoreaza unde este piesa
                   Y = im->Left  ;
                  im->Transparent=false;//Arata ce piesa am selectat



}
void __fastcall PIESE ::Pune_Piesa(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)

{
   sndPlaySound("sound.wav", SND_ASYNC);//Initializeaza sunetul cand lasam piesa
    TImage *im=dynamic_cast<TImage *>(Sender);  //Se specifica ca este pentru obiecte dinamice


                   X=im->Top  ;   //Lasa piesa unde vrei

                   Y=im->Left   ;

                  im->Transparent=true;//Face piesa transparenta
                  //Aici incepe codificarea pieselor pentru a le trimite pe retea
                  //Codifiica ce piesa si unde se muta ea
                   String top_Str=im->Top;
                  String linie_Str=linie_piesa;
                  String coloana_Str=coloana_piesa;
                  String left_Str=im->Left;
                  String send="";
                  send+=linie_Str;
                  send+=':';
                  send+=coloana_Str;
                  send+=':';
                  send+=top_Str;
                  send+=':';
                  send+=left_Str;
                  fMain->csClient->Socket->SendText(send);



}
void __fastcall PIESE::Muta_Piesa(TObject *Sender,
      TShiftState Shift, int X, int Y)

{
     //Aceasta functie face piesa sa urmareasca cursorul
        TImage *im=dynamic_cast<TImage *>(Sender);
        if(Shift.Contains(ssLeft)) // Folosim sintaxa din if pentru a urmari piesa
                                  //cand este pasat click stanga
        {
        int k,z;
    for(int i=0;i<2;i++)
        {

               im->Top =X  ;
                  X=k;
                  im->Left=Y ;
                  Y=z;
                  im->Transparent=true;
         
         }
           X=z;
          Y=k;




        }


}
//-----------------------------------------------------------------

PIESE::~PIESE ()
{

       delete poza;

}
PIESE::PIESE()
{

                          poza=new TImage(fSah);
                          poza->Parent=fSah;
                          poza->AutoSize=true;
                         poza->Transparent=true;





}


//---------------------------------------------------------------------------

#pragma package(smart_init)




