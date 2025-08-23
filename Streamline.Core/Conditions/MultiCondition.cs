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
        if (context is null) throw new ArgumentNullException();
        if (Conditions.Count == 0) return true;
        
        return Conditions.All(cond => cond.Evaluate(context));
    }

    public void AddCondition(Condition c)
    {
        if (c is null) throw new ArgumentNullException();
        if (Conditions.Contains(c)) return;
        Conditions.Add(c);
    }
    
}