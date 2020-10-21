CREATE TABLE import.cfdas
(
	id serial not null,
	audityear varchar(4),
	dbkey varchar(10),
	ein varchar(9),
	cfda varchar(55),
	awardidentification varchar(50),
	rd varchar(1),
	federalprogramname varchar(300),
	amount varchar(12),
	clustername varchar(75),
	stateclustername varchar(75),
	programtotal varchar(12),
	clustertotal varchar(12),
	direct varchar(1),
	passthroughaward varchar(1),
	passthroughamount varchar(12),
	majorprogram varchar(1),
	typereport_mp varchar(1),
	typerequirement varchar(15),
	qcosts2 varchar(12),
	findings varchar(2),
	findingrefnums varchar(100),
	arra varchar(4),
	loans varchar(4),
	loanbalance varchar(12),
	findingscount varchar(7),
	elecauditsid varchar(12), 
	CONSTRAINT pk_import_cfdas PRIMARY KEY ("id")	
);


