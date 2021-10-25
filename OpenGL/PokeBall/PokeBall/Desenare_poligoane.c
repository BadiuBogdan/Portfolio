/*
Programul afiseaza mai multe pokeball-uri
*/

#include "glos.h"
#include <GL/gl.h>
#include <GL/glu.h>
#include <Gl/GLAux.h>
#include <math.h>


void myinit(void);
void CALLBACK display(void);
void CALLBACK myReshape(GLsizei w, GLsizei h);
void CALLBACK MutaStanga(void);
void CALLBACK MutaDreapta(void);
void CALLBACK deschide_inchide_mingea(void);

static GLfloat alfa = 0;
static GLfloat x = 0, y = 0, z = 0, alfa2 = 90;
static GLdouble raza = 40, longi = 30, lat = 30;

void myinit (void) {
    glClearColor(1.0, 1.0, 0.0, 0.0);
}


void CALLBACK MutaStanga(void)
{
	x=x-10;
}

void CALLBACK MutaDreapta(void)
{
	x=x+10;
}
void CALLBACK MutaSus(void)
{
	y= y + 10;
}
void CALLBACK MutaJos(void)
{
	y =y  - 10;
}
void CALLBACK deschide_inchide_mingea( void)
{
	if (alfa == 0) 
	{
		alfa -= 30;
	}
	else
	{
		alfa = 0;
	}
			
}


void CALLBACK display (void)
{
	
	GLUquadricObj *obj;
	obj = gluNewQuadric();
    glClear(GL_COLOR_BUFFER_BIT);
    glLoadIdentity ();
	glRotatef(alfa, 1, 0, 0);
//Deseneaza un pokeball simplu
/////////////////////////////////////////////////////////
	//Deseneaza o sfera pentru pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x-200, y , z - 10);
	glColor3f(1.0, 1.0, 1.0);
	gluSphere(obj, 80, 60, 60);
	glPopMatrix();
	//----------------------------------------------
	//Deseneaza pickachu
	//*****************************************
	//cap
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 160, y, z - 10);
	glColor3f(1.0, 1.0, 0.0);
	gluSphere(obj, 10, 60, 60);
	glPopMatrix();
	//-------------------------------------
	//urechi
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 170, y+7, z-10 );
	glRotatef(180, 1, 0, 0);
	glColor3f(1.0, 1.0, 0.0);
	gluDisk(obj, 0, 5, 3, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 150, y+7 , z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(1.0, 1.0, 0.0);
	gluDisk(obj, 0, 5, 3, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 173, y + 9, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 0, 2, 3, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 147, y + 9, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 0, 2, 3, 30);
	glPopMatrix();
	//-------------------------------------
	//ochi
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 165, y+3 , z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 0, 1.6, 30, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 165, y + 3, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(1.0, 1.0, 1.0);
	gluDisk(obj, 0, 0.7, 30, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 155, y + 3, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 0, 1.6, 30, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 155, y + 3, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(1.0, 1.0, 1.0);
	gluDisk(obj, 0, 0.7, 30, 30);
	glPopMatrix();
	//----------------------------------------
	//gura
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 160, y - 1, z - 10);
	glColor3f(0.0, 0.0, 0.0);
	gluPartialDisk(obj, 3, 4, 100, 100, -90, -180);
	glPopMatrix();
	//-----------------------------------------
	//discuri rosi
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 167, y -3, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(1.0, 0.0, 0.0);
	gluDisk(obj, 0, 2, 30, 30);
	glPopMatrix();
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 153, y - 3, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(1.0, 0.0, 0.0);
	gluDisk(obj, 0, 2, 30, 30);
	glPopMatrix();
	//--------------------------------
	//nas
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x - 160, y, z - 10);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 0, 0.5, 30, 30);
	glPopMatrix();
	//---------------------------------
	//*************************************
	// Deseneaza un cilindru pentru pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_LINE);
	glTranslatef(x-200, y, z - 10);
	glRotatef(alfa2, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluCylinder(obj, 80, 80, 10, 30, 30);
	glPopMatrix();
	//--------------------------------------------
	//Deseneaza un cerc pt pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x -200, y -2, z + 30);
	glRotatef(180, 1, 0, 0);
	glColor3f(6.0, 6.0, 6.0);
	gluDisk(obj, 0, 20, 70, 30);
	glPopMatrix();
	//-------------------------------------------------
	//Disc pentru pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x-200 , y -2, z + 30);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 13, 20, 30, 30);
	glPopMatrix();
	//--------------------------------------------------
	//Sector disc pt pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x-200 , y , z + 30);
	glColor3f(1.0, 0.0, 0.0);
	gluPartialDisk(obj, 17, 80, 100, 100, -90, 180);
	glPopMatrix();
	//-------------------------------------------------
////////////////////////////////////////////////////////////////
//Deseneaza un pokeball cu albastru
/////////////////////////////////////////////////////////////////
//Deseneaza o sfera pentru pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x , y, z - 10);
	glColor3f(1.0, 1.0, 1.0);
	gluSphere(obj, 80, 60, 60);
	glPopMatrix();
	//----------------------------------------------
	// Deseneaza un cilindru pentru pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_LINE);
	glTranslatef(x , y, z - 10);
	glRotatef(alfa2, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluCylinder(obj, 80, 80, 10, 30, 30);
	glPopMatrix();
	//--------------------------------------------
	//Deseneaza un cerc pt pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x , y - 2, z + 30);
	glRotatef(180, 1, 0, 0);
	glColor3f(6.0, 6.0, 6.0);
	gluDisk(obj, 0, 20, 70, 30);
	glPopMatrix();
	//-------------------------------------------------
	//Disc pentru pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x , y - 2, z + 30);
	glRotatef(180, 1, 0, 0);
	glColor3f(0.0, 0.0, 0.0);
	gluDisk(obj, 13, 20, 30, 30);
	glPopMatrix();
	//--------------------------------------------------
	//Sector disc pt pokeball
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x , y, z + 30);
	glColor3f(0.0, 0.0, 1.0);
	gluPartialDisk(obj, 17, 80, 100, 100, -90, 180);
	glPopMatrix();
	//-------------------------------------------------
	//Cele 2 sectoare rosii
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x, y, z + 30);
	glColor3f(1.0, 0.0, 0.0);
	gluPartialDisk(obj, 17, 80, 100, 100, 35, 20);
	glPopMatrix();
	//*************************************************
	glPushMatrix();
	gluQuadricDrawStyle(obj, GLU_FILL);
	glTranslatef(x, y, z + 30);
	glColor3f(1.0, 0.0, 0.0);
	gluPartialDisk(obj, 17, 80, 100, 100, -60, 20);
	glPopMatrix();
	//--------------------------------------------------
	////////////////////////////////////////////////////////
	glFlush();
}

