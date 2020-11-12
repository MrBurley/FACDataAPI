CREATE TABLE import.import_log
(
    id serial not null,
    area text,
    records_imported numeric,
    success bool,
    dataerrors bool,
    baddata text,
    importstarted date,
    importended date,
    executiontime interval, 
    CONSTRAINT pk_import_log PRIMARY KEY ("id")
);
