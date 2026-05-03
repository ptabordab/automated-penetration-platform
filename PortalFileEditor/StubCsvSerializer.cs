using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace PortalFileEditor
{
    internal static class StubCsvSerializer
    {
        internal static void Save(string path, DocumentKind kind)
        {
            var marker = kind == DocumentKind.Entitlement ? "ENTITLEMENT_STUB" : "RELATIONSHIP_STUB";
            var sb = new StringBuilder();
            sb.AppendLine("HDR");
            sb.AppendLine(marker);
            sb.AppendLine("TRL," + 1.ToString(CultureInfo.InvariantCulture));
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        internal static void Load(string path, DocumentKind expectedKind)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length < 3)
                throw new InvalidOperationException("Invalid document file: too few lines.");

            if (!string.Equals(lines[0].Trim(), "HDR", StringComparison.Ordinal))
                throw new InvalidOperationException("Invalid document file: expected HDR.");

            var marker = lines[1].Trim();
            var expectedMarker = expectedKind == DocumentKind.Entitlement ? "ENTITLEMENT_STUB" : "RELATIONSHIP_STUB";
            if (!string.Equals(marker, expectedMarker, StringComparison.Ordinal))
                throw new InvalidOperationException("Invalid document file: unexpected body marker.");

            if (!lines[2].Trim().StartsWith("TRL,", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Invalid document file: expected TRL.");
        }
    }
}