/*void CALLBACK myReshape(GLsizei w, GLsizei h)
{
    if (!h) return;			//transformare anizotropica, forma se modifica functie de forma(dimens) viewportului
    glViewport(0, 0, w, h);	//daca w>h stabilim ca baza inaltime, si stab unit logica de dimens in fct de h(h/320, 320 lungime lat patrat)
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glOrtho (-160.0, 160.0, -160.0, 
        160.0, -10.0, 10.0);
    glMatrixMode(GL_MODELVIEW);
}*/

void CALLBACK myReshape(GLsizei w, GLsizei h)	
{
    if (!h) return;
    glViewport(0, 0, w, h);	
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    if (w <= h)		
    glOrtho (-160.0, 160.0, 160.0*(GLfloat)h/(GLfloat)w, 
        -160.0*(GLfloat)h/(GLfloat)w, -300.0, 300.0);
    else 
    glOrtho (-160.0*(GLfloat)w/(GLfloat)h, 
        160.0*(GLfloat)w/(GLfloat)h, -160.0, 160.0, -300.0, 300.0);
    glMatrixMode(GL_MODELVIEW);
}

int main(int argc, char** argv)
{
    auxInitDisplayMode (AUX_SINGLE | AUX_RGB);
    auxInitPosition (0, 0, 300, 200);
    auxInitWindow ("Mai multe forme 3D");
    myinit ();
	auxKeyFunc (AUX_LEFT, MutaStanga);
	auxKeyFunc (AUX_RIGHT, MutaDreapta);
	auxKeyFunc(AUX_UP, MutaSus);
	auxKeyFunc(AUX_DOWN, MutaJos);
	auxMouseFunc(AUX_LEFTBUTTON, AUX_MOUSEDOWN, deschide_inchide_mingea);
    auxReshapeFunc (myReshape);
    auxMainLoop(display);
    return(0);
}
