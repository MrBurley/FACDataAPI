create table general.system_logs
(
    id serial not null,
    browser              varchar(50),
    browser_version      varchar(10),
    user_agent           varchar(400),
    host                 varchar(200),
    referrer             varchar(100),
    remote_address       varchar(100),
    path                 varchar(600),
    query_string         varchar(600),
    message              varchar(300)       not null,
    severity             varchar(15),
    event_type           varchar(200),
    event_date           date,
    success              bool,
    application_name     varchar(40),
    source               varchar(255),
    stack_trace          text,
    exception_type       varchar(255),
    detail               text,
    application_version  varchar(30),
    constraint pk_system_logs primary key (id)
);
