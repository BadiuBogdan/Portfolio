/*
 *  planet.c
 *  Programul arata cum se compun transformarile de rotatie si de translatie
 *  pentru desenarea obiectelor rotite sau translatate.
 *  Interactiune:  left, right, up, down 
 *  
 */
#include "glos.h"

#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>

void myinit(void);
void drawPlane(void);
void CALLBACK dayAdd (void);
void CALLBACK daySubtract (void);
void CALLBACK yearAdd (void);
void CALLBACK yearSubtract (void);
void CALLBACK display(void);
void CALLBACK myReshape(GLsizei w, GLsizei h);

static int year = 0, day = 0, night = 0, moon = 0, alfa = 50;

void CALLBACK dayAdd (void)
{
    day = (day + 10) % 360;
}

void CALLBACK daySubtract (void)
{
    day = (day - 10) % 360;
}

void CALLBACK yearAdd (void)
{
    year = (year + 5) % 360;
}

void CALLBACK yearSubtract (void)
{
    year = (year - 5) % 360;
}
void CALLBACK nightAdd(void)
{
	night = (night + 10) % 360;
}

void CALLBACK nightSubtract(void)
{
	night = (night - 10) % 360;
}
void CALLBACK moonAdd(void)
{
	moon = (moon + 10) % 360;
}

void CALLBACK moonSubtract(void)
{
	moon = (moon - 10) % 360;
}

void CALLBACK display(void)
{
	GLUquadricObj *obj;
	obj = gluNewQuadric();
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glEnable(GL_DEPTH_TEST);


    glColor3f (1.0, 1.0, 1.0);
    glPushMatrix();//pentru a nu iesi obiectele din fereastra la reapelarea functiei display()(Inceput sistem solar)

/*  SOARELE    */
		
			glColor3f(1.0, 1.0, 0.0);
			auxSolidSphere(1.0);

/* Sistemul  Pamantul */
		glPushMatrix();

			//Pamantul
			
				glColor3f(0.0, 0.0, 1.0);
				glRotatef ((GLfloat) year, 0.0, 1.0, 0.0);
				glTranslatef (2.0, 0.0, 0.0);
			
				glPushMatrix();
					glRotatef ((GLfloat) day, 0.0, 1.0, 0.0);
					auxWireSphere(0.3);
				glPopMatrix();
		//-----------------------------------------------------------
		//Luna
				glPushMatrix();
					glColor3f(1.0, 1.0, 1.0);
					glRotatef((GLfloat)night, 0.0, 1.0, 0.0);
					glTranslatef(0.5, 0.0, 0.0);
					glRotatef((GLfloat)moon, 0.0, 1.0, 0.0);
					auxWireSphere(0.1);
				glPopMatrix();
		//-----------------------------------------------
		glPopMatrix();//Sfarsit sistem pamant
		//Saturn
		glPushMatrix();
			glColor3f(1.0, 0.0, 0.0);
			glRotatef((GLfloat)year, 0.0, 1.0, 0.0);
			glTranslatef(-3.0, 0.0, 0.0);

			glPushMatrix();
				glRotatef((GLfloat)day, 0.0, 1.0, 0.0);
				auxWireSphere(0.3);
			glPopMatrix();

			glPushMatrix();
				glColor3f(1.0, 1.0, 1.0);
				gluQuadricDrawStyle(obj, GLU_FILL);
				gluDisk(obj, 0.4,0.5, 100, 10);
				
			glPopMatrix();

		glPopMatrix();
		
   	 glPopMatrix();//Sfarsit sistem solar
    glFlush();
}

void myinit (void) {
    glShadeModel (GL_FLAT);
}

void CALLBACK myReshape(GLsizei w, GLsizei h)
{
    if (!h) return;
    glViewport(0, 0, w, h);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(60.0, (GLfloat) w/(GLfloat) h, 1.0, 20.0);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glTranslatef (0.0, 0.0, -5.0);
}


int main(int argc, char** argv)
{
    auxInitDisplayMode (AUX_SINGLE | AUX_RGB);
    auxInitPosition (0, 0, 500, 500);
    auxInitWindow ("Sistemul Solar");
    myinit ();
    auxKeyFunc (AUX_LEFT, yearSubtract);
    auxKeyFunc (AUX_RIGHT, yearAdd);
    auxKeyFunc (AUX_UP, dayAdd);
    auxKeyFunc (AUX_DOWN, daySubtract);
	auxKeyFunc(AUX_a, nightAdd);
	auxKeyFunc(AUX_d, nightSubtract);
	auxKeyFunc(AUX_s, moonAdd);
	auxKeyFunc(AUX_w, moonSubtract);
    auxReshapeFunc (myReshape);
    auxMainLoop(display);
    return(0);
}
