namespace ClientSync.UI
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.dgCustomers = new System.Windows.Forms.DataGridView();
            this.btn_updateToUpper = new System.Windows.Forms.Button();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.pnl_topbar = new System.Windows.Forms.Panel();
            this.lbl_appTitle = new System.Windows.Forms.Label();
            this.panel_bodyContainer = new System.Windows.Forms.Panel();
            this.pnl_gridViewContainer = new System.Windows.Forms.Panel();
            this.tbl_Layout_Cards = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_cardAndCtrls = new System.Windows.Forms.Panel();
            this.lbl_recordVal = new System.Windows.Forms.Label();
            this.lbl_recordTitle = new System.Windows.Forms.Label();
            this.flp_actionCtrls = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_resetGrid = new System.Windows.Forms.Button();
            this.btn_exportJson = new System.Windows.Forms.Button();
            this.btn_searchByAge = new System.Windows.Forms.Button();
            this.ttp_ActionDesc = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
            this.pnl_topbar.SuspendLayout();
            this.panel_bodyContainer.SuspendLayout();
            this.pnl_gridViewContainer.SuspendLayout();
            this.tbl_Layout_Cards.SuspendLayout();
            this.pnl_cardAndCtrls.SuspendLayout();
            this.flp_actionCtrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCustomers
            // 
            this.dgCustomers.AllowUserToAddRows = false;
            this.dgCustomers.AllowUserToDeleteRows = false;
            this.dgCustomers.AllowUserToResizeRows = false;
            this.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgCustomers.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCustomers.Location = new System.Drawing.Point(5, 5);
            this.dgCustomers.Margin = new System.Windows.Forms.Padding(5);
            this.dgCustomers.Name = "dgCustomers";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCustomers.RowHeadersWidth = 51;
            this.dgCustomers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCustomers.RowTemplate.Height = 24;
            this.dgCustomers.Size = new System.Drawing.Size(1242, 577);
            this.dgCustomers.TabIndex = 0;
            this.dgCustomers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGCustomers_KeyDown);
            // 
            // btn_updateToUpper
            // 
            this.btn_updateToUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateToUpper.AutoSize = true;
            this.btn_updateToUpper.BackColor = System.Drawing.Color.Transparent;
            this.btn_updateToUpper.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_updateToUpper.BackgroundImage")));
            this.btn_updateToUpper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_updateToUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_updateToUpper.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_updateToUpper.Location = new System.Drawing.Point(862, 0);
            this.btn_updateToUpper.Margin = new System.Windows.Forms.Padding(0);
            this.btn_updateToUpper.Name = "btn_updateToUpper";
            this.btn_updateToUpper.Padding = new System.Windows.Forms.Padding(5);
            this.btn_updateToUpper.Size = new System.Drawing.Size(60, 60);
            this.btn_updateToUpper.TabIndex = 2;
            this.btn_updateToUpper.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_updateToUpper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttp_ActionDesc.SetToolTip(this.btn_updateToUpper, "Click to change \'Last Name\' to \'UPPERCASE\' of all avaiable records in Grid.");
            this.btn_updateToUpper.UseVisualStyleBackColor = false;
            this.btn_updateToUpper.Click += new System.EventHandler(this.Btn_updateToUpper_Click);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveChanges.AutoSize = true;
            this.btn_SaveChanges.BackColor = System.Drawing.Color.Transparent;
            this.btn_SaveChanges.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SaveChanges.BackgroundImage")));
            this.btn_SaveChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_SaveChanges.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SaveChanges.Location = new System.Drawing.Point(922, 0);
            this.btn_SaveChanges.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Padding = new System.Windows.Forms.Padding(5);
            this.btn_SaveChanges.Size = new System.Drawing.Size(60, 60);
            this.btn_SaveChanges.TabIndex = 1;
            this.btn_SaveChanges.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttp_ActionDesc.SetToolTip(this.btn_SaveChanges, "Click to \'SAVE\' current changes of \'Grid\'.\r\n");
            this.btn_SaveChanges.UseVisualStyleBackColor = false;
            this.btn_SaveChanges.Click += new System.EventHandler(this.BtnSaveChanges_Click);
            // 
            // pnl_topbar
            // 
            this.pnl_topbar.BackColor = System.Drawing.Color.White;
            this.pnl_topbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_topbar.Controls.Add(this.lbl_appTitle);
            this.pnl_topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_topbar.Location = new System.Drawing.Point(0, 0);
            this.pnl_topbar.Name = "pnl_topbar";
            this.pnl_topbar.Size = new System.Drawing.Size(1262, 46);
            this.pnl_topbar.TabIndex = 4;
            // 
            // lbl_appTitle
            // 
            this.lbl_appTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_appTitle.AutoSize = true;
            this.lbl_appTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_appTitle.Location = new System.Drawing.Point(591, 8);
            this.lbl_appTitle.Name = "lbl_appTitle";
            this.lbl_appTitle.Size = new System.Drawing.Size(78, 29);
            this.lbl_appTitle.TabIndex = 0;
            this.lbl_appTitle.Text = "Home";
            this.lbl_appTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_bodyContainer
            // 
            this.panel_bodyContainer.Controls.Add(this.pnl_gridViewContainer);
            this.panel_bodyContainer.Controls.Add(this.tbl_Layout_Cards);
            this.panel_bodyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bodyContainer.Location = new System.Drawing.Point(0, 46);
            this.panel_bodyContainer.Name = "panel_bodyContainer";
            this.panel_bodyContainer.Padding = new System.Windows.Forms.Padding(5);
            this.panel_bodyContainer.Size = new System.Drawing.Size(1262, 707);
            this.panel_bodyContainer.TabIndex = 6;
            // 
            // pnl_gridViewContainer
            // 
            this.pnl_gridViewContainer.Controls.Add(this.dgCustomers);
            this.pnl_gridViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_gridViewContainer.Location = new System.Drawing.Point(5, 115);
            this.pnl_gridViewContainer.Name = "pnl_gridViewContainer";
            this.pnl_gridViewContainer.Padding = new System.Windows.Forms.Padding(5);
            this.pnl_gridViewContainer.Size = new System.Drawing.Size(1252, 587);
            this.pnl_gridViewContainer.TabIndex = 7;
            // 
            // tbl_Layout_Cards
            // 
            this.tbl_Layout_Cards.AutoScroll = true;
            this.tbl_Layout_Cards.AutoSize = true;
            this.tbl_Layout_Cards.ColumnCount = 2;
            this.tbl_Layout_Cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbl_Layout_Cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_Layout_Cards.Controls.Add(this.pnl_cardAndCtrls, 0, 0);
            this.tbl_Layout_Cards.Controls.Add(this.flp_actionCtrls, 1, 0);
            this.tbl_Layout_Cards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbl_Layout_Cards.Location = new System.Drawing.Point(5, 5);
            this.tbl_Layout_Cards.Name = "tbl_Layout_Cards";
            this.tbl_Layout_Cards.Padding = new System.Windows.Forms.Padding(5);
            this.tbl_Layout_Cards.RowCount = 1;
            this.tbl_Layout_Cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_Layout_Cards.Size = new System.Drawing.Size(1252, 110);
            this.tbl_Layout_Cards.TabIndex = 6;
            // 
            // pnl_cardAndCtrls
            // 
            this.pnl_cardAndCtrls.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnl_cardAndCtrls.Controls.Add(this.lbl_recordVal);
            this.pnl_cardAndCtrls.Controls.Add(this.lbl_recordTitle);
            this.pnl_cardAndCtrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_cardAndCtrls.Location = new System.Drawing.Point(5, 5);
            this.pnl_cardAndCtrls.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_cardAndCtrls.Name = "pnl_cardAndCtrls";
            this.pnl_cardAndCtrls.Size = new System.Drawing.Size(200, 100);
            this.pnl_cardAndCtrls.TabIndex = 0;
            // 
            // lbl_recordVal
            // 
            this.lbl_recordVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_recordVal.AutoSize = true;
            this.lbl_recordVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recordVal.ForeColor = System.Drawing.Color.White;
            this.lbl_recordVal.Location = new System.Drawing.Point(68, 48);
            this.lbl_recordVal.Name = "lbl_recordVal";
            this.lbl_recordVal.Size = new System.Drawing.Size(34, 25);
            this.lbl_recordVal.TabIndex = 1;
            this.lbl_recordVal.Text = "00";
            // 
            // lbl_recordTitle
            // 
            this.lbl_recordTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_recordTitle.AutoSize = true;
            this.lbl_recordTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recordTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_recordTitle.Location = new System.Drawing.Point(25, 14);
            this.lbl_recordTitle.Name = "lbl_recordTitle";
            this.lbl_recordTitle.Size = new System.Drawing.Size(133, 25);
            this.lbl_recordTitle.TabIndex = 0;
            this.lbl_recordTitle.Text = "Total Records";
            // 
            // flp_actionCtrls
            // 
            this.flp_actionCtrls.Controls.Add(this.btn_resetGrid);
            this.flp_actionCtrls.Controls.Add(this.btn_SaveChanges);
            this.flp_actionCtrls.Controls.Add(this.btn_updateToUpper);
            this.flp_actionCtrls.Controls.Add(this.btn_exportJson);
            this.flp_actionCtrls.Controls.Add(this.btn_searchByAge);
            this.flp_actionCtrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_actionCtrls.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_actionCtrls.Location = new System.Drawing.Point(205, 5);
            this.flp_actionCtrls.Margin = new System.Windows.Forms.Padding(0);
            this.flp_actionCtrls.Name = "flp_actionCtrls";
            this.flp_actionCtrls.Size = new System.Drawing.Size(1042, 100);
            this.flp_actionCtrls.TabIndex = 1;
            // 
            // btn_resetGrid
            // 
            this.btn_resetGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_resetGrid.AutoSize = true;
            this.btn_resetGrid.BackColor = System.Drawing.Color.Transparent;
            this.btn_resetGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_resetGrid.BackgroundImage")));
            this.btn_resetGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_resetGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_resetGrid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_resetGrid.Location = new System.Drawing.Point(982, 0);
            this.btn_resetGrid.Margin = new System.Windows.Forms.Padding(0);
            this.btn_resetGrid.Name = "btn_resetGrid";
            this.btn_resetGrid.Padding = new System.Windows.Forms.Padding(5);
            this.btn_resetGrid.Size = new System.Drawing.Size(60, 60);
            this.btn_resetGrid.TabIndex = 5;
            this.btn_resetGrid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_resetGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttp_ActionDesc.SetToolTip(this.btn_resetGrid, "Click to fetch record and reset the grid.");
            this.btn_resetGrid.UseVisualStyleBackColor = false;
            this.btn_resetGrid.Click += new System.EventHandler(this.Btn_resetGrid_Click);
            // 
            // btn_exportJson
            // 
            this.btn_exportJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportJson.AutoSize = true;
            this.btn_exportJson.BackColor = System.Drawing.Color.Transparent;
            this.btn_exportJson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_exportJson.BackgroundImage")));
            this.btn_exportJson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_exportJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_exportJson.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_exportJson.Location = new System.Drawing.Point(802, 0);
            this.btn_exportJson.Margin = new System.Windows.Forms.Padding(0);
            this.btn_exportJson.Name = "btn_exportJson";
            this.btn_exportJson.Padding = new System.Windows.Forms.Padding(5);
            this.btn_exportJson.Size = new System.Drawing.Size(60, 60);
            this.btn_exportJson.TabIndex = 3;
            this.btn_exportJson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_exportJson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttp_ActionDesc.SetToolTip(this.btn_exportJson, "Click to export matched records to \'JSON\'.");
            this.btn_exportJson.UseVisualStyleBackColor = false;
            this.btn_exportJson.Click += new System.EventHandler(this.BtnExportJson_Click);
            // 
            // btn_searchByAge
            // 
            this.btn_searchByAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_searchByAge.AutoSize = true;
            this.btn_searchByAge.BackColor = System.Drawing.Color.Transparent;
            this.btn_searchByAge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_searchByAge.BackgroundImage")));
            this.btn_searchByAge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_searchByAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_searchByAge.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_searchByAge.Location = new System.Drawing.Point(742, 0);
            this.btn_searchByAge.Margin = new System.Windows.Forms.Padding(0);
            this.btn_searchByAge.Name = "btn_searchByAge";
            this.btn_searchByAge.Padding = new System.Windows.Forms.Padding(5);
            this.btn_searchByAge.Size = new System.Drawing.Size(60, 60);
            this.btn_searchByAge.TabIndex = 4;
            this.btn_searchByAge.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_searchByAge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttp_ActionDesc.SetToolTip(this.btn_searchByAge, "Click to filtered records by age.");
            this.btn_searchByAge.UseVisualStyleBackColor = false;
            this.btn_searchByAge.Click += new System.EventHandler(this.Btn_searchByAge_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.panel_bodyContainer);
            this.Controls.Add(this.pnl_topbar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 800);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
            this.pnl_topbar.ResumeLayout(false);
            this.pnl_topbar.PerformLayout();
            this.panel_bodyContainer.ResumeLayout(false);
            this.panel_bodyContainer.PerformLayout();
            this.pnl_gridViewContainer.ResumeLayout(false);
            this.tbl_Layout_Cards.ResumeLayout(false);
            this.pnl_cardAndCtrls.ResumeLayout(false);
            this.pnl_cardAndCtrls.PerformLayout();
            this.flp_actionCtrls.ResumeLayout(false);
            this.flp_actionCtrls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgCustomers;
        private System.Windows.Forms.Button btn_updateToUpper;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.Panel pnl_topbar;
        private System.Windows.Forms.Label lbl_appTitle;
        private System.Windows.Forms.Panel panel_bodyContainer;
        private System.Windows.Forms.TableLayoutPanel tbl_Layout_Cards;
        private System.Windows.Forms.Panel pnl_cardAndCtrls;
        private System.Windows.Forms.Label lbl_recordTitle;
        private System.Windows.Forms.Label lbl_recordVal;
        private System.Windows.Forms.Panel pnl_gridViewContainer;
        private System.Windows.Forms.ToolTip ttp_ActionDesc;
        private System.Windows.Forms.FlowLayoutPanel flp_actionCtrls;
        private System.Windows.Forms.Button btn_exportJson;
        private System.Windows.Forms.Button btn_searchByAge;
        private System.Windows.Forms.Button btn_resetGrid;
    }
}