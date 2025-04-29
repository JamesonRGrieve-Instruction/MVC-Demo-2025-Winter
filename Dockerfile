FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
WORKDIR /app

# Copy csproj and restore dependencies
COPY ["src/ProjectName/*.csproj", "src/ProjectName/"]
COPY ["src/SolutionName.sln", "./"]

# Copy the rest of the project and build
COPY src/ ./src/
RUN dotnet restore src/ProjectName/*.csproj
RUN dotnet publish src/ProjectName/*.csproj -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runner
WORKDIR /app
COPY --from=builder /app/out .

# Install EF Core tools and curl for healthcheck
RUN apt-get update && apt-get install -y wget curl && \
    wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y dotnet-sdk-9.0

# Add startup script
COPY entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["/app/entrypoint.sh"]
