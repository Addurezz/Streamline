using System.Runtime.CompilerServices;
using Moq;
using Streamline.Core.Workflow;
using Streamline.Core.Workflow.WorkflowContext;
namespace Streamline.Tests;

public class ContextDictionaryTest
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
        ContextDictionary w = new ContextDictionary();

        Assert.Throws<ArgumentNullException>(() => w.Add(str, obj));
    }

    [Theory]
    [MemberData(nameof(KeyIsValid))]
    public void Add_KeyIsValid(string str, object obj)
    {
        ContextDictionary w = new ContextDictionary();
        w.Add(str, obj);
        Assert.Contains<string, object>(str, w.Dictionary);
    }

    [Fact]
    public void Add_SameKeyExists()
    {
        ContextDictionary w = new ContextDictionary();
        w.Add("a", new object());
        Assert.Throws<ArgumentException>(() => w.Add("a", "b"));
    }

    [Fact]
    public void Get_KeyNotFound()
    {
        ContextDictionary w = new ContextDictionary();

        Assert.Throws<KeyNotFoundException>(() => w.Get("b"));
    }

    [Theory]
    [InlineData("a", 3)]
    [InlineData("b", "a")]
    [InlineData("c", new long())]
    [InlineData("d", true)]
    
    public void Get_KeyExists(string str, object obj)
    {
        ContextDictionary w = new ContextDictionary();
        w.Add(str, obj);

        Assert.Equal(obj, w.Get(str));
    }

    [Fact]
    public void Edit_KeyNotFound()
    {
        ContextDictionary w = new ContextDictionary();
        Assert.Throws<KeyNotFoundException>(() => w.Edit("a", new object()));
    }

    [Fact]
    public void Edit_SuccessfulEdit()
    {
        ContextDictionary w = new ContextDictionary();
        w.Add("a", new object());
        
        Assert.Equal(3, w.Edit("a", 3).Get("a"));
    }

    [Theory]
    [MemberData(nameof(KeyIsNullOrEmpty))]
    public void Add_Or_Edit_KeyIsNullOrEmpty(string key, object val)
    {
        var w = new ContextDictionary();
        Assert.Throws<ArgumentNullException>(() => w.Add_Or_Edit(key, val));
    }

    [Fact]
    public void Add_Or_Edit_SuccessfulAdd()
    {
        var w = new ContextDictionary();
        var o = new object();
        w.Add_Or_Edit("a", o);
        
        Assert.True(w.Dictionary.Count == 1);
        Assert.Equal(o, w.Get("a"));
    }
    
    [Fact]
    public void Add_Or_Edit_SuccessfulEdit()
    {
        var w = new ContextDictionary();
        w.Add("a", new object());
        
        var o = new object();
        w.Add_Or_Edit("a", o);
        
        Assert.True(w.Dictionary.Count == 1);
        Assert.Equal(o, w.Get("a"));
    }

    [Fact]
    public void Remove_KeyNotFound()
    {
        var w = new ContextDictionary();

        Assert.Throws<KeyNotFoundException>(() => w.Remove("a"));
    }

    [Fact]
    public void Remove_SuccessfulRemoval()
    {
        ContextDictionary w = new ContextDictionary();
        w.Add("a", new object());
        w.Remove("a");
        Assert.DoesNotContain("a", w.Dictionary);
    }

    [Fact]
    public void Log_Successful()
    {
        var w = new ContextDictionary();
        w.Log("msg");
        
        Assert.Equal("msg\n", w.Get("log"));
    }
}