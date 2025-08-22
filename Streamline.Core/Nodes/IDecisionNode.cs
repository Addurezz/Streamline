using Streamline.Core.Workflow.WorkflowContext;
using Streamline.Core.Conditions;
namespace Streamline.Core.Nodes;

public interface IDecisionNode : INode
{
    List<INode> TrueNext { get; set; }
    List<INode> FalseNext { get; set; }
    Condition Condition { get; set; }

    void INode.Execute(IContext context)
    {
        if (Condition.Evaluate(context))
        {
            foreach (INode node in TrueNext)
            {
                node.Execute(context);
            }
            
            return;
        }

        foreach (INode node in FalseNext)
        {
            node.Execute(context);
        }
    }
}