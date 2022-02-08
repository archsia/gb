FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Four/HomeWork.Four.csproj", "HomeWork.Four/"]
RUN dotnet restore "HomeWork.Four/HomeWork.Four.csproj"
COPY . .
WORKDIR "/src/HomeWork.Four"
RUN dotnet build "HomeWork.Four.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Four.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Four.dll"]
