namespace WinFormsToDoList
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtCreateCategory = new System.Windows.Forms.Button();
            this.BtCreateJob = new System.Windows.Forms.Button();
            this.BtState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtCreateCategory
            // 
            this.BtCreateCategory.Location = new System.Drawing.Point(413, 42);
            this.BtCreateCategory.Name = "BtCreateCategory";
            this.BtCreateCategory.Size = new System.Drawing.Size(166, 61);
            this.BtCreateCategory.TabIndex = 0;
            this.BtCreateCategory.Text = "Create Category";
            this.BtCreateCategory.UseVisualStyleBackColor = true;
            this.BtCreateCategory.Click += new System.EventHandler(this.BtCreateCategory_Click);
            // 
            // BtCreateJob
            // 
            this.BtCreateJob.Location = new System.Drawing.Point(413, 152);
            this.BtCreateJob.Name = "BtCreateJob";
            this.BtCreateJob.Size = new System.Drawing.Size(166, 61);
            this.BtCreateJob.TabIndex = 1;
            this.BtCreateJob.Text = "Create Job";
            this.BtCreateJob.UseVisualStyleBackColor = true;
            this.BtCreateJob.Click += new System.EventHandler(this.BtCreateJob_Click);
            // 
            // BtState
            // 
            this.BtState.Location = new System.Drawing.Point(413, 261);
            this.BtState.Name = "BtState";
            this.BtState.Size = new System.Drawing.Size(166, 61);
            this.BtState.TabIndex = 2;
            this.BtState.Text = "Create State";
            this.BtState.UseVisualStyleBackColor = true;
            this.BtState.Click += new System.EventHandler(this.BtState_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 578);
            this.Controls.Add(this.BtState);
            this.Controls.Add(this.BtCreateJob);
            this.Controls.Add(this.BtCreateCategory);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtCreateCategory;
        private Button BtCreateJob;
        private Button BtState;
    }
}