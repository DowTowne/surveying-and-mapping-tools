namespace DropDrapFileSimple
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listViewFolder = new System.Windows.Forms.ListView();
            this.buttonSelFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewFolder
            // 
            this.listViewFolder.Location = new System.Drawing.Point(28, 77);
            this.listViewFolder.Name = "listViewFolder";
            this.listViewFolder.Size = new System.Drawing.Size(686, 379);
            this.listViewFolder.TabIndex = 0;
            this.listViewFolder.UseCompatibleStateImageBehavior = false;
            this.listViewFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFolder_DragDrop);
            this.listViewFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFolder_DragEnter);
            this.listViewFolder.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFolder_ItemDrag);
            // 
            // buttonSelFolder
            // 
            this.buttonSelFolder.Location = new System.Drawing.Point(26, 12);
            this.buttonSelFolder.Name = "buttonSelFolder";
            this.buttonSelFolder.Size = new System.Drawing.Size(133, 23);
            this.buttonSelFolder.TabIndex = 1;
            this.buttonSelFolder.Text = "Select Folder";
            this.buttonSelFolder.UseVisualStyleBackColor = true;
            this.buttonSelFolder.Click += new System.EventHandler(this.buttonSelFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCurFolder
            // 
            this.labelCurFolder.AutoSize = true;
            this.labelCurFolder.Location = new System.Drawing.Point(108, 46);
            this.labelCurFolder.Name = "labelCurFolder";
            this.labelCurFolder.Size = new System.Drawing.Size(22, 13);
            this.labelCurFolder.TabIndex = 3;
            this.labelCurFolder.Text = "C:\\";
            this.labelCurFolder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 483);
            this.Controls.Add(this.labelCurFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelFolder);
            this.Controls.Add(this.listViewFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Drop Drap";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListView listViewFolder;
        private System.Windows.Forms.Button buttonSelFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurFolder;
    }
}

