FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-focal AS runtime
WORKDIR /app
COPY ./out/ ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Timor.Cms.Web.dll"]