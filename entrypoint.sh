#!/bin/bash
set -e

# Wait for the database to be ready
#until nc -z -v -w30 postgres 5432
#do
#  echo "Waiting for the PostgreSQL container..."
#  sleep 5
#done

# Apply database migrations
dotnet ef database update

# Run the main application
exec "$@"
