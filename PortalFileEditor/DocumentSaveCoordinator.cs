using System;
using System.Windows.Forms;

namespace PortalFileEditor
{
    /// <summary>Allows document forms to request save without referencing MainForm directly.</summary>
    internal static class DocumentSaveCoordinator
    {
        internal static Func<IDocument, IWin32Window, bool> TrySave { get; set; }
    }
}
