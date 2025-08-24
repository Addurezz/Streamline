using System.Runtime.CompilerServices;
using Streamline.Core.Workflow;
using Streamline.Core.Workflow.WorkflowContext;
namespace Streamline.Tests;

public class WorkflowContextMapTest
{
    public static IEnumerable<object[]> KeyIsNullOrEmpty =>
        new List<object[]>
        {
            new object[] { null, new object() },
            new object[] { "", new object()},
            new object[] { null, null},
            new object[] {"", null},
        };
    
    public static IEnumerable<object[]> KeyIsValid =>
        new List<object[]>
        {
            new object[] { "a", new object() },
            new object[] { "a", null},
        };
    
    
    [Theory]
    [MemberData(nameof(KeyIsNullOrEmpty))]
    public void Add_KeyIsNullOrEmpty(string str, object obj)
    {
        WorkflowContextMap w = new WorkflowContextMap();

        Assert.Throws<ArgumentNullException>(() => w.Add(str, obj));
    }

    [Theory]
    [MemberData(nameof(KeyIsValid))]
    public void Add_KeyIsValid(string str, object obj)
    {
        WorkflowContextMap w = new WorkflowContextMap();
        w.Add(str, obj);
        Assert.Contains<string, object>(str, w.Dictionary);
    }

    [Fact]
    public void Add_SameKeyExists()
    {
        WorkflowContextMap w = new WorkflowContextMap();
        w.Add("a", new object());
        Assert.Throws<ArgumentException>(() => w.Add("a", "b"));
    }

    [Fact]
    public void Get_KeyNotFound()
    {
        WorkflowContextMap w = new WorkflowContextMap();

        Assert.Throws<KeyNotFoundException>(() => w.Get("b"));
    }

    [Theory]
    [InlineData("a", 3)]
    [InlineData("b", "a")]
    [InlineData("c", new long())]
    [InlineData("d", true)]
    
    public void Get_KeyExists(string str, object obj)
    {
        WorkflowContextMap w = new WorkflowContextMap();
        w.Add(str, obj);

        Assert.Equal(obj, w.Get(str));
    }

    [Fact]
    public void Edit_KeyNotFound()
    {
        WorkflowContextMap w = new WorkflowContextMap();
        Assert.Throws<KeyNotFoundException>(() => w.Edit("a", new object()));
    }

    [Fact]
    public void Edit_SuccessfulEdit()
    {
        WorkflowContextMap w = new WorkflowContextMap();
        w.Add("a", new object());
        
        Assert.Equal(3, w.Edit("a", 3).Get("a"));
    }

    [Theory]
    [MemberData(nameof(KeyIsNullOrEmpty))]
    public void Add_Or_Edit_KeyIsNullOrEmpty(string key, object val)
    {
        var w = new WorkflowContextMap();
        Assert.Throws<ArgumentNullException>(() => w.Add_Or_Edit(key, val));
    }

    [Fact]
    public void Add_Or_Edit_SuccessfulAdd()
    {
        var w = new WorkflowContextMap();
        var o = new object();
        w.Add_Or_Edit("a", o);
        
        Assert.True(w.Dictionary.Count == 1);
        Assert.Equal(o, w.Get("a"));
    }
    
    [Fact]
    public void Add_Or_Edit_SuccessfulEdit()
    {
        var w = new WorkflowContextMap();
        w.Add("a", new object());
        
        var o = new object();
        w.Add_Or_Edit("a", o);
        
        Assert.True(w.Dictionary.Count == 1);
        Assert.Equal(o, w.Get("a"));
    }

    [Fact]
    public void Remove_KeyNotFound()
    {
        var w = new WorkflowContextMap();

        Assert.Throws<KeyNotFoundException>(() => w.Remove("a"));
    }

    [Fact]
    public void Remove_SuccessfulRemoval()
    {
        var w = new WorkflowContextMap();
        w.Add("a", new object());
        
        Assert.Contains<string, object>("a", ((WorkflowContextMap)w.Remove("a")).Dictionary);
    }
}