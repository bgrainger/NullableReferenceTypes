namespace NullableReferenceTypes
{
	class FlowBangOperator
	{
		public void Open(Settings settings)
		{
			// This is a method that takes a generic "Settings" object, then dispatches to the appropriate
			// internal implementation based on what settings have been set.
			if (settings.FileName != null)
				OpenFile(settings);
		}

		private void OpenFile(Settings settings)
		{
			// I don't expect flow analysis to be propagated into this method, but I trust my public API
			// to only call this method if settings.FileName != null, so I use ! to suppress the warning.
			// This suppresses warning CS8604: Possible null reference argument for parameter 'fileName' in 'void FlowBangOperator.CheckValidCharacters(string fileName)'.
			CheckValidCharacters(settings.FileName!);

			// however I still get a warning here but I was expecting the compiler to internally mark that
			// variable as non-null for the rest of the method
			// warning CS8604: Possible null reference argument for parameter 'fileName' in 'File.File(string fileName)'.
			var file = new File(settings.FileName);
		}

		private static void CheckValidCharacters(string fileName)
		{
			// does some validation...
		}
	}

	public class Settings
	{
		public string? FileName { get; set; }
	}

	public class File
	{
		public File(string fileName) => FileName = fileName;

		public string FileName { get; }
	}
}
