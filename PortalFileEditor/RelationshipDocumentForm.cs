using System.Windows.Forms;

namespace PortalFileEditor
{
    public partial class RelationshipDocumentForm : Form, IDocument
    {
        public RelationshipDocumentForm()
        {
            InitializeComponent();
        }

        public DocumentKind Kind => DocumentKind.Relationship;

        public string FilePath { get; set; }

        public bool IsDirty { get; set; }

        public void ClearDirty()
        {
            IsDirty = false;
        }

        public void LoadFromFile(string path)
        {
            StubCsvSerializer.Load(path, DocumentKind.Relationship);
            FilePath = path;
            ClearDirty();
        }

        public void SaveToFile(string path)
        {
            StubCsvSerializer.Save(path, DocumentKind.Relationship);
            FilePath = path;
            ClearDirty();
        }
    }
}
