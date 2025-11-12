namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai06Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Button btnOpenClient;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnOpenServer = new Button();
            btnOpenClient = new Button();
            SuspendLayout();
            // 
            // btnOpenServer
            // 
            btnOpenServer.Font = new Font("Segoe UI", 12F);
            btnOpenServer.Location = new Point(23, 20);
            btnOpenServer.Name = "btnOpenServer";
            btnOpenServer.Size = new Size(250, 45);
            btnOpenServer.TabIndex = 0;
            btnOpenServer.Text = "Open TCP Server";
            btnOpenServer.UseVisualStyleBackColor = true;
            btnOpenServer.Click += btnOpenServer_Click;
            // 
            // btnOpenClient
            // 
            btnOpenClient.Font = new Font("Segoe UI", 12F);
            btnOpenClient.Location = new Point(23, 80);
            btnOpenClient.Name = "btnOpenClient";
            btnOpenClient.Size = new Size(250, 45);
            btnOpenClient.TabIndex = 1;
            btnOpenClient.Text = "Open new TCP Client";
            btnOpenClient.UseVisualStyleBackColor = true;
            btnOpenClient.Click += btnOpenClient_Click;
            // 
            // Bai06Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 150);
            Controls.Add(btnOpenClient);
            Controls.Add(btnOpenServer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Bai06Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 06 - Dashboard";
            ResumeLayout(false);
        }
    }
}
