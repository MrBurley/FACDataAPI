CREATE TABLE import.general
(
	id serial not null,
	audityear text,
	dbkey text,
	typeofentity text,
	fyenddate text,
	audittype text,
	periodcovered text,
	numbermonths text,
	ein text,
	multipleeins text,
	einsubcode text,
	duns text,
	multipleduns text,
	auditeename text,
	street1 text,
	street2 text,
	city text,
	state text,
	zipcode text,
	auditeecontact text,
	auditeetitle text,
	auditeephone text,
	auditeefax text,
	auditeeemail text,
	auditeedatesigned text,
	auditeenametitle text,
	cpafirmname text,
	cpastreet1 text,
	cpastreet2 text,
	cpacity text,
	cpastate text,
	cpazipcode text,
	cpacontact text,
	cpatitle text,
	cpaphone text,
	cpafax text,
	cpaemail text,
	cpadatesigned text,
	cog_over text,
	cogagency text,
	oversightagency text,
	typereport_fs text,
	sp_framework text,
	sp_framework_required text,
	typereport_sp_framework text,
	goingconcern text,
	reportablecondition text,
	materialweakness text,
	materialnoncompliance text,
	typereport_mp text,
	dup_reports text,
	dollarthreshold text,
	lowrisk text,
	reportablecondition_mp text,
	materialweakness_mp text,
	qcosts text,
	cyfindings text,
	pyschedule text,
	totfedexpend text,
	datefirewall text,
	previousdatefirewall text,
	reportrequired text,
	multiple_cpas text,
	auditor_ein text,
	facaccepteddate text,
    cpaforeign text,
    cpacountry text,
	CONSTRAINT pk_import_general PRIMARY KEY ("id")

);

