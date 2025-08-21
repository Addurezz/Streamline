namespace Streamline.Core.Decisions;

public class MultiCondition : Condition
{
    private List<Condition> _decisions;

    public MultiCondition()
    {
        _decisions = new List<Condition>();
    }
    
    public override bool Evaluate()
    {
        throw new NotImplementedException();
    }

    public void AddCondition(Condition c)
    {
    }
}