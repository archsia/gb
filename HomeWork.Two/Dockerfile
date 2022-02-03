FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Two/HomeWork.Two.csproj", "HomeWork.Two/"]
RUN dotnet restore "HomeWork.Two/HomeWork.Two.csproj"
COPY . .
WORKDIR "/src/HomeWork.Two"
RUN dotnet build "HomeWork.Two.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Two.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Two.dll"]
