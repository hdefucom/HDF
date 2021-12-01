namespace Windows32
{
	public enum TrackerEventFlags : uint
	{
		TME_HOVER = 1u,
		TME_LEAVE = 2u,
		TME_QUERY = 0x40000000,
		TME_CANCEL = 0x80000000
	}
}
