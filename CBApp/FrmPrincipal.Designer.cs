namespace CBApp
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.tbDecimal = new System.Windows.Forms.TextBox();
            this.lblDecimal = new System.Windows.Forms.Label();
            this.lbHex = new System.Windows.Forms.Label();
            this.tbHex = new System.Windows.Forms.TextBox();
            this.lblOctal = new System.Windows.Forms.Label();
            this.tbOctal = new System.Windows.Forms.TextBox();
            this.lblBinario = new System.Windows.Forms.Label();
            this.tbBinario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbDecimal
            // 
            resources.ApplyResources(this.tbDecimal, "tbDecimal");
            this.tbDecimal.Name = "tbDecimal";
            this.tbDecimal.TextChanged += new System.EventHandler(this.tbDecimal_TextChanged);
            // 
            // lblDecimal
            // 
            resources.ApplyResources(this.lblDecimal, "lblDecimal");
            this.lblDecimal.Name = "lblDecimal";
            // 
            // lbHex
            // 
            resources.ApplyResources(this.lbHex, "lbHex");
            this.lbHex.Name = "lbHex";
            // 
            // tbHex
            // 
            resources.ApplyResources(this.tbHex, "tbHex");
            this.tbHex.Name = "tbHex";
            this.tbHex.TextChanged += new System.EventHandler(this.tbHex_TextChanged);
            // 
            // lblOctal
            // 
            resources.ApplyResources(this.lblOctal, "lblOctal");
            this.lblOctal.Name = "lblOctal";
            // 
            // tbOctal
            // 
            resources.ApplyResources(this.tbOctal, "tbOctal");
            this.tbOctal.Name = "tbOctal";
            this.tbOctal.TextChanged += new System.EventHandler(this.tbOctal_TextChanged);
            // 
            // lblBinario
            // 
            resources.ApplyResources(this.lblBinario, "lblBinario");
            this.lblBinario.Name = "lblBinario";
            // 
            // tbBinario
            // 
            resources.ApplyResources(this.tbBinario, "tbBinario");
            this.tbBinario.Name = "tbBinario";
            this.tbBinario.TextChanged += new System.EventHandler(this.tbBinario_TextChanged);
            // 
            // FrmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBinario);
            this.Controls.Add(this.tbBinario);
            this.Controls.Add(this.lblOctal);
            this.Controls.Add(this.tbOctal);
            this.Controls.Add(this.lbHex);
            this.Controls.Add(this.tbHex);
            this.Controls.Add(this.lblDecimal);
            this.Controls.Add(this.tbDecimal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbDecimal;
        private System.Windows.Forms.Label lblDecimal;
        private System.Windows.Forms.Label lbHex;
        private System.Windows.Forms.TextBox tbHex;
        private System.Windows.Forms.Label lblOctal;
        private System.Windows.Forms.TextBox tbOctal;
        private System.Windows.Forms.Label lblBinario;
        private System.Windows.Forms.TextBox tbBinario;
    }
}

