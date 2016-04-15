-- DROP TABLES --
DROP TABLE Person CASCADE CONSTRAINTS;
DROP TABLE Perk CASCADE CONSTRAINTS;
DROP TABLE Review CASCADE CONSTRAINTS;
DROP TABLE Meeting CASCADE CONSTRAINTS;
DROP TABLE Request CASCADE CONSTRAINTS;
DROP TABLE Response CASCADE CONSTRAINTS;

-- CREATE TABLES --
CREATE TABLE Person
(
	personID 			    NUMBER(10) 		    PRIMARY KEY,
	personType 		    VARCHAR2(32) 	    CHECK (personType = 'Volunteer' OR personType = 'Patient' OR personType = 'Admin' )NOT NULL,
	name  			      VARCHAR2(32) 	    NOT NULL,
	email 			      VARCHAR2(64) 	    UNIQUE NOT NULL,
	description 	    VARCHAR2(256),
	dateOfBirth 	    DATE 			        NOT NULL,
	profilePicture 	  VARCHAR2(256), 					        -- Fileserver
	location 		      VARCHAR2(256)	    NOT NULL,
	phone 			      VARCHAR2(32),
	gender 			      VARCHAR2(1) 	    CHECK(gender = 'M' OR gender = 'V') NOT NULL,
  password          VARCHAR(64)       NOT NULL
);

CREATE TABLE Perk
(
	personID 			    NUMBER(10)        NOT NULL,
	perk 			        VARCHAR2(256) 	  NOT NULL,
	
	CONSTRAINT pk_Perk PRIMARY KEY (personID, perk)
);

CREATE TABLE Review
(
	reviewID 		      NUMBER 			      PRIMARY KEY,
	reviewerID 		    NUMBER 			      NOT NULL,
	revieweeID 		    NUMBER 			      NOT NULL,
	rating 			      NUMBER 			      NOT NULL,
	description 	    VARCHAR2(256) 	  NOT NULL,
	
	CONSTRAINT c_rating CHECK(rating >0 OR rating <5)

);

CREATE TABLE Meeting
(
	volunteerID 	    NUMBER 			      NOT NULL,
	patientID 		    NUMBER 			      NOT NULL,
	"location" 		    VARCHAR2(256),
	"date"			      DATE	            NOT NULL,
	status 			      NUMBER 			      NOT NULL,
	
	CONSTRAINT pk_Meeting PRIMARY KEY(volunteerID, patientID, "location", "date"),
	CONSTRAINT c_status CHECK(status = 0 OR status = 1)
);

CREATE TABLE Request
(
	requestID 		  NUMBER 			        PRIMARY KEY,
	personID 			  NUMBER 			        NOT NULL,
	title 			    VARCHAR2(64) 	      NOT NULL,
	description 	  VARCHAR2(256) 	    NOT NULL,
	perks 			    VARCHAR2(256),
	"location" 		  VARCHAR2(256) 	    NOT NULL,
	"date" 			    DATE     		        NOT NULL,
	urgency 		    NUMBER 			        DEFAULT 0 NOT NULL,
	
	CONSTRAINT c_urgency CHECK(urgency = 0 OR urgency = 1)

);

CREATE TABLE Response
(
	responderID 	  NUMBER 			        NOT NULL,
	requestID 		  NUMBER 			        NOT NULL,
	"date" 			    DATE 			          NOT NULL,
	description 	  VARCHAR2(256) 	    NOT NULL,
	
	CONSTRAINT pk_Response PRIMARY KEY(responderID, requestID)
);

-- FOREING KEYS --
ALTER TABLE Perk ADD FOREIGN KEY(personID) REFERENCES Person(personID);
ALTER TABLE Review ADD FOREIGN KEY(reviewerID) REFERENCES Person(personID);
ALTER TABLE Review ADD FOREIGN KEY(revieweeID) REFERENCES Person(personID);
ALTER TABLE Meeting ADD FOREIGN KEY(volunteerID) REFERENCES Person(personID);
ALTER TABLE Meeting ADD FOREIGN KEY(patientID) REFERENCES Person(personID);
ALTER TABLE Request ADD FOREIGN KEY(personID) REFERENCES Person(personID);
ALTER TABLE Response ADD FOREIGN KEY(responderID) REFERENCES Person(personID);
ALTER TABLE Response ADD FOREIGN KEY(requestID) REFERENCES Request(requestID);

