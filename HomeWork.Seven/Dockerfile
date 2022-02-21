FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Seven/HomeWork.Seven.csproj", "HomeWork.Seven/"]
RUN dotnet restore "HomeWork.Seven/HomeWork.Seven.csproj"
COPY . .
WORKDIR "/src/HomeWork.Seven"
RUN dotnet build "HomeWork.Seven.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Seven.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Seven.dll"]
