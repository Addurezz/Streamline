using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Conditions;

public class SingleCondition : Condition
{
    public Func<IContext, bool> DecisionCheck { get; set; }

    public SingleCondition(Func<IContext, bool> c)
    {
        DecisionCheck = c;
    }
    
    public override bool Evaluate(IContext context)
    {
        throw new NotImplementedException();
    }
}