namespace WinFormsToDoList
{
    partial class FormState
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
            this.Dtg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtRemove = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbFind = new System.Windows.Forms.TextBox();
            this.BtFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dtg
            // 
            this.Dtg.BackgroundColor = System.Drawing.Color.White;
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.Location = new System.Drawing.Point(116, 200);
            this.Dtg.Name = "Dtg";
            this.Dtg.ReadOnly = true;
            this.Dtg.RowHeadersWidth = 51;
            this.Dtg.RowTemplate.Height = 29;
            this.Dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg.Size = new System.Drawing.Size(755, 314);
            this.Dtg.TabIndex = 41;
            this.Dtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(275, -41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 38);
            this.label1.TabIndex = 36;
            this.label1.Text = "CREATE CATEGORY";
            // 
            // BtRemove
            // 
            this.BtRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtRemove.Enabled = false;
            this.BtRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtRemove.Location = new System.Drawing.Point(746, 522);
            this.BtRemove.Name = "BtRemove";
            this.BtRemove.Size = new System.Drawing.Size(123, 40);
            this.BtRemove.TabIndex = 40;
            this.BtRemove.Text = "Delete";
            this.BtRemove.UseVisualStyleBackColor = false;
            this.BtRemove.Click += new System.EventHandler(this.BtRemove_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtUpdate.Enabled = false;
            this.BtUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtUpdate.Location = new System.Drawing.Point(449, 520);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(123, 40);
            this.BtUpdate.TabIndex = 39;
            this.BtUpdate.Text = "Update";
            this.BtUpdate.UseVisualStyleBackColor = false;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtAdd
            // 
            this.BtAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtAdd.Location = new System.Drawing.Point(114, 520);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(123, 40);
            this.BtAdd.TabIndex = 38;
            this.BtAdd.Text = "Save";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TbName);
            this.panel1.Location = new System.Drawing.Point(221, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 66);
            this.panel1.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Name";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(188, 16);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(290, 27);
            this.TbName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(368, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 38);
            this.label2.TabIndex = 42;
            this.label2.Text = "CREATE CATEGORY";
            // 
            // TbFind
            // 
            this.TbFind.Location = new System.Drawing.Point(221, 74);
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(545, 27);
            this.TbFind.TabIndex = 43;
            // 
            // BtFind
            // 
            this.BtFind.Location = new System.Drawing.Point(806, 74);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(94, 27);
            this.BtFind.TabIndex = 44;
            this.BtFind.Text = "Find";
            this.BtFind.UseVisualStyleBackColor = true;
            this.BtFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(116, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 45;
            this.label3.Text = "Search";
            // 
            // FormState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 578);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtFind);
            this.Controls.Add(this.TbFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dtg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtRemove);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.panel1);
            this.Name = "FormState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormState";
            this.Load += new System.EventHandler(this.FormState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView Dtg;
        private Label label1;
        private Button BtRemove;
        private Button BtUpdate;
        private Button BtAdd;
        private Panel panel1;
        private Label label4;
        private TextBox TbName;
        private Label label2;
        private TextBox TbFind;
        private Button BtFind;
        private Label label3;
    }
}