CREATE TABLE import.formattedcaptext
(
    id             serial not null,
    seq_number     varchar(4),
    dbkey          varchar(10),
    audityear      varchar(4),
    findingrefnums varchar(100),
    text           text,
    chartstables   varchar(1),
    CONSTRAINT pk_import_formattedcaptext PRIMARY KEY ("id")
);