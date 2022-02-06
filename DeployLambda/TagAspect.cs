using Amazon.CDK;
using Constructs;
using System;
using System.Collections.Generic;

namespace DeployLambda
{
    public class TagAspect : Amazon.JSII.Runtime.Deputy.DeputyBase, IAspect
    {
        private readonly IList<string> _requiredTags;

        public TagAspect(IList<string> requiredTags)
        {
           _requiredTags = requiredTags;
        }

        public void Visit(IConstruct node)
        {
            if (node is Stack stack)
            {
                foreach (var requiredTag in _requiredTags)
                {
                    if (!stack.Tags.TagValues().ContainsKey(requiredTag))
                    {
                        Annotations.Of(node).AddError($"Missing required tag {requiredTag} on stack with id {stack.StackName}");
                    }
                }
            }
        }
    }
}
