FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY Account.WebAPI/Account.WebAPI.csproj Account.WebAPI/
RUN dotnet restore "Account.WebAPI/Account.WebAPI.csproj"
COPY . .
WORKDIR "/src/Account.WebAPI"
RUN dotnet build "Account.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Account.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Account.WebAPI.dll"]
