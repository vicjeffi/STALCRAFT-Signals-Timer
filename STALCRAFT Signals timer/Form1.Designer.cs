namespace STALCRAFT_Signals_timer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseBindItem = new System.Windows.Forms.ToolStripComboBox();
            this.timerTimeItem = new System.Windows.Forms.ToolStripTextBox();
            this.exitAppItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "Hello!";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseBindItem,
            this.timerTimeItem,
            this.toolStripSeparator1,
            this.exitAppItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(194, 106);
            // 
            // chooseBindItem
            // 
            this.chooseBindItem.Name = "chooseBindItem";
            this.chooseBindItem.Size = new System.Drawing.Size(121, 23);
            this.chooseBindItem.Text = "Выбор клавиши";
            // 
            // timerTimeItem
            // 
            this.timerTimeItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timerTimeItem.Name = "timerTimeItem";
            this.timerTimeItem.Size = new System.Drawing.Size(100, 23);
            // 
            // exitAppItem
            // 
            this.exitAppItem.ForeColor = System.Drawing.Color.IndianRed;
            this.exitAppItem.Name = "exitAppItem";
            this.exitAppItem.Size = new System.Drawing.Size(193, 22);
            this.exitAppItem.Text = "Закрыть приложение";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(145, 77);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripComboBox chooseBindItem;
        private System.Windows.Forms.ToolStripMenuItem exitAppItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripTextBox timerTimeItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

