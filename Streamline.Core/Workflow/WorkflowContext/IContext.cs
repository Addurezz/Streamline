
namespace Streamline.Core.Workflow.WorkflowContext;

public interface IContext
{
    public void Add(String str, Object obj);
    public void Edit(String str, Object obj);
    public void Add_Or_Edit(String str, Object obj);
    public void Remove(String str);
    public Object Get(String str);
    public void Log(String m);
}