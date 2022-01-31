FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork/HomeWork.csproj", "HomeWork/"]
RUN dotnet restore "HomeWork/HomeWork.csproj"
COPY . .
WORKDIR "/src/HomeWork"
RUN dotnet build "HomeWork.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.dll"]
