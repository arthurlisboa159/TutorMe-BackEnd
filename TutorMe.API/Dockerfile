FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TutorMe.API/TutorMe.API.csproj", "TutorMe.API/"]
RUN dotnet restore "TutorMe.API/TutorMe.API.csproj"
COPY . .
WORKDIR "/src/TutorMe.API"
RUN dotnet build "TutorMe.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TutorMe.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TutorMe.API.dll"]
