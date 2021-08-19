using DCSoft.ShapeEditor.Dom;
using System;

namespace DCSoftDotfuscate
{
	internal class Class187
	{
		public static void smethod_0(Type type_0)
		{
			int num = 17;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!type_0.Equals(typeof(ShapeElement)) && !type_0.IsSubclassOf(typeof(ShapeElement)))
			{
				throw new ArgumentException("Bad element type:" + type_0.FullName);
			}
		}
	}
}
