using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Streamline.Core.Conditions;
using Streamline.Core.Workflow.WorkflowContext;
using Moq;
namespace Streamline.Tests;


public class ConditionsTest
{
    public Func<IContext, bool> TestConditionTrue = (context) => true;
    public Func<IContext, bool> TestConditionFalse = (context) => false;
    
    [Fact]
    public void SingleCondition_DecisionIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new SingleCondition(null));
    }

    [Fact]
    public void SingleCondition_SetDecisionIsNull()
    {
        
        SingleCondition s = new SingleCondition(TestConditionTrue);
        Assert.Throws<ArgumentNullException>(() => s.SetDecision(null));
    }

    [Fact]
    public void SingleCondition_EvaluateAlwaysTrue()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        Condition s = new SingleCondition(TestConditionTrue);
        Assert.True(s.Evaluate(mockContext.Object));
    }
    
    [Fact]
    public void SingleCondition_EvaluateAlwaysFalse()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        Condition s = new SingleCondition(TestConditionFalse);
        Assert.False(s.Evaluate(mockContext.Object));
    }

    [Fact]
    public void SingleCondition_EvaluateIsTrueWithIntegers()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        mockContext.Setup(c => c.Get("x")).Returns(3);
        mockContext.Setup(c => c.Get("y")).Returns(5);

        Func<IContext, bool> fn = (c) =>
        {
            return (int)c.Get("x") + (int)c.Get("y") == 8;
        };

        SingleCondition s = new SingleCondition(fn);
        
        Assert.True(s.Evaluate(mockContext.Object));
    }

    [Fact]
    public void SingleDecision_EvaluateArgumentIsNull()
    {
        SingleCondition s = new SingleCondition(TestConditionFalse);
        Assert.Throws<ArgumentNullException>(() => s.Evaluate(null));
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
        Mock<IContext> mockContext = new Mock<IContext>();
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        m.Conditions.Add(s);
        
        Assert.True(m.Evaluate(mockContext.Object));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateWithSingleConditionIsFalse()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionFalse);
        m.Conditions.Add(s);
        
        Assert.False(m.Evaluate(mockContext.Object));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateConditionsIsTrue()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        SingleCondition st = new SingleCondition(TestConditionTrue);
        m.Conditions.Add(s);
        m.Conditions.Add(st);
        
        Assert.True(m.Evaluate(mockContext.Object));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateConditionsIsFalse()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionFalse);
        SingleCondition st = new SingleCondition(TestConditionFalse);
        m.Conditions.Add(s);
        m.Conditions.Add(st);
        
        Assert.False(m.Evaluate(mockContext.Object));
    } 
    
    [Fact]
    public void MultiCondition_EvaluateWithDifferentConditionsIsFalse()
    {
        Mock<IContext> mockContext = new Mock<IContext>();
        MultiCondition m = new MultiCondition();
        SingleCondition s = new SingleCondition(TestConditionTrue);
        SingleCondition st = new SingleCondition(TestConditionFalse);
        m.Conditions.Add(s);
        m.Conditions.Add(st);
        
        Assert.False(m.Evaluate(mockContext.Object));
    }

    [Fact]
    public void MultiCondition_AddConditionArgumentIsNull()
    {
        MultiCondition m = new MultiCondition();
        Assert.Throws<ArgumentNullException>(() => m.AddCondition(null));
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
        Assert.True(m.Conditions.Count == 1);
    }
    
    [Fact]
    public void MultiCondition_EvaluateArgumentIsNull()
    {
        MultiCondition s = new MultiCondition();
        Assert.Throws<ArgumentNullException>(() => s.Evaluate(null));
    }
}