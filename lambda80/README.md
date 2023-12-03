# Welcome to your CDK C# project!

This is a blank project for CDK development with C#.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

It uses the [.NET CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute your project.

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template

## Local development

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

Build docker image
```shell
docker build -t minimalapi:latest .
```

Run docker image
```shell
docker run -p 8080:8080 minimalapi:latest
```

Open [http://localhost:8080/](http://localhost:8080/) in the browser