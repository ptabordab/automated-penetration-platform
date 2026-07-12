namespace PortalFileEditor
{
    partial class AccountDocumentForm
    {
        private System.ComponentModel.IContainer components;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label hdrLabel;
        private System.Windows.Forms.TextBox hdrIndicatorTextBox;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.Panel trailerPanel;
        private System.Windows.Forms.Label trlLabel;
        private System.Windows.Forms.Label trailerCountLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new System.Windows.Forms.Panel();
            hdrIndicatorTextBox = new System.Windows.Forms.TextBox();
            hdrLabel = new System.Windows.Forms.Label();
            bodyPanel = new System.Windows.Forms.Panel();
            grid = new System.Windows.Forms.DataGridView();
            colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            trailerPanel = new System.Windows.Forms.Panel();
            trailerCountLabel = new System.Windows.Forms.Label();
            trlLabel = new System.Windows.Forms.Label();
            headerPanel.SuspendLayout();
            bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(grid)).BeginInit();
            trailerPanel.SuspendLayout();
            SuspendLayout();
            //
            // headerPanel
            //
            headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            headerPanel.Controls.Add(hdrIndicatorTextBox);
            headerPanel.Controls.Add(hdrLabel);
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new System.Windows.Forms.Padding(8);
            headerPanel.Size = new System.Drawing.Size(784, 48);
            headerPanel.TabIndex = 0;
            //
            // hdrLabel
            //
            hdrLabel.AutoSize = true;
            hdrLabel.Location = new System.Drawing.Point(11, 16);
            hdrLabel.Name = "hdrLabel";
            hdrLabel.Size = new System.Drawing.Size(94, 15);
            hdrLabel.TabIndex = 0;
            hdrLabel.Text = "Header indicator";
            //
            // hdrIndicatorTextBox
            //
            hdrIndicatorTextBox.Location = new System.Drawing.Point(130, 13);
            hdrIndicatorTextBox.Name = "hdrIndicatorTextBox";
            hdrIndicatorTextBox.ReadOnly = true;
            hdrIndicatorTextBox.Size = new System.Drawing.Size(60, 23);
            hdrIndicatorTextBox.TabIndex = 1;
            hdrIndicatorTextBox.TabStop = false;
            hdrIndicatorTextBox.Text = "HDR";
            //
            // bodyPanel
            //
            bodyPanel.Controls.Add(grid);
            bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            bodyPanel.Location = new System.Drawing.Point(0, 48);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new System.Windows.Forms.Padding(8);
            bodyPanel.Size = new System.Drawing.Size(784, 364);
            bodyPanel.TabIndex = 1;
            //
            // grid
            //
            grid.AllowUserToResizeRows = false;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colFileName });
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.Location = new System.Drawing.Point(8, 8);
            grid.Name = "grid";
            grid.RowHeadersWidth = 48;
            grid.Size = new System.Drawing.Size(768, 348);
            grid.TabIndex = 0;
            grid.CellValidated += Grid_CellValidated;
            grid.CellValidating += Grid_CellValidating;
            grid.CellValueChanged += Grid_CellValueChanged;
            grid.RowsAdded += Grid_RowsAdded;
            grid.RowsRemoved += Grid_RowsRemoved;
            //
            // colFileName
            //
            colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colFileName.HeaderText = "file_name";
            colFileName.MaxInputLength = 10;
            colFileName.Name = "colFileName";
            //
            // trailerPanel
            //
            trailerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            trailerPanel.Controls.Add(trailerCountLabel);
            trailerPanel.Controls.Add(trlLabel);
            trailerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            trailerPanel.Location = new System.Drawing.Point(0, 412);
            trailerPanel.Name = "trailerPanel";
            trailerPanel.Padding = new System.Windows.Forms.Padding(8);
            trailerPanel.Size = new System.Drawing.Size(784, 49);
            trailerPanel.TabIndex = 2;
            //
            // trlLabel
            //
            trlLabel.AutoSize = true;
            trlLabel.Location = new System.Drawing.Point(11, 17);
            trlLabel.Name = "trlLabel";
            trlLabel.Size = new System.Drawing.Size(27, 15);
            trlLabel.TabIndex = 0;
            trlLabel.Text = "TRL";
            //
            // trailerCountLabel
            //
            trailerCountLabel.AutoSize = true;
            trailerCountLabel.Location = new System.Drawing.Point(54, 17);
            trailerCountLabel.Name = "trailerCountLabel";
            trailerCountLabel.Size = new System.Drawing.Size(13, 15);
            trailerCountLabel.TabIndex = 1;
            trailerCountLabel.Text = "0";
            //
            // AccountDocumentForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(bodyPanel);
            Controls.Add(trailerPanel);
            Controls.Add(headerPanel);
            MinimumSize = new System.Drawing.Size(400, 280);
            Name = "AccountDocumentForm";
            Text = "Account";
            FormClosing += AccountDocumentForm_FormClosing;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            bodyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(grid)).EndInit();
            trailerPanel.ResumeLayout(false);
            trailerPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
