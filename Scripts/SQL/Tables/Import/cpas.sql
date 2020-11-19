CREATE TABLE import.cpas
(
	id serial not null,
	dbkey text,
	audityear text,
	cpafirmname text,
	cpaein text,
	cpastreet1 text,
	cpacity text,
	cpastate text,
	cpazipcode text,
	cpacontact text,
	cpatitle text,
	cpaphone text,
	cpafax text,
	cpaemail text,
	CONSTRAINT pk_import_cpas PRIMARY KEY ("id")   
);


