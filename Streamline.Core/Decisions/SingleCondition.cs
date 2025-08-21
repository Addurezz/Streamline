using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Decisions;

public class SingleCondition : Condition
{
    private Func<IContext, bool> _ConditionCheck;
    
    public override bool Evaluate()
    {
        throw new NotImplementedException();
    }

    public void SetCondition(Func<IContext, bool> c)
    {
        
    }
}