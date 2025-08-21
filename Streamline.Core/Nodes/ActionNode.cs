using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Nodes;

public class ActionNode : INode
{
    private Action? _action;
    
    public void Execute(IContext context)
    {
        throw new NotImplementedException();
    }

    public void SetAction(Action action)
    {
        _action = action;
    }
}