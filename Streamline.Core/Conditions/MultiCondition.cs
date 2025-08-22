using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Conditions;

public class MultiCondition : Condition
{
    public List<Condition> Conditions { get; set; }

    public MultiCondition()
    {
        Conditions = new List<Condition>();
    }
    
    public override bool Evaluate(IContext context)
    {
        throw new NotImplementedException();
    }

    public void AddCondition(Condition c)
    {
    }
    
}