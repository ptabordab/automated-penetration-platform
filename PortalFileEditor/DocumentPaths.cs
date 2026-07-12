using System;
using System.IO;

namespace PortalFileEditor
{
    internal static class DocumentPaths
    {
        internal const string CsvOpenSaveFilter =
            "Account (*.acct.csv)|*.acct.csv|" +
            "Entitlement (*.entitlement.csv)|*.entitlement.csv|" +
            "Relationship (*.relation.csv)|*.relation.csv|" +
            "All CSV (*.csv)|*.csv";

        internal static DocumentKind KindFromPath(string path)
        {
            var name = Path.GetFileName(path) ?? string.Empty;
            if (name.EndsWith(".acct.csv", StringComparison.OrdinalIgnoreCase))
                return DocumentKind.Account;
            if (name.EndsWith(".entitlement.csv", StringComparison.OrdinalIgnoreCase))
                return DocumentKind.Entitlement;
            if (name.EndsWith(".relation.csv", StringComparison.OrdinalIgnoreCase))
                return DocumentKind.Relationship;
            throw new InvalidOperationException(
                "File name must end with .acct.csv, .entitlement.csv, or .relation.csv.");
        }

        internal static int FilterIndexForKind(DocumentKind kind)
        {
            switch (kind)
            {
                case DocumentKind.Account: return 1;
                case DocumentKind.Entitlement: return 2;
                case DocumentKind.Relationship: return 3;
                default: return 4;
            }
        }

        internal static string SuggestedFileName(DocumentKind kind)
        {
            switch (kind)
            {
                case DocumentKind.Account: return "document.acct.csv";
                case DocumentKind.Entitlement: return "document.entitlement.csv";
                case DocumentKind.Relationship: return "document.relation.csv";
                default: return "document.csv";
            }
        }
    }
}
