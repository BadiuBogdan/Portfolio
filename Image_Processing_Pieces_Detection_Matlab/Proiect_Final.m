clc
clear all
close all
%=================Incarcare Imagine Tabla de Moara(T5.png)===============

numePoza='T5.png'; %incarcare poze diferite
%numePoza='ImagineTest1.png';
%numePoza='ImagineTest2.png';
%numePoza='ImagineTest3.png';
%numePoza='T6.jpg';


imag=double(imread(numePoza))/255;%Trnsformam intervalul [0,255] in [0,1]
                            
figure('Name','Imagine Originala','NumberTitle','off')
imshow(imag) %Afisare Imagine Originala
title('Tabla de Moara cu piese Rosi/Albastre');
%=================================================================


%=====Transformare imagine originala in GrayScale===============
imagGray=0.3*imag(:,:,1)+0.6*imag(:,:,2)+0.1*imag(:,:,3);
figure('Name','Imagine GrayScale','NumberTitle','off')
imshow(imagGray)%Afisare Imagine GrayScale
title('Imagine GrayScale')
%===============================================================

[M,N] = size(imagGray); %M,N sunt dimensiunea imaginii pe randuri si coloane


%=====Aplicarea unui Flitru de mediere pentru a scapa de detalii din imagine==========
imagFiltrat = zeros(M,N); %initializare imagine filtrata cu 0
H = [1,2,1;2,4,2;1,2,1];
H = 1/16 * H;
for i = 2 : M - 1
    for j = 2 : N - 1
        regiune = imag(i-1:i+1,j-1:j+1);
        convolutie = sum(sum(regiune.*H));
        imagFiltrat(i,j) = convolutie;
    end
end
imagGray2=imagFiltrat;
figure('Name','Imagine Filtrata ','NumberTitle','off')
imshow(imagFiltrat)%Afisare Imagine GrayScale
title('Imagine Filtata cu filtru de mediere pentru ascunderea detaliilor')
%===============================================================

%=====Segmentarea imaginii cu K-Mean Cluster===============
%------------valori aleatoare pentru a determina media minima si maxima----------
%     c=rand(1,2); 
%     c1=min(c);
%     c2=max(c);
 %------------------------------------------------------------- 
%----primele valori care segmenteaza fara linii, dar taie din pixelii pieselor
%     c1=0.06569;%media minima pe care o scadem din pixel
%     c2=0.7221;%media minima pe care o scadem din pixel 
%------------------------------------------------------------------
 c1=0.01069;%media minima pe care o scadem din pixel
 c2=0.9421;%media minima pe care o scadem din pixel

%[M,N]=size(imagGray);%determinam marimea imaginii
imagBinar=zeros(M,N);%initializarea unei imagini golae pentru a pune ce segmentam

c1_old=0;%initializam o valuare veche pentru media minima cu 0
c2_old=1;%initializam o valuare veche pentru media maxima cu 1
            %se face cu 0 si 1 deoarece lucram intre 0 si 1

while c1~=c1_old && c2~=c2_old%Expicatie la "EX**"
    %Se parcurge toata imaginea(este doar o iteratie)
    for i = 1 : M
        for j = 1 : N
            d1=abs(imagGray2(i,j)-c1);%se calculeazavaluarea distanta pentru minim
                                        %valuarea absoluta a pixelului
                                        %minus meida minima
            d2=abs(imagGray2(i,j)-c2);%se calculeazavaluarea distanta pentru maxim
                                        %valuarea absoluta a pixelului
                                        %minus meida maxima
            if d1<d2 %daca d1 este mai mic ca d2 inseamna ca avem un minim si punem 1
                        %daca nu se pune un 0
            imagBinar(i,j)=1;
            else
            imagBinar(i,j)=0;
            end
            %aceste calcule se fac pentru toata imaginea!!!!!
        end
    end
    %=================================
    c1=mean(imagGray2 (find(imagBinar==1)));%se calculeaza iar media minima
    %c1 se  calculeaza ca media din Imaginea Gray a valorilor care au 1 in
    %imaginea binara
    
    c2=mean(imagGray2 (find(imagBinar==0)));%se calculeaza iar media maxima
    %c2 se  calculeaza ca media din Imaginea Gray a valorilor care au 0 in
    %imaginea binara
    
    %acestea se calculeaza in imagine dupa ce am aplicat parcurgerea
    %compleat a imaginii
    
    c1_old=c1;%acum media veche este cea actuala in ambele cazuri
    c2_old=c2;
    %EX** se face acest lucru deoarece verificam in "whiel" de mai sus
        %schimbarile medilo
    %daca intre 2 iteratii consecutive ale "whiel" nu se schimba nimic
    %atunci se opreste algoritmul
