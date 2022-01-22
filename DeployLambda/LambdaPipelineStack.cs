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
                SelfMutation =true,
                Synth = new CodeBuildStep("build", new CodeBuildStepProps
                {
                    ProjectName = "example-lambda-synth",
                    Input = CodePipelineSource.GitHub("DionBrNz/LambaCdkPipeline", "master"),
                    Commands = new string[] { "npm install -g aws-cdk", "cdk synth --output=cdk.out" },
                    BuildEnvironment = new BuildEnvironment
                    {
                        BuildImage = LinuxBuildImage.AMAZON_LINUX_2_ARM_2,
                        ComputeType = ComputeType.SMALL
                    }
                })
            });

            pipeline.AddStage(new LambdaDeployStage(this, "lambda-deploy-stage"));
        }
    }
}
