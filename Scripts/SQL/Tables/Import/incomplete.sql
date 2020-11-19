CREATE TABLE import.incomplete
(
	id serial not null,
	audityear text,
	dbkey text,
	ein text,
	auditeename text,
	street1 text,
	street2 text,
	city text,
	state text,
	zipcode text,
	status text,
	cogagency text,
	totfedexpend text,
	initialdatereceived text,
	formdate text,
	componentdate text,
	CONSTRAINT pk_import_incomplete PRIMARY KEY ("id")
);

