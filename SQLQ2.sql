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
    NumEmp   NUMBER NOT NULL ,
    NumFonction NUMBER NOT NULL ,
    DateEmp      DATE NOT NULL
  ) ;
ALTER TABLE Occupation ADD CONSTRAINT Occupation_PK PRIMARY KEY
(
  NumEmp, NumFonction, DateEmp
)
;

ALTER TABLE Employes ADD CONSTRAINT Employes_Departements_FK FOREIGN KEY ( CodeDept ) REFERENCES Departements ( CodeDept ) ;

ALTER TABLE Occupation ADD CONSTRAINT Occupation_Employes_FK FOREIGN KEY ( NumEmp ) REFERENCES Employes ( NumEmp ) ;

ALTER TABLE Occupation ADD CONSTRAINT Occupation_Fonctions_FK FOREIGN KEY ( NumFonction ) REFERENCES Fonctions ( NumFonction ) ;

Alter Table Employes modify Salaireemp Number(8,2);

ALTER TABLE Employes ADD CONSTRAINT Employes_Employes_FK FOREIGN KEY ( NumempResp ) REFERENCES Employes ( NumEmp ) ;

Alter table Employes ADD Constraint CK_Salaire CHECK (Salaireemp > 0 and Salaireemp < 500000); 

CREATE SEQUENCE SEQEMP INCREMENT BY 1 
START WITH 0
minvalue 0;

--create or replace 
--trigger EMPINC
--BEFORE INSERT ON Employes
--for each row
--BEGIN
-- if :new.numemp is null then select SEQEMP.nextval into :new.numemp from dual;
--END if;
--end;

-----------------------------------------------------------------------------------------------------------------------------------

--Question 3

--1
Insert into Departements Values (2,'World 2-1','10-01-01');
Insert into Departements Values (3,'World 3-4','11-02-01');
Insert into Departements Values (4,'World 5-2','11-03-01');
Insert into Departements Values (5,'Bureau Chef Bowser','10-01-01');
Insert into Departements Values (6,'Bureau Chef FABIEN','13-01-01');


Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept) Values('Bros','Mario',25000,'11-01-01','2');
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Bros','Luigi',20000,'11-01-01','2',0);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Toadstool','Peach',24000,'11-02-01','3',1);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Koopa','Paratroopa',25000,'11-01-01','3',1);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Bros','Wario',23000,'11-01-01','3',1);
Insert into Employes
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp )Values ('Koopa','Wendy',11000,'12-01-01','5',5);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Koopa','Larry',12000,'12-01-01','5',5);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Koopa','Bowser',17500,'11-01-01','5',2);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Savard','Fafard',1,'11-01-01','5',2);
Insert into Employes 
(nomemp,prenomemp,salaireemp,dateembauche,codedept,numempresp) Values ('Savard','LESCLAVEA',1,'11-01-01','5',8);



Insert into Fonctions VALUES (11,'Nettoyeur de tuyau');
Insert into Fonctions VALUES (12,'Sauver des princesses');
Insert into Fonctions VALUES (13,'Rien Foutre');


Insert into Occupation VALUES (0,12,'11-01-01');
Insert into Occupation VALUES (1,12,'11-01-01');
Insert into Occupation VALUES (2,13,'11-01-01');
Insert into Occupation VALUES (3,13,'11-01-01');
Insert into Occupation VALUES (4,13,'11-01-01');
Insert into Occupation VALUES (5,13,'11-01-01');
Insert into Occupation VALUES (6,13,'11-01-01');
Insert into Occupation VALUES (7,13,'11-01-01');
Insert into Occupation VALUES (8,11,'11-01-01');

--OK

--2
Select * from Employes where dateembauche >'11-01-21';
--Seems ok

--3
Select count(e.numemp) AS NbEmploye ,d.nomdept from employes e inner join 
departements d on d.codedept = e.codedept
group by nomdept;
--OK

--4
select MAX ( Select COUNT(*)
from departements D inner join Employes E on e.codedept = d.codedept)
;
-- a finir

--5
Select E.Nomemp , D.CodeDept 
From Employes E Inner Join Departements D on D.codedept = E.Codedept
Where D.CodeDept = ( Select CodeDept
                     From Employes
                     Where NomEmp = 'Savard'
                    );

--Marche pas checker


--6
Select D.CodeDept, NomDept FROM departements D 
LEFT OUTER JOIN Employes E ON D.Codedept = E.Codedept 
WHERE E.NumEmp IS NULL 
GROUP BY D.CodeDEpt, NomDept ;

--OK

--7
Select salaireemp as SALAIREMAX,nomemp,prenomemp
from Employes
where salaireemp = (select max(salaireemp) from Employes);
--Afficher le fuckin nom


--8
Update Employes set SalaireEmp = ( Salaireemp + (SalaireEmp * 0.02) )
where dateembauche > '09-01-01';

--MOIS DATE DE MARDE SON MON LAPTOP A REGARDER SEEMS TO WORK

--9
Drop View ViewEmployes;
CREATE VIEW ViewEmployes AS
SELECT E.NomEmp,E.PrenomEmp,F.NomFonction,O.DateEmp,E.SalaireEmp
FROM Employes E inner join Occupation O on O.Numemp = E.Numemp Inner join Fonctions F on F.NumFonction = O.NumFonction
Order by E.NomEmp;

--View OK

--10
                  
Select nomemp,prenomemp,numempresp
From Employes
START WITH nomemp ='Savard'
Connect by PRIOR numemp = Numempresp;
-- Is that ok?


--11
Select nomemp , numempresp
From Employes;
--pas fini


--12
Select nomemp,prenomemp,numempresp
from Employes
where numempresp IS null;

--OK

--13




--14
CREATE PUBLIC SYNONYM Employes FOR cotefran.employes;

--15
grant all on Employes to stlauren with grant option;
grant select on cotejoueurs to public;