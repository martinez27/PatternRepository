#Obtener la imagen base 
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

#Copiado de csproj y restauracion
COPY ["PatternRepository.API/PatternRepository.API.csproj","./"]
RUN dotnet restore

#Copiado de todos los demas archivos y contruir la imagen
COPY . ./
RUN dotnet publish PatternRepository.API -c Release -o out

#Generar imagen en tiempo de ejecucion 
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","PatternRepository.API.dll"]