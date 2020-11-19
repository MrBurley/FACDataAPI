CREATE TABLE import.formattedcaptext
(
    id             serial not null,
    seq_number     text,
    dbkey          text,
    audityear      text,
    findingrefnums text,
    text           text,
    chartstables   text,
    CONSTRAINT pk_import_formattedcaptext PRIMARY KEY ("id")
);