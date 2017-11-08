using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Swagger_Test.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShiftDayOffRule
    {
        /// <summary>
        /// Shift has no day off rule.
        /// </summary>
        None = 0,       // DayOffNotRequired

        /// <summary>
        /// If shift with this rule is scheduled then next day must be a day off.
        /// </summary>
        OffAfter = 1,   // DayOffAfter <=> next is off

        /// <summary>
        /// If shift with this rule is scheduled then previous day must be a day off.
        /// </summary>
        OffBefore = -1, // DayOffBefore <=> previous is off

        /// <summary>
        /// If shift with this rule is scheduled then next day must be a work day.
        /// </summary>
        InAfter = 3     // DayInAfter <=> next cannot be off
    };
}