using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Script
{
	[ComVisible(false)]
	public class DotNetAssemblyInfoConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType.Equals(typeof(InstanceDescriptor)))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object Value, Type destinationType)
		{
			if (destinationType.Equals(typeof(InstanceDescriptor)))
			{
				DotNetAssemblyInfo dotNetAssemblyInfo = (DotNetAssemblyInfo)Value;
				ConstructorInfo constructor = typeof(DotNetAssemblyInfo).GetConstructor(new Type[6]
				{
					typeof(string),
					typeof(string),
					typeof(string),
					typeof(string),
					typeof(string),
					typeof(AssemblyNameFlags)
				});
				return new InstanceDescriptor(constructor, new object[6]
				{
					dotNetAssemblyInfo.Name,
					dotNetAssemblyInfo.VersionString,
					dotNetAssemblyInfo.RuntimeVersionString,
					dotNetAssemblyInfo.CodeBase,
					dotNetAssemblyInfo.FileName,
					dotNetAssemblyInfo.Flags
				}, isComplete: true);
			}
			return base.ConvertTo(context, culture, Value, destinationType);
		}
	}
}
