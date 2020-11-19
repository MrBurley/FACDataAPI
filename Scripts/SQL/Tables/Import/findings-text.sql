CREATE TABLE import.findingstext
(
    id             serial not null,
    seq_number     text,
    dbkey          text,
    audityear      text,
    findingrefnums text,
    text           text,
    chartstables   text,
    CONSTRAINT pk_import_findingstext PRIMARY KEY ("id")
);