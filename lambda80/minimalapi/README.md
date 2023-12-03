# Minimal API

This is a minimal API using .NET 8.0 and C# 12.0

This project was created using the following command:
```shell
dotnet new web -o minimalapi
```
It was then modified to use the minimal API syntax.

## TODO
- Intention is to use this as a starting point for a serverless API, but this is not implemented yet
  - The base image in the [working lambda example](../../lambda/README.md) in this project is `mcr.microsoft.com/dotnet/sdk:6.0` 
    which is quite 
    different the one that is used here `mcr.microsoft.com/dotnet/sdk:8.0`
- `<PublishAot>true</PublishAot>` is not working yet 
  - see [Dockerfile-aot](./minimalapi/Dockerfile-aot) 
  - see [Dockerfile-aot2](./minimalapi/Dockerfile-aot2) 

  for attempts to get it working

## Local development
Local development is done using the `dotnet` dev server or using docker

cd into the `minimalapi` directory befor running the other cmds
```shell
cd lambda80/minimalapi
```

### `dotnet` dev server
Run dev server from local machine
```shell
dotnet run
```
Open [http://localhost:5180/](http://localhost:5180/) in the browser

### Other commands
```shell
dotnet publish -c Release -f net8.0 -r linux-x64
dotnet build -c Release
dotnet publish -c Release
```
### Docker
Run using docker instead 

Build docker image
```shell
docker build -t minimalapi:latest .
```

Run docker image
```shell
docker run -p 8080:8080 minimalapi:latest
```

Open [http://localhost:8080/](http://localhost:8080/) in the browser