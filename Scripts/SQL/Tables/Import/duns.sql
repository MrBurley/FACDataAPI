CREATE TABLE import.duns
(
	id serial not null,
	audityear text,
	dbkey text,
	duns text,
	dunseqnum text,
	CONSTRAINT pk_import_duns PRIMARY KEY ("id")
);


