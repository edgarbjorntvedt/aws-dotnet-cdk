using System.Collections.Generic;
using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using IResource = Amazon.CDK.AWS.APIGateway.IResource;

namespace Lambda80
{
    public class Lambda80Stack : Stack
    {
        internal Lambda80Stack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {

            // The code that defines your stack goes here



            // Lambda Functions
            var helloLambda = new DockerImageFunction(
                this,
                "helloFunction",
                new DockerImageFunctionProps()
                {
                    Code = DockerImageCode.FromImageAsset(
                        "../minimalapi",
                        new AssetImageCodeProps()
                        {
                            File = "Dockerfile"
                        }
                    ),
                    FunctionName = "helloFunction",
                    Timeout = Duration.Seconds(10)
                }
            );
            

            // API Gateway
            // Create an API Gateway resource for each of the CRUD operations
            var api = new RestApi(this,
              "helloApi",
              new LambdaRestApiProps()
              {
                  RestApiName = "Items Service"
              });

            var hello = api.Root.AddResource("hello");
            hello.AddMethod("GET", new LambdaIntegration(helloLambda));
            AddCorsOptions(hello);
        }


        private void AddCorsOptions(IResource apiResource)
        {
            apiResource.AddMethod("OPTIONS",
                new MockIntegration(new IntegrationOptions()
                {
                    IntegrationResponses = new IIntegrationResponse[]
                {
                new IntegrationResponse()
                {
                StatusCode = "200",
                ResponseParameters = new Dictionary<string, string>()
                {
                    {
                    "method.response.header.Access-Control-Allow-Headers",
                    "'Content-Type,X-Amz-Date,Authorization,X-Api-Key,X-Amz-Security-Token,X-Amz-User-Agent'"
                    },
                    {
                    "method.response.header.Access-Control-Allow-Origin", "'*'"
                    },
                    {
                    "method.response.header.Access-Control-Allow-Credentials", "'false'"
                    },
                    {
                    "method.response.header.Access-Control-Allow-Methods", "'OPTIONS,GET,PUT,POST,DELETE'"
                    }
                }
                }
                },
                    PassthroughBehavior = PassthroughBehavior.NEVER,
                    RequestTemplates = new Dictionary<string, string>()
                {
                {
                "application/json", "{\"statusCode\": 200}"
                }
                },
                }),
                new MethodOptions()
                {
                    MethodResponses = new IMethodResponse[]
                {
                new MethodResponse()
                {
                StatusCode = "200",
                ResponseParameters = new Dictionary<string, bool>()
                {
                    {
                    "method.response.header.Access-Control-Allow-Headers", true
                    },
                    {
                    "method.response.header.Access-Control-Allow-Methods", true
                    },
                    {
                    "method.response.header.Access-Control-Allow-Credentials", true
                    },
                    {
                    "method.response.header.Access-Control-Allow-Origin", true
                    }
                }
                }
                }
                });
        }
    }
}
