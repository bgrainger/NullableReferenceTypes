using System;

namespace NullableReferenceTypes
{
	class DoubleAssignment
	{
		public void Method()
		{
			string? value = null;
			if (value == null)
				value = _value = "";

			// warning CS8602: Possible dereference of a null reference.
			// Only happens with `value = _value = "";` not with `value = "";`
			Console.WriteLine(value.Length);
		}

		string? _value;
	}
}
