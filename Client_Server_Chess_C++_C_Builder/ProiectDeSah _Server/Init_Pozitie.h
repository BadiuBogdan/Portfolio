//---------------------------------------------------------------------------

#ifndef Init_PozitieH
#define Init_PozitieH
#define C_REGE_ALB  6
#define C_REGINA_ALB        5
#define C_TURA_ALB  2
#define C_CAL_ALB   3
#define C_NEBUN_ALB 4
#define C_PION_ALB  1
#define C_TURA_NEGRU    -2
#define C_CAL_NEGRU     -3
#define C_NEBUN_NEGRU   -4
#define C_REGINA_NEGRU  -5
#define C_REGE_NEGRU    -6
#define C_PION_NEGRU    -1
#define C_GOL   0

#define Cord   48
#define Pas     64
#define DIM     8

class POZITIA_PIESELOR
{
protected:
int pozitie[DIM][DIM];
int x,y;
public:
        POZITIA_PIESELOR();


};
//---------------------------------------------------------------------------
#endif
