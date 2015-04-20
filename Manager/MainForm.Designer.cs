namespace Manager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.iOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.iAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.iEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.iRemoteDesktop = new System.Windows.Forms.ToolStripMenuItem();
            this.iRemoteProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.iRemoteService = new System.Windows.Forms.ToolStripMenuItem();
            this.iRemoteWMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mConfig,
            this.mFunc});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(204, 25);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip";
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iOpen});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(58, 21);
            this.mFile.Text = "文件(&F)";
            // 
            // iOpen
            // 
            this.iOpen.Name = "iOpen";
            this.iOpen.Size = new System.Drawing.Size(118, 22);
            this.iOpen.Text = "打开(&O)";
            this.iOpen.Click += new System.EventHandler(this.iOpen_Click);
            // 
            // mConfig
            // 
            this.mConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iAdd,
            this.iEdit});
            this.mConfig.Name = "mConfig";
            this.mConfig.Size = new System.Drawing.Size(59, 21);
            this.mConfig.Text = "配置(&S)";
            // 
            // iAdd
            // 
            this.iAdd.Name = "iAdd";
            this.iAdd.Size = new System.Drawing.Size(116, 22);
            this.iAdd.Text = "添加(&A)";
            this.iAdd.Click += new System.EventHandler(this.remoteNew_Click);
            // 
            // iEdit
            // 
            this.iEdit.Name = "iEdit";
            this.iEdit.Size = new System.Drawing.Size(116, 22);
            this.iEdit.Text = "编辑(&E)";
            // 
            // mFunc
            // 
            this.mFunc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iRemoteDesktop,
            this.iRemoteProcess,
            this.iRemoteService,
            this.iRemoteWMI});
            this.mFunc.Name = "mFunc";
            this.mFunc.Size = new System.Drawing.Size(64, 21);
            this.mFunc.Text = "功能(&M)";
            // 
            // iRemoteDesktop
            // 
            this.iRemoteDesktop.Name = "iRemoteDesktop";
            this.iRemoteDesktop.Size = new System.Drawing.Size(116, 22);
            this.iRemoteDesktop.Text = "远程(&R)";
            // 
            // iRemoteProcess
            // 
            this.iRemoteProcess.Name = "iRemoteProcess";
            this.iRemoteProcess.Size = new System.Drawing.Size(116, 22);
            this.iRemoteProcess.Text = "进程(&P)";
            // 
            // iRemoteService
            // 
            this.iRemoteService.Name = "iRemoteService";
            this.iRemoteService.Size = new System.Drawing.Size(116, 22);
            this.iRemoteService.Text = "服务(&S)";
            // 
            // iRemoteWMI
            // 
            this.iRemoteWMI.Name = "iRemoteWMI";
            this.iRemoteWMI.Size = new System.Drawing.Size(116, 22);
            this.iRemoteWMI.Text = "WMI";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 38);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem mConfig;
        private System.Windows.Forms.ToolStripMenuItem mFunc;
        private System.Windows.Forms.ToolStripMenuItem iRemoteDesktop;
        private System.Windows.Forms.ToolStripMenuItem iRemoteProcess;
        private System.Windows.Forms.ToolStripMenuItem iRemoteService;
        private System.Windows.Forms.ToolStripMenuItem iRemoteWMI;
        private System.Windows.Forms.ToolStripMenuItem iAdd;
        private System.Windows.Forms.ToolStripMenuItem iEdit;
        private System.Windows.Forms.ToolStripMenuItem iOpen;
    }
}

