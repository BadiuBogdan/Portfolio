/* Programul afiseaza o corabie care se invarte in jurul unei insule
 
 */
#include "glos.h"

#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>
int merge = 0;
int merge2 = 0;
int merge3 = 0;
int palmier = 0;
int ct = 0;
 GLfloat soare  = 0;
 GLfloat soare2 = 0;
 GLfloat soare3 = 0;
 GLfloat beta = 0;
 GLfloat z = 0;
GLdouble taiere_insula[4] = { 0.0, 1.0, 0.0, -4.5 };
GLfloat light_position[] = { 1.0 , 1.0 , 1.0, 1.0 };
static GLfloat poz_light_position[] = { -90.0 , 45.0 , 10.0, 1.0 };
void myinit(void);
void initlights(void);
void CALLBACK Miscare(void);
void CALLBACK Misca_tot(void);
void CALLBACK myReshape(GLsizei w, GLsizei h);
void CALLBACK display(void);
void CALLBACK muta_soare_x(void);
void CALLBACK rotire_corabie_fata(void);
void CALLBACK rotire_corabie_spate(void);
void CALLBACK muta_soare_x2(void);
void CALLBACK muta_soare_y(void);
/*
	// O incercare nereusita de umbra ":-(("

void MatriceUmbra(GLfloat puncte[3][3], GLfloat pozSursa[4],
	GLfloat mat[4][4]);
void calcCoeficientiPlan(float P[3][3], float coef[4]);
void calcCoeficientiPlan(float P[3][3], float coef[4])
{
	float v1[3], v2[3];
	float length;
	static const int x = 0;
	static const int y = 1;
	static const int z = 2;
	//calculeazã doi vectori din trei puncte
	v1[x] = P[0][x] - P[1][x];
	v1[y] = P[0][y] - P[1][y];
	v1[z] = P[0][z] - P[1][z];

	v2[x] = P[1][x] - P[2][x];
	v2[y] = P[1][y] - P[2][y];
	v2[z] = P[1][z] - P[2][z];

	//se cacluleazã produsul vectorial al celor doi vectori
	// care reprezintã un al treilea vector perpendicular pe plan 
	// ale cãrui componente sunt chiar coeficienþii A, B, C din ecuaþia planului
	coef[x] = v1[y] * v2[z] - v1[z] * v2[y];
	coef[y] = v1[z] * v2[x] - v1[x] * v2[z];
	coef[x] = v1[x] * v2[y] - v1[y] * v2[x];
	//normalizeazã vectorul
	length = (float)sqrt((coef[x] * coef[x]) + (coef[y] * coef[y]) + (coef[z] * coef[z]));
	coef[x] /= length;
	coef[y] /= length;
	coef[z] /= length;
}
//creazã matricea care dã umbra cunoscându-se coeficienþii planului ºi 
//poziþia sursei. În mat se salveazã matricea.
void MatriceUmbra(GLfloat puncte[3][3], GLfloat pozSursa[4],
	GLfloat mat[4][4])
{
	GLfloat coefPlan[4];
	GLfloat temp;
	//determinã coeficienþii planului
	calcCoeficientiPlan(puncte, coefPlan);
	//determinã si pe D
	coefPlan[3] = -(
		(coefPlan[0] * puncte[2][0]) +
		(coefPlan[1] * puncte[2][1]) +
		(coefPlan[2] * puncte[2][2]));
	//temp=A*xL+B*yL+C*zL+D*w
	temp = coefPlan[0] * pozSursa[0] +
		coefPlan[1] * pozSursa[1] +
		coefPlan[2] * pozSursa[2] +
		coefPlan[3] * pozSursa[3];
	//prima coloanã
	mat[0][0] = temp - pozSursa[0] * coefPlan[0];
	mat[1][0] = 0.0f - pozSursa[0] * coefPlan[1];
	mat[2][0] = 0.0f - pozSursa[0] * coefPlan[2];
	mat[3][0] = 0.0f - pozSursa[0] * coefPlan[3];
	//a doua coloana
	mat[0][1] = 0.0f - pozSursa[1] * coefPlan[0];
	mat[1][1] = temp - pozSursa[1] * coefPlan[1];
	mat[2][1] = 0.0f - pozSursa[1] * coefPlan[2];
	mat[3][1] = 0.0f - pozSursa[1] * coefPlan[3];
	//a treia coloana
	mat[0][2] = 0.0f - pozSursa[2] * coefPlan[0];
	mat[1][2] = 0.0f - pozSursa[2] * coefPlan[1];
	mat[2][2] = temp - pozSursa[2] * coefPlan[2];
	mat[3][2] = 0.0f - pozSursa[2] * coefPlan[3];
	//a patra coloana
	mat[0][3] = 0.0f - pozSursa[3] * coefPlan[0];
	mat[1][3] = 0.0f - pozSursa[3] * coefPlan[1];
	mat[2][3] = 0.0f - pozSursa[3] * coefPlan[2];
	mat[3][3] = temp - pozSursa[3] * coefPlan[3];
}*/
void CALLBACK Miscare(void) {
	if (ct == 0) {
		ct++;
		if (palmier > -3)
		{

			palmier = -3;
		}
		else
			palmier = 3;
	}
	else {
		ct++;
		if (ct == 5)
		{
			ct = 0;
		}
	}
}
void CALLBACK muta_soare_x(void)
{
	Miscare();
	if (soare <= 189){
		soare += 3;
	}
}
void CALLBACK muta_soare_x2(void)
{
	Miscare();
	if (soare >= -12){
		soare -= 3;
	}
}
void CALLBACK muta_soare_y(void)
{
	Miscare();
	if (soare2 <= 6)
	{
		soare2 += 3;
	}
	
}
void CALLBACK muta_soare_y2(void)
{
	Miscare();
	if (soare2 >= -33)
	{
		soare2 -= 3;
	}
	
}

