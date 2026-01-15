FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy csproj and restore
COPY ["ChannelWepApi.csproj", "./"]
RUN dotnet restore "./ChannelWepApi.csproj"

# copy everything else and publish
COPY . .
RUN dotnet publish "ChannelWepApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ChannelWepApi.dll"]
