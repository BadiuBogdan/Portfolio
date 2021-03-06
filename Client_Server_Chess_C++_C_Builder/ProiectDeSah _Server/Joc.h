//---------------------------------------------------------------------------

#ifndef JocH
#define JocH

#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <jpeg.hpp>
#include "Tabla.h"
#include "Piese.h"
#include "Init_Pozitie.h"
class JOC:public POZITIA_PIESELOR
{
        TABLA *ImTabla;
        TLabel*pune_piesele_luate;
        public:
        PIESE *piese[DIM][DIM];
        void Afisare_Tabla();
        void Initializare_Piese();
        void Piese_Luate();  // Afiseaza label cu piese albe si piese negre
                                //pentru a stii unde se iau cele albe si cele negre
        ~JOC();

};
//---------------------------------------------------------------------------
#endif
