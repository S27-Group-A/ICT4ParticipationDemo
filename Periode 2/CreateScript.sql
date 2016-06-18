--DROP TABLES
DROP TABLE "Account" CASCADE CONSTRAINTS;
DROP TABLE "User" CASCADE CONSTRAINTS;
DROP TABLE "Admin" CASCADE CONSTRAINTS;
DROP TABLE Volunteer CASCADE CONSTRAINTS;
DROP TABLE Skill CASCADE CONSTRAINTS;
DROP TABLE Review CASCADE CONSTRAINTS;
DROP TABLE Request CASCADE CONSTRAINTS;
DROP TABLE VehicleType CASCADE CONSTRAINTS;
DROP TABLE Patient CASCADE CONSTRAINTS;
DROP TABLE Meeting CASCADE CONSTRAINTS;
DROP TABLE VolunteerSkill CASCADE CONSTRAINTS;
DROP TABLE RequestSkill CASCADE CONSTRAINTS;
DROP TABLE Chat CASCADE CONSTRAINTS;
DROP TABLE "Availability" CASCADE CONSTRAINTS;
DROP TABLE Response CASCADE CONSTRAINTS;

--CREATE TABLES AND ADD PRIMARY KEYS
Create Table "Account"
(
  AccountId Number(10) Primary Key,
  Username Varchar2(32) Not Null Unique,
  Password Varchar2(32) Not Null,
  Email Varchar2(255) Not Null Unique
);

Create Table "User"
(
  AccountId Number(10) Primary Key,
  Name Varchar2(32) Not Null,
  Phone Varchar2(16),
  Datederegistration Date,
  Adress Varchar2(255),
  Location Varchar(255),
  Car Varchar2(1) DEFAULT '0',
  Driverslicense Varchar2(1) DEFAULT '0',
  RfId Varchar2(255),
  --Banned Varchar2(1) DEFAULT '0',
  --Unban Date,
  Enabled Varchar2(1) DEFAULT '1', 
  CHECK (Car = '1' OR Car = '0'), 
  --CHECK (Banned = '1' OR Banned = '0'), 
  CHECK (Enabled = '1' OR Enabled = '0') 
);

Create Table "Admin"
(
  AccountId Number(10) Primary Key
);


Create Table Volunteer
(
  AccountId Number(10) Primary Key,
  Vog Varchar2(255),
  Birthdate Date,
  Photo Varchar2(255),
  VogConfirmation Varchar2(1) DEFAULT '0',
  CHECK (VogConfirmation = '1' OR VogConfirmation = '0') 
);

Create Table Skill
(
  SkillId Number(10) Primary Key,
  Description Varchar2(255) Not Null Unique
);

Create Table Request
(
  AccountId NUMBER(10),
  RequestId Number(10),
  Description Varchar2(255),
  Location Varchar2(255),
  Traveltime NUMBER(10),
  Startdate Date,
  Enddate Date,
  Urgency Number(1),
  AmountOfVolunteers Number(10),
  PRIMARY KEY (RequestId)
);

Create Table Review
(  
  ReviewId Number(10),
  AccountId Number(10),
  RequestId Number(10),
  Rating Number(2),
  Description Varchar2(255),
  Primary Key (ReviewId, AccountId, RequestId)
);

Create Table Vehicletype
( 
  VehicleTypeId Number(10),
  RequestId Number(10),
  Description Varchar2(255) Not Null,
  Primary Key (VehicletypeId, RequestId)
);

Create Table Patient
( 
  AccountId Number(10) Primary Key,
  Ov Varchar2(1) DEFAULT '0',
  CHECK (Ov = '1' OR Ov = '0')
);

Create Table Meeting
(
  VolunteerId Number(10),
  PatientId Number(10),
  Location Varchar(255),
  Meetingdate Date,
  Status Varchar2(1) DEFAULT '0',
  Primary Key(VolunteerId, PatientId),
  CHECK (Status = '1' OR Status = '0')
);

Create Table Volunteerskill
(
  AccountId Number(10),
  SkillId Number(10),
  Primary Key (AccountId, SkillId)
);
--TODO Drop below
Create Table Requestskill
(
  RequestId Number(10),
  SkillId Number(10),
  Primary Key (RequestId, SkillId)
);

Create Table Chat
(
  Accounta Number(10),
  Accountb Number(10),
  Datetime Date,
  Message Varchar2(255) Not Null,
  Primary Key (Accounta, Accountb, Datetime)
);

Create Table "Availability"
(
  AccountId Number(10), 
  Day Varchar2(2),
  TimeOfDay Varchar2(10),
  Primary Key(AccountId, Day, TimeOfDay)
);

