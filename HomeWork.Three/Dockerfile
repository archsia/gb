FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Three/HomeWork.Three.csproj", "HomeWork.Three/"]
RUN dotnet restore "HomeWork.Three/HomeWork.Three.csproj"
COPY . .
WORKDIR "/src/HomeWork.Three"
RUN dotnet build "HomeWork.Three.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Three.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Three.dll"]
