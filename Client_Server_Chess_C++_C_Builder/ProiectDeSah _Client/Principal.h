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
        TClientSocket *csClient;
        TLabel *lConnect;
        void __fastcall lExitClick(TObject *Sender);
        void __fastcall lPlayClick(TObject *Sender);
        void __fastcall lPlayMouseEnter(TObject *Sender);
        void __fastcall lPlayMouseLeave(TObject *Sender);
        void __fastcall lExitMouseEnter(TObject *Sender);
        void __fastcall lExitMouseLeave(TObject *Sender);
        void __fastcall csClientRead(TObject *Sender,
          TCustomWinSocket *Socket);
        void __fastcall lConnectClick(TObject *Sender);
        void __fastcall lConnectMouseEnter(TObject *Sender);
        void __fastcall lConnectMouseLeave(TObject *Sender);
private:	// User declarations
          JOC *initializare_joc;
public:		// User declarations
        __fastcall TfMain(TComponent* Owner);
        
};
//---------------------------------------------------------------------------
extern PACKAGE TfMain *fMain;
//---------------------------------------------------------------------------
#endif
