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
    NumempResp   NUMBER NOT NULL
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