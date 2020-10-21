#!/bin/bash

TARGET_DB="facdata"
HOST="localhost"

psql -w -U $USER -h $HOST -d $TARGET_DB -f ./SQL/Schemas/import_schema.sql
