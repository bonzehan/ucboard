﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucterm
{
    public partial class Form1 : Form
    {
        private UCConnector m_connector;

        public Form1()
        {
            InitializeComponent();

            m_connector = new UCConnector();
            m_connector.ConnectionStateChange += connector_ConnectionStateChange;
            m_connector.NewDisplayData += connector_NewDisplayData;
            m_connector.NewDAQData += connector_NewDAQData;
            m_connector.NewRespData += connector_NewRespData;

            cmdRefreshCOMList_Click(this, null);

            txtBaudrate.Text = "921600";

            return;
        }

        private void cmdRefreshCOMList_Click(object sender, EventArgs e)
        {
            lstCOMPorts.Items.Clear();
            lstCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            lstCOMPorts.SelectedIndex = lstCOMPorts.Items.Count - 1;

            return;
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            if (m_connector.ConnectionState == UCConnector.EnConnState.CONNECTED)
            {
                m_connector.disconnect();
            }
            else
            {
                String portName;
                UInt32 baudRate;

                portName = (String)lstCOMPorts.SelectedItem;

                if (portName == null)
                {
                    System.Windows.Forms.MessageBox.Show("Kein Portname ausgewählt!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }


                if (!UInt32.TryParse(txtBaudrate.Text, out baudRate))
                {
                    System.Windows.Forms.MessageBox.Show("Ungültige Baudrate!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else if (baudRate < 9600)
                {
                    System.Windows.Forms.MessageBox.Show("Baudrate zu klein! (Mindestwert: 9600)", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                m_connector.connect(portName, baudRate);
            }

            return;
        }

        private void lstBaudrates_Click(object sender, EventArgs e)
        {
            String text;

            text = (String)lstBaudrates.SelectedItem;

            if (text != null)
            {
                txtBaudrate.Text = text;
            }

            return;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            String cmd = txtTxCommand.Text;

            rtbCommands.AppendText("\n");
            rtbCommands.AppendText(cmd);
            m_connector.send(cmd);

            return;
        }

        private void connector_NewRespData(object sender, String data)
        {
            MethodInvoker updater;

            updater = delegate
            {
                rtbCommands.AppendText("\n");
                rtbCommands.AppendText(data);
                rtbCommands.SelectionStart = rtbCommands.Text.Length;
                rtbCommands.ScrollToCaret();
            };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(updater);
            }
            else
            {
                updater();
            }

            return;
        }

        private void connector_NewDisplayData(object sender, String data)
        {
            MethodInvoker updater;

            updater = delegate
            {
                rtbDisplay.AppendText("\n");
                rtbDisplay.AppendText(data);
                rtbDisplay.SelectionStart = rtbDisplay.Text.Length;
                rtbDisplay.ScrollToCaret();
            };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(updater);
            }
            else
            {
                updater();
            }

            return;
        }

        private void connector_NewDAQData(object sender, String data)
        {
            MethodInvoker updater;

            updater = delegate
            {
                rtbDAQ.AppendText("\n");
                rtbDAQ.AppendText(data);
                rtbDAQ.SelectionStart = rtbDAQ.Text.Length;
                rtbDAQ.ScrollToCaret();
            };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(updater);
            }
            else
            {
                updater();
            }

            return;
        }


        private void connector_ConnectionStateChange(object sender, EventArgs data)
        {
            MethodInvoker updater;
            UCConnector.EnConnState state = m_connector.ConnectionState;

            String szState;

            switch (state)
            {
                case UCConnector.EnConnState.DISCONNECTED: szState = "Nicht verbunden"; break;
                case UCConnector.EnConnState.CONNECTED: szState = "Verbunden"; break;
                case UCConnector.EnConnState.BROKEN: szState = "Verbindung verloren ..."; break;
                case UCConnector.EnConnState.CONNECTING: szState = "Verbindet ..."; break;
                case UCConnector.EnConnState.DISCONNECTING: szState = "Trennen ..."; break;
                case UCConnector.EnConnState.FAILED_TO_CONNECTED: szState = "Verbinden fehlgeschlagen!"; break;
                case UCConnector.EnConnState.SEARCH: szState = "Suchen ..."; break;
                case UCConnector.EnConnState.TRY_REVIVE: szState = "Wiederverbinden ..."; break;
                default: szState = ""; break;
            }

            updater = delegate
            {
                txtConnectionState.Text = szState;

                if (state == UCConnector.EnConnState.CONNECTED)
                {
                    grpConnection.Enabled = true;

                    lstCOMPorts.Enabled = false;
                    lstBaudrates.Enabled = false;
                    txtBaudrate.Enabled = false;
                    cmdRefreshCOMList.Enabled = false;

                    cmdConnect.Text = "Trennen";
                }
                else if ( (state == UCConnector.EnConnState.DISCONNECTED) || (state == UCConnector.EnConnState.FAILED_TO_CONNECTED) )
                {
                    grpConnection.Enabled = true;

                    lstCOMPorts.Enabled = true;
                    lstBaudrates.Enabled = true;
                    txtBaudrate.Enabled = true;
                    cmdRefreshCOMList.Enabled = true;

                    cmdConnect.Text = "Verbinden";
                }
                else
                {
                    grpConnection.Enabled = false;
                }
            };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(updater);
            }
            else
            {
                updater();
            }

            return;
        }


        private void txtTxCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSend_Click(this, null);
            }

            return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_connector.disconnect();
        }
    }
}