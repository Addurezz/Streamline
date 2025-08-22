using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Nodes;

public interface IActionNode : INode
{
    public Action<IContext> Action { get; set; }

    public void Execute(IContext context)
    {
        Action(context);
    }

    public void SetAction(Action action);
}