-- INSERT DATA --
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password)
VALUES(1, 'Patient', 'Marian', 'Marian@email.com', 'Hallo, ik ben Marian, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'filepath', 'Rachelsmolen 1, Eindhoven', '061234547', 'M', 'Wachtwoord');
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password)
VALUES(2, 'Patient', 'Dory', 'Dory@email.com', 'Hallo, ik ben Dory, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'filepath', 'Rachelsmolen 2, Eindhoven', '061234547', 'V', 'Wachtwoord');
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password)
VALUES(3, 'Volunteer', 'Jan', 'Jan@email.com', 'Hallo, ik ben Jan, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'filepath', 'Rachelsmolen 1, Eindhoven', '061234547', 'M', 'Wachtwoord');
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password)
VALUES(4, 'Volunteer', 'Nemo', 'Nemo@email.com', 'Hallo, ik ben Nemo, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'filepath', 'Rachelsmolen 5, Eindhoven', '061234547', 'M', 'Wachtwoord');
INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password)
VALUES(5, 'Admin', 'Mr. Jansen', 'M.Jansen@email.com', 'Hallo, ik ben Mr. Jansen, en dit is mijn profiel', to_date('10/09/2015', 'dd/mm/yyyy'), 'filepath', 'Rachelsmolen 1, Eindhoven', '061234547', 'M', 'Wachtwoord');

INSERT INTO Perk(personID, perk)
VALUES(1, 'Auto');
INSERT INTO Perk(personID, perk)
VALUES(2, 'Fiets');
INSERT INTO Perk(personID, perk)
VALUES(2, 'Auto');
INSERT INTO Perk(personID, perk)
VALUES(4, 'Vrije tijd');
INSERT INTO Perk(personID, perk)
VALUES(4, 'Fiets');

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

INSERT INTO Meeting(volunteerID, patientID, "location", "date", status)
VALUES(3, 1, 'Uit eten', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Meeting(volunteerID, patientID, "location", "date", status)
VALUES(4, 2, 'Naar de kerk', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Meeting(volunteerID, patientID, "location", "date", status)
VALUES(4, 1, 'Fontys Rachelsmolen', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);
INSERT INTO Meeting(volunteerID, patientID, "location", "date", status)
VALUES(3, 2, 'Naar school', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Meeting(volunteerID, patientID, "location", "date", status)
VALUES(5, 1, 'Etentje', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);

INSERT INTO Request(requestID, personID, title, description, perks, "location", "date", urgency)
VALUES(1, 1, 'Pet me dog', 'pleas pet dog', 'Dog', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);
INSERT INTO Request(requestID, personID, title, description, perks, "location", "date", urgency)
VALUES(2, 1, 'Laat mijn hond uit', 'Ik ben niet meer zo goed te been, maar mijn hond moet wel uitgelaten worden', 'Goed te been', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);
INSERT INTO Request(requestID, personID, title, description, perks, "location", "date", urgency)
VALUES(3, 1, 'Was mijn hond', 'Mijn hond moet gewassen worden, maar ik heb er geen tijd voor', 'Badkuip', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Request(requestID, personID, title, description, perks, "location", "date", urgency)
VALUES(4, 1, 'Breng mijn kinderen naar school', 'Ik heb moeite om in de ochtend op tijd klaar te zijn om mijn zoon en dochter naar school te brengen', 'auto', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 0);
INSERT INTO Request(requestID, personID, title, description, perks, "location", "date", urgency)
VALUES(5, 2, 'Ik wil naar de kerk gebracht worden', 'Ik moet naar een kerkmis een paar dorpen verderop, maar ik heb geen auto', 'auto', 'Rachelsmolen 1, Eindhoven', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 1);

INSERT INTO Response(responderID, requestID, "date", description)
VALUES(3, 2, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Is goed');
INSERT INTO Response(responderID, requestID, "date", description)
VALUES(4, 3, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Klinkt goed!');
INSERT INTO Response(responderID, requestID, "date", description)
VALUES(4, 2, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Lijkt me leuk');
INSERT INTO Response(responderID, requestID, "date", description)
VALUES(3, 1, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'k');
INSERT INTO Response(responderID, requestID, "date", description)
VALUES(3, 5, to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'same');

-- DROP SEQUENCES --
DROP SEQUENCE "SEQ_personID";
DROP SEQUENCE "SEQ_reviewID";
DROP SEQUENCE "SEQ_requestID";
DROP SEQUENCE "SEQ_responseID";

-- CREATE SEQUENCES --
CREATE SEQUENCE "SEQ_personID" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1 START WITH 5 CACHE 20 NOORDER NOCYCLE;
CREATE SEQUENCE "SEQ_reviewID" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1 START WITH 5 CACHE 20 NOORDER NOCYCLE;
CREATE SEQUENCE "SEQ_requestID" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1 START WITH 5 CACHE 20 NOORDER NOCYCLE;
CREATE SEQUENCE "SEQ_responseID" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1 START WITH 5 CACHE 20 NOORDER NOCYCLE;



INSERT INTO Person(personID, personType, name, email, description, dateOfBirth, profilePicture, location, phone, gender, password) 
VALUES(6, 'Patient', 'testnaam', 'testemail', 'Testdescription', to_date('10/09/2015 12:15', 'dd/mm/yyyy mi:ss'), 'Testurl', 'Testlocation', 'textphone', 'M', 'pw');