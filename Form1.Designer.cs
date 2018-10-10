namespace MLP_hw2
{
    partial class MLP
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbFileName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.hiddenN = new System.Windows.Forms.Label();
            this.txtHidden = new System.Windows.Forms.TextBox();
            this.btnSetHidden = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbFileName
            // 
            this.cbFileName.FormattingEnabled = true;
            this.cbFileName.Location = new System.Drawing.Point(75, 12);
            this.cbFileName.Name = "cbFileName";
            this.cbFileName.Size = new System.Drawing.Size(169, 20);
            this.cbFileName.TabIndex = 16;
            this.cbFileName.SelectedValueChanged += new System.EventHandler(this.cbFileName_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "檔案名稱:";
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Location = new System.Drawing.Point(30, 81);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(200, 185);
            this.pnlCanvas.TabIndex = 17;
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
            // 
            // hiddenN
            // 
            this.hiddenN.AutoSize = true;
            this.hiddenN.Location = new System.Drawing.Point(13, 41);
            this.hiddenN.Name = "hiddenN";
            this.hiddenN.Size = new System.Drawing.Size(112, 12);
            this.hiddenN.TabIndex = 18;
            this.hiddenN.Text = "隱藏層神經元(~100):";
            // 
            // txtHidden
            // 
            this.txtHidden.Location = new System.Drawing.Point(127, 38);
            this.txtHidden.Name = "txtHidden";
            this.txtHidden.Size = new System.Drawing.Size(52, 22);
            this.txtHidden.TabIndex = 19;
            this.txtHidden.Text = "2";
            this.txtHidden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSetHidden
            // 
            this.btnSetHidden.Location = new System.Drawing.Point(186, 39);
            this.btnSetHidden.Name = "btnSetHidden";
            this.btnSetHidden.Size = new System.Drawing.Size(58, 23);
            this.btnSetHidden.TabIndex = 20;
            this.btnSetHidden.Text = "set";
            this.btnSetHidden.UseVisualStyleBackColor = true;
            this.btnSetHidden.Click += new System.EventHandler(this.btnSetHidden_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(221, 272);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(58, 23);
            this.btnTrain.TabIndex = 21;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // MLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 307);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnSetHidden);
            this.Controls.Add(this.txtHidden);
            this.Controls.Add(this.hiddenN);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.cbFileName);
            this.Controls.Add(this.label1);
            this.Name = "MLP";
            this.Text = "MLP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Label hiddenN;
        private System.Windows.Forms.TextBox txtHidden;
        private System.Windows.Forms.Button btnSetHidden;
        private System.Windows.Forms.Button btnTrain;
    }
}

