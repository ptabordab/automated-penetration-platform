using System;
using System.IO;
using System.Windows.Forms;

namespace PortalFileEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DocumentSaveCoordinator.TrySave = TrySaveDocument;
        }

        private static string TitleForDocument(DocumentKind kind, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                switch (kind)
                {
                    case DocumentKind.Account: return "Account — Untitled";
                    case DocumentKind.Entitlement: return "Entitlement — Untitled";
                    default: return "Relationship — Untitled";
                }
            }

            return Path.GetFileName(path);
        }

        private static Form CreateDocumentForm(DocumentKind kind)
        {
            switch (kind)
            {
                case DocumentKind.Account:
                    return new AccountDocumentForm();
                case DocumentKind.Entitlement:
                    return new EntitlementDocumentForm();
                default:
                    return new RelationshipDocumentForm();
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = DocumentPaths.CsvOpenSaveFilter;
                dlg.CheckFileExists = true;
                dlg.Multiselect = false;
                dlg.Title = "Open document";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                DocumentKind kind;
                try
                {
                    kind = DocumentPaths.KindFromPath(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Form child;
                try
                {
                    child = CreateDocumentForm(kind);
                    child.MdiParent = this;
                    child.Text = TitleForDocument(kind, dlg.FileName);

                    var doc = (IDocument)child;
                    doc.LoadFromFile(dlg.FileName);

                    child.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            var doc = ActiveMdiChild as IDocument;
            if (doc == null)
            {
                MessageBox.Show(this, "No document window is active.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TrySaveDocument(doc, this);
        }

        internal bool TrySaveDocument(IDocument doc, IWin32Window owner)
        {
            var path = doc.FilePath;
            if (string.IsNullOrEmpty(path))
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = DocumentPaths.CsvOpenSaveFilter;
                    dlg.FilterIndex = DocumentPaths.FilterIndexForKind(doc.Kind);
                    dlg.FileName = DocumentPaths.SuggestedFileName(doc.Kind);
                    dlg.DefaultExt = "csv";
                    dlg.AddExtension = true;
                    dlg.Title = "Save document";

                    if (dlg.ShowDialog(owner ?? this) != DialogResult.OK)
                        return false;

                    path = dlg.FileName;
                }
            }

            DocumentKind pathKind;
            try
            {
                pathKind = DocumentPaths.KindFromPath(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner ?? this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (pathKind != doc.Kind)
            {
                MessageBox.Show(
                    owner ?? this,
                    "The selected file name does not match the active document type.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                doc.SaveToFile(path);

                if (doc is Form f)
                    f.Text = TitleForDocument(doc.Kind, path);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner ?? this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CascadeMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DocumentSaveCoordinator.TrySave = null;

            foreach (Form child in MdiChildren)
            {
                var doc = child as IDocument;
                if (doc == null || !doc.IsDirty)
                    continue;

                ActivateMdiChild(child);

                var result = MessageBox.Show(
                    this,
                    "Save changes to \"" + child.Text + "\"?",
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (result == DialogResult.Yes && !TrySaveDocument(doc, this))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
