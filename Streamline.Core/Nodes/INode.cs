using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Nodes;

public interface INode
{
    public void Execute(IContext context);
}