#!/bin/bash

TARGET_DB="facdata"
HOST="localhost"

#Create the schemas
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Schemas/import_schema.sql

#Create the tables
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/agencies.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cfdas.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cpas.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/duns.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/eins.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/findings.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/general.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/incomplete.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/passthrough.sql
