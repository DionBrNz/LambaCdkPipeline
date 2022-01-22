using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeployLambda
{
    internal class LambdaStackProps : StackProps
    {
        public string CodeStarConnectionArn { get; set; }
    }
}
