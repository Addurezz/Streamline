using System.Collections;

namespace Streamline.Core.Workflow.WorkflowContext;

public class ContextDictionary : IContext
{
    public Dictionary<string, object> Dictionary = new Dictionary<string, object>();
    public IContext Add(string str, object obj)
    {
        if (str == "" || str is null) throw new ArgumentNullException();
        if (Dictionary.ContainsKey(str)) throw new ArgumentException();
        
        Dictionary[str] = obj;
        
        return this;
    }

    public IContext Edit(string str, object obj)
    {
        if (!Dictionary.ContainsKey(str)) throw new KeyNotFoundException();

        Dictionary[str] = obj;
        return this;
    }

    public IContext Add_Or_Edit(string str, object obj)
    {
        if (Dictionary.ContainsKey(str)) Edit(str, obj);

        else Add(str, obj);
        
        return this;
    }

    public IContext Remove(string str)
    {
        if (!Dictionary.ContainsKey(str)) throw new KeyNotFoundException();

        Dictionary.Remove(str);
        
        return this;
    }

    public Object Get(string str)
    {
        if (!Dictionary.ContainsKey(str)) throw new KeyNotFoundException();
        
        return Dictionary[str];
    }

    public IContext Log(string m)
    {
        if (!Dictionary.ContainsKey("log")) Dictionary.Add("log", "");

        string msg = (string)Dictionary["log"] + m + "\n";
        Dictionary["log"] = msg;
        return this;
    }

    public IEnumerable GetALlItems()
    {
        return Dictionary;
    }
}