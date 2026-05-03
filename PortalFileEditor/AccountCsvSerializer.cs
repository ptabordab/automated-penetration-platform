using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace PortalFileEditor
{
    internal static class AccountCsvSerializer
    {
        internal static void Save(string path, IEnumerable<string> fileNames)
        {
            var rows = fileNames
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToList();

            foreach (var name in rows)
            {
                if (name.Length > 10)
                    throw new InvalidOperationException(
                        $"file_name exceeds 10 characters: '{name}'.");
            }

            var sb = new StringBuilder();
            sb.AppendLine("HDR");
            sb.AppendLine(CsvEscape("file_name"));
            foreach (var name in rows)
                sb.AppendLine(CsvEscape(name));
            sb.AppendLine("TRL," + rows.Count.ToString(CultureInfo.InvariantCulture));

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        internal static IReadOnlyList<string> Load(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length < 3)
                throw new InvalidOperationException("Invalid Account file: too few lines.");

            if (!string.Equals(lines[0].Trim(), "HDR", StringComparison.Ordinal))
                throw new InvalidOperationException("Invalid Account file: expected HDR.");

            var header = UnescapeCsvLine(lines[1]).Trim();
            if (!string.Equals(header, "file_name", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Invalid Account file: expected file_name header.");

            var body = new List<string>();
            for (var i = 2; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("TRL,", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = line.Split(new[] { ',' }, 2);
                    if (parts.Length != 2 || !int.TryParse(parts[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var trailerCount))
                        throw new InvalidOperationException("Invalid Account file: malformed TRL line.");

                    if (trailerCount != body.Count)
                        throw new InvalidOperationException(
                            $"Invalid Account file: TRL count {trailerCount} does not match body rows {body.Count}.");

                    if (i != lines.Length - 1 && lines.Skip(i + 1).Any(l => !string.IsNullOrWhiteSpace(l)))
                        throw new InvalidOperationException("Invalid Account file: unexpected lines after TRL.");

                    foreach (var name in body)
                    {
                        if (name.Length > 10)
                            throw new InvalidOperationException($"file_name exceeds 10 characters: '{name}'.");
                    }

                    return body;
                }

                var value = UnescapeCsvLine(line).Trim();
                if (value.Length == 0)
                    throw new InvalidOperationException("Invalid Account file: empty file_name not allowed.");

                if (value.Length > 10)
                    throw new InvalidOperationException($"file_name exceeds 10 characters: '{value}'.");

                body.Add(value);
            }

            throw new InvalidOperationException("Invalid Account file: missing TRL.");
        }

        private static string CsvEscape(string value)
        {
            if (value.IndexOfAny(new[] { '"', ',', '\r', '\n' }) >= 0)
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private static string UnescapeCsvLine(string line)
        {
            line = line.Trim();
            if (line.Length >= 2 && line[0] == '"' && line[line.Length - 1] == '"')
            {
                var inner = line.Substring(1, line.Length - 2).Replace("\"\"", "\"");
                return inner;
            }

            return line;
        }
    }
}
