namespace DweepConstcoh
{
    partial class frmMain
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
            this.tmrGameProcesses = new System.Windows.Forms.Timer(this.components);
            this.pnlGameSpace = new System.Windows.Forms.Panel();
            this.pnlToolset = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tmrGameProcesses
            // 
            this.tmrGameProcesses.Enabled = true;
            this.tmrGameProcesses.Tick += new System.EventHandler(this.tmrGameProcesses_Tick);
            // 
            // pnlGameSpace
            // 
            this.pnlGameSpace.Location = new System.Drawing.Point(12, 12);
            this.pnlGameSpace.Name = "pnlGameSpace";
            this.pnlGameSpace.Size = new System.Drawing.Size(776, 496);
            this.pnlGameSpace.TabIndex = 0;
            this.pnlGameSpace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGameSpace_MouseDown);
            // 
            // pnlToolset
            // 
            this.pnlToolset.Location = new System.Drawing.Point(12, 514);
            this.pnlToolset.Name = "pnlToolset";
            this.pnlToolset.Size = new System.Drawing.Size(462, 54);
            this.pnlToolset.TabIndex = 1;
            this.pnlToolset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlToolset_MouseDown);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 589);
            this.Controls.Add(this.pnlToolset);
            this.Controls.Add(this.pnlGameSpace);
            this.Name = "frmMain";
            this.Text = "Dweep Constcoh";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameProcesses;
        private System.Windows.Forms.Panel pnlGameSpace;
        private System.Windows.Forms.Panel pnlToolset;
    }
}