end

imagBinar(imagGray==0)=0;
figure('Name','Imagine Segmentata','NumberTitle','off')
imshow(imagBinar)
title('Imagine Segmentata cu K-mean Cluster')
%===============================================================
%===== Scoatere cercuri din imagine===============
imagSegmentat=zeros(M,N);
 for i = 5 : M-4
        for j = 5 : N-4
          if(imagBinar(i-3:i+3,j-3:j+3)==1)
             imagSegmentat(i-5:i+5,j-5:j+5)=imagBinar(i-5:i+5,j-5:j+5);
          end
        end
 end
    
figure('Name','Imagine Segmentata2','NumberTitle','off')
imshow(imagSegmentat)
title('Imagine Segmentata fara impuritati')
%==================================================
%============Region Growing pentru a afla o singura piesa============
 %----Pentru a determina pozitia unui pexel alb--------------
seadRow=1;
seadCol=1;
 for i = 1: M
        for j = 1 : N
            if(imagSegmentat(i,j)==1)
                seadRow=i;%locul in care ne plasam/ de unde vrem sa plecam
                seadCol=j;    %in regiunea noastra
                break
            end
        end
 end
%---------------------------------------

oPiesa=zeros(M,N); %declararea unei regiuni care are doar zerouri
                            %populam regiunea cu 1 cand avem o valuare 
                            %din regiunea pe care o dorim
                            
oPiesa(seadRow,seadCol)=1;%specificam ca in regiune pozitia de unde plecam este 1
                               %pentru a avea un reper in viitor
                               %acolo am plantat "samanta regiunii"
                               
                                                                    
pixeliAlbregiune=1;%N este totalitatea pixelilor de 1 din regiune,deci la inceput este 1 deoarece
        %avem pixelul "samanta" in regiune
        
existaSchimbare=true; %contpor pentru a vedea daca exista schimbare intre 2
                                                    %regiuni consecutive
                            %pentru a se executra algoritmul pana cand nu
                            %exista schimbare
                            
%==========Implementare Algoritmului===================
    while(existaSchimbare) %Se realizeaza acest algoritm atata timp cat ecista o schimbare
                                %in regiune(diferenta intre 2 regiuni), 
                                    %adica atata timp cat suntem in regiunea 
                                        %pe care dorim sa o segmentam
                               
        existaSchimbare=false;
        for i=2:M-1
            for j=2:N-1
              
                if((imagSegmentat(i,j)==1)&&(oPiesa(i,j)==0)&&(oPiesa(i+1,j)==1||oPiesa(i,j+1)==1||oPiesa(i-1,j)==1||oPiesa(i,j-1)==1)) 
                    oPiesa(i,j)=1;
                    pixeliAlbregiune=pixeliAlbregiune+1;
                    existaSchimbare=true;
                end                                            
            end
        end
    end
figure('Name','Imagine Segmentata3','NumberTitle','off')
imshow(oPiesa)
title('Imagine Segmentata cu 1 singura piesa')
%=============================================================
%========Numara de pixeli al unei piese================
contorPiesa=0;
        for i=1:M
            for j=1:N
                if(oPiesa(i,j)==1) 
                 contorPiesa=contorPiesa+1;
                end                                            
            end
        end
  %==============================================    
  %========Numara de pixeli al tutoror pieselor================
contorTotal=0;
        for i=1:M
            for j=1:N
                if(imagSegmentat(i,j)==1) 
                 contorTotal=contorTotal+1;
                end                                            
            end
        end
  %==============================================   
  totalPiese=round(contorTotal/contorPiesa);
  disp('Numarul de piese albastre este: ');
  disp(totalPiese);
  
    %========Transformarea pieselor originale in alb================
    imagFinal=imag;
        for i=1:M
            for j=1:N
                if(imagSegmentat(i,j)==1)
                    imagFinal(i,j,1)=1;
                    imagFinal(i,j,2)=1;
                    imagFinal(i,j,3)=1;
                end                                            
            end
        end
figure('Name','Imagine Finala','NumberTitle','off')
imshow(imagFinal)
title('Imagine cu piese ALBE/ROSI')
  %==============================================   
