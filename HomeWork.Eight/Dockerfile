FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Eight/HomeWork.Eight.csproj", "HomeWork.Eight/"]
RUN dotnet restore "HomeWork.Eight/HomeWork.Eight.csproj"
COPY . .
WORKDIR "/src/HomeWork.Eight"
RUN dotnet build "HomeWork.Eight.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Eight.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Eight.dll"]
