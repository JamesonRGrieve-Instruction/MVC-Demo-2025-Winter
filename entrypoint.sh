#!/bin/bash
set -e

# Run migrations
echo "Running database migrations..."
cd /app
dotnet ef database update

# Start the application
echo "Starting application..."
dotnet ProjectName.dll
