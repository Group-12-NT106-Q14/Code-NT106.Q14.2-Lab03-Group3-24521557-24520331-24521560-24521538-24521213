namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai05Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
        private void InitializeComponent()
        {
            btnServer = new Button();
            btnClient = new Button();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.Location = new Point(16, 18);
            btnServer.Name = "btnServer";
            btnServer.Size = new Size(288, 46);
            btnServer.TabIndex = 0;
            btnServer.Text = "Open TCP Server";
            btnServer.UseVisualStyleBackColor = true;
            btnServer.Click += btnServer_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(16, 74);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(288, 46);
            btnClient.TabIndex = 1;
            btnClient.Text = "Open new TCP Client";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // Bai05Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 140);
            Controls.Add(btnClient);
            Controls.Add(btnServer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Bai05Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 05 - Dashboard";
            ResumeLayout(false);
        }
    }
}
