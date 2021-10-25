//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "USah.h"
#include "Principal.h"
#include "Tabla.h"
#include "Joc.h"
#include <mmsystem.hpp>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfSah *fSah;
//---------------------------------------------------------------------------
__fastcall TfSah::TfSah(TComponent* Owner)
        : TForm(Owner)
{
        fSah->Color=RGB(135,60,21);
         if(joc==NULL)
         {
            sndPlaySound("sunetTabla.wav", SND_ASYNC);
         }
}
//---------------------------------------------------------------------------
void __fastcall TfSah::btnCancelClick(TObject *Sender)
{
sndPlaySound("buton.wav", SND_ASYNC);
        ModalResult=mrCancel;
        fMain->Show();

}
//---------------------------------------------------------------------------

void __fastcall TfSah::btnNewGameClick(TObject *Sender)
{
                if(joc!=NULL)     //Sterge piesele
                {
                delete joc;
                }
          
             joc=new JOC();
             joc->Initializare_Piese(); // Initializeza piesele pe tabla
             sndPlaySound("buton.wav", SND_ASYNC);
}
//---------------------------------------------------------------------------





