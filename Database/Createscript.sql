SET SERVEROUTPUT ON;

-- DROP TABLES --
DROP TABLE Person CASCADE CONSTRAINTS;
DROP TABLE Perk CASCADE CONSTRAINTS;
DROP TABLE PERK_PERSON CASCADE CONSTRAINTS;
DROP TABLE Review CASCADE CONSTRAINTS;
DROP TABLE Meeting CASCADE CONSTRAINTS;
DROP TABLE Request CASCADE CONSTRAINTS;
DROP TABLE Response CASCADE CONSTRAINTS;
DROP TABLE Perk_Request CASCADE CONSTRAINTS;




-- CREATE TABLES --
CREATE TABLE Person
(
	personID 			      NUMBER(10) 		    PRIMARY KEY,
	personType 		    	VARCHAR2(32) 	    NOT NULL,
	name  			      	VARCHAR2(32) 	    NOT NULL,
	email 			      	VARCHAR2(64) 	    UNIQUE NOT NULL,
	description 	    	VARCHAR2(256),
	dateOfBirth 	    	DATE 			        NOT NULL,
	profilePicture 	  	VARCHAR2(256), 					        -- Fileserver
	location 		      	VARCHAR2(256)	    NOT NULL,
	phone 			      	VARCHAR2(32),
	gender 			      	VARCHAR2(1) 	    NOT NULL,
	password          		VARCHAR(64)       	NOT NULL,
	rfid					VARCHAR(64)			UNIQUE,
	vog						VARCHAR(255)    	UNIQUE,              -- Fileserver
	banned					NUMBER(1)			DEFAULT 0,
	unban					DATE,
	enabled					NUMBER(1)			DEFAULT 1,

	
	CONSTRAINT c_personType CHECK (personType = 'Volunteer' OR personType = 'Patient' OR personType = 'Admin'),
	CONSTRAINT c_gender CHECK(gender = 'M' OR gender = 'V'),
	CONSTRAINT c_banned CHECK(banned = 0 OR  banned = 1 OR banned = 2),
	CONSTRAINT c_enabled CHECK(enabled = 0 or enabled = 1)
	-- 0 = not banned, 1 = banned until X, 2 = permanent banned
);

CREATE TABLE Perk
(

	perkID					NUMBER				        PRIMARY KEY,
	perktext 			    VARCHAR2(256) 	  	NOT NULL
);

Create TABLE PERK_PERSON
(
perkID            NUMBER(10)            NOT NULL,
personID          NUMBER(10)            NOT NULL,

CONSTRAINT pk_Perk_Person PRIMARY KEY(perkID, personID)
);

CREATE TABLE Review
(
	reviewID 		      	NUMBER 			    PRIMARY KEY,
	reviewerID 		    	NUMBER 			    NOT NULL,
	revieweeID 		    	NUMBER 			    NOT NULL,
	rating 			      	NUMBER 			    NOT NULL,
	description 	    	VARCHAR2(256) 	NOT NULL,
	
	CONSTRAINT c_rating CHECK(rating >0 OR rating <5)
);


CREATE TABLE Meeting
(
	volunteerID 	    	NUMBER 			   	NOT NULL,
	patientID 		    	NUMBER 			    NOT NULL,
	place 		    		VARCHAR2(256),
	placingdate			  	DATE	            NOT NULL,
	status 			      	NUMBER 			    NOT NULL,
	
	CONSTRAINT pk_Meeting PRIMARY KEY(volunteerID, patientID, place, placingdate),
	CONSTRAINT c_status CHECK(status = 0 OR status = 1)
);

CREATE TABLE Request
(
	requestID 		  	NUMBER 			    PRIMARY KEY,
	personID 			  	NUMBER 			    NOT NULL,
	title 			    	VARCHAR2(64) 	    NOT NULL,
	description 	  		VARCHAR2(256) 	    NOT NULL,
	place 		  			VARCHAR2(256) 	    NOT NULL,
	placingdate			    DATE     		    NOT NULL,
	urgency 		    	NUMBER 			    DEFAULT 0 NOT NULL,
	
	CONSTRAINT c_urgency CHECK(urgency >= 0 OR urgency <= 5)
);

CREATE TABLE Response
(
	responderID 	  		NUMBER 			    NOT NULL,
	requestID 		  		NUMBER 			    NOT NULL,
	placingDate			    DATE 			    NOT NULL,
	description 	  		VARCHAR2(256) 	    NOT NULL,
	CONSTRAINT pk_Response PRIMARY KEY(responderID, requestID)
);

CREATE TABLE Perk_Request
(
	requestID				NUMBER 				NOT NULL,
	perkID					NUMBER 				NOT NULL					
);