void CALLBACK rotire_soare(void)
{
	Miscare();
	soare3 += 30;

}
void CALLBACK rotire_corabie_fata(void)
{
	Miscare();
	merge = (merge + 3) % 360;
	
	
}
void CALLBACK rotire_corabie_spate(void)
{
	Miscare();
	merge = (merge - 3) % 360;
	

}
void CALLBACK rotire_rechin_fata(void)
{
	
	merge2 = (merge2 + 3) % 360;
	merge3 = (merge3 - 3) % 360;


}
void CALLBACK rotire_rechin_fata_btn(void)
{

	merge2 = (merge2 + 3) % 360;
	merge3 = (merge3 - 3) % 360;
	display();
	Sleep(40);


}



void CALLBACK rotire_rechin_spate(void)
{
	
	merge2 = (merge2 - 3) % 360;
	merge3 = (merge3 + 3) % 360;


}
void CALLBACK rotire_ambele_fata(void)
{
	Miscare();
	merge = (merge + 3) % 360;
	merge2 = (merge2 + 3) % 360;
	merge3 = (merge3 - 3) % 360;


}



void CALLBACK rotire_ambele_spate(void)
{
	Miscare();
	merge = (merge - 3) % 360;
	merge2 = (merge2 - 3) % 360;
	merge3 = (merge3 + 3) % 360;


}

void CALLBACK Misca_tot(void) {
	rotire_ambele_fata();
	display();
	Sleep(40);

}

void CALLBACK Misca_rechin_btn(void) {
	auxIdleFunc(rotire_rechin_fata_btn);
}
void CALLBACK Misca_tot_btn(void) {
	auxIdleFunc(Misca_tot);
}
void CALLBACK Opreste(void) {
	auxIdleFunc(NULL);
}
void CALLBACK Roteste_tot_1(void) {
	beta += 5;
}
void CALLBACK Roteste_tot_2(void) {
	beta -= 5;
}

