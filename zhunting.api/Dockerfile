FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["zhunting.api/zhunting.api.csproj", "zhunting.api/"]
COPY ["zhunting.DataAccess/zhunting.DataAccess.csproj", "zhunting.DataAccess/"]
COPY ["zhunting.Data/zhunting.Data.csproj", "zhunting.Data/"]
RUN dotnet restore "zhunting.api/zhunting.api.csproj"

COPY . .

WORKDIR "/src/zhunting.api"
RUN dotnet build "zhunting.api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "zhunting.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zhunting.api.dll"]
