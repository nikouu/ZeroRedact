﻿namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to a string.
    /// </summary>
    public enum StringRedaction
    {
        /// <summary>
        /// the string is redacted.
        /// </summary>
        /// <remarks>Example: "Hello, world!" becomes "*************"</remarks>
        All,

        /// <summary>
        /// the string is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "Hello, world!" becomes "*********"</remarks>
        FixedLength,

        /// <summary>
        /// The first half of the string is redacted.
        /// </summary>
        /// <remarks>Example: "Hello, world!" becomes "*******world!"</remarks>
        FirstHalf,

        /// <summary>
        /// The second half of the string is redacted.
        /// </summary>
        /// <remarks>Example: "Hello, world!" becomes "Hello,*******"</remarks>
        SecondHalf,

        /// <summary>
        /// All characters are redacted except symbols.
        /// </summary>
        /// <remarks>Example: "Hello, world!" becomes "******, *****!"</remarks>
        IgnoreSymbols
    }
}