Create Table Response
(
  ResponderId NUMBER(10),
  RequestId NUMBER(10),
  ResponseDate DATE,
  Description VARCHAR2(255),
  PRIMARY KEY (ResponderId, RequestId, ResponseDate)
);

--ADD FOREIGN KEY CONSTRAINTS
Alter Table "User" Add Foreign Key (AccountId) References "Account"(AccountId);
Alter Table "Admin" Add Foreign Key (AccountId) References "Account"(AccountId);
Alter Table Volunteer Add Foreign Key (AccountId) References "User"(AccountId);
Alter Table Patient Add Foreign Key (AccountId) References "User" (AccountId);
Alter Table "Availability" Add Foreign Key (AccountId) References Volunteer(AccountId);
Alter Table Meeting Add Foreign Key (VolunteerId) References Volunteer(AccountId);
Alter Table Meeting Add Foreign Key (PatientId) References Patient(AccountId);
Alter Table Chat Add Foreign Key (Accounta) References Volunteer(AccountId);
Alter Table Chat Add Foreign Key (Accountb) References Patient(AccountId);
Alter Table Volunteerskill Add Foreign Key (AccountId) References Volunteer(AccountId);
Alter Table Volunteerskill Add Foreign Key (SkillId) References Skill(SkillId);
Alter Table RequestSkill Add Foreign Key (RequestId) References Request(RequestId);
Alter Table RequestSkill Add Foreign Key (SkillId) References Skill(SkillId);
Alter Table Review Add Foreign Key (RequestId) References Request(RequestId);
Alter Table Review Add Foreign Key (AccountId) References Volunteer(AccountId);
Alter Table Response Add Foreign Key (ResponderId) References Volunteer(AccountId);
Alter Table Response Add Foreign Key (RequestId) References Request(RequestId);
Alter Table VehicleType Add Foreign Key (RequestId) References Request(RequestId);

--CHECK CONSTRAINTS
ALTER TABLE "Availability" 
ADD CONSTRAINT chk_Availability_Day  CHECK (Day = 'Mo' OR Day = 'Di' OR Day = 'Wo' OR Day = 'Do' OR Day = 'Vr' OR Day = 'Za' OR Day = 'Zo');
ALTER TABLE "Availability"
ADD CONSTRAINT chk_Availability_TimeOfDay CHECK (TimeOfDay = 'Middag' OR TimeOfDay = 'Avond' OR TimeOfDay = 'Ochtend');


--AUTO IdINTIFIER INCREMENT SEQUENCES
DROP SEQUENCE AccountIncrementSeq;
DROP SEQUENCE SkillIncrementSeq;
DROP SEQUENCE ReviewIncrementSeq;
DROP SEQUENCE RequestIncrementSeq;
DROP SEQUENCE VehicleTypeIncrementSeq;

CREATE SEQUENCE AccountIncrementSeq
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 9999999999999999999999999999
 START WITH 1
 CACHE 20;
/
 
CREATE SEQUENCE SkillIncrementSeq
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 9999999999999999999999999999
 START WITH 1
 CACHE 20;
/

CREATE SEQUENCE ReviewIncrementSeq
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 9999999999999999999999999999
 START WITH 1
 CACHE 20;
/

CREATE SEQUENCE RequestIncrementSeq
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 9999999999999999999999999999
 START WITH 1
 CACHE 20;
/

CREATE SEQUENCE VehicleTypeIncrementSeq
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 9999999999999999999999999999
 START WITH 1
 CACHE 20;
/

--AUTO IdINTIFIER INCREMENT TRIGGERS
CREATE OR REPLACE TRIGGER AccountIncrementTrig BEFORE INSERT ON "Account" REFERENCING OLD AS "OLD" NEW AS "NEW" FOR EACH ROW ENABLE WHEN (new.AccountId IS NULL)
BEGIN
  SELECT AccountIncrementSeq.NEXTVAL INTO :new.AccountId FROM dual;
END;
/

CREATE OR REPLACE TRIGGER SkillIncrementTrig BEFORE INSERT ON Skill REFERENCING OLD AS "OLD" NEW AS "NEW" FOR EACH ROW ENABLE WHEN (new.SkillId IS NULL)
BEGIN
  SELECT SkillIncrementSeq.NEXTVAL INTO :new.SkillId FROM dual;
END;
/

CREATE OR REPLACE TRIGGER ReviewIncrementTrig BEFORE INSERT ON Review REFERENCING OLD AS "OLD" NEW AS "NEW" FOR EACH ROW ENABLE WHEN (new.ReviewId IS NULL)
BEGIN
  SELECT ReviewIncrementSeq.NEXTVAL INTO :new.ReviewId FROM dual;
END;
/

