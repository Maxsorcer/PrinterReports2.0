#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PrinterReports/PrinterReports.csproj", "PrinterReports/"]
RUN dotnet restore "PrinterReports/PrinterReports.csproj"
COPY . .
WORKDIR "/src/PrinterReports"
RUN dotnet build "PrinterReports.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrinterReports.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrinterReports.dll"]