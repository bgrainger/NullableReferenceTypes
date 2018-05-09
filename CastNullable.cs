using System.IO;

namespace NullableReferenceTypes
{
	class CastNullable
	{
		public CastNullable(Stream? stream)
		{
			// warning CS8600: Converting null literal or possible null value to non-nullable type.
			// This cast can be fixed by casting to (FileStream?) but it feels like a spurious
			// warning since it's immediately being assigned to a FileStream? variable. The intent
			// here is to downcast (if FileStream), throw (if some other kind of Stream) or
			// store null. There's no nullability concern here.
			_stream = (FileStream) stream;
		}

		FileStream? _stream;
	}
}
