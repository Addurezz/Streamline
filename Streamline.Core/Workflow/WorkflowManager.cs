namespace Streamline.Core.Workflow;

public class WorkflowManager
{
    public WorkflowManager Instance { get; }

    private WorkflowManager()
    {
        Instance = new WorkflowManager();
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