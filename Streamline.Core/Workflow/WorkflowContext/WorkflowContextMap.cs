namespace Streamline.Core.Workflow.WorkflowContext;

public class WorkflowContextMap : IContext
{
    private Dictionary<string, object> _dictionary = new Dictionary<string, object>();
    public void Add(string str, object obj)
    {
        _dictionary[str] = obj;
    }

    public void Edit(string str, object obj)
    {
        if (_dictionary.ContainsKey(str)) _dictionary[str] = obj;
    }

    public void Add_Or_Edit(string str, object obj)
    {
        throw new NotImplementedException();
    }

    public void Remove(string str)
    {
        throw new NotImplementedException();
    }

    public Object Get(string str)
    {
        return _dictionary[str];
    }

    public void Log(string m)
    {
        throw new NotImplementedException();
    }
}