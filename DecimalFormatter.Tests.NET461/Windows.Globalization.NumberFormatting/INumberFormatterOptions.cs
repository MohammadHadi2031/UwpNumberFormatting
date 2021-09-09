namespace Windows.Globalization.NumberFormatting
{
    public partial interface INumberFormatterOptions
    {
        int FractionDigits { get; set; }
        string GeographicRegion { get; }
        int IntegerDigits { get; set; }
        bool IsDecimalPointAlwaysDisplayed { get; set; }
        bool IsGrouped { get; set; }
        global::System.Collections.Generic.IReadOnlyList<string> Languages { get; }
        string NumeralSystem { get; set; }
        string ResolvedGeographicRegion { get; }
        string ResolvedLanguage { get; }
    }
}
