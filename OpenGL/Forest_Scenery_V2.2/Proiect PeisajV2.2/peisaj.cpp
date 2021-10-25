#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>
#include "glos.h"
#include "tga.h"
#include <math.h>
#include "math3d.h"
#include <glut.h>
#include "glee.h"
#include "glframe.h"   // Frame class
#include <GL.h>
#include <GLU.h>
#include <GLAux.h>
#pragma pack(1)
typedef struct
{
	GLbyte	identsize;              // Size of ID field that follows header (0)
	GLbyte	colorMapType;           // 0 = None, 1 = paletted
	GLbyte	imageType;              // 0 = none, 1 = indexed, 2 = rgb, 3 = grey, +8=rle
	unsigned short	colorMapStart;          // First colour map entry
	unsigned short	colorMapLength;         // Number of colors
	unsigned char 	colorMapBits;   // bits per palette entry
	unsigned short	xstart;                 // image x origin
	unsigned short	ystart;                 // image y origin
	unsigned short	width;                  // width in pixels
	unsigned short	height;                 // height in pixels
	GLbyte	bits;                   // bits per pixel (8 16, 24, 32)
	GLbyte	descriptor;             // image descriptor
} TGAHEADER;
#pragma pack(8)


// ========Delaraarea varoiabilelor pt SkyBox===============
const char *szCubeFaces[6] = { "pos_x.tga", "neg_x.tga", "pos_y.tga", "neg_y.tga", "pos_z.tga", "neg_z.tga" };
//vector cu numele fiecarei fete a SkyBox-ului

GLenum  cube[6] = { GL_TEXTURE_CUBE_MAP_POSITIVE_X,
					GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
					GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
					GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
					GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
					GL_TEXTURE_CUBE_MAP_NEGATIVE_Z };//Specificam carei fete i se aplica texturile de mai sus
// ================================================================

// date pentru iluminare
GLfloat fLightPos[4] = { -100.0f, 100.0f, 50.0f, 1.0f };  // poyitia sursei
GLfloat fLightPosMirror[4] = { -100.0f, -100.0f, 50.0f, 1.0f };
GLfloat fNoLight[] = { 0.0f, 0.0f, 0.0f, 0.0f };
GLfloat fLowLight[] = { 0.25f, 0.25f, 0.25f, 1.0f };
GLfloat fBrightLight[] = { 1.0f, 1.0f, 1.0f, 1.0f };

GLuint *texture = new GLuint[3];//pentru a pune mai multe texturi folosing obiectele de texturare
GLbyte *pBytes;//Pentru imaginea pe care o dorim
GLint iWidth, iHeight, iComponents;//Pentru trasaturile imaginii pe care dorim sa o incarcam
GLenum eFormat;