///Pentru a-mi scrie numele in interior
//tabloul contine toate caracterele, pe 13 rânduri si 2 octeti lãtime
GLubyte rasters[][13] = {
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x18, 0x18, 0x00, 0x00, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18 },
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x36, 0x36, 0x36 },
	{ 0x00, 0x00, 0x00, 0x66, 0x66, 0xff, 0x66, 0x66, 0xff, 0x66, 0x66, 0x00, 0x00 },
	{ 0x00, 0x00, 0x18, 0x7e, 0xff, 0x1b, 0x1f, 0x7e, 0xf8, 0xd8, 0xff, 0x7e, 0x18 },
	{ 0x00, 0x00, 0x0e, 0x1b, 0xdb, 0x6e, 0x30, 0x18, 0x0c, 0x76, 0xdb, 0xd8, 0x70 },
	{ 0x00, 0x00, 0x7f, 0xc6, 0xcf, 0xd8, 0x70, 0x70, 0xd8, 0xcc, 0xcc, 0x6c, 0x38 },
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x1c, 0x0c, 0x0e },
	{ 0x00, 0x00, 0x0c, 0x18, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x18, 0x0c },
	{ 0x00, 0x00, 0x30, 0x18, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x18, 0x30 },
	{ 0x00, 0x00, 0x00, 0x00, 0x99, 0x5a, 0x3c, 0xff, 0x3c, 0x5a, 0x99, 0x00, 0x00 },
	{ 0x00, 0x00, 0x00, 0x18, 0x18, 0x18, 0xff, 0xff, 0x18, 0x18, 0x18, 0x00, 0x00 },
	{ 0x00, 0x00, 0x30, 0x18, 0x1c, 0x1c, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x00, 0x38, 0x38, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x60, 0x60, 0x30, 0x30, 0x18, 0x18, 0x0c, 0x0c, 0x06, 0x06, 0x03, 0x03 },
	{ 0x00, 0x00, 0x3c, 0x66, 0xc3, 0xe3, 0xf3, 0xdb, 0xcf, 0xc7, 0xc3, 0x66, 0x3c },
	{ 0x00, 0x00, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78, 0x38, 0x18 },
	{ 0x00, 0x00, 0xff, 0xc0, 0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x03, 0xe7, 0x7e },
	{ 0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x07, 0x7e, 0x07, 0x03, 0x03, 0xe7, 0x7e },
	{ 0x00, 0x00, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0xff, 0xcc, 0x6c, 0x3c, 0x1c, 0x0c },
	{ 0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x07, 0xfe, 0xc0, 0xc0, 0xc0, 0xc0, 0xff },
	{ 0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xc7, 0xfe, 0xc0, 0xc0, 0xc0, 0xe7, 0x7e },
	{ 0x00, 0x00, 0x30, 0x30, 0x30, 0x30, 0x18, 0x0c, 0x06, 0x03, 0x03, 0x03, 0xff },
	{ 0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xe7, 0x7e, 0xe7, 0xc3, 0xc3, 0xe7, 0x7e },
	{ 0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x03, 0x7f, 0xe7, 0xc3, 0xc3, 0xe7, 0x7e },
	{ 0x00, 0x00, 0x00, 0x38, 0x38, 0x00, 0x00, 0x38, 0x38, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x30, 0x18, 0x1c, 0x1c, 0x00, 0x00, 0x1c, 0x1c, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x06, 0x0c, 0x18, 0x30, 0x60, 0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06 },
	{ 0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0x00, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x03, 0x06, 0x0c, 0x18, 0x30, 0x60 },
	{ 0x00, 0x00, 0x18, 0x00, 0x00, 0x18, 0x18, 0x0c, 0x06, 0x03, 0xc3, 0xc3, 0x7e },
	{ 0x00, 0x00, 0x3f, 0x60, 0xcf, 0xdb, 0xd3, 0xdd, 0xc3, 0x7e, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xc3, 0xc3, 0xc3, 0xc3, 0xff, 0xc3, 0xc3, 0xc3, 0x66, 0x3c, 0x18 },
	{ 0x00, 0x00, 0xfe, 0xc7, 0xc3, 0xc3, 0xc7, 0xfe, 0xc7, 0xc3, 0xc3, 0xc7, 0xfe },
	{ 0x00, 0x00, 0x7e, 0xe7, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xe7, 0x7e },
	{ 0x00, 0x00, 0xfc, 0xce, 0xc7, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc7, 0xce, 0xfc },
	{ 0x00, 0x00, 0xff, 0xc0, 0xc0, 0xc0, 0xc0, 0xfc, 0xc0, 0xc0, 0xc0, 0xc0, 0xff },
	{ 0x00, 0x00, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xfc, 0xc0, 0xc0, 0xc0, 0xff },
	{ 0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xcf, 0xc0, 0xc0, 0xc0, 0xc0, 0xe7, 0x7e },
	{ 0x00, 0x00, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xff, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3 },
	{ 0x00, 0x00, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7e },
	{ 0x00, 0x00, 0x7c, 0xee, 0xc6, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06, 0x06 },
	{ 0x00, 0x00, 0xc3, 0xc6, 0xcc, 0xd8, 0xf0, 0xe0, 0xf0, 0xd8, 0xcc, 0xc6, 0xc3 },
	{ 0x00, 0x00, 0xff, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0 },
	{ 0x00, 0x00, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xdb, 0xff, 0xff, 0xe7, 0xc3 },
	{ 0x00, 0x00, 0xc7, 0xc7, 0xcf, 0xcf, 0xdf, 0xdb, 0xfb, 0xf3, 0xf3, 0xe3, 0xe3 },
	{ 0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xe7, 0x7e },
	{ 0x00, 0x00, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xfe, 0xc7, 0xc3, 0xc3, 0xc7, 0xfe },
	{ 0x00, 0x00, 0x3f, 0x6e, 0xdf, 0xdb, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0x66, 0x3c },
	{ 0x00, 0x00, 0xc3, 0xc6, 0xcc, 0xd8, 0xf0, 0xfe, 0xc7, 0xc3, 0xc3, 0xc7, 0xfe },
	{ 0x00, 0x00, 0x7e, 0xe7, 0x03, 0x03, 0x07, 0x7e, 0xe0, 0xc0, 0xc0, 0xe7, 0x7e },
	{ 0x00, 0x00, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0xff },
	{ 0x00, 0x00, 0x7e, 0xe7, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3 },
	{ 0x00, 0x00, 0x18, 0x3c, 0x3c, 0x66, 0x66, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3 },
	{ 0x00, 0x00, 0xc3, 0xe7, 0xff, 0xff, 0xdb, 0xdb, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3 },
	{ 0x00, 0x00, 0xc3, 0x66, 0x66, 0x3c, 0x3c, 0x18, 0x3c, 0x3c, 0x66, 0x66, 0xc3 },
	{ 0x00, 0x00, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x3c, 0x3c, 0x66, 0x66, 0xc3 },
	{ 0x00, 0x00, 0xff, 0xc0, 0xc0, 0x60, 0x30, 0x7e, 0x0c, 0x06, 0x03, 0x03, 0xff },
	{ 0x00, 0x00, 0x3c, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x3c },
	{ 0x00, 0x03, 0x03, 0x06, 0x06, 0x0c, 0x0c, 0x18, 0x18, 0x30, 0x30, 0x60, 0x60 },
	{ 0x00, 0x00, 0x3c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x3c },
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xc3, 0x66, 0x3c, 0x18 },
	{ 0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x38, 0x30, 0x70 },
	{ 0x00, 0x00, 0x7f, 0xc3, 0xc3, 0x7f, 0x03, 0xc3, 0x7e, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xfe, 0xc3, 0xc3, 0xc3, 0xc3, 0xfe, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0 },
	{ 0x00, 0x00, 0x7e, 0xc3, 0xc0, 0xc0, 0xc0, 0xc3, 0x7e, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x7f, 0xc3, 0xc3, 0xc3, 0xc3, 0x7f, 0x03, 0x03, 0x03, 0x03, 0x03 },
	{ 0x00, 0x00, 0x7f, 0xc0, 0xc0, 0xfe, 0xc3, 0xc3, 0x7e, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x30, 0x30, 0x30, 0x30, 0x30, 0xfc, 0x30, 0x30, 0x30, 0x33, 0x1e },
	{ 0x7e, 0xc3, 0x03, 0x03, 0x7f, 0xc3, 0xc3, 0xc3, 0x7e, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xc3, 0xfe, 0xc0, 0xc0, 0xc0, 0xc0 },
	{ 0x00, 0x00, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00, 0x00, 0x18, 0x00 },
	{ 0x38, 0x6c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x0c, 0x00, 0x00, 0x0c, 0x00 },
	{ 0x00, 0x00, 0xc6, 0xcc, 0xf8, 0xf0, 0xd8, 0xcc, 0xc6, 0xc0, 0xc0, 0xc0, 0xc0 },
	{ 0x00, 0x00, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78 },
	{ 0x00, 0x00, 0xdb, 0xdb, 0xdb, 0xdb, 0xdb, 0xdb, 0xfe, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xfc, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x7c, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0x7c, 0x00, 0x00, 0x00, 0x00 },
	{ 0xc0, 0xc0, 0xc0, 0xfe, 0xc3, 0xc3, 0xc3, 0xc3, 0xfe, 0x00, 0x00, 0x00, 0x00 },
	{ 0x03, 0x03, 0x03, 0x7f, 0xc3, 0xc3, 0xc3, 0xc3, 0x7f, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xe0, 0xfe, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xfe, 0x03, 0x03, 0x7e, 0xc0, 0xc0, 0x7f, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x1c, 0x36, 0x30, 0x30, 0x30, 0x30, 0xfc, 0x30, 0x30, 0x30, 0x00 },
	{ 0x00, 0x00, 0x7e, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x18, 0x3c, 0x3c, 0x66, 0x66, 0xc3, 0xc3, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xc3, 0xe7, 0xff, 0xdb, 0xc3, 0xc3, 0xc3, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xc3, 0x66, 0x3c, 0x18, 0x3c, 0x66, 0xc3, 0x00, 0x00, 0x00, 0x00 },
	{ 0xc0, 0x60, 0x60, 0x30, 0x18, 0x3c, 0x66, 0x66, 0xc3, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0xff, 0x60, 0x30, 0x18, 0x0c, 0x06, 0xff, 0x00, 0x00, 0x00, 0x00 },
	{ 0x00, 0x00, 0x0f, 0x18, 0x18, 0x18, 0x38, 0xf0, 0x38, 0x18, 0x18, 0x18, 0x0f },
	{ 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18 },
	{ 0x00, 0x00, 0xf0, 0x18, 0x18, 0x18, 0x1c, 0x0f, 0x1c, 0x18, 0x18, 0x18, 0xf0 },
	{ 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x8f, 0xf1, 0x60, 0x00, 0x00, 0x00 }
};

