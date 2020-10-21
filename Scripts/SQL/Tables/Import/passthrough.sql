CREATE TABLE import.passthrough
(
	id serial not null,
	dbkey varchar(10),
	audityear varchar(4),
	elecauditsid varchar(12),
	passthroughname varchar(70),
	passthroughid varchar(70),
	CONSTRAINT pk_import_passthrough PRIMARY KEY ("id")
);

