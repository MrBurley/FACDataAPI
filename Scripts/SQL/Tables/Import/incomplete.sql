CREATE TABLE import.incomplete
(
	id serial not null,
	audityear varchar(4),
	dbkey varchar(10),
	ein varchar(9),
	auditeename varchar(70),
	street1 varchar(45),
	street2 varchar(45),
	city varchar(30),
	state varchar(2),
	zipcode varchar(10),
	status varchar(10),
	cogagency varchar(4),
	totfedexpend varchar(12),
	initialdatereceived varchar(10),
	formdate varchar(10),
	componentdate varchar(10),
	CONSTRAINT pk_import_incomplete PRIMARY KEY ("id")
);

