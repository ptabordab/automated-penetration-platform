namespace PortalFileEditor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileSepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fileSepToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            //
            // mainMenuStrip
            //
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                fileToolStripMenuItem,
                windowToolStripMenuItem
            });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(984, 24);
            mainMenuStrip.TabIndex = 0;
            //
            // fileToolStripMenuItem
            //
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                openToolStripMenuItem,
                saveToolStripMenuItem,
                fileSepToolStripMenuItem,
                exitToolStripMenuItem
            });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            //
            // openToolStripMenuItem
            //
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            openToolStripMenuItem.Text = "&Open…";
            openToolStripMenuItem.Click += OpenMenuItem_Click;
            //
            // saveToolStripMenuItem
            //
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += SaveMenuItem_Click;
            //
            // fileSepToolStripMenuItem
            //
            fileSepToolStripMenuItem.Name = "fileSepToolStripMenuItem";
            fileSepToolStripMenuItem.Size = new System.Drawing.Size(177, 6);
            //
            // exitToolStripMenuItem
            //
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitMenuItem_Click;
            //
            // windowToolStripMenuItem
            //
            windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                cascadeToolStripMenuItem,
                tileVerticalToolStripMenuItem,
                tileHorizontalToolStripMenuItem
            });
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            windowToolStripMenuItem.Text = "&Window";
            //
            // cascadeToolStripMenuItem
            //
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            cascadeToolStripMenuItem.Text = "&Cascade";
            cascadeToolStripMenuItem.Click += CascadeMenuItem_Click;
            //
            // tileVerticalToolStripMenuItem
            //
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            tileVerticalToolStripMenuItem.Click += TileVerticalMenuItem_Click;
            //
            // tileHorizontalToolStripMenuItem
            //
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            tileHorizontalToolStripMenuItem.Click += TileHorizontalMenuItem_Click;
            //
            // MainForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 661);
            Controls.Add(mainMenuStrip);
            IsMdiContainer = true;
            MainMenuStrip = mainMenuStrip;
            MinimumSize = new System.Drawing.Size(640, 480);
            Name = "MainForm";
            Text = "Portal File Editor";
            FormClosing += MainForm_FormClosing;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
