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

        private StringBuilder m_sbDAQData;
        private StringBuilder m_sbDisplayData;
        private StringBuilder m_sbCmdRespData;

        private System.Timers.Timer m_updateTimer;

        private Boolean m_bClearText = false;

        public Form1()
        {
            InitializeComponent();

            Text = "ucterm " + VersionInfo.VersionString;

            m_sbDAQData = new StringBuilder(10000);
            m_sbDisplayData = new StringBuilder(10000);
            m_sbCmdRespData = new StringBuilder(10000);

            m_connector = new UCConnector();
            m_connector.ConnectionStateChange += connector_ConnectionStateChange;
            m_connector.NewDisplayData += connector_NewDisplayData;
            m_connector.NewDAQData += connector_NewDAQData;
            m_connector.NewRespData += connector_NewRespData;

            cmdRefreshCOMList_Click(this, null);

            txtBaudrate.Text = "921600";
            connector_ConnectionStateChange(this, null);

            m_updateTimer = new System.Timers.Timer();
            m_updateTimer.Elapsed += new System.Timers.ElapsedEventHandler(updatetimer_Elapsed);
            m_updateTimer.AutoReset = false;
            m_updateTimer.Interval = 200;
            m_updateTimer.Start();

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

            System.Threading.Monitor.Enter(m_sbCmdRespData);

            m_sbCmdRespData.Append("\n");
            m_sbCmdRespData.Append(cmd);

            System.Threading.Monitor.Exit(m_sbCmdRespData);

            m_connector.send(cmd);

            return;
        }

        private void connector_NewRespData(object sender, String data)
        {
            System.Threading.Monitor.Enter(m_sbCmdRespData);

            m_sbCmdRespData.Append("\n");
            m_sbCmdRespData.Append(data);

            System.Threading.Monitor.Exit(m_sbCmdRespData);

            return;
        }

        private void connector_NewDisplayData(object sender, String data)
        {
            System.Threading.Monitor.Enter(m_sbDisplayData);

            m_sbDisplayData.Append("\n");
            m_sbDisplayData.Append(data);

            System.Threading.Monitor.Exit(m_sbDisplayData);

            return;
        }

        private void connector_NewDAQData(object sender, String data)
        {
            System.Threading.Monitor.Enter(m_sbDAQData);

            m_sbDAQData.Append("\n");
            m_sbDAQData.Append(data);

            System.Threading.Monitor.Exit(m_sbDAQData);

            return;
        }


        private void updatetimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            String szCmdRespData = null;
            String szDisplayData = null;
            String szDAQData = null;


            System.Threading.Monitor.Enter(m_sbCmdRespData);

            if (m_sbCmdRespData.Length > 0)
            {
                szCmdRespData = m_sbCmdRespData.ToString();
                m_sbCmdRespData.Clear();
            }

            System.Threading.Monitor.Exit(m_sbCmdRespData);


            System.Threading.Monitor.Enter(m_sbDisplayData);

            if (m_sbDisplayData.Length > 0)
            {
                szDisplayData = m_sbDisplayData.ToString();
                m_sbDisplayData.Clear();
            }

            System.Threading.Monitor.Exit(m_sbDisplayData);


            System.Threading.Monitor.Enter(m_sbDAQData);

            if (m_sbDAQData.Length > 0)
            {
                szDAQData = m_sbDAQData.ToString();
                m_sbDAQData.Clear();
            }

            System.Threading.Monitor.Exit(m_sbDAQData);



            MethodInvoker updater;

            updater = delegate
            {
                if (m_bClearText)
                {
                    rtbCommands.Clear();
                    rtbDisplay.Clear();
                    rtbDAQ.Clear();

                    m_bClearText = false;
                }
                else
                {
                    if (szCmdRespData != null)
                    {
                        if (rtbCommands.TextLength + szCmdRespData.Length > 10 * 1024 * 1024)
                        {
                            rtbCommands.Text = rtbCommands.Text.Remove(0, 5 * 1024 * 1024) + szCmdRespData;
                        }
                        else
                        {
                            rtbCommands.AppendText(szCmdRespData);
                        }

                        rtbCommands.SelectionStart = rtbCommands.Text.Length;
                        rtbCommands.ScrollToCaret();
                    }

                    if (szDisplayData != null)
                    {
                        if (rtbDisplay.TextLength + szDisplayData.Length > 10 * 1024 * 1024)
                        {
                            rtbDisplay.Text = rtbDisplay.Text.Remove(0, 5 * 1024 * 1024) + szDisplayData;
                        }
                        else
                        {
                            rtbDisplay.AppendText(szDisplayData);
                        }

                        rtbDisplay.SelectionStart = rtbDisplay.Text.Length;
                        rtbDisplay.ScrollToCaret();
                    }

                    if (szDAQData != null)
                    {
                        if (rtbDAQ.TextLength + szDAQData.Length > 10 * 1024 * 1024)
                        {
                            rtbDAQ.Text = rtbDAQ.Text.Remove(0, 5 * 1024 * 1024) + szDAQData;
                        }
                        else
                        {
                            rtbDAQ.AppendText(szDAQData);
                        }

                        rtbDAQ.SelectionStart = rtbDAQ.Text.Length;
                        rtbDAQ.ScrollToCaret();
                    }
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

            m_updateTimer.Start();

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

                    cmdSend.Enabled = true;
                    txtTxCommand.Enabled = true;

                    cmdConnect.Text = "Trennen";
                }
                else if ( (state == UCConnector.EnConnState.DISCONNECTED) || (state == UCConnector.EnConnState.FAILED_TO_CONNECTED) )
                {
                    grpConnection.Enabled = true;

                    lstCOMPorts.Enabled = true;
                    lstBaudrates.Enabled = true;
                    txtBaudrate.Enabled = true;
                    cmdRefreshCOMList.Enabled = true;

                    cmdSend.Enabled = false;
                    txtTxCommand.Enabled = false;

                    cmdConnect.Text = "Verbinden";
                }
                else
                {
                    grpConnection.Enabled = false;

                    cmdSend.Enabled = false;
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
            m_updateTimer.Enabled = false;

            return;
        }

        private void cmdClearText_Click(object sender, EventArgs e)
        {
            m_bClearText = true;

            return;
        }
    }
}
