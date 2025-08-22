using Streamline.Core.Conditions;
using Streamline.Core.Workflow.WorkflowContext;
namespace Streamline.Tests;


public class ConditionsTest
{
    public Func<IContext, bool> TestConditionTrue = (context) => true;
    public Func<IContext, bool> TestConditionFalse = (context) => false;
    public IContext Context = new WorkflowContextMap();
    
    [Fact]
    public void SingleCondition_DecisionIsNull()
    {
        Assert.Throws<NullReferenceException>(() => new SingleCondition(null));
    }

    [Fact]
    public void SingleCondition_SetDecisionIsNull()
    {
        
        SingleCondition s = new SingleCondition(TestConditionTrue);
        Assert.Throws<NullReferenceException>(() => s.DecisionCheck = null);
    }

    [Fact]
    public void SingleCondition_EvaluateAlwaysTrue()
    {
        Condition s = new SingleCondition(TestConditionTrue);
        Assert.True(s.Evaluate(Context));
    }
    
    [Fact]
    public void SingleCondition_EvaluateAlwaysFalse()
    {
        IContext context = new WorkflowContextMap();
        Condition s = new SingleCondition(TestConditionFalse);
        Assert.False(s.Evaluate(Context));
    }

    [Fact]
    public void SingleCondition_EvaluateIsTrueWithIntegers()
    {
        IContext context = new WorkflowContextMap();
        context.Add("x", 3);
        context.Add("y", 4);

        Func<IContext, bool> fn = (_context) =>
        {
            return (int)_context.Get("x") + (int)_context.Get("y") == 7;
        };
    }

    [Fact]
    public void MultiCondition_AddDecision()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition((c) => true);
        m.Conditions.Add(s);

        Assert.Single(m.Conditions, s);
        Assert.Contains(s, m.Conditions);
        Assert.True(m.Conditions.Count == 1);
    }

    [Fact]
    public void MultiCondition_EvaluateWithSingleConditionIsTrue()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        m.Conditions.Add(s);
        
        Assert.True(m.Evaluate(Context));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateWithSingleConditionIsFalse()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionFalse);
        m.Conditions.Add(s);
        
        Assert.True(m.Evaluate(Context));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateConditionsIsTrue()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        SingleCondition st = new SingleCondition(TestConditionTrue);
        m.Conditions.Add(s);
        m.Conditions.Add(st);
        
        Assert.True(m.Evaluate(Context));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateConditionsIsFalse()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionFalse);
        SingleCondition st = new SingleCondition(TestConditionFalse);
        m.Conditions.Add(s);
        m.Conditions.Add(st);
        
        Assert.True(m.Evaluate(Context));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateWithDifferentConditionsIsFalse()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        SingleCondition st = new SingleCondition(TestConditionFalse);
        m.Conditions.Add(s);
        m.Conditions.Add(st);
        
        Assert.True(m.Evaluate(Context));
    }

    [Fact]
    public void MultiCondition_AddConditionArgumentIsNull()
    {
        MultiCondition m = new MultiCondition();
        Assert.Throws<NullReferenceException>(() => m.AddCondition(null));
    }
    
    [Fact]

    public void MultiCondition_AddConditionCorrectlyInsertsSingleCondition()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        m.AddCondition(s);
        Assert.Contains(s, m.Conditions);
    }

    [Fact]
    public void MultiCondition_AddConditionArgumentExistsAlready()
    {
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        m.AddCondition(s);
        m.AddCondition(s);
        Assert.Contains(s, m.Conditions);
        Assert.True(m.Conditions.Count == 2);
    }
}