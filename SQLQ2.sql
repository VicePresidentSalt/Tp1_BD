CREATE TABLE Departements
  (
    CodeDep      CHAR (5) NOT NULL ,
    NomDep       VARCHAR2 (40) NOT NULL ,
    DateCreation DATE
  ) ;
ALTER TABLE Departements ADD CONSTRAINT Departements_PK PRIMARY KEY
(
  CodeDep
)
;

CREATE TABLE Employes
  (
    NumEmp       NUMBER NOT NULL ,
    Nomemp       VARCHAR2 (40) NOT NULL ,
    Prenomemp    VARCHAR2 (40) ,
    Salaireemp   NUMBER (2,8) ,
    DateEmbauche DATE ,
    CodeDept     CHAR (5) NOT NULL ,
    NumempResp   NUMBER
  ) ;
CREATE INDEX Employes__IDX ON Employes
  ( Nomemp ASC
  ) ;
ALTER TABLE Employes ADD CONSTRAINT Employes_PK PRIMARY KEY
(
  NumEmp
)
;

CREATE TABLE Fonctions
  (
    CodeFonction NUMBER NOT NULL ,
    NomFonction  VARCHAR2 (40) NOT NULL
  ) ;
ALTER TABLE Fonctions ADD CONSTRAINT Fonctions_PK PRIMARY KEY
(
  CodeFonction
)
;

CREATE TABLE Occupation
  (
    NumeroEmp   NUMBER NOT NULL ,
    NumFonction NUMBER NOT NULL ,
    "Date"      DATE NOT NULL
  ) ;
ALTER TABLE Occupation ADD CONSTRAINT Occupation_PK PRIMARY KEY
(
  NumeroEmp, "Date", NumFonction
)
;

ALTER TABLE Employes ADD CONSTRAINT Employes_Departements_FK FOREIGN KEY ( CodeDept ) REFERENCES Departements ( CodeDep ) ;

ALTER TABLE Employes ADD CONSTRAINT Employes_Employes_FK FOREIGN KEY ( NumempResp ) REFERENCES Employes ( NumEmp ) ;

ALTER TABLE Occupation ADD CONSTRAINT Occupation_Employes_FK FOREIGN KEY ( NumeroEmp ) REFERENCES Employes ( NumEmp ) ;

ALTER TABLE Occupation ADD CONSTRAINT Occupation_Fonctions_FK FOREIGN KEY ( NumFonction ) REFERENCES Fonctions ( CodeFonction ) ;

Alter Table Employes modify Salaireemp Number(8,2);

Alter table Employes modify Numempresp null;


-----------------------------------------------------------------------------------------------------------------------------------

--Question 3

--1
Insert into Departements Values (2,'World 2-1','10-01-01');
Insert into Departements Values (3,'World 3-4','11-02-01');
Insert into Departements Values (4,'World 5-2','11-03-01');
Insert into Departements Values (5,'Bureau Chef Bowser','10-01-01');

Insert into Employes Values (2,'Bros','Mario',25000,'11-01-01','2',NULL);
Insert into Employes Values (3,'Bros','Luigi',20000,'11-01-01','2',2);
Insert into Employes Values (4,'Toadstool','Peach',24000,'11-02-01','3',2);
Insert into Employes Values (5,'Koopa','Paratroopa',25000,'11-01-01','3',2);
Insert into Employes Values (6,'Bros','Wario',23000,'11-01-01','3',2);
Insert into Employes Values (7,'Koopa','Wendy',11000,'12-01-01','5',5);
Insert into Employes Values (8,'Koopa','Larry',12000,'12-01-01','5',5);
Insert into Employes Values (9,'Koopa','Bowser',17500,'11-01-01','5',2);

--2
Select * from Employes where dateembauche >'11-01-21';

--3



