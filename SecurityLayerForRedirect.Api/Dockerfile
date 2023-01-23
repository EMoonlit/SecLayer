FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecurityLayerForRedirect.Api/SecurityLayerForRedirect.Api.csproj", "SecurityLayerForRedirect.Api/"]
RUN dotnet restore "SecurityLayerForRedirect.Api/SecurityLayerForRedirect.Api.csproj"
COPY . .
WORKDIR "/src/SecurityLayerForRedirect.Api"
RUN dotnet build "SecurityLayerForRedirect.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecurityLayerForRedirect.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecurityLayerForRedirect.Api.dll"]
