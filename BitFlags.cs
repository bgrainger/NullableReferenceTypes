using System.IO;

namespace NullableReferenceTypes
{
	class BitFlags
	{
		public FileAccess GetFileAccess(bool isWritable)
		{
			return FileAccess.Read |
				// warning CS8626: No best nullability for operands of conditional expression 'int' and 'FileAccess'.
				(isWritable ? 0 : FileAccess.Write);

			// workaround: use 'default'
			// (isWritable ? default : FileAccess.Write);
		}
	}
}