-- FOREIGN KEYS --
ALTER TABLE PERK_PERSON ADD FOREIGN KEY(personID)     REFERENCES Person(PersonID);
ALTER TABLE PERK_PERSON ADD FOREIGN KEY(perkID)       REFERENCES PERK(perkID);
ALTER TABLE Review 			ADD FOREIGN KEY(reviewerID) 	REFERENCES Person(personID);
ALTER TABLE Review 			ADD FOREIGN KEY(revieweeID) 	REFERENCES Person(personID);
ALTER TABLE Meeting 		ADD FOREIGN KEY(volunteerID) 	REFERENCES Person(personID);
ALTER TABLE Meeting 		ADD FOREIGN KEY(patientID) 		REFERENCES Person(personID);
ALTER TABLE Request 		ADD FOREIGN KEY(personID) 		REFERENCES Person(personID);
ALTER TABLE Response 		ADD FOREIGN KEY(responderID) 	REFERENCES Person(personID);
ALTER TABLE Response 		ADD FOREIGN KEY(requestID) 		REFERENCES Request(requestID);
ALTER TABLE Perk_Request	ADD FOREIGN KEY(requestID)		REFERENCES Request(requestID);
ALTER TABLE Perk_Request	ADD FOREIGN KEY(perkID)			REFERENCES Perk(perkID);


-- INSERT DATA --
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password, rfid, vog, banned, enabled)
VALUES(1, 'Patient', 'Marian', 'Marian@email.com', 'Hallo, ik ben Marian, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'pf0.png', 'Rachelsmolen 1, Eindhoven', '061234547', 'M', 'Wachtwoord', 1, 'file1', 0, 1);
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password, rfid, vog, banned, enabled)
VALUES(2, 'Patient', 'Dory', 'Dory@email.com', 'Hallo, ik ben Dory, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'pf0.png', 'Rachelsmolen 2, Eindhoven', '061234547', 'V', 'Wachtwoord', 2, 'file2', 0, 1);
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password, rfid, vog, banned, enabled)
VALUES(3, 'Volunteer', 'Jan', 'Jan@email.com', 'Hallo, ik ben Jan, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'pf0.png', 'Rachelsmolen 1, Eindhoven', '061234547', 'M', 'Wachtwoord', 3, 'file3', 0, 1);
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password, rfid, vog, banned, enabled)
VALUES(4, 'Volunteer', 'Nemo', 'Nemo@email.com', 'Hallo, ik ben Nemo, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'pf0.png', 'Rachelsmolen 5, Eindhoven', '061234547', 'M', 'Wachtwoord', 4, 'file4', 0, 1);
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password, rfid, vog, banned, enabled)
VALUES(5, 'Admin', 'Mr. Jansen', 'M.Jansen@email.com', 'Hallo, ik ben Mr. Jansen, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'pf0.png', 'Rachelsmolen 1, Eindhoven', '061234547', 'M', 'Wachtwoord', 5, 'file5', 0, 1);

INSERT INTO Perk(perkID, perktext)
VALUES(1, 'Auto');
INSERT INTO Perk(perkID, perktext)
VALUES(2, 'Fiets');
INSERT INTO Perk(perkID, perktext)
VALUES(3, 'Brommer');
INSERT INTO Perk(perkID, perktext)
VALUES(4, 'Vrije tijd');
INSERT INTO Perk(perkID, perktext)
VALUES(5, 'Computervaardig');

INSERT INTO PERK_PERSON(perkID, personID) VALUES(1, 1);
INSERT INTO PERK_PERSON(perkID, personID) VALUES(2, 2);
INSERT INTO PERK_PERSON(perkID, personID) VALUES(3, 2);
INSERT INTO PERK_PERSON(perkID, personID) VALUES(4, 4);
INSERT INTO PERK_PERSON(perkID, personID) VALUES(5, 4);

INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description)
VALUES(1, 1, 3, 5, 'Leuke knul');
INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description)
VALUES(2, 2, 3, 1, 'kwam niet opdagen???');
INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description)
VALUES(3, 4, 2, 4, 'super cool');
INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description)
VALUES(4, 1, 3, 2, 'was wel okay');
INSERT INTO Review(reviewID, reviewerID, revieweeID, rating, description)
VALUES(5, 1, 3, 1, 'Deed het niet goed, kwam niet spontaan over');


