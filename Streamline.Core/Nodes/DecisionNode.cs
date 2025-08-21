using Streamline.Core.Decisions;
using Streamline.Core.Workflow.WorkflowContext;

namespace Streamline.Core.Nodes;

public class DecisionNode : INode
{
    private List<INode> _trueNext = new List<INode>();
    private List<INode> _falseNext = new List<INode>();
    private Condition _condition;
    
    public void Execute(IContext context)
    {
        throw new NotImplementedException();
    }
}