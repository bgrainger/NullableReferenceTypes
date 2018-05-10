using System.Collections.Generic;
using System.Threading;

namespace NullableReferenceTypes
{
	class CSharpKeyword
	{
		public void Lock()
		{
			object? myLock = null;

			// I understand that the BCL isn't annotated for non-nullability yet (so no warning)...
			Monitor.Enter(myLock);

			// ... but when I use a C# keyword, I'd like a warning that 'myLock' might be null
			lock (myLock)
			{
			}
		}

		public void ForEach()
		{
			List<int>? list = null;

			// If I use the C# keyword there's no warning about using a potentially null value:
			foreach (var x in list)
			{
			}

			// But if I write the generated code out by hand, I get a warning
			// warning CS8602: Possible dereference of a null reference.
			using (var enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
				}
			}
		}
	}
}
