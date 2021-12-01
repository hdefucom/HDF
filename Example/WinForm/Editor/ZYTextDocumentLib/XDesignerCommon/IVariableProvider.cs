namespace XDesignerCommon
{
	public interface IVariableProvider
	{
		string[] AllNames
		{
			get;
		}

		bool Exists(string Name);

		string Get(string Name);

		void Set(string Name, string Value);
	}
}
