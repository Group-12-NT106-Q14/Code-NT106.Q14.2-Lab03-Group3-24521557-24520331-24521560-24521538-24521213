namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai02Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnListen = new System.Windows.Forms.Button();
            this.listViewCommand = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(520, 20);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(110, 40);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.StartListen);
            // 
            // listViewCommand
            // 
            this.listViewCommand.Font = new System.Drawing.Font("Consolas", 12F);
            this.listViewCommand.Location = new System.Drawing.Point(20, 70);
            this.listViewCommand.Name = "listViewCommand";
            this.listViewCommand.Size = new System.Drawing.Size(610, 380);
            this.listViewCommand.TabIndex = 1;
            this.listViewCommand.View = System.Windows.Forms.View.List;
            // 
            // Bai02Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 470);
            this.Controls.Add(this.listViewCommand);
            this.Controls.Add(this.btnListen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai02Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab03_Bai02 - TCP Telnet Server";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListView listViewCommand;
    }
}
