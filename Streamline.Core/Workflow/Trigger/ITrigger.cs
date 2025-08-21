namespace Streamline.Core.Workflow.Trigger;

public interface ITrigger
{
    public void Execute();
    public void OnNotify();
    public bool CheckCondition();
}