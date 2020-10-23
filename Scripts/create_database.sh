#!/bin/bash

TARGET_DB="facdata"
HOST="localhost"

#Create the schemas
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Schemas/import_schema.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Schemas/general_schema.sql


#Create the import tables
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/agencies.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cfdas.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cpas.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/duns.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/eins.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/findings.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/general.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/incomplete.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/passthrough.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/revisions.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cap-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/formatted-cap-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/findings-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/formatted-findings-text.sql

#Create the general tables
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/General/system_log.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/General/archived_system_logs.sql


