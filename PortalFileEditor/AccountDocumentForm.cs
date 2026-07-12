using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PortalFileEditor
{
    public partial class AccountDocumentForm : Form, IDocument
    {
        private bool _loading;

        public AccountDocumentForm()
        {
            InitializeComponent();
            trailerCountLabel.Text = "0";
            UpdateTrailerFromGrid();
        }

        public DocumentKind Kind => DocumentKind.Account;

        public string FilePath { get; set; }

        public bool IsDirty { get; set; }

        public void ClearDirty()
        {
            IsDirty = false;
        }

        public void LoadFromFile(string path)
        {
            _loading = true;
            try
            {
                grid.Rows.Clear();
                var names = AccountCsvSerializer.Load(path);
                foreach (var name in names)
                    grid.Rows.Add(name);

                FilePath = path;
                ClearDirty();
                UpdateTrailerFromGrid();
            }
            finally
            {
                _loading = false;
            }
        }

        public void SaveToFile(string path)
        {
            var names = GetBodyFileNames();
            AccountCsvSerializer.Save(path, names);
            FilePath = path;
            ClearDirty();
        }

        private IEnumerable<string> GetBodyFileNames()
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var cell = row.Cells[colFileName.Index];
                var raw = cell.Value?.ToString() ?? string.Empty;
                var trimmed = raw.Trim();
                if (trimmed.Length == 0)
                    continue;

                yield return trimmed;
            }
        }

        private void UpdateTrailerFromGrid()
        {
            trailerCountLabel.Text = CountBodyRows().ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private int CountBodyRows()
        {
            return grid.Rows.Cast<DataGridViewRow>()
                .Count(r => !r.IsNewRow && !string.IsNullOrWhiteSpace(r.Cells[colFileName.Index].Value?.ToString()));
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || e.RowIndex < 0)
                return;

            UpdateTrailerFromGrid();
            IsDirty = true;
        }

        private void Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_loading)
                return;

            UpdateTrailerFromGrid();
            IsDirty = true;
        }

        private void Grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_loading)
                return;

            UpdateTrailerFromGrid();
            IsDirty = true;
        }

        private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_loading || e.RowIndex < 0)
                return;

            if (grid.Rows[e.RowIndex].IsNewRow)
                return;

            if (e.ColumnIndex != colFileName.Index)
                return;

            var proposed = e.FormattedValue?.ToString()?.Trim() ?? string.Empty;
            if (proposed.Length == 0)
            {
                grid.Rows[e.RowIndex].ErrorText = "file_name is required.";
                e.Cancel = true;
                return;
            }

            if (proposed.Length > 10)
            {
                grid.Rows[e.RowIndex].ErrorText = "Maximum length is 10 characters.";
                e.Cancel = true;
                return;
            }

            grid.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void Grid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grid.Rows.Count)
                grid.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void AccountDocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsDirty)
                return;

            var result = MessageBox.Show(
                this,
                "Save changes to this Account document?",
                Text,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (result != DialogResult.Yes)
                return;

            var owner = MdiParent ?? (IWin32Window)this;
            if (DocumentSaveCoordinator.TrySave == null || !DocumentSaveCoordinator.TrySave(this, owner))
                e.Cancel = true;
        }
    }
}
