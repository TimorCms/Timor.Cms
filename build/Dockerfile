FROM mcr.microsoft.com/dotnet/core/sdk:5.0.100-preview.2-focal AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./ ./
RUN dotnet restore

# copy everything else and build app
RUN dotnet publish -c Release -o out src/Timor.Cms.Web/Timor.Cms.Web.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0.0-preview.2-focal AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Timor.Cms.Web.dll"]