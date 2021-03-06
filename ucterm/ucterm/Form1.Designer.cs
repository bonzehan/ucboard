﻿namespace ucterm
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstCOMPorts = new System.Windows.Forms.ListBox();
            this.cmdRefreshCOMList = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaudrate = new System.Windows.Forms.TextBox();
            this.lstBaudrates = new System.Windows.Forms.ListBox();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.txtConnectionState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTxCommand = new System.Windows.Forms.TextBox();
            this.rtbCommands = new System.Windows.Forms.RichTextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.rtbDAQ = new System.Windows.Forms.RichTextBox();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.grpDAQ = new System.Windows.Forms.GroupBox();
            this.grpCommands = new System.Windows.Forms.GroupBox();
            this.cmdClearText = new System.Windows.Forms.Button();
            this.grpConnection.SuspendLayout();
            this.grpDisplay.SuspendLayout();
            this.grpDAQ.SuspendLayout();
            this.grpCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCOMPorts
            // 
            this.lstCOMPorts.FormattingEnabled = true;
            this.lstCOMPorts.Location = new System.Drawing.Point(6, 32);
            this.lstCOMPorts.Name = "lstCOMPorts";
            this.lstCOMPorts.Size = new System.Drawing.Size(127, 108);
            this.lstCOMPorts.TabIndex = 0;
            // 
            // cmdRefreshCOMList
            // 
            this.cmdRefreshCOMList.Location = new System.Drawing.Point(6, 146);
            this.cmdRefreshCOMList.Name = "cmdRefreshCOMList";
            this.cmdRefreshCOMList.Size = new System.Drawing.Size(127, 23);
            this.cmdRefreshCOMList.TabIndex = 1;
            this.cmdRefreshCOMList.Text = "Aktualisieren";
            this.cmdRefreshCOMList.UseVisualStyleBackColor = true;
            this.cmdRefreshCOMList.Click += new System.EventHandler(this.cmdRefreshCOMList_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(245, 146);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(95, 23);
            this.cmdConnect.TabIndex = 2;
            this.cmdConnect.Text = "Verbinden";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Baudrate";
            // 
            // txtBaudrate
            // 
            this.txtBaudrate.Location = new System.Drawing.Point(139, 32);
            this.txtBaudrate.Name = "txtBaudrate";
            this.txtBaudrate.Size = new System.Drawing.Size(100, 20);
            this.txtBaudrate.TabIndex = 4;
            // 
            // lstBaudrates
            // 
            this.lstBaudrates.FormattingEnabled = true;
            this.lstBaudrates.Items.AddRange(new object[] {
            "9600",
            "57600",
            "115200",
            "230400",
            "921600"});
            this.lstBaudrates.Location = new System.Drawing.Point(139, 61);
            this.lstBaudrates.Name = "lstBaudrates";
            this.lstBaudrates.Size = new System.Drawing.Size(100, 108);
            this.lstBaudrates.TabIndex = 5;
            this.lstBaudrates.Click += new System.EventHandler(this.lstBaudrates_Click);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.txtConnectionState);
            this.grpConnection.Controls.Add(this.label2);
            this.grpConnection.Controls.Add(this.cmdConnect);
            this.grpConnection.Controls.Add(this.txtBaudrate);
            this.grpConnection.Controls.Add(this.lstCOMPorts);
            this.grpConnection.Controls.Add(this.label1);
            this.grpConnection.Controls.Add(this.lstBaudrates);
            this.grpConnection.Controls.Add(this.cmdRefreshCOMList);
            this.grpConnection.Location = new System.Drawing.Point(12, 12);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(350, 178);
            this.grpConnection.TabIndex = 6;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Verbindung";
            // 
            // txtConnectionState
            // 
            this.txtConnectionState.Location = new System.Drawing.Point(245, 120);
            this.txtConnectionState.Name = "txtConnectionState";
            this.txtConnectionState.ReadOnly = true;
            this.txtConnectionState.Size = new System.Drawing.Size(95, 20);
            this.txtConnectionState.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // txtTxCommand
            // 
            this.txtTxCommand.Location = new System.Drawing.Point(6, 19);
            this.txtTxCommand.Name = "txtTxCommand";
            this.txtTxCommand.Size = new System.Drawing.Size(263, 20);
            this.txtTxCommand.TabIndex = 8;
            this.txtTxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTxCommand_KeyDown);
            // 
            // rtbCommands
            // 
            this.rtbCommands.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCommands.Location = new System.Drawing.Point(6, 46);
            this.rtbCommands.Name = "rtbCommands";
            this.rtbCommands.ReadOnly = true;
            this.rtbCommands.Size = new System.Drawing.Size(338, 478);
            this.rtbCommands.TabIndex = 9;
            this.rtbCommands.Text = "";
            this.rtbCommands.WordWrap = false;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(275, 17);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(69, 23);
            this.cmdSend.TabIndex = 10;
            this.cmdSend.Text = "Senden";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbDisplay.Location = new System.Drawing.Point(6, 19);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(338, 321);
            this.rtbDisplay.TabIndex = 11;
            this.rtbDisplay.Text = "";
            this.rtbDisplay.WordWrap = false;
            // 
            // rtbDAQ
            // 
            this.rtbDAQ.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbDAQ.Location = new System.Drawing.Point(6, 19);
            this.rtbDAQ.Name = "rtbDAQ";
            this.rtbDAQ.ReadOnly = true;
            this.rtbDAQ.Size = new System.Drawing.Size(338, 505);
            this.rtbDAQ.TabIndex = 12;
            this.rtbDAQ.Text = "";
            this.rtbDAQ.WordWrap = false;
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.rtbDisplay);
            this.grpDisplay.Location = new System.Drawing.Point(12, 196);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(350, 346);
            this.grpDisplay.TabIndex = 13;
            this.grpDisplay.TabStop = false;
            this.grpDisplay.Text = "Display";
            // 
            // grpDAQ
            // 
            this.grpDAQ.Controls.Add(this.rtbDAQ);
            this.grpDAQ.Location = new System.Drawing.Point(724, 12);
            this.grpDAQ.Name = "grpDAQ";
            this.grpDAQ.Size = new System.Drawing.Size(350, 530);
            this.grpDAQ.TabIndex = 14;
            this.grpDAQ.TabStop = false;
            this.grpDAQ.Text = "DAQ";
            // 
            // grpCommands
            // 
            this.grpCommands.Controls.Add(this.txtTxCommand);
            this.grpCommands.Controls.Add(this.cmdSend);
            this.grpCommands.Controls.Add(this.rtbCommands);
            this.grpCommands.Location = new System.Drawing.Point(368, 12);
            this.grpCommands.Name = "grpCommands";
            this.grpCommands.Size = new System.Drawing.Size(350, 530);
            this.grpCommands.TabIndex = 14;
            this.grpCommands.TabStop = false;
            this.grpCommands.Text = "Befehle/Antworten";
            // 
            // cmdClearText
            // 
            this.cmdClearText.Location = new System.Drawing.Point(999, 548);
            this.cmdClearText.Name = "cmdClearText";
            this.cmdClearText.Size = new System.Drawing.Size(75, 23);
            this.cmdClearText.TabIndex = 15;
            this.cmdClearText.Text = "Löschen";
            this.cmdClearText.UseVisualStyleBackColor = true;
            this.cmdClearText.Click += new System.EventHandler(this.cmdClearText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 581);
            this.Controls.Add(this.cmdClearText);
            this.Controls.Add(this.grpCommands);
            this.Controls.Add(this.grpDAQ);
            this.Controls.Add(this.grpDisplay);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ucterm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpDisplay.ResumeLayout(false);
            this.grpDAQ.ResumeLayout(false);
            this.grpCommands.ResumeLayout(false);
            this.grpCommands.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCOMPorts;
        private System.Windows.Forms.Button cmdRefreshCOMList;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaudrate;
        private System.Windows.Forms.ListBox lstBaudrates;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTxCommand;
        private System.Windows.Forms.RichTextBox rtbCommands;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.RichTextBox rtbDAQ;
        private System.Windows.Forms.TextBox txtConnectionState;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.GroupBox grpDAQ;
        private System.Windows.Forms.GroupBox grpCommands;
        private System.Windows.Forms.Button cmdClearText;
    }
}

