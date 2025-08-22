using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Conditions;

public abstract class Condition
{
    public abstract bool Evaluate(IContext context);
}