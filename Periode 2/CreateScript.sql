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
  Accountid Number(10) Primary Key,
  Username Varchar2(32) Not Null,
  Password Varchar2(32) Not Null Unique,
  Email Varchar2(255) Not Null Unique
);

Create Table "User"
(
  Accountid Number(10) Primary Key,
  Name Varchar2(32) Not Null,
  Phone Varchar2(16),
  Datederegistration Date,
  Adress Varchar2(255),
  Location Varchar(255),
  Car Varchar2(1) DEFAULT '0',
  Driverslicense Varchar2(1) DEFAULT '0',
  Rfid Varchar2(255),
  Banned Varchar2(1) DEFAULT '0',
  Unban Date,
  Enabled Varchar2(1) DEFAULT '1', 
  CHECK (Car = '1' OR Car = '0'), 
  CHECK (Banned = '1' OR Banned = '0'), 
  CHECK (Enabled = '1' OR Enabled = '0') 
);

Create Table "Admin"
(
  Accountid Number(10) Primary Key
);


Create Table Volunteer
(
  Accountid Number(10) Primary Key,
  Vog Varchar2(255),
  Birthdate Date,
  Photo Varchar2(255),
  VogConfirmation Varchar2(1) DEFAULT '0',
  CHECK (VogConfirmation = '1' OR VogConfirmation = '0') 
);

Create Table Skill
(
  Skillid Number(10) Primary Key,
  Description Varchar2(255) Not Null
);

Create Table Request
(
  Requestid Number(10) Primary Key,
  Description Varchar2(255),
  Location Varchar2(255),
  Traveltime Timestamp,
  Startdate Date,
  Enddate Date,
  Urgency Number(1),
  Amountofvolunteers Number(10)
);

Create Table Review
(  
  Reviewid Number(10),
  Accountid Number(10),
  Requestid Number(10),
  Rating Number(2),
  "Comment" Varchar2(255),
  Primary Key (Reviewid, Accountid, Requestid)
);

Create Table Vehicletype
( 
  VehicleTypeId Number(10),
  Requestid Number(10),
  Description Varchar2(255) Not Null,
  Primary Key (Vehicletypeid, Requestid)
);

Create Table Patient
( 
  Accountid Number(10) Primary Key,
  Ov Varchar2(1) DEFAULT '0',
  CHECK (Ov = '1' OR Ov = '0')
);

Create Table Meeting
(
  Volunteerid Number(10),
  Patientid Number(10),
  Location Varchar(255),
  Meetingdate Date,
  Status Varchar2(1) DEFAULT '0',
  Primary Key(Volunteerid, Patientid),
  CHECK (Status = '1' OR Status = '0')
);

Create Table Volunteerskill
(
  Accountid Number(10),
  Skillid Number(10),
  Primary Key (Accountid, Skillid)
);
--TODO Drop below
Create Table Requestskill
(
  Requestid Number(10),
  Skillid Number(10),
  Primary Key (RequestId, Skillid)
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
  Accountid Number(10) Primary Key,
  Day Varchar2(2),
  Timeofday Varchar2(10),
  CHECK (Day = 'Mo' OR Day = 'Di' OR Day = 'Wo' OR Day = 'Do' OR Day = 'Vr' OR Day = 'Za' OR Day = 'Zo')
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
Alter Table "User" Add Foreign Key (Accountid) References "Account"(Accountid);
Alter Table "Admin" Add Foreign Key (Accountid) References "Account"(Accountid);
Alter Table Volunteer Add Foreign Key (Accountid) References "User"(Accountid);
Alter Table Patient Add Foreign Key (Accountid) References "User" (Accountid);
Alter Table "Availability" Add Foreign Key (Accountid) References Volunteer(Accountid);
Alter Table Meeting Add Foreign Key (Volunteerid) References Volunteer(Accountid);
Alter Table Meeting Add Foreign Key (Patientid) References Patient(Accountid);
Alter Table Chat Add Foreign Key (Accounta) References Volunteer(Accountid);
Alter Table Chat Add Foreign Key (Accountb) References Patient(Accountid);
Alter Table Volunteerskill Add Foreign Key (Accountid) References Volunteer(Accountid);
Alter Table Volunteerskill Add Foreign Key (Skillid) References Skill(Skillid);
Alter Table Requestskill Add Foreign Key (RequestId) References Request(RequestId);
Alter Table Requestskill Add Foreign Key (SkillId) References Skill(SkillId);
Alter Table Review Add Foreign Key (RequestId) References Request(RequestId);
Alter Table Review Add Foreign Key (AccountId) References Volunteer(AccountId);
Alter Table Response Add Foreign Key (ResponderId) References Volunteer(AccountId);
Alter Table Response Add Foreign Key (RequestId) References Request(RequestId);
Alter Table VehicleType Add Foreign Key (Requestid) References Request(RequestId);


/*
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
*/

--AUTO IDINTIFIER INCREMENT SEQUENCES
DROP SEQUENCE AccountIncrementSeq;
DROP SEQUENCE SkillIncrementSeq;
DROP SEQUENCE ReviewIncrementSeq;
DROP SEQUENCE RequestIncrementSeq;

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

--AUTO IDINTIFIER INCREMENT TRIGGERS
DROP TRIGGER AccountIncrementTrig;
DROP TRIGGER SkillIncrementTrig;
DROP TRIGGER ReviewIncrementTrig;
DROP TRIGGER RequestIncrementTrig;

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

INSERT INTO "Account" (Username, Password, Email) VALUES ('patient', 'patient', 'patient@patient.nl');
INSERT INTO "User" (AccountId, Name) VALUES (1, 'patientje');
INSERT INTO Patient (AccountId) VALUES (1);

INSERT INTO "Account" (Username, Password, Email) VALUES ('volunteer', 'volunteer', 'volunteer@volunteer.nl'); 
INSERT INTO "User" (AccountId, Name) VALUES (2, 'volunteertje');
INSERT INTO Volunteer (AccountId) VALUES (2);

INSERT INTO "Account" (Username, Password, Email) VALUES ('admin', 'admin', 'admin@admin.nl');
INSERT INTO "Admin" (AccountId) VALUES (3);

commit;

SELECT ad.AccountId as "AdminId",
v.AccountId as "VolunteerId", v.Birthdate, v.Photo, v.Vog, v.VogConfirmation,
P.Ov, p.AccountId as "PatientId", a.AccountId as "UserId", a.Username, a.Password, a.Email, 
u.Name, u.Phone, u. Datederegistration, u.Adress, u.Location, u.Car, u.DriversLicense, u.Rfid, u.Banned, u.Unban, u.Enabled 
FROM "User" u FULL OUTER JOIN "Account" a ON u.AccountId = a.AccountId
FULL OUTER JOIN "Admin" ad ON ad.AccountId = a.AccountId
FULL OUTER JOIN Volunteer v ON v.AccountId = a.AccountId
FULL OUTER JOIN Patient p ON v.AccountId = p.AccountId
WHERE a.Username = 'patient' AND a.Password = 'patient' 
; 