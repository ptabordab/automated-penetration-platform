namespace PortalFileEditor
{
    partial class EntitlementDocumentForm
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label stubLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            stubLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            //
            // stubLabel
            //
            stubLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            stubLabel.Location = new System.Drawing.Point(0, 0);
            stubLabel.Name = "stubLabel";
            stubLabel.Padding = new System.Windows.Forms.Padding(16);
            stubLabel.Size = new System.Drawing.Size(784, 461);
            stubLabel.TabIndex = 0;
            stubLabel.Text = "Entitlement document (stub).\r\n\r\nUse File → Save after opening or when creating a new file from Save dialog.";
            //
            // EntitlementDocumentForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(stubLabel);
            MinimumSize = new System.Drawing.Size(400, 200);
            Name = "EntitlementDocumentForm";
            Text = "Entitlement";
            ResumeLayout(false);
        }
    }
}