//Cordonate pentru Suprafata Bezier (Pentru a face lacul)
GLfloat ctrlpoints2[4][4][3] = {
	//x1				//x2				//x3				//x4
	{ { -1.0, -1.0, 0.0 },{ -0.1, -2.0, 0.0 },{ 0.1, -2.0, 0.0 },{ 1.0, -1.0, 0.0 } },
	//x5				//x6				//x7				//x8
	{ { -1.2, -0.5, 0.0 },{ -0.1, -0.5, 0.0 },{ 0.1, -0.5, 0.0 },{ 1.2, -0.5, 0.0 } },
	//x9				//x10				//x11				//x12
	{ { -1.4, 0.0, 0.0 },{ -0.1, 0.0, 0.0 },{ 0.1, 0.0, 0.0 },{ 0.5, 0.0, 0.0 } },
	//x13				//x14				//x15				//x16
	{ { -0.5, 1.0, 0.0 },{ -0.1, 1.5, 0.0 },{ 0.1, 1.5, 0.0 },{ 0.5, 1.0, 0.0 } },
};
////////////////////////////////////////////////////////////////
GLbyte *gltLoadTGA(const char *szFileName, GLint *iWidth, GLint *iHeight, GLint *iComponents, GLenum *eFormat)
{
	FILE *pFile;			// File pointer
	TGAHEADER tgaHeader;		// TGA file header
	unsigned long lImageSize;		// Size in bytes of image
	short sDepth;			// Pixel depth;
	GLbyte	*pBits = NULL;          // Pointer to bits

									// Default/Failed values
	*iWidth = 0;
	*iHeight = 0;
	*eFormat = GL_BGR_EXT;
	*iComponents = GL_RGB8;

	// Attempt to open the file
	pFile = fopen(szFileName, "rb");
	if (pFile == NULL)
		return NULL;

	// Read in header (binary)
	fread(&tgaHeader, sizeof(TGAHEADER), 1, pFile);


	// Get width, height, and depth of texture
	*iWidth = tgaHeader.width;
	*iHeight = tgaHeader.height;
	sDepth = tgaHeader.bits / 8;
	// Put some validity checks here. Very simply, I only understand
	// or care about 8, 24, or 32 bit targa's.
	//if(tgaHeader.bits != 8 && tgaHeader.bits != 24 && tgaHeader.bits != 32)
	//  return NULL;

	// Calculate size of image buffer
	lImageSize = tgaHeader.width * tgaHeader.height * sDepth;
	// Allocate memory and check for success
	pBits = (GLbyte*)malloc(lImageSize * sizeof(GLbyte));
	if (pBits == NULL)
		return NULL;

	// Read in the bits
	// Check for read error. This should catch RLE or other 
	// weird formats that I don't want to recognize
	if (fread(pBits, lImageSize, 1, pFile) != 1)
	{
		free(pBits);
		return NULL;
	}

	// Set OpenGL format expected
	switch (sDepth)
	{
	case 3:     // Most likely case
		*eFormat = GL_BGR_EXT;
		*iComponents = GL_RGB8;
		break;
	case 4:
		*eFormat = GL_BGRA_EXT;
		*iComponents = GL_RGBA8;
		break;
	case 1:
		*eFormat = GL_LUMINANCE;
		*iComponents = GL_LUMINANCE8;
		break;
	};


	// Done with File
	fclose(pFile);

	// Return pointer to image data
	return pBits;
}
//////////////////////////////////////////////////////////////////
// se fac initializarile
// 
void CALLBACK SetupRC()
{


	// se taie fetele spate
	glCullFace(GL_BACK);
	glFrontFace(GL_CCW);
	glEnable(GL_CULL_FACE);
	glEnable(GL_DEPTH_TEST);

	// parametrii sursei de lumina
	glLightModelfv(GL_LIGHT_MODEL_AMBIENT, fNoLight);
	glLightfv(GL_LIGHT0, GL_AMBIENT, fLowLight);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, fBrightLight);
	glLightfv(GL_LIGHT0, GL_SPECULAR, fBrightLight);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);



	///////////////////////////////////////////////////
	//========Incarcarea copacului=============
	tgaInfo *image;
	glEnable(GL_DEPTH_TEST);


	glGenTextures(2, texture);
	image = tgaLoad(".\\tree.tga");
	glBindTexture(GL_TEXTURE_2D, texture[0]);


	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);

	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, image->width, image->height,
		0, GL_RGBA, GL_UNSIGNED_BYTE, image->imageData);
	//===================================================

	//====Incarcarea pamantului==========
	glBindTexture(GL_TEXTURE_2D, texture[1]);
	pBytes = gltLoadTGA("grassMare.tga", &iWidth, &iHeight, &iComponents, &eFormat);
	gluBuild2DMipmaps(GL_TEXTURE_2D, iComponents, iWidth, iHeight, eFormat, GL_UNSIGNED_BYTE, pBytes);
	free(pBytes);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);
	//==============================================

	// ====Incarcarea SkyBox==========
	glBindTexture(GL_TEXTURE_CUBE_MAP, texture[3]);
	glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
	glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
	glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
	glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_WRAP_R, GL_CLAMP_TO_EDGE);

	// Load Cube Map images
	for (int i = 0; i < 6; i++)
	{
		// Load this texture map
		glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_GENERATE_MIPMAP, GL_TRUE);
		pBytes = gltLoadTGA(szCubeFaces[i], &iWidth, &iHeight, &iComponents, &eFormat);
		glTexImage2D(cube[i], 0, iComponents, iWidth, iHeight, 0, eFormat, GL_UNSIGNED_BYTE, pBytes);
		free(pBytes);
	}
	// ====================================
}

