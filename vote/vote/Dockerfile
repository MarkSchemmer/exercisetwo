FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["vote/vote.csproj", "vote/"]
RUN dotnet restore "vote/vote.csproj"
COPY . .
WORKDIR "/src/vote"
RUN dotnet build "vote.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "vote.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "vote.dll"]