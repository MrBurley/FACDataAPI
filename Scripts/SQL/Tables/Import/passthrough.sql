CREATE TABLE import.passthrough
(
	id serial not null,
	dbkey text,
	audityear text,
	elecauditsid text,
	passthroughname text,
	passthroughid text,
	CONSTRAINT pk_import_passthrough PRIMARY KEY ("id")
);

