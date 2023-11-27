# Welcome to your CDK C# project!

This is a blank project for CDK development with C#.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

It uses the [.NET CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute your project.

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template

https://878rhuh3d9.execute-api.eu-west-1.amazonaws.com/prod/items


example curl 
```shell
curl -X POST --header 'Content-Type: application/json' --header 'Accept: application/json' --header 'x-tfso-trackingid: manualExecutioncarina' --header 'x-tfso-license: 00000000-0000-0000-0000-000000000001;611907646440257;1' 'http://bank-ledger-aggregator.api2.24sevenoffice.com/incomingpayments/matching/3445d593-8bcf-489f-b065-6f9420b65495?autoPost=false&limit=3000' 

```

curl for getting items from aws

```shell 
curl -X GET --header 'Accept: application/json' 'https://878rhuh3d9.execute-api.eu-west-1.amazonaws.com/prod/items'
```

curl for posting items to aws

```shell 
curl -X POST --header 'Content-Type: application/json' --header 'Accept: application/json' -d '{ \ 
   "ItemId": "1", \ 
   "AnExampleField": "stuff", \ 
 }' 'https://878rhuh3d9.execute-api.eu-west-1.amazonaws.com/prod/items'
```

