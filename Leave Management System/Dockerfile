#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Leave Management System/Leave Management System.csproj", "Leave Management System/"]
RUN dotnet restore "Leave Management System/Leave Management System.csproj"
COPY . .
WORKDIR "/src/Leave Management System"
RUN dotnet build "Leave Management System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Leave Management System.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Leave Management System.dll"]