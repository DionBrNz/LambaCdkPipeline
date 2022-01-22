using Amazon.CDK;
using Amazon.CDK.AWS.CodeBuild;
using Amazon.CDK.Pipelines;
using Constructs;

namespace DeployLambda
{
    internal class LambdaPipelineStack : Stack
    {
        public LambdaPipelineStack(Construct scope, string id, StackProps props) : base(scope, id, props)
        {
            var pipeline = new CodePipeline(this, "lambda-pipeline", new CodePipelineProps
            {
                PipelineName = "example-lambda-pipeline",
                
                SelfMutation =true,
                Synth = new CodeBuildStep("build", new CodeBuildStepProps
                {
                    ProjectName = "example-lambda-synth",
                    Input = CodePipelineSource.Connection("DionBrNz/LambaCdkPipeline", "master", new ConnectionSourceOptions
                    {
                        ConnectionArn = $"arn:aws:codestar-connections:{Region}:{Account}:connection/f6d21f24-21db-4453-8c18-86ed3e230da6"
                    }),
                    Commands = new string[] { "npm install -g aws-cdk", "cdk synth --output=cdk.out" },
                    BuildEnvironment = new BuildEnvironment
                    {
                        BuildImage = LinuxBuildImage.STANDARD_5_0,
                        ComputeType = ComputeType.SMALL,
                        Privileged = true,
                    }
                })
            });

            

            pipeline.AddStage(new LambdaDeployStage(this, "lambda-deploy-stage"));
        }
    }
}
