# Example of deploying a C# lambda using CDK pipelines
This is a full example of how to use CDK pipelines to deploy a lambda written in C#.  

The documentation from AWS is poor for how to do this with C#. For some reason AWS example shows how to write a CDK pipeline in C# to deploy a Node lambda, but if you are using C# it is more likely your lambda will also be written in C#.
A colleague and I pieced together how to do it and this example is to help others trying to figure out how do it.
Since I'm also interested in using Graviton for work loads this example is setup to use ARM to build the code and deploys an ARM lambda.

## Set up
Besides an AWS account the other thing you will need is a [CodeStar connection](https://aws.amazon.com/blogs/devops/using-aws-codepipeline-and-aws-codestar-connections-to-deploy-from-bitbucket/) to the source control repository of your choice. You will then need to change [line 21 of LambdaPipelineStack.cs](https://github.com/DionBrNz/LambaCdkPipeline/blob/master/DeployLambda/LambdaPipelineStack.cs#L22) to use your connection ARN.

To deploy the example run
```powershell
cdk deploy
```
