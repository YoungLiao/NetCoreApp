#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:2.2-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["WindowsService1/WindowsService1.csproj", "WindowsService1/"]
RUN dotnet restore "WindowsService1/WindowsService1.csproj"
COPY . .
WORKDIR "/src/WindowsService1"
RUN dotnet build "WindowsService1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WindowsService1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WindowsService1.dll"]