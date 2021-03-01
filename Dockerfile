#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# baixa a img do .net core e mete no app 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build-env 
WORKDIR /app

# copia o cs.prj para a raiz e faz restore
COPY Next.Steps.API/Next.Steps.API.csproj ./
RUN dotnet restore

# copia da direc local p/ a app, publica sln config release e mete no out
COPY . .
RUN dotnet publish Next.Steps.sln -c Release -o out

# baixa a img do asp.net, vai expor a API na porta 80, copiar da build-env do out para a app e executar
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Next.Steps.API.dll"]
