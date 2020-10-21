
CREATE TABLE import.findings
(

	id serial not null,
	dbkey varchar(10),
	audityear varchar(4),
	elecauditsid varchar(10),
	elecauditfindingsid varchar(10),
	findingsrefnums varchar(100),
	typerequirement varchar(16),
	modifiedopinion varchar(1),
	othernoncompliance varchar(1),
	materialweakness varchar(1),
	significantdeficiency varchar(1),
	otherfindings varchar(1),
	qcosts varchar(1),
	repeatfinding varchar(1),
	priorfindingrefnums varchar(100),
	CONSTRAINT pk_import_findings PRIMARY KEY ("id")	
);

	
