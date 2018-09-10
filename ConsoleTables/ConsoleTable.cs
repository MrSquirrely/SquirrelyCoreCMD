using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTables {
    public class ConsoleTable {
        public IList<object> Columns { get; set; }
        public IList<object[]> Rows { get; protected set; }

        public ConsoleTableOptions Options { get; protected set; }

        public ConsoleTable(params string[] columns)
            : this(new ConsoleTableOptions { Columns = new List<string>(columns) }) {
        }

        public ConsoleTable(ConsoleTableOptions options) {
            Options = options ?? throw new ArgumentNullException("options");
            Rows = new List<object[]>();
            Columns = new List<object>(options.Columns);
        }

        public ConsoleTable AddColumn(IEnumerable<string> names) {
            foreach (string name in names) {
                Columns.Add(name);
            }

            return this;
        }

        public ConsoleTable AddRow(params object[] values) {
            if (values == null) {
                throw new ArgumentNullException(nameof(values));
            }

            if (!Columns.Any()) {
                throw new Exception("Please set the columns first");
            }

            if (Columns.Count != values.Length) {
                throw new Exception(
                    $"The number columns in the row ({Columns.Count}) does not match the values ({values.Length}");
            }

            Rows.Add(values);
            return this;
        }

        public static ConsoleTable From<T>(IEnumerable<T> values) {
            ConsoleTable table = new ConsoleTable();

            IEnumerable<string> columns = GetColumns<T>();

            table.AddColumn(columns);

            foreach (IEnumerable<object> propertyValues in values.Select(value => columns.Select(column => GetColumnValue<T>(value, column)))) {
                table.AddRow(propertyValues.ToArray());
            }

            return table;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            // find the longest column by searching each row
            List<int> columnLengths = ColumnLengths();

            // create the string format with padding
            string format = Enumerable.Range(0, Columns.Count)
                .Select(i => " | {" + i + ",-" + columnLengths[i] + "}")
                .Aggregate((s, a) => s + a) + " |";

            // find the longest formatted line
            int maxRowLength = Math.Max(0, Rows.Any() ? Rows.Max(row => string.Format(format, row).Length) : 0);
            string columnHeaders = string.Format(format, Columns.ToArray());

            // longest line is greater of formatted columnHeader and longest row
            int longestLine = Math.Max(maxRowLength, columnHeaders.Length);

            // add each row
            List<string> results = Rows.Select(row => string.Format(format, row)).ToList();

            // create the divider
            string divider = " " + string.Join("", Enumerable.Repeat("-", longestLine - 1)) + " ";

            builder.AppendLine(divider);
            builder.AppendLine(columnHeaders);

            foreach (string row in results) {
                builder.AppendLine(divider);
                builder.AppendLine(row);
            }

            builder.AppendLine(divider);

            if (Options.EnableCount) {
                builder.AppendLine("");
                builder.AppendFormat(" Count: {0}", Rows.Count);
            }

            return builder.ToString();
        }

        public string ToMarkDownString() => ToMarkDownString('|');

        private string ToMarkDownString(char delimiter) {
            StringBuilder builder = new StringBuilder();

            // find the longest column by searching each row
            List<int> columnLengths = ColumnLengths();

            // create the string format with padding
            string format = Format(columnLengths, delimiter);

            // find the longest formatted line
            string columnHeaders = string.Format(format, Columns.ToArray());

            // add each row
            List<string> results = Rows.Select(row => string.Format(format, row)).ToList();

            // create the divider
            string divider = Regex.Replace(columnHeaders, @"[^|]", "-");

            builder.AppendLine(columnHeaders);
            builder.AppendLine(divider);
            results.ForEach(row => builder.AppendLine(row));

            return builder.ToString();
        }

        public string ToMinimalString() => ToMarkDownString(char.MinValue);

        public string ToStringAlternative() {
            StringBuilder builder = new StringBuilder();

            // find the longest column by searching each row
            List<int> columnLengths = ColumnLengths();

            // create the string format with padding
            string format = Format(columnLengths);

            // find the longest formatted line
            string columnHeaders = string.Format(format, Columns.ToArray());

            // add each row
            List<string> results = Rows.Select(row => string.Format(format, row)).ToList();

            // create the divider
            string divider = Regex.Replace(columnHeaders, @"[^|]", "-");
            string dividerPlus = divider.Replace("|", "+");

            builder.AppendLine(dividerPlus);
            builder.AppendLine(columnHeaders);

            foreach (string row in results) {
                builder.AppendLine(dividerPlus);
                builder.AppendLine(row);
            }
            builder.AppendLine(dividerPlus);

            return builder.ToString();
        }

        private string Format(List<int> columnLengths, char delimiter = '|') {
            string delimiterStr = delimiter == char.MinValue ? string.Empty : delimiter.ToString();
            string format = (Enumerable.Range(0, Columns.Count)
                .Select(i => " " + delimiterStr + " {" + i + ",-" + columnLengths[i] + "}")
                .Aggregate((s, a) => s + a) + " " + delimiterStr).Trim();
            return format;
        }

        private List<int> ColumnLengths() {
            List<int> columnLengths = Columns
                .Select((t, i) => Rows.Select(x => x[i])
                    .Union(new[] { Columns[i] })
                    .Where(x => x != null)
                    .Select(x => x.ToString().Length).Max())
                .ToList();
            return columnLengths;
        }

        public void Write(Format format = ConsoleTables.Format.Minimal) {
            switch (format) {
                case ConsoleTables.Format.Default:
                    Console.WriteLine(ToString());
                    break;
                case ConsoleTables.Format.MarkDown:
                    Console.WriteLine(ToMarkDownString());
                    break;
                case ConsoleTables.Format.Alternative:
                    Console.WriteLine(ToStringAlternative());
                    break;
                case ConsoleTables.Format.Minimal:
                    Console.WriteLine(ToMinimalString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        private static IEnumerable<string> GetColumns<T>() => typeof(T).GetProperties().Select(x => x.Name).ToArray();

        private static object GetColumnValue<T>(object target, string column) => typeof(T).GetProperty(column).GetValue(target, null);
    }

    public class ConsoleTableOptions {
        public IEnumerable<string> Columns { get; set; } = new List<string>();
        public bool EnableCount { get; set; } = true;
    }

    public enum Format {
        Default = 0,
        MarkDown = 1,
        Alternative = 2,
        Minimal = 3
    }
}
