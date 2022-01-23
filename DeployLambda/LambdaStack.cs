using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using System.Collections.Generic;
using AssetOptions = Amazon.CDK.AWS.S3.Assets.AssetOptions;


namespace DeployLambda
{
    public class LambdaStack : Stack
    {
        internal LambdaStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
           IEnumerable<string> commands = new[]
            {
                "cd /asset-input",
                "dotnet publish -c Release -r linux-arm -p:PublishReadyToRun=true -o /asset-output"
            };

            var function = new Function(this, "example-lambda", new FunctionProps
            {
                FunctionName = "ToUpper-Lambda",
                Description = "Changes input to upper case",
                Runtime = Runtime.DOTNET_CORE_3_1,
                Handler = "ExampleLambda::ExampleLambda.Function::FunctionHandler",
                Architecture = Architecture.ARM_64,
                Code = Code.FromAsset("./ExampleLambda/", new AssetOptions
                {
                    Bundling = new BundlingOptions
                    {
                        Image = Runtime.DOTNET_CORE_3_1.BundlingImage,
                        Command = new []
                        {
                            "bash", "-c", string.Join(" && ", commands)
                        }
                    }
                })
            });
        }
    }
}