GLuint fontOffset;
void makeRasterFont(void)
{
	GLuint i;
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);

	fontOffset = glGenLists(128);
	for (i = 32; i < 127; i++) {
		glNewList(i + fontOffset, GL_COMPILE);
		glBitmap(8, 13, 0.0, 2.0, 10.0, 0.0, rasters[i - 32]);
		glEndList();
	}
}
void printString(char *s)
{
	glPushAttrib(GL_LIST_BIT);
	glListBase(fontOffset);
	glCallLists(strlen(s), GL_UNSIGNED_BYTE, (GLubyte *)s);
	glPopAttrib();
}
///-----------------------------------------------------------------------

// tabloul ctrlpoints defineste cele 16 puncte de control ale suprafetei pentru baza barci
GLfloat ctrlpoints_baza_barca[4][4][3] = {
			//x1				//x2				//x3				//x4
	{ { -0.7, -1.0, 0.0 },{ -0.3, -2.5, -0.4},{ 0.3, -2.5, -0.4},{ 0.7, -1.0, 0.0 } },
			//x5				//x6				//x7				//x8
	{ { -1.1, -0.8, 0.0 },{ -0.5, -2.0, 3.0 },{ 0.5, -2.0, 3.0 },{ 1.1, -0.8, 0.0 } },
			//x9				//x10				//x11				//x12
	{ { -1.1, 2.3, 0.0 },{ -1.0, 2.7, 1.5 },{ 1.0, 2.7, 1.5 },{ 1.1, 2.3, 0.0 } },
			//x13				//x14				//x15				//x16
	{ { -0.7, 2.5, 0.0 },{ -0.5, 3.0, 0.0 },{ 0.5, 3.0, 0.0 },{ 0.7, 2.5, 0.0 } },
};
// tabloul ctrlpoints defineste cele 16 puncte de control ale suprafetei pentru panzele mari ale vaporului
GLfloat ctrlpoints_panza_mare[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.9, -0.93, 0.0 },{ -0.1, -0.93, 0.0 },{ 0.1, -0.93, 0.0 },{ 0.9, -0.93, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -0.9, -0.8, 0.2 },{ -0.1, -0.8, 0.2},{ 0.1, -0.8, 0.2 },{ 0.9, -0.8, 0.2 } },
	//x9				//x10				//x11				//x12
	{ { -0.9, -0.1, 0.2 },{ -0.1, -0.1, 0.2},{ 0.1, -0.1, 0.2 },{ 0.9, -0.1, 0.2 } },
	//x13				//x14				//x15				//x16
	{ { -0.9, 0.0, 0.0 },{ -0.1, 0.0, 0.0 },{ 0.1, 0.0, 0.0 },{ 0.9, 0.0, 0.0 } },
};
// tabloul ctrlpoints defineste cele 16 puncte de control ale suprafetei pentru panzele mici ale vaporului
GLfloat ctrlpoints_panza_mica[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.9, -0.7, 0.0 },{ -0.1, -0.7, 0.0 },{ 0.1, -0.7, 0.0 },{ 0.9, -0.7, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -0.9, -0.65, 0.5 },{ -0.1, -0.65, 0.5 },{ 0.1, -0.65, 0.5 },{ 0.9, -0.65, 0.5 } },
	//x9				//x10				//x11				//x12 
	{ { -0.9, -0.15, 0.5 },{ -0.1, -0.15, 0.5 },{ 0.1, -0.15, 0.5 },{ 0.9, -0.15, 0.5 } },
	//x13				//x14				//x15				//x16
	{ { -0.9, -0.1, 0.0 },{ -0.1, -0.1, 0.0 },{ 0.1, -0.1, 0.0 },{ 0.9, -0.1, 0.0 } },
};
// tabloul ctrlpoints defineste cele 16 puncte de control ale suprafetei pentru puntea barcii
GLfloat ctrlpoints_punte[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.7, -1.0, 0.0 },{ -0.3, -2.5, -0.4 },{ 0.3, -2.5, -0.4 },{ 0.7, -1.0, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -1.1, -0.8, 0.0 },{ -0.5, -2.0, 0.1 },{ 0.5, -2.0, 0.1 },{ 1.1, -0.8, 0.0 } },
	//x9				//x10				//x11				//x12
	{ { -1.1, 2.3, 0.0 },{ -1.0, 2.7, 0.3 },{ 1.0, 2.7, 0.3 },{ 1.1, 2.3, 0.0 } },
	//x13				//x14				//x15				//x16
	{ { -0.7, 2.5, 0.0 },{ -0.5, 3.0, 0.0 },{ 0.5, 3.0, 0.0 },{ 0.7, 2.5, 0.0 } },
};
// tabloul ctrlpoints defineste cele 16 puncte de control ale suprafetei pentru steag
GLfloat ctrlpoints_steag[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.4, -0.7, 0.0 },{ -0.1, -0.7, 0.3 },{ 0.1, -0.7, -0.3 },{ 0.4, -0.7, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -0.4, -0.65, 0.0 },{ -0.1, -0.65, 0.3 },{ 0.1, -0.65, -0.3 },{ 0.4, -0.65, 0.0 } },
	//x9				//x10				//x11				//x12
	{ { -0.4, -0.15, 0.0 },{ -0.1, -0.15, 0.3 },{ 0.1, -0.15, -0.3 },{ 0.4, -0.15, 0.0 } },
	//x13				//x14				//x15				//x16
	{ { -0.4, -0.1, 0.0 },{ -0.1, -0.1, 0.3 },{ 0.1, -0.1, -0.3 },{ 0.4, -0.1, 0.0 } },
};
GLfloat ctrlpoints_copac_fata[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.9, -12, 0.0 },{ -0.1, -12, 1.0 },{ 0.1, -12, 1.0 },{ 0.9, -12, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -4.2, -4, 0.0 },{ -3.6, -4, 1.0 },{ -2.8, -4, 1.0 },{ -2.2, -4, 0.0 } },
	//x9				//x10				//x11				//x12
	{ { -4.4, 6, 0.0 },{ -3.8, 6, 1.0 },{ -3.0, -1, 1.0 },{ -2.4, 6, 0.0 } },
	//x13				//x14				//x15				//x16
	{ { -0.9, 12.0, 0.0 },{ -0.1, 12.0, 1.0 },{ 0.1, 12.0, 1.0 },{ 0.9, 12.0, 0.0 } },
};
GLfloat ctrlpoints_copac_spate[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.9, -12, 0.0 },{ -0.1, -12, -1.0 },{ 0.1, -12, -1.0 },{ 0.9, -12, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -4.2, -4, 0.0 },{ -3.6, -4, -1.0 },{ -2.8, -4, -1.0 },{ -2.2, -4, 0.0 } },
	//x9				//x10				//x11				//x12
	{ { -4.4, 6, 0.0 },{ -3.8, 6, -1.0 },{ -3.0, -1, -1.0 },{ -2.4, 6, 0.0 } },
	//x13				//x14				//x15				//x16
	{ { -0.9, 12.0, 0.0 },{ -0.1, 12.0, -1.0 },{ 0.1, 12.0, -1.0 },{ 0.9, 12.0, 0.0 } },
};
GLfloat ctrlpoints_frunze[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -0.3, -0.7, 0.0 },{ -0.1, -2.0, 0.0 },{ 0.1, -2.0, 0.0 },{ 0.3, -0.7, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -0.3, -0.3, 0.0 },{ -0.1, -1.5, 0.0 },{ 0.1, -1.5, 0.0},{ 0.3, -0.3, 0.0 } },
	//x9				//x10				//x11				//x12
	{ { -0.3, -0.15, 0.0 },{ -0.1, 0.9, 0.0 },{ 0.1, 0.9, 0.0 },{ 0.3, -0.15, 0.0 } },
	//x13				//x14				//x15				//x16
	{ { -0.3, -0.1, 0.0 },{ -0.1, 1.2, 0.0 },{ 0.1, 1.2, 0.0 },{ 0.3, -0.1, 0.0 } },
};
void Deseneaza_cerul() {

	GLUquadricObj *obj;			//Declarare obiect pentru cvadrice
	obj = gluNewQuadric();
	glScalef(1.8, 1.8, 1.8);
	//Deseneaza cerul 
	glPushMatrix();
		gluQuadricDrawStyle(obj, GLU_FILL);
		glTranslatef(0.0, 146.0, -55.0);
		glColor3d(0.0, 0.498039, 1.0);
		glRotatef(45, 0.0, 0.0, 1.0);
		gluDisk(obj, 0.0, 200, 4, 10);
	glPopMatrix();
	//--------------------------------
	//Deseneaza soarele
	glPushMatrix();
		glDisable(GL_LIGHTING);
		gluQuadricDrawStyle(obj, GLU_FILL);
		glColor3d(0.858824, 0.858824, 0.439216);
		glTranslatef(-90.0+soare, 45.0+soare2, 10.0);
		gluSphere(obj, 5, 40, 40);
		glEnable(GL_LIGHTING);
	glPopMatrix();
	//--------------------------------------
}

