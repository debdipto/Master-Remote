using AmaranthineServer;
using Newtonsoft.Json;
using OculusClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvergreenMasterRemote
{
    public partial class frm_Main : Form
    {
        TcpClient clientSocket = null;
        PollingThread pollingThread = null;
        Thread polling = null;
        static object locker = new object();
        String oldClientList = String.Empty;
        MultiChat multiChatObject = null;
        Controller controllerObject = null;
        PiClient piObject = null;
        String c = Char.ConvertFromUtf32(30);
        public frm_Main()
        {
            InitializeComponent();

            lstb_UserList.Sorted = true;

            if (EvergreenMasterRemote.Properties.Settings.Default.AutoConnect && EvergreenMasterRemote.Properties.Settings.Default.Username != "" && EvergreenMasterRemote.Properties.Settings.Default.Password != "")
            {
                setupConnection();
            }
        }

        public void setupConnection()
        {
            if (clientSocket != null)
                disconnect();

            displayLine("Client started");

            try
            {
                clientSocket = new TcpClient();
                displayLine("Checking IP address:" + EvergreenMasterRemote.Properties.Settings.Default.ServerIP);
                clientSocket.Connect(EvergreenMasterRemote.Properties.Settings.Default.ServerIP, 6669);
                displayLine("Server Connected");

                String status = writeToServer(EvergreenMasterRemote.Properties.Settings.Default.Username + ":" + EvergreenMasterRemote.Properties.Settings.Default.Password+"$$");
                //String status = readFromServer();
                displayLine(status);
                if (status == "OculusMessage:Authentication Failed$$")
                {
                    disconnect();
                    displayLine("Authentication Failed",true);
                    return;
                }                

                //getListOfClients();                

                pollingThread = new PollingThread(this, EvergreenMasterRemote.Properties.Settings.Default.Username, clientSocket);
                polling = new Thread(new ThreadStart(pollingThread.poll));
                polling.Start();
                this.Text = EvergreenMasterRemote.Properties.Settings.Default.Username;
                return;
            }
            catch (Exception)
            {
                displayLine("No server found in that IP");
            }

            displayLine("Server Not Found");
        }

        public void fetchListOfClients()
        {
            String listOfUsers = writeToServer("clientlist");

            getListOfClients(listOfUsers);
        }
        public void getListOfClients(String listOfUsers)
        {
            int oldselection = 0;
            String selectedUsername = String.Empty;
            if (lstb_UserList.Items.Count > 0)
            {
                oldselection = lstb_UserList.SelectedIndex;
                selectedUsername = lstb_UserList.SelectedItem.ToString();
            }
            if (oldClientList != listOfUsers)
            {
                String[] clientList = listOfUsers.Split(':');
                lstb_UserList.Items.Clear();
                foreach (String client in clientList)
                {
                    if (client.Trim() != String.Empty && client.Trim() != EvergreenMasterRemote.Properties.Settings.Default.Username)
                        lstb_UserList.Items.Add(client);
                }
                if (lstb_UserList.Items.Contains(selectedUsername))
                {
                    lstb_UserList.SelectedIndex = lstb_UserList.Items.IndexOf(selectedUsername);
                }
                else
                {
                    if(lstb_UserList.Items.Count>0)
                        lstb_UserList.SelectedIndex = 0;
                }
                oldClientList = listOfUsers;

                loadSelectedUserControl();
            }
        }

        private void loadSelectedUserControl()
        {
            if (lstb_UserList.Items.Count > 0)
            {
                String deviceType = writeToServer("deviceType:" + lstb_UserList.SelectedItem.ToString());

                loadUserControl(deviceType);
            }
        }

        public void loadUserControl(String deviceType)
        {
            deviceType = deviceType.ToLower();
            grpb_Container.Controls.Clear();
            controllerObject = null;
            multiChatObject = null;
            piObject = null;
            grpb_Container.Text = lstb_UserList.SelectedItem.ToString() + " Remote";
            displayLine(deviceType);
            switch (deviceType)
            {
                case "controller":
                    {
                        controllerObject = new Controller(this);
                        controllerObject.Location = new Point(1, 20);
                        grpb_Container.Controls.Add(controllerObject);
                    }
                    break;
                case "multichat":
                    {
                        multiChatObject = new MultiChat(this);
                        multiChatObject.Location = new Point(1, 20);
                        grpb_Container.Controls.Add(multiChatObject);
                    }
                    break;
                case "piclient":
                    {
                        piObject = new PiClient(this);
                        piObject.Location = new Point(1, 20);
                        grpb_Container.Controls.Add(piObject);
                    }
                    break;
            }
        }

        public string readFromServer()
        {            
            String read = String.Empty;
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Flush();
                byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                networkStream.Flush();

                String dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                read = dataFromClient.Substring(0, dataFromClient.IndexOf("$$"));                
            }
            catch(Exception e)
            {
                displayLine("Disconnected");
                Exception ex = new Exception("Read from Server failed");
                throw ex;
            }            
            return read;
        }

        public void writeToServerHalfCall(String serverResponse)
        {
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                serverResponse = serverResponse.Trim();
                serverResponse += c;
                byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
            }
            catch (Exception e)
            {
                displayLine("Disconnected");
                disconnect();
            }
        }

        public void getClientList(String[] response)
        {
            int oldselection = 0;
            String selectedUsername = String.Empty;
            if (lstb_UserList.Items.Count > 0)
            {
                oldselection = lstb_UserList.SelectedIndex;
                selectedUsername = lstb_UserList.SelectedItem.ToString();
            }
            try
            {
                lstb_UserList.Items.Clear();
                foreach (String client in response)
                {
                    
                    //displayLine(client,true);
                    lstb_UserList.Items.Add(client);
                }
                if (lstb_UserList.Items.Contains(selectedUsername))
                {
                    lstb_UserList.SelectedIndex = lstb_UserList.Items.IndexOf(selectedUsername);
                }
                else
                {
                    if (lstb_UserList.Items.Count > 0)
                        lstb_UserList.SelectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                displayLine("Unable to get client list.",true);
            }
        }

        public String writeToServer(String serverResponse)
        {
            String read = String.Empty;
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                serverResponse = serverResponse.Trim();
                byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();

                byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                networkStream.Flush();

                String dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                read = dataFromClient.Substring(0, dataFromClient.LastIndexOf("$$"));

                return read;
            }
            catch (Exception e)
            {
                displayLine("Disconnected");
                disconnect();
                return read;
            }
        }

        public void sendMnemonic(String message)
        {
            IMPacket sendIM = new IMPacket();
            sendIM.Action = Mnemonics.Actions.senddatanow;
            sendIM.SourceUsername = EvergreenMasterRemote.Properties.Settings.Default.Username;
            sendIM.TargetUsername = lstb_UserList.SelectedItem.ToString();
            sendIM.Message = message;
            String JSONServerResponse = JsonConvert.SerializeObject(sendIM);

            writeToServerHalfCall(JSONServerResponse);
        }        

        public void displayLine(String message, Boolean balloon = false)
        {
            try
            {
                if(multiChatObject!=null)
                {
                    multiChatObject.displayLine(message);
                }

                if (balloon && !this.ContainsFocus)
                {
                    ntfy_Tray.BalloonTipTitle = message;
                    ntfy_Tray.BalloonTipText = "New message from " + message.Split('>')[0];
                    ntfy_Tray.ShowBalloonTip(3000);
                }
            }
            catch (Exception)
            {
                
            }
        }

        public void disconnect()
        {
            try
            {
                this.Text = "Oculus Client v1.0";
                if (polling != null && polling.IsAlive)
                    polling.Abort();
                polling = null;

                if (clientSocket != null)
                {
                    clientSocket.Close();
                    clientSocket = null;
                }

                if (!EvergreenMasterRemote.Properties.Settings.Default.RememberMe)
                {
                    EvergreenMasterRemote.Properties.Settings.Default.Username = "";
                    EvergreenMasterRemote.Properties.Settings.Default.Password = "";

                    EvergreenMasterRemote.Properties.Settings.Default.Save();
                }
            }
            catch (Exception)
            { }
            displayLine("Client offline");
        }

        private void connectToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectTo connectTo = new ConnectTo(this);
            connectTo.Show();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnect();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnect();
            Dispose();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnect();
        }

        private void lstb_UserList_SelectedValueChanged(object sender, EventArgs e)
        {
            IMPacket sendIM = new IMPacket();
            sendIM.Action = Mnemonics.Actions.deviceType;
            sendIM.SourceUsername = EvergreenMasterRemote.Properties.Settings.Default.Username;
            sendIM.TargetUsername = lstb_UserList.SelectedItem.ToString();
            sendIM.Message = String.Empty;
            String JSONServerResponse = JsonConvert.SerializeObject(sendIM);

            writeToServerHalfCall(JSONServerResponse);
        }        
    }
}
