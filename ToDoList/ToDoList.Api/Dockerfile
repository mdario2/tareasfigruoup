#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5024

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ToDoList.Api/ToDoList.Api.csproj", "ToDoList.Api/"]
COPY ["ToDoList.Infraestructure/ToDoList.Infraestructure.csproj", "ToDoList.Infraestructure/"]
COPY ["ToDoList.Core/ToDoList.Core.csproj", "ToDoList.Core/"]
RUN dotnet restore "ToDoList.Api/ToDoList.Api.csproj"
COPY . .
WORKDIR "/src/ToDoList.Api"
RUN dotnet build "ToDoList.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoList.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.Api.dll"]