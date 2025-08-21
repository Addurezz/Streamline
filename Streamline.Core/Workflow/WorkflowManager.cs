namespace Streamline.Core.Workflow;

public class WorkflowManager
{
    private WorkflowManager? _instance;

    private WorkflowManager() { }

    public WorkflowManager GetInstance()
    {
        if (_instance is null) _instance = new WorkflowManager();

        return _instance;
    }
    
    public void Start(Workflow w)
    {
        
    }

    public void Stop(Workflow w)
    {
        
    }

    public void Pause(Workflow w)
    {
        
    }

    public void Resume(Workflow w)
    {
        
    }
}