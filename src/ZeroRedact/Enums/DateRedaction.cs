namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to a date.
    /// </summary>
    public enum DateRedaction
    {
        /// <summary>
        /// the date is redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "*********"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "********"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "********"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "********"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        All,

        /// <summary>
        /// the date is redacted with a fixed length.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "********"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "********"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "********"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "********"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        FixedLength,

        /// <summary>
        /// the date is redacted, showing the date separator.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "**/**/****"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "*/**/****"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "****/**/**"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "**/**/****"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        Full,

        /// <summary>
        /// The day is redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "**/06/2023"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "6/**/2023"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "2023/06/**"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "06/**/2023"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        Day,

        /// <summary>
        /// The month is redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "15/**/2023"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "*/15/2023"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "2023/**/15"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "**/15/2023"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        Month,

        /// <summary>
        /// The year is redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "15/06/****"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "6/15/****"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "****/06/15"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "06/15/****"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        Year,

        /// <summary>
        /// The day and month are redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "**/**/2023"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "*/**/2023"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "2023/**/**"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "**/**/2023"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        DayAndMonth,

        /// <summary>
        /// The month and year are redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "15/**/****"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "*/15/****"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "****/**/15"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "**/15/****"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        MonthAndYear,

        /// <summary>
        /// The day and year are redacted.
        /// </summary>
        /// <remarks>
        /// <para>Takes the current <see cref="System.Globalization.CultureInfo"/> into account.</para>
        /// <para>Example for "2023/06/15":
        /// <list type="bullet">      
        /// <item>
        /// <description>en-NZ: "**/06/****"</description>
        /// </item>
        /// <item>
        /// <description>en-US: "6/**/****"</description>
        /// </item>
        /// <item>
        /// <description>ja-JP: "****/06/**"</description>
        /// </item>
        /// <item>
        /// <description>InvariantCulture: "06/**/****"</description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        DayAndYear
    }
}