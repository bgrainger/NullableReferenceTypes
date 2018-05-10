namespace NullableReferenceTypes
{
	class NullDefaultArgument
	{
		// Expected an error specifying 'null' as the default argument value for 'string'; no warning generated.
		public static void Method1(string message = null)
		{
		}

		// warning CS8625: Cannot convert null literal to non-nullable reference or unconstrained type parameter.
		public static void Method2() => Method1(null);
	}
}