///Se fac Functii pentru fiecare suprafata
void Baza_barca(){
	glEnable(GL_DEPTH_TEST);
	glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
		0, 1, 12, 4, &ctrlpoints_baza_barca[0][0][0]);
	glEnable(GL_MAP2_VERTEX_3);
	glEnable(GL_AUTO_NORMAL);
	glEnable(GL_NORMALIZE);
	glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
	glColor3d(0.35, 0.16, 0.14);
	glEvalMesh2(GL_FILL, 0, 20, 0, 20);
}
void Panza_mare() {
	glEnable(GL_DEPTH_TEST);
	glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
		0, 1, 12, 4, &ctrlpoints_panza_mare[0][0][0]);
	glEnable(GL_MAP2_VERTEX_3);
	glEnable(GL_AUTO_NORMAL);
	glEnable(GL_NORMALIZE);
	glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
	glColor3d(0.8, 0.8, 0.8);
	glEvalMesh2(GL_FILL, 0, 20, 0, 20);
}
void Panza_mica() {
	glEnable(GL_DEPTH_TEST);
	glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
		0, 1, 12, 4, &ctrlpoints_panza_mica[0][0][0]);
	glEnable(GL_MAP2_VERTEX_3);
	glEnable(GL_AUTO_NORMAL);
	glEnable(GL_NORMALIZE);
	glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
	glColor3d(0.8, 0.8, 0.8);
	glEvalMesh2(GL_FILL, 0, 20, 0, 20);
}
void Punte() {
	glEnable(GL_DEPTH_TEST);
	glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
		0, 1, 12, 4, &ctrlpoints_punte[0][0][0]);
	glEnable(GL_MAP2_VERTEX_3);
	glEnable(GL_AUTO_NORMAL);
	glEnable(GL_NORMALIZE);
	glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
	glColor3d(0.52, 0.37, 0.26);
	glEvalMesh2(GL_FILL, 0, 20, 0, 20);
}
void Steag() {
	glEnable(GL_DEPTH_TEST);
	glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
		0, 1, 12, 4, &ctrlpoints_steag[0][0][0]);
	glEnable(GL_MAP2_VERTEX_3);
	glEnable(GL_AUTO_NORMAL);
	glEnable(GL_NORMALIZE);
	glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
	glColor3d(0.1, 0.1, 0.1);
	glEvalMesh2(GL_FILL, 0, 20, 0, 20);
}
///-----------------------------------------------------------------------
///Aici se deseneaza Barca cu ajutorul Suprafetei Bezier si a Cvadricelor
void Vapor() {

	glEnable(GL_DEPTH_TEST);	//Pentru ascunderea suprafetelor
	glDisable(GL_CLIP_PLANE3);
	GLUquadricObj *obj;			//Declarare obiect pentru cvadrice
	obj = gluNewQuadric();

	glScalef(15.5, 15.5, 15.5);

	Baza_barca();				//Apelare functia baza pentru barca

	Punte();					//Apelare functia punte pentru barca, deoarece este o alta suprafata,
										//de aceea trebuie o functie pentru fiecare suprafata 

	
	///Deseneaza ornamentul din fata
		glPushMatrix();
			gluQuadricDrawStyle(obj, GLU_FILL);
			glColor3d(0.35, 0.16, 0.14);
			glTranslatef(0.0, -3.0, -0.7);
			glRotatef(300, 1.0, 0.0, 0.0);
			gluCylinder(obj, 0.06, 0.15, 1.2, 10, 10);
			gluSphere(obj, 0.16, 10, 10);
		glPopMatrix();
	///-----------------------------------------------
	///Deseneaza Catargele
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(0.0, 1.3, -2.6);
				gluCylinder(obj, 0.1, 0.1, 2.6, 10, 10);
				gluDisk(obj, 0.0, 0.1, 10, 10);
			glPopMatrix();
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(0.0, -0.5, -2.6);
				gluCylinder(obj, 0.1, 0.1, 2.6, 10, 10);
				gluDisk(obj, 0.0, 0.1, 10, 10);
			glPopMatrix();
		//Deseneaza cilindri unde se agata panza pentru primul catarg
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(-0.9, -0.5, -2.0);
				glRotatef(90, 0.0, 1.0, 0.0);
				gluCylinder(obj, 0.05, 0.05, 1.8, 10, 10);
				gluDisk(obj, 0.0, 0.05, 10, 10);
				glTranslatef(0.0, 0.0, 1.8);
				gluDisk(obj, 0.0, 0.05, 10, 10);
			glPopMatrix();
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(-0.9, -0.5, -1.4);
				glRotatef(90, 0.0, 1.0, 0.0);
				gluCylinder(obj, 0.05, 0.05, 1.8, 10, 10);
				gluDisk(obj, 0.0, 0.05, 10, 10);
				glTranslatef(0.0, 0.0, 1.8);
				gluDisk(obj, 0.0, 0.05, 10, 10);
			glPopMatrix();
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(-0.9, -0.5, -0.5);
				glRotatef(90, 0.0, 1.0, 0.0);
				gluCylinder(obj, 0.05, 0.05, 1.8, 10, 10);
				gluDisk(obj, 0.0, 0.05, 10, 10);
				glTranslatef(0.0, 0.0, 1.8);
				gluDisk(obj, 0.0, 0.05, 10, 10);
			glPopMatrix();
		//--------------------------------------------------------
		//Deseneaza cilindri unde se agata panza pentru al 2-lea catarg
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(-0.9, 1.3, -2.0);
				glRotatef(90, 0.0, 1.0, 0.0);
				gluCylinder(obj, 0.05, 0.05, 1.8, 10, 10);
				gluDisk(obj, 0.0, 0.05, 10, 10);
				glTranslatef(0.0, 0.0, 1.8);
				gluDisk(obj, 0.0, 0.05, 10, 10);
			glPopMatrix();
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(-0.9, 1.3, -1.4);
				glRotatef(90, 0.0, 1.0, 0.0);
				gluCylinder(obj, 0.05, 0.05, 1.8, 10, 10);
				gluDisk(obj, 0.0, 0.05, 10, 10);
				glTranslatef(0.0, 0.0, 1.8);
				gluDisk(obj, 0.0, 0.05, 10, 10);
			glPopMatrix();
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(-0.9, 1.3, -0.5);
				glRotatef(90, 0.0, 1.0, 0.0);
				gluCylinder(obj, 0.05, 0.05, 1.8, 10, 10);
				gluDisk(obj, 0.0, 0.05, 10, 10);
				glTranslatef(0.0, 0.0, 1.8);
				gluDisk(obj, 0.0, 0.05, 10, 10);
			glPopMatrix();
		//--------------------------------------------------------
		//Deseneaza locul marinarului
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.35, 0.16, 0.14);
				glTranslatef(0.0, 1.3, -2.8);
				gluCylinder(obj, 0.4, 0.3, 0.3, 10, 10);
				glTranslatef(0.0, 0.0, 0.3);
				glColor3d(0.647059, 0.164706, 0.164706);
				gluDisk(obj, 0.0, 0.3, 10, 10);
			glPopMatrix();

		//-------------------------------------
		//Deseneaza loc pentru steag
			glPushMatrix();
				gluQuadricDrawStyle(obj, GLU_FILL);
				glColor3d(0.647059, 0.164706, 0.164706);
				glTranslatef(0.0, 1.3, -3.4);
				gluCylinder(obj, 0.03, 0.03, 0.9, 10, 10);
				gluDisk(obj, 0.0, 0.03, 10, 10);
			glPopMatrix();
			//----------------------------------------
		///-----------------------------------------------
		///Deseneaza Panzele
			//Deseneaza panza mare
				glPushMatrix();
					glRotatef(90, 1.0, 0.0, 0.0);
					glTranslatef(0.0, -0.5, -1.3);
					Panza_mare();
				glPopMatrix();
				glPushMatrix();
					glRotatef(90, 1.0, 0.0, 0.0);
					glTranslatef(0.0, -0.5, 0.5);
					Panza_mare();
				glPopMatrix();
			//----------------------------------------------------
			//Deseneaza panza mica
				glPushMatrix();
					glRotatef(90, 1.0, 0.0, 0.0);
					glTranslatef(0.0, -1.3, -1.3);
					Panza_mica();
				glPopMatrix();
				glPushMatrix();
					glRotatef(90, 1.0, 0.0, 0.0);
					glTranslatef(0.0, -1.3, 0.5);
					Panza_mica();
				glPopMatrix();
			//----------------------------------------------------
			//Deseneaza steag
				glPushMatrix();
					glRotatef(90, 1.0, 0.0, 0.0);
					glPushMatrix();
						glRotatef(80, 0.0, 1.0, 0.0);
						glTranslatef(1.7,-2.8, -0.23);
						Steag();
					glPopMatrix();
				glPopMatrix();
				
				//----------------------------------------------------
	///-----------------------------------------------
	///Deseneaza Cutia din spatele vaporului
				glPushMatrix();
					gluQuadricDrawStyle(obj, GLU_FILL);
					glColor3d(0.647059, 0.164706, 0.164706);
					glTranslatef(0.0, 2.23, -0.6);
					glRotatef(45, 0.0, 0.0, 1.0);
					gluCylinder(obj, 0.7, 0.7, 0.6, 4, 4);
					gluDisk(obj, 0.0, 0.7, 4, 4);
					glTranslatef(0.0, 0.0, 0.6);
					gluDisk(obj, 0.0, 0.7, 4, 4);
				glPopMatrix();
		///--------------------------------------------------
}
///-------------------------------------------------------------------------------
///Aici se deseneaza insula 
	//Desenam palmier de pe insula
		void Copac_fata() {
			glEnable(GL_DEPTH_TEST);
			glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
				0, 1, 12, 4, &ctrlpoints_copac_fata[0][0][0]);
			glEnable(GL_MAP2_VERTEX_3);
			glEnable(GL_AUTO_NORMAL);
			glEnable(GL_NORMALIZE);
				glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
				glColor3d(0.52, 0.37, 0.26);
			glEvalMesh2(GL_FILL, 0, 20, 0, 20);
		}
		void Copac_spate() {
			glEnable(GL_DEPTH_TEST);
			glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
				0, 1, 12, 4, &ctrlpoints_copac_spate[0][0][0]);
			glEnable(GL_MAP2_VERTEX_3);
			glEnable(GL_AUTO_NORMAL);
			glEnable(GL_NORMALIZE);
			glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
			glColor3d(0.52, 0.37, 0.26);
			glEvalMesh2(GL_FILL, 0, 20, 0, 20);
		}
	//-----------------------------
	//Desenare frunze
		void Frunze() {
			glScalef(6, 6, 6);
			glRotatef(-55.0, 1.0, 0.0, 0.0);
			glEnable(GL_DEPTH_TEST);
			glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
				0, 1, 12, 4, &ctrlpoints_frunze[0][0][0]);
			glEnable(GL_MAP2_VERTEX_3);
			glEnable(GL_AUTO_NORMAL);
			glEnable(GL_NORMALIZE);
			glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
			glColor3d(0.137255, 0.556863, 0.137255);
			glEvalMesh2(GL_FILL, 0, 20, 0, 20);
		}
		void Frunze2() {
			glScalef(6, 6, 6);
			//glRotatef(-55.0, 1.0, 0.0, 0.0);
			glEnable(GL_DEPTH_TEST);
			glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
				0, 1, 12, 4, &ctrlpoints_frunze[0][0][0]);
			glEnable(GL_MAP2_VERTEX_3);
			glEnable(GL_AUTO_NORMAL);
			glEnable(GL_NORMALIZE);
			glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
			glColor3d(0.137255, 0.556863, 0.137255);
			glEvalMesh2(GL_FILL, 0, 20, 0, 20);
		}
	//---------------------------------------
	//Desenam  insula
		void Insula() {
			GLUquadricObj *obj;
			obj = gluNewQuadric();
			glScalef(2.0, 2.0, 2.0);
				//Desenare copac
				glPushMatrix();
				glRotatef((GLfloat)palmier, 0.0, 1.0, 1.0);
				glScalef(0.6, 0.6, 0.6);
					glPushMatrix();
						glTranslatef(10.0, 10.0, 0.0);
						glRotatef(-15.0, 0.0, 0.0, 1.0);
						Copac_fata();
						Copac_spate();
					glPopMatrix();
					glPushMatrix();
						glColor3d(0.52, 0.37, 0.26);
						glTranslatef(13.0, 22.0, 0.0);
						glRotatef(-15.0, 0.0, 0.0, 1.0);
						auxSolidSphere(2.0);
					glPopMatrix();
					glPushMatrix();
						glTranslatef(13.0, 18.0, 5.0);
						Frunze();
					glPopMatrix();
					glPushMatrix();
						glTranslatef(13.0, 28.0, -10.0);
						Frunze();
					glPopMatrix();
					glPushMatrix();
						glTranslatef(23.0, 22.0, -4.0);
						glRotatef(200.0, 0.0, 1.0, 0.0);
						glPushMatrix();
							glRotatef(30.0, 1.0, 0.0, 0.0);
								glPushMatrix();
									glRotatef(90.0, .0, 0.0, 1.0);
									Frunze2();
								glPopMatrix();
							glPopMatrix();
					glPopMatrix();
						glPushMatrix();
							glTranslatef(8.0, 22.0, 1.0);
							glRotatef(200.0, 0.0, 1.0, 0.0);
								glPushMatrix();
									glRotatef(30.0, 1.0, 0.0, 0.0);
									glPushMatrix();
									glRotatef(90.0, .0, 0.0, 1.0);
									Frunze2();
								glPopMatrix();
						glPopMatrix();
					glPopMatrix();
				glPopMatrix();
				//-----------------------------
				glPushMatrix();
					glTranslatef(0.0, -20.0, 0.0);
					glColor3d(1.0, 0.65, 0.20);
					glClipPlane(GL_CLIP_PLANE3, taiere_insula);
					glEnable(GL_CLIP_PLANE3);
					glRotatef(90.0, 1.0, 1.0, 0.0);
					auxSolidSphere(20.0);
				glPopMatrix();
				glPopMatrix();
			glPopMatrix();
		}
	//--------------------------------------------
		void Rechini(){
			GLUquadricObj *obj;
			obj = gluNewQuadric();
			glPushMatrix();
				glTranslatef(10.0, -20.0, 60.0);
				glColor3d(0.0, 0.458039, 0.6);
				glRotatef(90.0, 1.0, 0.0, 0.0);
				gluCylinder(obj, 0, 4, 6.0, 10, 10);
			glPopMatrix();
		}