CREATE OR REPLACE TRIGGER RequestIncrementTrig BEFORE INSERT ON Request REFERENCING OLD AS "OLD" NEW AS "NEW" FOR EACH ROW ENABLE WHEN (new.RequestId IS NULL)
BEGIN
  SELECT RequestIncrementSeq.NEXTVAL INTO :new.RequestId FROM dual;
END;
/

CREATE OR REPLACE TRIGGER VehicleTypeIncrementTrig BEFORE INSERT ON VehicleType REFERENCING OLD AS "OLD" NEW AS "NEW" FOR EACH ROW ENABLE WHEN (new.VehicleTypeId IS NULL)
BEGIN
  SELECT VehicleTypeIncrementSeq.NEXTVAL INTO :new.VehicleTypeId FROM dual; 
END;
/

--DUMMY DATA
INSERT INTO "Account" (Username, Password, Email) VALUES ('patient', 'patient', 'patient@patient.nl');
INSERT INTO "User" (AccountId, Name) VALUES (1, 'patientje');
INSERT INTO Patient (AccountId) VALUES (1);

INSERT INTO "Account" (Username, Password, Email) VALUES ('volunteer', 'volunteer', 'volunteer@volunteer.nl'); 
INSERT INTO "User" (AccountId, Name) VALUES (2, 'volunteertje');
INSERT INTO Volunteer (AccountId) VALUES (2);

INSERT INTO "Account" (Username, Password, Email) VALUES ('secondvolunteer', 'secondvolunteer', 'secondvolunteer@volunteer.nl'); 
INSERT INTO "User" (AccountId, Name) VALUES (3, 'volunteertjetje');
INSERT INTO Volunteer (AccountId) VALUES (3);

INSERT INTO "Account" (Username, Password, Email) VALUES ('admin', 'password', 'admin@admin.nl');
INSERT INTO "User" (AccountId, Name) VALUES (4, 'Administrator');
INSERT INTO  Volunteer (AccountId) VALUES (4);
INSERT INTO "Admin" (AccountId) VALUES (4);

INSERT INTO Request (AccountId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers)
VALUES (1, 'Mijn kat zit vast in de boom!', 'Rachelsmolen 1, Eindhoven', 80, 
TO_DATE('01-01-2017', 'DD-MM-YY'), TO_DATE('01-01-2018', 'DD-MM-YY'), 3, 2);

INSERT INTO Request (AccountId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers)
VALUES (1, 'Mijn hond zit vast in de boom!', 'Rachelsmolen 2, Eindhoven', 80, 
TO_DATE('01-01-2017', 'DD-MM-YY'), TO_DATE('01-01-2018', 'DD-MM-YY'), 4, 1);

INSERT INTO Request (AccountId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers)
VALUES (1, 'Mijn olifant zit vast in de boom!', 'Rachelsmolen 2, Eindhoven', 80, 
TO_DATE('01-01-2017', 'DD-MM-YY'), TO_DATE('01-01-2018', 'DD-MM-YY'), 5, 1);

INSERT INTO Request (AccountId, Description, Location, TravelTime, StartDate, EndDate, Urgency, AmountOfVolunteers)
VALUES (1, 'Mijn dolfijn zit vast in de boom!', 'Aqualand', 80, 
TO_DATE('01-01-2017', 'DD-MM-YY'), TO_DATE('01-01-2018', 'DD-MM-YY'), 5, 1);

INSERT INTO VehicleType (RequestId, Description)
VALUES (1, 'Volkswagen');

INSERT INTO Skill(Description)
VALUES ('Goed met dieren');
INSERT INTO Skill(Description)
VALUES ('Masseur');

INSERT INTO VolunteerSkill(AccountId, SkillId)
VALUES (2, 1);

INSERT INTO RequestSkill(SkillId, RequestId)
VALUES (1, 1);

INSERT INTO Response(ResponderId, RequestId, ResponseDate, Description)
VALUES (2, 1, TO_DATE('01-03-2017', 'DD-MM-YY'), 'Ik kan helpen!');

INSERT INTO "Availability"(AccountId, Day, TimeOfDay)
VALUES (2, 'Mo', 'Middag');
INSERT INTO "Availability"(AccountId, Day, TimeOfDay)
VALUES (2, 'Di', 'Avond');
INSERT INTO "Availability"(AccountId, Day, TimeOfDay)
VALUES (2, 'Di', 'Middag');
INSERT INTO "Availability"(AccountId, Day, TimeOfDay)
VALUES (3, 'Mo', 'Ochtend');

INSERT INTO Review (Requestid, AccountId, Rating, Description)
VALUES (1, 2, 10, 'Aardige jongeman');

INSERT INTO Meeting (VolunteerId, PatientId, Location, MeetingDate, Status)
VALUES (2, 1, 'Hier', TO_DATE('20-01-1995', 'DD-MM-YYYY'), 0);

commit;

savepoint svpoint;
rollback to svpoint;