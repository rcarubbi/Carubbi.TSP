namespace Carubbi.TSP.UI
{
    partial class frmTSP
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
            this.pnlMap = new System.Windows.Forms.Panel();
            this.pnlChromossomeList = new System.Windows.Forms.Panel();
            this.lstCromossomes = new System.Windows.Forms.ListBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnNextGen = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblCostValue = new System.Windows.Forms.Label();
            this.lblGenerationValue = new System.Windows.Forms.Label();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.pnlChromossomeList.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMap
            // 
            this.pnlMap.Location = new System.Drawing.Point(12, 12);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(963, 610);
            this.pnlMap.TabIndex = 0;
            this.pnlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMap_Paint);
            // 
            // pnlChromossomeList
            // 
            this.pnlChromossomeList.Controls.Add(this.lstCromossomes);
            this.pnlChromossomeList.Location = new System.Drawing.Point(981, 12);
            this.pnlChromossomeList.Name = "pnlChromossomeList";
            this.pnlChromossomeList.Size = new System.Drawing.Size(194, 610);
            this.pnlChromossomeList.TabIndex = 1;
            // 
            // lstCromossomes
            // 
            this.lstCromossomes.FormattingEnabled = true;
            this.lstCromossomes.Location = new System.Drawing.Point(5, 3);
            this.lstCromossomes.Name = "lstCromossomes";
            this.lstCromossomes.Size = new System.Drawing.Size(186, 602);
            this.lstCromossomes.TabIndex = 0;
            this.lstCromossomes.SelectedIndexChanged += new System.EventHandler(this.lstCromossomes_SelectedIndexChanged);
            this.lstCromossomes.SelectedValueChanged += new System.EventHandler(this.lstCromossomes_SelectedValueChanged);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnNextGen);
            this.pnlButtons.Controls.Add(this.btnInitialize);
            this.pnlButtons.Location = new System.Drawing.Point(981, 628);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(194, 56);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnNextGen
            // 
            this.btnNextGen.Location = new System.Drawing.Point(75, 3);
            this.btnNextGen.Name = "btnNextGen";
            this.btnNextGen.Size = new System.Drawing.Size(66, 46);
            this.btnNextGen.TabIndex = 1;
            this.btnNextGen.Text = "Next Gen";
            this.btnNextGen.UseVisualStyleBackColor = true;
            this.btnNextGen.Click += new System.EventHandler(this.btnNextGen_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(3, 3);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(66, 46);
            this.btnInitialize.TabIndex = 0;
            this.btnInitialize.Text = "Init";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(852, 633);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(58, 13);
            this.lblCost.TabIndex = 3;
            this.lblCost.Text = "Total Cost:";
            // 
            // lblCostValue
            // 
            this.lblCostValue.BackColor = System.Drawing.Color.White;
            this.lblCostValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCostValue.Location = new System.Drawing.Point(915, 628);
            this.lblCostValue.Name = "lblCostValue";
            this.lblCostValue.Size = new System.Drawing.Size(59, 25);
            this.lblCostValue.TabIndex = 4;
            // 
            // lblGenerationValue
            // 
            this.lblGenerationValue.BackColor = System.Drawing.Color.White;
            this.lblGenerationValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGenerationValue.Location = new System.Drawing.Point(787, 628);
            this.lblGenerationValue.Name = "lblGenerationValue";
            this.lblGenerationValue.Size = new System.Drawing.Size(59, 25);
            this.lblGenerationValue.TabIndex = 6;
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(724, 633);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(62, 13);
            this.lblGeneration.TabIndex = 5;
            this.lblGeneration.Text = "Generation:";
            // 
            // frmTSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 700);
            this.Controls.Add(this.lblGenerationValue);
            this.Controls.Add(this.lblGeneration);
            this.Controls.Add(this.lblCostValue);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlChromossomeList);
            this.Controls.Add(this.pnlMap);
            this.Name = "frmTSP";
            this.Text = "Form1";
            this.pnlChromossomeList.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Panel pnlChromossomeList;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnNextGen;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.ListBox lstCromossomes;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblCostValue;
        private System.Windows.Forms.Label lblGenerationValue;
        private System.Windows.Forms.Label lblGeneration;
    }
}