///////////////////////////////////////////////////////////////////////
//Se deseneaza lacul, copacii si pamantul
void pamant(void) {

	///Pntru textura de pamant
	glBindTexture(GL_TEXTURE_2D, texture[1]);
	glEnable(GL_TEXTURE_2D);
	glPushMatrix();
	glMatrixMode(GL_TEXTURE);
	glPushMatrix();
	glScalef(10, 10, 10);
	glMatrixMode(GL_MODELVIEW);
	glBegin(GL_POLYGON);
	glTexCoord2f(0, 0);
	glVertex3f(-2, 0, 10); //1
	glTexCoord2f(1, 0);
	glVertex3f(2, 0, 10); //2
	glTexCoord2f(1, 1);
	glVertex3f(2, 0, -10); //3
	glTexCoord2f(0, 1);
	glVertex3f(-2, 0, -10); //4
	glEnd();
	glMatrixMode(GL_TEXTURE);
	glPopMatrix();
	glMatrixMode(GL_MODELVIEW);
	glDisable(GL_TEXTURE_2D);
}

void lac() {

	glTranslatef(0.3f, 0.0f, -2.5f); //Pentru a pune lacul in centru
	glScalef(1.07, 1.07, 1.07); //Pentru ai scimba marimea
	glMap2f(GL_MAP2_VERTEX_3, 0, 1, 3, 4,
		0, 1, 12, 4, &ctrlpoints2[0][0][0]);
	glEnable(GL_MAP2_VERTEX_3);
	glMapGrid2f(20, 0.0, 1.0, 20, 0.0, 1.0);
	glRotatef(90, 1.0, 0.0, 0.0); //Pentru a face lacul pe aceleasi cordonate ca patrat mare
	glEvalMesh2(GL_FILL, 0, 20, 0, 20);
}
void copac(void) {
	glActiveTexture(GL_TEXTURE0);
	glBindTexture(GL_TEXTURE_2D, texture[0]);
	glEnable(GL_TEXTURE_2D);
	glEnable(GL_BLEND);
	glEnable(GL_ALPHA_TEST);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	glAlphaFunc(GL_GREATER, 0);


	glBegin(GL_QUADS);
	glTexCoord2f(0, 0);
	glVertex2f(-0.5f, -0.5f);
	glTexCoord2f(1, 0);
	glVertex2f(0.5f, -0.5f);
	glTexCoord2f(1, 1);
	glVertex2f(0.5f, 0.5f);
	glTexCoord2f(0, 1);
	glVertex2f(-0.5f, 0.5f);
	glEnd();
	glDisable(GL_TEXTURE_2D);
	glDisable(GL_ALPHA_TEST);
}

