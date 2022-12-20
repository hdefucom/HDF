using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.IO;

namespace GHIS.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class GHISAnalyzersAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "GHISAnalyzers";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Naming";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId,
            Title,
            MessageFormat,
            Category,
            DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            description: Description);



        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information


            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.InvocationExpression);
        }


        private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {



            var invocationExpr = (InvocationExpressionSyntax)context.Node;
            var memberAccessExpr = invocationExpr.Expression as MemberAccessExpressionSyntax;
            if (memberAccessExpr == null)
                return;
            if (memberAccessExpr.Name.ToString() != nameof(object.Equals))
                return;
            var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpr).Symbol as IMethodSymbol;
            if (memberSymbol == null)
                return;

            _ = memberSymbol.ContainingType.SpecialType;// Object


            var child = invocationExpr.Parent.ChildNodes();

            SyntaxNode pre = null;

            foreach (var childChild in child)
            {
                if (childChild == invocationExpr)
                    break;
                pre = childChild;
            }

            if (pre != null)
            {


                var sy = context.SemanticModel.GetSymbolInfo(pre).Symbol;// as ILocalSymbol;

                if (sy != null)
                {
                    var str = sy.Name;
                    File.WriteAllText(@"C:\Users\12131\Desktop\111.txt", str);

                }
                else
                {

                }

            }


            //if (memberSymbol.ContainingType.SpecialType != SpecialType.System_String)
            //    return;

            //// If there are not 3 arguments, the comparison type is missing => report it
            //// We could improve this validation by checking the types of the arguments, but it would be a little longer for this post.
            //var argumentList = invocationExpr.ArgumentList;
            ////if ((argumentList?.Arguments.Count ?? 0) == 2)
            //{
            //    var diagnostic = Diagnostic.Create(Rule, invocationExpr.GetLocation());
            //    context.ReportDiagnostic(diagnostic);
            //}


            //var str2 = JsonConvert.SerializeObject(memberAccessExpr);
            //File.WriteAllText(@"C:\Users\12131\Desktop\222.json", str2);

            //if (memberSymbol.ContainingType.Name.Contains("BaseOperator"))
            {
                var diagnostic = Diagnostic.Create(Rule, invocationExpr.GetLocation());
                context.ReportDiagnostic(diagnostic);
            }

        }













    }
}
