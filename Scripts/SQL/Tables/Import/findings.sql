
CREATE TABLE import.findings
(

	id serial not null,
	dbkey text,
	audityear text,
	elecauditsid text,
	elecauditfindingsid text,
	findingsrefnums text,
	typerequirement text,
	modifiedopinion text,
	othernoncompliance text,
	materialweakness text,
	significantdeficiency text,
	otherfindings text,
	qcosts text,
	repeatfinding text,
	priorfindingrefnums text,
	CONSTRAINT pk_import_findings PRIMARY KEY ("id")	
);

	
