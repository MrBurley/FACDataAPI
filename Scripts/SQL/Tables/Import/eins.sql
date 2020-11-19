CREATE TABLE import.eins
(
	id serial not null,
	audityear text,
	dbkey text,
	ein text,
	einseqnum text,
	CONSTRAINT pk_import_eins PRIMARY KEY ("id")
);

