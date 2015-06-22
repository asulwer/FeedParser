namespace FeedParser
{
    partial class frmData
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.cbStartStop = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbShares = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFeed = new System.Windows.Forms.TabPage();
            this.tabTransaction = new System.Windows.Forms.TabPage();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCash = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAssets = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.dgInvestments = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.bwGetFeed = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabFeed.SuspendLayout();
            this.tabTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvestments)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chartData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgData, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(711, 424);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // chartData
            // 
            this.chartData.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft;
            this.chartData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartData.Legends.Add(legend3);
            this.chartData.Location = new System.Drawing.Point(3, 215);
            this.chartData.Name = "chartData";
            this.chartData.Size = new System.Drawing.Size(705, 206);
            this.chartData.TabIndex = 3;
            this.chartData.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chartData_GetToolTipText);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.Location = new System.Drawing.Point(3, 3);
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.Size = new System.Drawing.Size(705, 206);
            this.dgData.TabIndex = 2;
            this.dgData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgData_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Interval m\\s";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(75, 11);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(116, 20);
            this.tbInterval.TabIndex = 9;
            this.tbInterval.TextChanged += new System.EventHandler(this.tbInterval_TextChanged);
            // 
            // cbStartStop
            // 
            this.cbStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStartStop.AutoSize = true;
            this.cbStartStop.Location = new System.Drawing.Point(639, 10);
            this.cbStartStop.Name = "cbStartStop";
            this.cbStartStop.Size = new System.Drawing.Size(75, 17);
            this.cbStartStop.TabIndex = 8;
            this.cbStartStop.Text = "Start/Stop";
            this.cbStartStop.UseVisualStyleBackColor = true;
            this.cbStartStop.Click += new System.EventHandler(this.cbStartStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbPrice
            // 
            this.tbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrice.Location = new System.Drawing.Point(611, 22);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(100, 20);
            this.tbPrice.TabIndex = 0;
            this.tbPrice.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Shares";
            // 
            // tbShares
            // 
            this.tbShares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShares.Location = new System.Drawing.Point(611, 61);
            this.tbShares.Name = "tbShares";
            this.tbShares.Size = new System.Drawing.Size(100, 20);
            this.tbShares.TabIndex = 1;
            this.tbShares.Text = "0";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabFeed);
            this.tabControl1.Controls.Add(this.tabTransaction);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 493);
            this.tabControl1.TabIndex = 21;
            // 
            // tabFeed
            // 
            this.tabFeed.Controls.Add(this.tableLayoutPanel1);
            this.tabFeed.Controls.Add(this.label1);
            this.tabFeed.Controls.Add(this.tbInterval);
            this.tabFeed.Controls.Add(this.cbStartStop);
            this.tabFeed.Location = new System.Drawing.Point(4, 22);
            this.tabFeed.Name = "tabFeed";
            this.tabFeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabFeed.Size = new System.Drawing.Size(720, 467);
            this.tabFeed.TabIndex = 0;
            this.tabFeed.Text = "Feed";
            this.tabFeed.UseVisualStyleBackColor = true;
            // 
            // tabTransaction
            // 
            this.tabTransaction.Controls.Add(this.btnDeleteSelected);
            this.tabTransaction.Controls.Add(this.btnSell);
            this.tabTransaction.Controls.Add(this.label5);
            this.tabTransaction.Controls.Add(this.tbCash);
            this.tabTransaction.Controls.Add(this.label4);
            this.tabTransaction.Controls.Add(this.tbAssets);
            this.tabTransaction.Controls.Add(this.btnBuy);
            this.tabTransaction.Controls.Add(this.dgInvestments);
            this.tabTransaction.Controls.Add(this.tbPrice);
            this.tabTransaction.Controls.Add(this.label2);
            this.tabTransaction.Controls.Add(this.tbShares);
            this.tabTransaction.Controls.Add(this.label3);
            this.tabTransaction.Location = new System.Drawing.Point(4, 22);
            this.tabTransaction.Name = "tabTransaction";
            this.tabTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransaction.Size = new System.Drawing.Size(720, 467);
            this.tabTransaction.TabIndex = 1;
            this.tabTransaction.Text = "Transaction";
            this.tabTransaction.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(614, 438);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSell
            // 
            this.btnSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSell.Location = new System.Drawing.Point(666, 87);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(45, 23);
            this.btnSell.TabIndex = 3;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(608, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Cash";
            // 
            // tbCash
            // 
            this.tbCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCash.Location = new System.Drawing.Point(611, 149);
            this.tbCash.Name = "tbCash";
            this.tbCash.Size = new System.Drawing.Size(100, 20);
            this.tbCash.TabIndex = 4;
            this.tbCash.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(608, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Assets";
            // 
            // tbAssets
            // 
            this.tbAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAssets.Location = new System.Drawing.Point(611, 188);
            this.tbAssets.Name = "tbAssets";
            this.tbAssets.Size = new System.Drawing.Size(100, 20);
            this.tbAssets.TabIndex = 5;
            this.tbAssets.Text = "0";
            // 
            // btnBuy
            // 
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.Location = new System.Drawing.Point(611, 87);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(45, 23);
            this.btnBuy.TabIndex = 2;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // dgInvestments
            // 
            this.dgInvestments.AllowUserToAddRows = false;
            this.dgInvestments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgInvestments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvestments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvestments.Location = new System.Drawing.Point(6, 6);
            this.dgInvestments.Name = "dgInvestments";
            this.dgInvestments.Size = new System.Drawing.Size(599, 455);
            this.dgInvestments.TabIndex = 21;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(634, 511);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(50, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(690, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bwGetFeed
            // 
            this.bwGetFeed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetFeed_DoWork);
            this.bwGetFeed.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetFeed_RunWorkerCompleted);
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 546);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmData";
            this.Text = "frmData";
            this.Load += new System.EventHandler(this.frmData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabFeed.ResumeLayout(false);
            this.tabFeed.PerformLayout();
            this.tabTransaction.ResumeLayout(false);
            this.tabTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvestments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.CheckBox cbStartStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbShares;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFeed;
        private System.Windows.Forms.TabPage tabTransaction;
        private System.Windows.Forms.DataGridView dgInvestments;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAssets;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCash;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.ComponentModel.BackgroundWorker bwGetFeed;
    }
}