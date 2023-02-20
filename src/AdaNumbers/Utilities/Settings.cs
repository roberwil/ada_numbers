namespace Ada.Numbers.Utilities;

public abstract class Settings
{
	public abstract class Parameters
	{
		public enum Languages
		{
			Pt,
			En
		}

		public enum Scales
		{
			Short,
			Long
		}
	}

	public static Parameters.Languages Language { get; set; } = Parameters.Languages.Pt;
	public static Parameters.Scales Scale { get; set; } = Parameters.Scales.Long;

	public static void Reset()
	{
		Language = Parameters.Languages.Pt;
		Scale = Parameters.Scales.Long;
	}
}
