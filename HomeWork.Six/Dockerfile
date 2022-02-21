FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Six/HomeWork.Six.csproj", "HomeWork.Six/"]
RUN dotnet restore "HomeWork.Six/HomeWork.Six.csproj"
COPY . .
WORKDIR "/src/HomeWork.Six"
RUN dotnet build "HomeWork.Six.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Six.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Six.dll"]
