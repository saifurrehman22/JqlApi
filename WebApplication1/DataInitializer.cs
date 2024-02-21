using System.Collections.Generic;
using WebApplication1.Models;

namespace WebDataInitializer
{
    public static class DataInitializer
    {
        public static List<JqlData> GetInitialData()
        {
            return new List<JqlData>
            {
                new JqlData
                {
                    Value = "a4j-incident-creation-deduplication-alias",
                    DisplayName = "a4j-incident-creation-deduplication-alias",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.category",
                    DisplayName = "Account.category",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                }
            };
        }
    }
}