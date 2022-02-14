FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeWork.Five/HomeWork.Five.csproj", "HomeWork.Five/"]
RUN dotnet restore "HomeWork.Five/HomeWork.Five.csproj"
COPY . .
WORKDIR "/src/HomeWork.Five"
RUN dotnet build "HomeWork.Five.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeWork.Five.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeWork.Five.dll"]