void linieDeCopaci(int nrCopaci) {
	for (int i = 0;i < nrCopaci / 2;i++) {
		float a = -0.6*i;
		glPushMatrix();
		glTranslatef(a, 0.5f, -3.5f);
		copac();
		glPopMatrix();

	}
	for (int i = 0;i < nrCopaci / 2;i++) {
		float a = 0.6*i;
		glPushMatrix();
		glTranslatef(a, 0.5f, -3.5f);
		copac();
		glPopMatrix();
	}
}
void DrawSkyBox(void)
{
	GLfloat fExtent = 10.0f;
	glActiveTexture(GL_TEXTURE1);
	glBindTexture(GL_TEXTURE_CUBE_MAP, texture[3]);
	glEnable(GL_TEXTURE_CUBE_MAP);
	glBegin(GL_QUADS);
	//////////////////////////////////////////////
	// Negative X
	// Note, we must now use the multi-texture version of glTexCoord
	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, -1.0f, 1.0f);
	glVertex3f(-fExtent, -fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, -1.0f, -1.0f);
	glVertex3f(-fExtent, -fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, 1.0f, -1.0f);
	glVertex3f(-fExtent, fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, 1.0f, 1.0f);
	glVertex3f(-fExtent, fExtent, fExtent);


	///////////////////////////////////////////////
	//  Postive X
	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, -1.0f, -1.0f);
	glVertex3f(fExtent, -fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, -1.0f, 1.0f);
	glVertex3f(fExtent, -fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, 1.0f, 1.0f);
	glVertex3f(fExtent, fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, 1.0f, -1.0f);
	glVertex3f(fExtent, fExtent, -fExtent);


	////////////////////////////////////////////////
	// Negative Z 
	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, -1.0f, -1.0f);
	glVertex3f(-fExtent, -fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, -1.0f, -1.0f);
	glVertex3f(fExtent, -fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, 1.0f, -1.0f);
	glVertex3f(fExtent, fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, 1.0f, -1.0f);
	glVertex3f(-fExtent, fExtent, -fExtent);


	////////////////////////////////////////////////
	// Positive Z 
	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, -1.0f, 1.0f);
	glVertex3f(fExtent, -fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, -1.0f, 1.0f);
	glVertex3f(-fExtent, -fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, 1.0f, 1.0f);
	glVertex3f(-fExtent, fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, 1.0f, 1.0f);
	glVertex3f(fExtent, fExtent, fExtent);


	//////////////////////////////////////////////////
	// Positive Y
	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, 1.0f, 1.0f);
	glVertex3f(-fExtent, fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, 1.0f, -1.0f);
	glVertex3f(-fExtent, fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, 1.0f, -1.0f);
	glVertex3f(fExtent, fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, 1.0f, 1.0f);
	glVertex3f(fExtent, fExtent, fExtent);


	///////////////////////////////////////////////////
	// Negative Y
	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, -1.0f, -1.0f);
	glVertex3f(-fExtent, -fExtent, -fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, -1.0f, -1.0f, 1.0f);
	glVertex3f(-fExtent, -fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, -1.0f, 1.0f);
	glVertex3f(fExtent, -fExtent, fExtent);

	glMultiTexCoord3f(GL_TEXTURE1, 1.0f, -1.0f, -1.0f);
	glVertex3f(fExtent, -fExtent, -fExtent);
	glEnd();
	glDisable(GL_TEXTURE_CUBE_MAP);
}

