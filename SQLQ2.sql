Drop table Occupation;
Drop table Fonctions;
Drop table Employes;
DROP TABLE Departements;

CREATE TABLE Departements
  (
    CodeDept      CHAR (5) NOT NULL ,
    NomDept       VARCHAR2 (40) NOT NULL ,
    DateCreation DATE
  ) ;
ALTER TABLE Departements ADD CONSTRAINT Departements_PK PRIMARY KEY
(
   CodeDept
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
    NumFonction NUMBER NOT NULL ,
    NomFonction  VARCHAR2 (40) NOT NULL
  ) ;
ALTER TABLE Fonctions ADD CONSTRAINT Fonctions_PK PRIMARY KEY
(
  NumFonction
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

ALTER TABLE Employes ADD CONSTRAINT Employes_Departements_FK FOREIGN KEY ( CodeDept ) REFERENCES Departements ( CodeDept ) ;



ALTER TABLE Occupation ADD CONSTRAINT Occupation_Employes_FK FOREIGN KEY ( NumeroEmp ) REFERENCES Employes ( NumEmp ) ;

ALTER TABLE Occupation ADD CONSTRAINT Occupation_Fonctions_FK FOREIGN KEY ( NumFonction ) REFERENCES Fonctions ( NumFonction ) ;

Alter Table Employes modify Salaireemp Number(8,2);

Alter table Employes modify Numempresp null;

ALTER TABLE Employes ADD CONSTRAINT Employes_Employes_FK FOREIGN KEY ( NumempResp ) REFERENCES Employes ( NumEmp ) ;

Alter table Employes ADD Constraint CK_Salaire CHECK (Salaireemp > 0 and Salaireemp < 500000); 

CREATE SEQUENCE SEQEMP INCREMENT BY 1 
START WITH 0
minvalue 0;

create or replace 
trigger EMPINC
BEFORE INSERT ON Employes
for each row
BEGIN
 if :new.numemp is null then select SEQEMP.nextval into :new.numemp from dual;
END if;
end;

-----------------------------------------------------------------------------------------------------------------------------------

--Question 3

--1
Insert into Departements Values (2,'World 2-1','10-01-01');
Insert into Departements Values (3,'World 3-4','11-02-01');
Insert into Departements Values (4,'World 5-2','11-03-01');
Insert into Departements Values (5,'Bureau Chef Bowser','10-01-01');

ALTER TABLE Employes Drop CONSTRAINT Employes_Employes_FK

Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept) Values('Bros','Mario',25000,'11-01-01','2');

ALTER TABLE Employes ADD CONSTRAINT Employes_Employes_FK FOREIGN KEY ( NumempResp ) REFERENCES Employes ( NumEmp ) ;

Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Bros','Luigi',20000,'11-01-01','2',2);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Toadstool','Peach',24000,'11-02-01','3',2);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Koopa','Paratroopa',25000,'11-01-01','3',2);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Bros','Wario',23000,'11-01-01','3',2);
Insert into Employes
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp )Values ('Koopa','Wendy',11000,'12-01-01','5',5);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Koopa','Larry',12000,'12-01-01','5',5);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Koopa','Bowser',17500,'11-01-01','5',2);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Savard','Fafard',1,'11-01-01','5',2);

--2
Select * from Employes where dateembauche >'11-01-21';

--3
Select count(e.numemp) AS NbEmploye ,d.nomdept from employes e inner join 
departements d on d.codedept = e.codedept
group by nomdept;

--4
select nomdept from departements 
where nomdept = ( select 

--5





--6
Select nomdept , Count(E.CodeDept) As NbEmployes 
From Departements D inner join Employes E on E.CodeDept = D.Codedept
Where NbEmployes = 0;

--FUCK YOU CALISS SA MARCHE PAS



--7
Select E.Nomemp , D.CodeDept 
From Employes E Inner Join Departements D on D.codedept = E.Codedept
Where D.CodeDept = ( Select CodeDept
                     From Employes
                     Where NomEmp = 'Savard'
                );
--8




--9


--10



--11




--12






--13




--14
CREATE PUBLIC SYNONYM Employes FOR cotefran.employes;

--15
grant all on Employes to stlauren with grant option;
grant select on cotejoueurs to public;