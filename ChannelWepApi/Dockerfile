FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["ChannelWepApi.csproj", "./"]
RUN dotnet restore "./ChannelWepApi.csproj"
COPY . .
RUN dotnet publish "ChannelWepApi.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ChannelWepApi.dll"]
