using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Decisions;

public class SingleDecision : Decision
{
    private Func<IContext, bool> _ConditionCheck;
    
    public override bool Evaluate()
    {
        throw new NotImplementedException();
    }
}