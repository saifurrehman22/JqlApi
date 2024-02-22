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
                    Operators = new List<string> { "=",  "in",  "not", "is is" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.category.id",
                    DisplayName = "Account.category.id",
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not", "<", "<=", ">", ">=" },
                    Types = new List<string> { "java.lang.Number" }
                },
                new JqlData
                {
                    Value = "Account.category.key",
                    DisplayName = "Account.category.key",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=","in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.category.name",
                    DisplayName = "Account.category.name",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.category.type",
                    DisplayName = "Account.category.type",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.customer",
                    DisplayName = "Account.customer",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.customer.id",
                    DisplayName = "Account.customer.id",
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not", "<", "<=", ">", ">=" },
                    Types = new List<string> { "java.lang.Number" }
                },
                new JqlData
                {
                    Value = "Account.customer.key",
                    DisplayName = "Account.customer.key",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=","in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.customer.name",
                    DisplayName = "Account.customer.name",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new JqlData
                {
                    Value = "Account.global",
                    DisplayName = "Account.global",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                // Add more data here if needed
            };
        }
    }
}
