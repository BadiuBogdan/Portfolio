//---------------------------------------------------------------------------


#pragma hdrstop

#include "Tabla.h"
#include "Principal.h"
#include "USah.h"
 TABLA::TABLA()
{
        poza_tabla=new TImage(fSah);
        poza_tabla->Parent=fSah;
        poza_tabla->AutoSize=true;
        poza_tabla->Top=0;
        poza_tabla->Left=0;
        poza_tabla->Picture->LoadFromFile("Imagini\\Board.jpg");
}

//---------------------------------------------------------------------------

#pragma package(smart_init)
