using Amazon.CDK;
using Constructs;

namespace DeployLambda
{
    internal class LambdaDeployStage : Stage
    {
        public LambdaStack LambdaStack {get;}

        public LambdaDeployStage(Construct scope, string id, IStageProps props = null) : base(scope, id, props)
        {
            LambdaStack = new LambdaStack(this, "lambda-stack");
        }
    }
}
