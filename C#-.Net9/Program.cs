using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CSharp_Net9_CollectionIndexer;


var summary = BenchmarkRunner.Run<Methods>();

public class Methods
{
    List<int> items = Enumerable.Range(1, 10000).ToList();

    [Benchmark]
    public void WithSimpleVariable()
    {
        StringBuilder sb = new StringBuilder();
        int i = 0;
        foreach (var item in items)
        {
            sb.Append($"index:{i}-item:{item}");
            i++;
        }
    }

    [Benchmark]
    public void WithIndexBuiltInMethod()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var it in items.Index())
        {
            sb.Append($"index:{it.Index}-item:{it.Item}");
        }
    }
    [Benchmark]
    public void WithIndexCustomMethod()
    {
        StringBuilder sb = new StringBuilder();
        foreach ((int item, var index) in items.WithIndex())
        {
            sb.Append($"index:{index}-item:{item}");
        }
    }


}


