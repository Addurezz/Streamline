
namespace Streamline.Core.Workflow.WorkflowContext;

public interface IContext
{
    public IContext Add(String str, Object obj);
    public IContext Edit(String str, Object obj);
    public IContext Add_Or_Edit(String str, Object obj);
    public IContext Remove(String str);
    public Object Get(String str);
    public void Log(String m);
}