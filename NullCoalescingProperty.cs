namespace NullableReferenceTypes
{
	class NullCoalescingProperty
	{
		public void ClearChild(Node? parent)
		{
			if (parent?.Left != null)
			{
				// warning CS8602: Possible dereference of a null reference.
				// however, we know that parent.Left != null, therefore parent != null
				parent.Left = null;
			}
		}
	}

	class Node
	{
		public Node? Left { get; set; }
		public Node? Right { get; set; }
	}
}
