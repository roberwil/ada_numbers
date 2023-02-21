namespace Ada.Numbers.Utilities;

public abstract class Settings
{
	/// <summary>
	/// Parameters for Settings. available parameters are: <para/>
	///  - Language which can be "En" or "Pt" <br/>
	///  - Scale which can be "Short" or "Long" <br/>
	/// </summary>
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

	/// <summary>
	/// Set the language for the converters. Available languages are Portuguese and English.
	/// </summary>
	public static Parameters.Languages Language { get; set; } = Parameters.Languages.Pt;

	/// <summary>
	/// Set the Scale of conversion. Available scales are short and long.
	/// </summary>
	public static Parameters.Scales Scale { get; set; } = Parameters.Scales.Long;

	/// <summary>
	/// Reset to defaults: long scale and portuguese.
	/// </summary>
	public static void Reset()
	{
		Language = Parameters.Languages.Pt;
		Scale = Parameters.Scales.Long;
	}
}
