FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RecipeApp/RecipeApp.csproj", "RecipeApp/"]
RUN dotnet restore "RecipeApp/RecipeApp.csproj"
COPY . .
WORKDIR "/src/RecipeApp"
RUN dotnet build "RecipeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipeApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeApp.dll"]
