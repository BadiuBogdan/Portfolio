//---------------------------------------------------------------------------

#ifndef PieseH
#define PieseH

#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <jpeg.hpp>
class PIESE
{
    public:
    int linie_piesa, coloana_piesa;
    TImage *poza;
    void Muta_Piesele_pe_tabla(); //Muta piesele cu ajutorul evenimentelor dinamice
   PIESE();//Afisare piese
//-----------------------------------------------------------------------------------------
//Aceste metode sunt facute pentru a putea apela evenimentele pentru alocarea dinamica
        void __fastcall Ia_Piesa(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y); //Selectare piesa
        void __fastcall Pune_Piesa(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y);  //Unde se muta piesa
        void __fastcall Muta_Piesa(TObject *Sender,
      TShiftState Shift, int X, int Y); // Piesa urmareste cursorul
    ~PIESE();






};
//---------------------------------------------------------------------------
#endif
