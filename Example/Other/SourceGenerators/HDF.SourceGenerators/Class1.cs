using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HDF.SourceGenerators;



[Generator]
public class MySourceGenerator2 : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {

        //string filename = System.Environment.CurrentDirectory;

        //filename = Path.Combine(filename, "Test.cs");

        //using StreamReader reader = File.OpenText(filename);

        //context.AddSource("HDF.SG.Test", SourceText.From(reader, (int)reader.BaseStream.Length));






        ////获取第一个附加文件内容，用作代码模板
        //var template = context.AdditionalFiles.First().GetText().ToString();

        ////获取第一个类名
        //var className = context.Compilation.SyntaxTrees.SelectMany(p => p.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>()).First().Identifier.Text;

        //// 替换文本生成代码
        //// 你也可以使用模板引擎或者StringBuilder拼接出代码
        //var source = template.Replace("{Class}", className);

        //// 向编译过程添加代码文件
        //context.AddSource("Demo", SourceText.From(source, Encoding.UTF8));




        //获取第一个附加文件内容，用作代码模板

        Debug.WriteLine(context.AdditionalFiles.Length);

        var template = context.AdditionalFiles.First().GetText().ToString();

        context.AddSource("helloWorldGenerator2", SourceText.From(template, Encoding.UTF8));


    }

    public void Initialize(GeneratorInitializationContext context)
    {

    }
}






[Generator]
public class MySourceGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        // TODO - actual source generator goes here!

        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.RootNamespace", out var currentNamespace);



        // begin creating the source we'll inject into the users compilation
        var sourceBuilder = new StringBuilder(@$"
using System;
namespace {currentNamespace}
{{
    public static class HelloWorld
    {{
        public static void SayHello() 
        {{
            Console.WriteLine(""Hello from generated code!"");
            Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
");

        // using the context, get a list of syntax trees in the users compilation
        var syntaxTrees = context.Compilation.SyntaxTrees;

        // add the filepath of each tree to the class we're building
        foreach (SyntaxTree tree in syntaxTrees)
        {
            sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
        }

        // finish creating the source to inject
        sourceBuilder.Append(@"
        }
    }
}");

        // inject the created source into the users compilation
        context.AddSource("HelloWorldGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));



    }

    public void Initialize(GeneratorInitializationContext context)
    {
        // No initialization required for this one
    }
}





