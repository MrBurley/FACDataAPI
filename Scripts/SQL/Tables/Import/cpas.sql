CREATE TABLE import.cpas
(
	id serial not null,
	dbkey varchar(10),
	audityear varchar(4),
	cpafirmname varchar(70),
	cpaein varchar(9),
	cpastreet1 varchar(50),
	cpacity varchar(30),
	cpastate varchar(2),
	cpazipcode varchar(9),
	cpacontact varchar(50),
	cpatitle varchar(40),
	cpaphone varchar(10),
	cpafax varchar(10),
	cpaemail varchar(60),
	CONSTRAINT pk_import_cpas PRIMARY KEY ("id")   
);


