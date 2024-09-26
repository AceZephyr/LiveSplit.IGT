namespace LiveSplit.UI.Components {
    partial class IGTSettings {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.topLevelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputInitialIGT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputDisplayName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputFPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDisplayTwoRows = new System.Windows.Forms.CheckBox();
            this.topLevelLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLevelLayoutPanel
            // 
            this.topLevelLayoutPanel.AutoSize = true;
            this.topLevelLayoutPanel.ColumnCount = 1;
            this.topLevelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLevelLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.topLevelLayoutPanel.Controls.Add(this.checkBoxDisplayTwoRows, 0, 1);
            this.topLevelLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topLevelLayoutPanel.Name = "topLevelLayoutPanel";
            this.topLevelLayoutPanel.RowCount = 2;
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelLayoutPanel.Size = new System.Drawing.Size(234, 212);
            this.topLevelLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.inputInitialIGT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputDisplayName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputFPS, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputInitialIGT
            // 
            this.inputInitialIGT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputInitialIGT.Location = new System.Drawing.Point(117, 77);
            this.inputInitialIGT.Name = "inputInitialIGT";
            this.inputInitialIGT.Size = new System.Drawing.Size(108, 20);
            this.inputInitialIGT.TabIndex = 5;
            this.inputInitialIGT.Text = "0";
            this.inputInitialIGT.TextChanged += new System.EventHandler(this.inputInitialIGT_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Initial IGT (seconds)";
            // 
            // inputDisplayName
            // 
            this.inputDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDisplayName.Location = new System.Drawing.Point(117, 45);
            this.inputDisplayName.Name = "inputDisplayName";
            this.inputDisplayName.Size = new System.Drawing.Size(108, 20);
            this.inputDisplayName.TabIndex = 3;
            this.inputDisplayName.Text = "In-Game Time";
            this.inputDisplayName.TextChanged += new System.EventHandler(this.inputDisplayName_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display Name";
            // 
            // inputFPS
            // 
            this.inputFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFPS.Location = new System.Drawing.Point(117, 8);
            this.inputFPS.Name = "inputFPS";
            this.inputFPS.Size = new System.Drawing.Size(108, 20);
            this.inputFPS.TabIndex = 0;
            this.inputFPS.Text = "59.81";
            this.inputFPS.TextChanged += new System.EventHandler(this.inputFPS_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPS";
            // 
            // checkBoxDisplayTwoRows
            // 
            this.checkBoxDisplayTwoRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDisplayTwoRows.AutoSize = true;
            this.checkBoxDisplayTwoRows.Location = new System.Drawing.Point(3, 150);
            this.checkBoxDisplayTwoRows.Name = "checkBoxDisplayTwoRows";
            this.checkBoxDisplayTwoRows.Size = new System.Drawing.Size(228, 17);
            this.checkBoxDisplayTwoRows.TabIndex = 1;
            this.checkBoxDisplayTwoRows.Text = "Display Two Rows";
            this.checkBoxDisplayTwoRows.UseVisualStyleBackColor = true;
            // 
            // IGTSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.topLevelLayoutPanel);
            this.Name = "IGTSettings";
            this.Size = new System.Drawing.Size(237, 215);
            this.Load += new System.EventHandler(this.IGTSettings_Load);
            this.topLevelLayoutPanel.ResumeLayout(false);
            this.topLevelLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topLevelLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox inputFPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDisplayTwoRows;
        private System.Windows.Forms.TextBox inputDisplayName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputInitialIGT;
        private System.Windows.Forms.Label label3;
    }
}
