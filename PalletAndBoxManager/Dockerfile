FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PalletAndBoxManager/PalletAndBoxManager.csproj", "PalletAndBoxManager/"]
RUN dotnet restore "PalletAndBoxManager/PalletAndBoxManager.csproj"
COPY . .
WORKDIR "/src/PalletAndBoxManager"
RUN dotnet build "PalletAndBoxManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PalletAndBoxManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PalletAndBoxManager.dll"]
