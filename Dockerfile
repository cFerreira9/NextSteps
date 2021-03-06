#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build-env 
WORKDIR /app

COPY Next.Steps.API/Next.Steps.API.csproj ./
WORKDIR Next.Steps.API
RUN dotnet restore

COPY . ./
RUN dotnet publish Next.Steps.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Next.Steps.API.dll"]
