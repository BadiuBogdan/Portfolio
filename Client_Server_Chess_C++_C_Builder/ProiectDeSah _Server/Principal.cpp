//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Principal.h"
#include "USah.h"
#include "Tabla.h"
#include "Joc.h"
#include <mmsystem.hpp>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfMain *fMain;
//---------------------------------------------------------------------------
__fastcall TfMain::TfMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfMain::lExitClick(TObject *Sender)
{
        exit(0);        
}
//---------------------------------------------------------------------------
void __fastcall TfMain::lPlayClick(TObject *Sender)
{
        initializare_joc=new JOC();  //Instantiem obiectul joc
         initializare_joc->Afisare_Tabla();//Afiseaza tabla in forma Sah
         initializare_joc->Piese_Luate();
           fMain->Hide(); //Ascunde forma principala
        fSah->ShowModal(); //Deschide forma Sah
}
//---------------------------------------------------------------------------
void __fastcall TfMain::lPlayMouseEnter(TObject *Sender)
{
        lPlay->Font->Color=clYellow;
         lPlay->Font->Size+=6;
         sndPlaySound("buton.wav", SND_ASYNC);
}
//---------------------------------------------------------------------------

void __fastcall TfMain::lPlayMouseLeave(TObject *Sender)
{

        lPlay->Font->Color=clWhite;
        lPlay->Font->Size=24;
}
//---------------------------------------------------------------------------

void __fastcall TfMain::lExitMouseEnter(TObject *Sender)
{
        lExit->Font->Color=clYellow;
        lExit->Font->Size+=6;
        sndPlaySound("buton.wav", SND_ASYNC);
}
//---------------------------------------------------------------------------

void __fastcall TfMain::lExitMouseLeave(TObject *Sender)
{
        lExit->Font->Color=clWhite;
        lExit->Font->Size=24;        
}
//---------------------------------------------------------------------------







void __fastcall TfMain::ssServerClientRead(TObject *Sender,
      TCustomWinSocket *Socket)
{
String instr=Socket->ReceiveText();
        char *str=instr.c_str();
        String linie_String="";
        String coloana_String="";
        String top_String="";
        String left_String="";

        bool rand_decodare[4];
        rand_decodare[0] = true;
        rand_decodare[1] = false;
        rand_decodare[2] = false;
        rand_decodare[3] = false;

        for(int i = 0; i < instr.Length(); i++)
        {
                if(rand_decodare[0] == true)
                {
                        if(str[i] != ':')
                                linie_String += str[i];

                           else
                        {
                       rand_decodare[0] = false;
                        rand_decodare[1] = true;
                        i++;
                        }
                }
                if(rand_decodare[1] == true)
                {
                        if(str[i] != ':')
                                coloana_String += str[i];

                else
                {
                        rand_decodare[1] = false;
                        rand_decodare[2] = true;
                        i++;
                }
                }
                if(rand_decodare[2] == true)
                {
                        if(str[i] != ':')
                                top_String += str[i];

                else
                {
                       rand_decodare[2] = false;
                        rand_decodare[3] = true;
                        i++;
                }
                }
                if(rand_decodare[3] == true)
                {
                        if(str[i] != ':')
                                left_String += str[i];

                else
                {
                       rand_decodare[3] = false;
                        break;
                }
                }
        }

        int linie_decodata = StrToInt(linie_String);
        int coloana_decodata = StrToInt(coloana_String);
        int top_decodat = StrToInt(top_String);
        int left_decodat = StrToInt(left_String);
        fSah->joc->piese[linie_decodata][coloana_decodata]->poza->Top=top_decodat;
        fSah->joc->piese[linie_decodata][coloana_decodata]->poza->Left=left_decodat;        
}
//---------------------------------------------------------------------------

