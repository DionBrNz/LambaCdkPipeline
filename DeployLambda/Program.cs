using Amazon.CDK;

namespace DeployLambda
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            

            new LambdaPipelineStack(app, "lambda-pipeline", new StackProps
            {
                Env = new Amazon.CDK.Environment
                {
                    Account = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_ACCOUNT"),
                    Region = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_REGION"),
                },
                
            });
            
            app.Synth();
        }
    }
}
