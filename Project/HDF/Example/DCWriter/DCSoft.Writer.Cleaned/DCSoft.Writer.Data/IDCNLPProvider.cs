using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	[ComVisible(false)]
	public interface IDCNLPProvider
	{
		List<NLPTerm> Tokenizer(string sourceText);
	}
}
