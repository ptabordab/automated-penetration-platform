using System.Windows.Forms;

namespace PortalFileEditor
{
    public partial class EntitlementDocumentForm : Form, IDocument
    {
        public EntitlementDocumentForm()
        {
            InitializeComponent();
        }

        public DocumentKind Kind => DocumentKind.Entitlement;

        public string FilePath { get; set; }

        public bool IsDirty { get; set; }

        public void ClearDirty()
        {
            IsDirty = false;
        }

        public void LoadFromFile(string path)
        {
            StubCsvSerializer.Load(path, DocumentKind.Entitlement);
            FilePath = path;
            ClearDirty();
        }

        public void SaveToFile(string path)
        {
            StubCsvSerializer.Save(path, DocumentKind.Entitlement);
            FilePath = path;
            ClearDirty();
        }
    }
}