INSERT INTO Meeting(volunteerID, patientID, place, placingdate, status)
VALUES(3, 1, 'Uit eten', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Meeting(volunteerID, patientID, place, placingdate, status)
VALUES(4, 2, 'Naar de kerk', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Meeting(volunteerID, patientID, place, placingdate, status)
VALUES(4, 1, 'Fontys Rachelsmolen', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);
INSERT INTO Meeting(volunteerID, patientID, place, placingdate, status)
VALUES(3, 2, 'Naar school', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Meeting(volunteerID, patientID, place, placingdate, status)
VALUES(5, 1, 'Etentje', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);

INSERT INTO Request(requestID, personID, title, description, place, placingdate, urgency)
VALUES(1, 1, 'Pet me dog', 'pleas pet dog', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);
INSERT INTO Request(requestID, personID, title, description, place, placingdate, urgency)
VALUES(2, 1, 'Laat mijn hond uit', 'Ik ben niet meer zo goed te been, maar mijn hond moet wel uitgelaten worden', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);
INSERT INTO Request(requestID, personID, title, description, place, placingdate, urgency)
VALUES(3, 1, 'Was mijn hond', 'Mijn hond moet gewassen worden, maar ik heb er geen tijd voor', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Request(requestID, personID, title, description, place, placingdate, urgency)
VALUES(4, 1, 'Breng mijn kinderen naar school', 'Ik heb moeite om in de ochtend op tijd klaar te zijn om mijn zoon en dochter naar school te brengen', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Request(requestID, personID, title, description, place, placingdate, urgency)
VALUES(5, 2, 'Ik wil naar de kerk gebracht worden', 'Ik moet naar een kerkmis een paar dorpen verderop, maar ik heb geen auto', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);

INSERT INTO Response(responderID, requestID, placingdate, description)
VALUES(3, 2, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Is goed');
INSERT INTO Response(responderID, requestID, placingdate, description)
VALUES(4, 3, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Klinkt goed!');
INSERT INTO Response(responderID, requestID, placingdate, description)
VALUES(4, 2, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Lijkt me leuk');
INSERT INTO Response(responderID, requestID, placingdate, description)
VALUES(3, 1, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'k');
INSERT INTO Response(responderID, requestID, placingdate, description)
VALUES(3, 5, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'same');


INSERT INTO Perk_Request(requestID, perkID)
VALUES(1, 1);
INSERT INTO Perk_Request(requestID, perkID)
VALUES(2, 1);
INSERT INTO Perk_Request(requestID, perkID)
VALUES(2, 2);
INSERT INTO Perk_Request(requestID, perkID)
VALUES(4, 3);
INSERT INTO Perk_Request(requestID, perkID)
VALUES(2, 3);

-- DROP SEQUENCES --
DROP SEQUENCE SEQ_personID;
DROP SEQUENCE SEQ_reviewID;
DROP SEQUENCE SEQ_requestID;
DROP SEQUENCE SEQ_responseID;
DROP SEQUENCE SEQ_PerkID;

-- CREATE SEQUENCES --

--CREATE SEQUENCE SEQ_personID
DECLARE
    I_personID INTEGER := 0;
BEGIN
   SELECT max(personID) + 1
   INTO   I_personID
   FROM   person;
   EXECUTE IMMEDIATE 'CREATE SEQUENCE SEQ_personID
                       start with ' || I_personID ||
                       ' increment by 1';
END;
/
--CREATE SEQUENCE SEQ_reviewID
DECLARE
    I_reviewID INTEGER := 0;
BEGIN
   SELECT max(reviewID) + 1
   INTO   I_reviewID
   FROM   review;
   EXECUTE IMMEDIATE 'CREATE SEQUENCE SEQ_reviewID
                       start with ' || I_reviewID ||
                       ' increment by 1';
END;
/
--CREATE SEQUENCE SEQ_requestID
DECLARE
    I_requestID INTEGER := 0;
BEGIN
   SELECT max(requestID) + 1
   INTO   I_requestID
   FROM   request;
   EXECUTE IMMEDIATE 'CREATE SEQUENCE SEQ_requestID
                       start with ' || I_requestID ||
                       ' increment by 1';
END;
/

--CREATE SEQUENCE SEQ_responseID
DECLARE
  I_responderID INTEGER := 0;
BEGIN
   SELECT max(responderID) + 1
   INTO   I_responderID
   FROM   response;
   EXECUTE IMMEDIATE 'CREATE SEQUENCE SEQ_responseID
                       start with ' || I_responderID ||
                       ' increment by 1';
END;
/

--CREATE SEQUENCE SEQ_PerkID
DECLARE
  I_PerkID INTEGER := 0;
BEGIN
   SELECT max(perkID) + 1
   INTO   I_PerkID
   FROM   perk;
   EXECUTE IMMEDIATE 'CREATE SEQUENCE SEQ_PerkID
                       start with ' || I_PerkID ||
                       ' increment by 1';
END;
/



COMMIT;