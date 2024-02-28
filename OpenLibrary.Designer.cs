namespace ASSIGMENT11._2
{
    partial class OpenLibrary
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
            this.ResultList = new System.Windows.Forms.DataGridView();
            this.btnSearchAPI = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOpenLibrary = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtbxSearchAPI = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultList
            // 
            this.ResultList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ResultList.BackgroundColor = System.Drawing.Color.White;
            this.ResultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultList.Location = new System.Drawing.Point(42, 124);
            this.ResultList.Name = "ResultList";
            this.ResultList.RowHeadersWidth = 51;
            this.ResultList.RowTemplate.Height = 24;
            this.ResultList.Size = new System.Drawing.Size(864, 403);
            this.ResultList.TabIndex = 0;
            this.ResultList.SelectionChanged += new System.EventHandler(this.ResultList_SelectionChanged);
            // 
            // btnSearchAPI
            // 
            this.btnSearchAPI.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSearchAPI.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAPI.Location = new System.Drawing.Point(667, 68);
            this.btnSearchAPI.Name = "btnSearchAPI";
            this.btnSearchAPI.Size = new System.Drawing.Size(160, 31);
            this.btnSearchAPI.TabIndex = 3;
            this.btnSearchAPI.Text = "Search";
            this.btnSearchAPI.UseVisualStyleBackColor = false;
            this.btnSearchAPI.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.Cornsilk;
            this.btnTransfer.Font = new System.Drawing.Font("Bodoni MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(667, 553);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(239, 43);
            this.btnTransfer.TabIndex = 12;
            this.btnTransfer.Text = "Transfer to Library";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.lblOpenLibrary);
            this.panel1.Location = new System.Drawing.Point(-2, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 47);
            this.panel1.TabIndex = 5;
            // 
            // lblOpenLibrary
            // 
            this.lblOpenLibrary.AutoSize = true;
            this.lblOpenLibrary.Font = new System.Drawing.Font("Bodoni MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenLibrary.Location = new System.Drawing.Point(426, 8);
            this.lblOpenLibrary.Name = "lblOpenLibrary";
            this.lblOpenLibrary.Size = new System.Drawing.Size(137, 27);
            this.lblOpenLibrary.TabIndex = 2;
            this.lblOpenLibrary.Text = "Open Library";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(47, 76);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(52, 23);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Title:";
            // 
            // txtbxSearchAPI
            // 
            this.txtbxSearchAPI.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxSearchAPI.Location = new System.Drawing.Point(132, 68);
            this.txtbxSearchAPI.Name = "txtbxSearchAPI";
            this.txtbxSearchAPI.Size = new System.Drawing.Size(476, 31);
            this.txtbxSearchAPI.TabIndex = 16;
            // 
            // OpenLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(966, 655);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.txtbxSearchAPI);
            this.Controls.Add(this.btnSearchAPI);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ResultList);
            this.Name = "OpenLibrary";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultList;
        private System.Windows.Forms.Button btnSearchAPI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOpenLibrary;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtbxSearchAPI;
        private System.Windows.Forms.Button btnTransfer;
    }
}