//---------------------------------------------------------------------------

#ifndef PrincipalH
#define PrincipalH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <jpeg.hpp>
#include "Joc.h"
#include <ScktComp.hpp>
//---------------------------------------------------------------------------
class TfMain : public TForm
{
__published:	// IDE-managed Components
        TImage *iBg;
        TLabel *lPlay;
        TLabel *lExit;
        TLabel *lText;
        TServerSocket *ssServer;
        void __fastcall lExitClick(TObject *Sender);
        void __fastcall lPlayClick(TObject *Sender);
        void __fastcall lPlayMouseEnter(TObject *Sender);
        void __fastcall lPlayMouseLeave(TObject *Sender);
        void __fastcall lExitMouseEnter(TObject *Sender);
        void __fastcall lExitMouseLeave(TObject *Sender);
        void __fastcall ssServerClientRead(TObject *Sender,
          TCustomWinSocket *Socket);
private:	// User declarations
        JOC *initializare_joc;
public:		// User declarations
        __fastcall TfMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfMain *fMain;
//---------------------------------------------------------------------------
#endif
