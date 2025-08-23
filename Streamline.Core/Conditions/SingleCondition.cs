using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Conditions;

public class SingleCondition : Condition
{
    public Func<IContext, bool> DecisionCheck { get; set; }

    public SingleCondition(Func<IContext, bool> c)
    {
        if (c is null)
            throw new ArgumentNullException();
        DecisionCheck = c;
    }
    
    public override bool Evaluate(IContext context)
    {
        if (context is null) throw new ArgumentNullException();
        return DecisionCheck(context);
    }

    public void SetDecision(Func<IContext, bool> func)
    {
        if (func is null) throw new ArgumentNullException();
        DecisionCheck = func;
    } 
}