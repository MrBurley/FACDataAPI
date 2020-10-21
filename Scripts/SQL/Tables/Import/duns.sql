CREATE TABLE import.duns
(
	id serial not null,
	audityear varchar(4),
	dbkey varchar(10),
	duns varchar(9),
	dunseqnum varchar(4),
	CONSTRAINT pk_import_duns PRIMARY KEY ("id")
);


