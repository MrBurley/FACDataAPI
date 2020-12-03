#!/bin/bash

TARGET_DB="facdata"
HOST="localhost"
APP_USER="facdatauser"

#Create the schemas
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Schemas/import_schema.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Schemas/general_schema.sql

#Grant usage priviliges on schemas
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT USAGE ON SCHEMA import to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT USAGE ON SCHEMA general to $APP_USER"


#Create the import tables
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/agencies.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cfdas.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cpas.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/duns.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/eins.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/findings.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/general.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/passthrough.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/revisions.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/cap-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/formatted-cap-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/findings-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/formatted-findings-text.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/Import/import_log.sql

#Grant priviliges on import tables
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.agencies to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.cfdas to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.cpas to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.duns to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.eins to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.findings to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.general to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.passthrough to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.revisions to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.captext to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.formattedcaptext to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.findingstext to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.formattedfindingstext to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE import.import_log to $APP_USER"

#Create the general tables
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/General/system_log.sql
psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Tables/General/archived_system_logs.sql

#Grant priviliges on general tables
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE general.system_logs to $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT SELECT,INSERT,UPDATE,DELETE, TRUNCATE ON TABLE general.archived_system_logs to $APP_USER"


#Grant sequence usage on all schemas
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA import TO $APP_USER"
psql -w -U $USER -h $HOST -d $TARGET_DB -c "GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA general TO $APP_USER"
