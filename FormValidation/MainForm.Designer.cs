namespace FormValidation
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dsEmployees = new System.Windows.Forms.DataGridView();
            this.lblActions = new System.Windows.Forms.Label();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnSetDB = new System.Windows.Forms.Button();
            this.lblDB = new System.Windows.Forms.Label();
            this.lblDBTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dsEmployees);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblActions);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteEmployee);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditEmployee);
            this.splitContainer1.Panel2.Controls.Add(this.btnExit);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddEmployee);
            this.splitContainer1.Panel2.Controls.Add(this.btnSetDB);
            this.splitContainer1.Panel2.Controls.Add(this.lblDB);
            this.splitContainer1.Panel2.Controls.Add(this.lblDBTitle);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 603;
            this.splitContainer1.TabIndex = 0;
            // 
            // dsEmployees
            // 
            this.dsEmployees.AllowUserToAddRows = false;
            this.dsEmployees.AllowUserToDeleteRows = false;
            this.dsEmployees.AllowUserToResizeRows = false;
            this.dsEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dsEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsEmployees.Location = new System.Drawing.Point(0, 0);
            this.dsEmployees.Name = "dsEmployees";
            this.dsEmployees.ReadOnly = true;
            this.dsEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dsEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dsEmployees.Size = new System.Drawing.Size(603, 450);
            this.dsEmployees.TabIndex = 0;
            this.dsEmployees.DoubleClick += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Location = new System.Drawing.Point(13, 127);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(57, 13);
            this.lblActions.TabIndex = 7;
            this.lblActions.Text = "Действия";
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(16, 201);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(158, 23);
            this.btnDeleteEmployee.TabIndex = 6;
            this.btnDeleteEmployee.Text = "Изтрий";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(16, 172);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(158, 23);
            this.btnEditEmployee.TabIndex = 5;
            this.btnEditEmployee.Text = "Редактирай";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnExit
            // 
            this.btnExit.CausesValidation = false;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(106, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Изход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(16, 143);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(158, 23);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "Добави нов автомобил";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnSetDB
            // 
            this.btnSetDB.Location = new System.Drawing.Point(59, 61);
            this.btnSetDB.Name = "btnSetDB";
            this.btnSetDB.Size = new System.Drawing.Size(75, 23);
            this.btnSetDB.TabIndex = 2;
            this.btnSetDB.Text = "Избери";
            this.btnSetDB.UseVisualStyleBackColor = true;
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(13, 31);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(35, 13);
            this.lblDB.TabIndex = 1;
            this.lblDB.Text = "Няма";
            // 
            // lblDBTitle
            // 
            this.lblDBTitle.AutoSize = true;
            this.lblDBTitle.Location = new System.Drawing.Point(13, 9);
            this.lblDBTitle.Name = "lblDBTitle";
            this.lblDBTitle.Size = new System.Drawing.Size(68, 13);
            this.lblDBTitle.TabIndex = 0;
            this.lblDBTitle.Text = "База данни:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автомобили";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DoubleClick += new System.EventHandler(this.btnEditEmployee_Click);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dsEmployees;
        private System.Windows.Forms.Button btnSetDB;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Label lblDBTitle;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddEmployee;
    }
}