///------------------------------------------------------
//Functia de iluminare de la laborator
void initlights(void)
{
    GLfloat ambient[] = { 0.3, 0.3, 0.3, 1.0 };
    GLfloat mat_diffuse[] = { 0.3, 0.3, 0.3, 1.0 };
    GLfloat mat_specular[] = { 0.0, 0.0, 0.0, 1.0 };
    GLfloat mat_shininess[] = { 65.0 };
    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
	glDepthFunc(GL_LESS);
	glEnable(GL_DEPTH_TEST);
    glLightfv(GL_LIGHT0, GL_AMBIENT, ambient);
    glMaterialfv(GL_FRONT, GL_DIFFUSE, mat_diffuse);
    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
}
//-------------------------------------------------------------
void CALLBACK display(void)
{
	GLUquadricObj *obj;			//Declarare obiect pentru cvadrice
	obj = gluNewQuadric();
	/*
			// Pentru umbra
	GLfloat matUmbra[4][4];
	//oricare trei puncte din plan în sens CCW
	GLfloat puncte[3][3] = { { -50.0f, -164.0f, -50.0f },
	{ -50.0, -164.0f, 50.0 },
	{ 50.0f, -164.0f, 50.0f } };
	*/
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	
			glRotatef(beta, 0.0, 1.0, 0.0);
			

		glPushMatrix();
			glTranslatef(-92.5 + soare, 47.5 + soare2, 10.0);
			glScalef(6.0, 6.0, 6.0);
			initlights();
			glRotated(90+soare3, 1.0, 1.0, 0.0);
			glLightfv(GL_LIGHT0, GL_POSITION, light_position);
		glPopMatrix();
	
		glPushMatrix();
			Deseneaza_cerul();
		glPopMatrix();
			gluLookAt(1, 1, 1, 80.0, -20.0, 0.0,20,20,0);
		glPushMatrix();
				//glDisable(GL_LIGHTING); //Fara lumina la insula
			glRotatef(280.0, 0.0, 1.0, 0.0);
			Insula();
		glPopMatrix();
		glPushMatrix();
				//glDisable(GL_LIGHTING); //Fara lumina la rechin 1
			glRotatef((GLfloat)merge2, 0.0, 1.0, 0.0);
			Rechini();
		glPopMatrix();
		glPushMatrix();
				//glDisable(GL_LIGHTING); //Fara lumina la rechin 2
			glRotatef((GLfloat)merge3, 0.0, 1.0, 0.0);
			Rechini();
		glPopMatrix();
		glPushMatrix();	
	
			glRotatef((GLfloat)merge, 0.0, 1.0, 0.0);
			glTranslatef(80.0, -12.0, 0.0);
			glPushMatrix();
					//glDisable(GL_LIGHTING); //Fara lumina la vapor
				glRotatef(90.0, 1.0, 0.0, 0.0);
				Vapor();
			glPopMatrix();
		glPopMatrix();
			glPushMatrix();
			glColor3f(0.0, 0.0, 0.0);
			makeRasterFont();
			glRasterPos2i(-80, -76);
			printString("Student: Badiu Bogdan-Vasile");
		glPopMatrix();
	
	
		
    glFlush();
}

