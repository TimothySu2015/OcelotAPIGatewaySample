FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY Payment.WebAPI/Payment.WebAPI.csproj Payment.WebAPI/
RUN dotnet restore "Payment.WebAPI/Payment.WebAPI.csproj"
COPY . .
WORKDIR "/src/Payment.WebAPI"
RUN dotnet build "Payment.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.WebAPI.dll"]