///////////////////////////////////////////////////////////////////////        
// se seseneaza scena
void CALLBACK RenderScene(void)
{

	// se sterge fereastra cu culoarea curenta de stergere

	glClearStencil(0);
	glClearDepth(1);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);
	glDisable(GL_LIGHTING);
	glColorMask(GL_FALSE, GL_FALSE, GL_FALSE, GL_FALSE);
	glDepthMask(GL_FALSE);

	glEnable(GL_STENCIL_TEST);

	glStencilOp(GL_REPLACE, GL_REPLACE, GL_REPLACE);
	glStencilFunc(GL_ALWAYS, 0x01, 0x03);
	pamant();

	glStencilFunc(GL_ALWAYS, 0x02, 0x03);
	glPushMatrix();
	glTranslatef(0.3f, 0.0f, -2.5f);
	glRotatef(100, 0.0, 1.0, 0.0); //O rotatie pe y pentru a reprezenta lacul pe lateral
	glTranslatef(-0.3f, 0.0f, 2.5f);
	lac();
	glPopMatrix();


	glColorMask(GL_TRUE, GL_TRUE, GL_TRUE, GL_TRUE);
	glDepthMask(GL_TRUE);

	glPushMatrix();

	glStencilFunc(GL_EQUAL, 0x02, 0x02);
	glStencilOp(GL_KEEP, GL_KEEP, GL_KEEP);

	glEnable(GL_LIGHTING);
	glLightfv(GL_LIGHT0, GL_POSITION, fLightPosMirror);
	glPushMatrix();
	glFrontFace(GL_CW);             // geometria este oglindita
	glScalef(1.0f, -1.0f, 1.0f);

	//Desenare reflectie la copaci
	//Desenare Copaci////////////////////////
	glPushMatrix();
	DrawSkyBox();

	linieDeCopaci(8);
	for (int i = 0;i < 20;i++)
	{
		if (i % 2 == 0)
		{
			glTranslatef(-0.2, 0.0f, -0.6f);
			linieDeCopaci(7);
		}
		if (i % 2 != 0)
		{
			glTranslatef(0.2, 0.0f, -0.6f);
			linieDeCopaci(8);
		}
	}

	glPopMatrix();
	////////////////////////////////////////

	glFrontFace(GL_CCW);
	glPopMatrix();


	glDisable(GL_LIGHTING);
	glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

	glPushMatrix();
	glColor4f(0.25099, 0.64314, 0.87451, 0.40);
	glTranslatef(0.3f, 0.0f, -2.5f);
	glRotatef(100, 0.0, 1.0, 0.0); //O rotatie pe y pentru a reprezenta lacul pe lateral
	glTranslatef(-0.3f, 0.0f, 2.5f);
	lac();
	glPopMatrix();

	glDisable(GL_BLEND);
	glEnable(GL_LIGHTING);

	glStencilFunc(GL_EQUAL, 0x01, 0x01);
	glStencilOp(GL_KEEP, GL_KEEP, GL_KEEP);
	pamant();
	glEnable(GL_LIGHTING);

	glStencilFunc(GL_EQUAL, 0x00, 0x00);
	glStencilOp(GL_KEEP, GL_KEEP, GL_KEEP);

	//Desenare Copaci////////////////////////
	glPushMatrix();

	DrawSkyBox();

	linieDeCopaci(8);
	for (int i = 0;i < 20;i++)
	{
		if (i % 2 == 0)
		{
			glTranslatef(-0.2, 0.0f, -0.6f);
			linieDeCopaci(7);
		}
		if (i % 2 != 0)
		{
			glTranslatef(0.2, 0.0f, -0.6f);
			linieDeCopaci(8);
		}
	}

	glPopMatrix();
	/////////////////////////////////////////
	glPopMatrix();


	// comuta buffer-ele
	auxSwapBuffers();
}



///////////////////////////////////////////////////////////
void CALLBACK ChangeSize(int w, int h)
{
	GLfloat fAspect;

	// previne impartirea cu 0
	// 
	if (h == 0)
		h = 1;

	glViewport(0, 0, w, h);

	fAspect = (GLfloat)w / (GLfloat)h;

	// se reseteaza matricea de proiectie la inceput
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();

	// volumul de vizualizare
	gluPerspective(35.0f, fAspect, 1.0f, 50.0f);

	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glTranslatef(0.0f, -0.4f, 0.0f);
}
/////////////////////////////////////////////////////////////
// programul principal
int main(int argc, char** argv)
{

	auxInitDisplayMode(AUX_DOUBLE | AUX_RGB | AUX_DEPTH | AUX_STENCIL);
	auxInitPosition(0, 0, 800, 600);
	auxInitWindow((LPCWSTR)"Peisaj de Padure");
	auxReshapeFunc(ChangeSize);
	SetupRC();
	auxMainLoop(RenderScene);

	return 0;
}
