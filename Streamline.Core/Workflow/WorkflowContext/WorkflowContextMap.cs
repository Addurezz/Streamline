namespace Streamline.Core.Workflow.WorkflowContext;

public class WorkflowContextMap : IContext
{
    public Dictionary<string, object> Dictionary = new Dictionary<string, object>();
    public IContext Add(string str, object obj)
    {
        Dictionary[str] = obj;
        return this;
    }

    public IContext Edit(string str, object obj)
    {
        if (Dictionary.ContainsKey(str)) Dictionary[str] = obj;
        return this;
    }

    public IContext Add_Or_Edit(string str, object obj)
    {
        return this;
    }

    public IContext Remove(string str)
    {
        return this;
    }

    public Object Get(string str)
    {
        return Dictionary[str];
    }

    public void Log(string m)
    {
        throw new NotImplementedException();
    }
}