void myinit(void)
{
	
	//Culuarea ferestrei pentru a parea ca este pe mare
   glClearColor (0.137255, 0.137255, 0.556863, 0.0);
   glColorMaterial(GL_FRONT, GL_DIFFUSE);
   glEnable(GL_COLOR_MATERIAL);
   glEnable(GL_DEPTH_BUFFER_BIT);
  
}

void CALLBACK myReshape(GLsizei w, GLsizei h)
{
    if (!h) return;
    glViewport(0, 0, w, h);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    if (w <= h)
    glOrtho(-100.0, 100.0, -100.0*(GLfloat)h/(GLfloat)w, 
        100.0*(GLfloat)h/(GLfloat)w, -100.0, 100.0);
    else
    glOrtho(-100.0*(GLfloat)w/(GLfloat)h, 
        100.0*(GLfloat)w/(GLfloat)h, -100.0, 100.0, -100.0, 100.0);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}

int main(int argc, char** argv)
{
    auxInitDisplayMode (AUX_SINGLE | AUX_RGB | AUX_DEPTH16);
    auxInitPosition (0, 0, 500, 500);
    auxInitWindow ("Vapor 2.1");

    myinit();	
	
	auxKeyFunc(AUX_UP, rotire_corabie_fata);
	auxKeyFunc(AUX_DOWN, rotire_corabie_spate);
	auxKeyFunc(AUX_LEFT, rotire_ambele_fata);
	auxKeyFunc(AUX_RIGHT, rotire_ambele_spate);
	auxKeyFunc(AUX_x, rotire_rechin_fata);
	auxKeyFunc(AUX_z, rotire_rechin_spate);
	auxKeyFunc(AUX_w, muta_soare_y);
	auxKeyFunc(AUX_s,muta_soare_y2 );
	auxKeyFunc(AUX_a, muta_soare_x2);
	auxKeyFunc(AUX_d, muta_soare_x);
	auxKeyFunc(AUX_p, Misca_tot_btn);
	auxKeyFunc(AUX_r, Misca_rechin_btn);
	auxKeyFunc(AUX_o, Opreste);
	auxMouseFunc(AUX_LEFTBUTTON, AUX_MOUSEDOWN, Roteste_tot_1);
	auxMouseFunc(AUX_RIGHTBUTTON, AUX_MOUSEDOWN, Roteste_tot_2);
	
    auxReshapeFunc (myReshape);
    auxMainLoop(display); 
	
    return(0);
}
