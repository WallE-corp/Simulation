using System;
using System.Windows.Forms;
using SocketIOClient;
using Newtonsoft.Json;

namespace MobileMock
{
    public partial class mainForm : Form
    {
        SocketIO? client;
        public mainForm()
        {
            InitializeComponent();
            tbxServerAddress.Text = "127.0.0.1:3000";
            gbxControls.Enabled = false;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        async private void btnConnect_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                string address = tbxServerAddress.Text;
                client = new SocketIO($"http://{address}");
                client.OnConnected += OnConnected;
                client.OnDisconnected += OnDisconnected;
                client.On("message", OnMessageReceived);

            }

            if (client.Connected == false)
            {
                await client.ConnectAsync();
            }
            else
            {
                await client.DisconnectAsync();

            }
        }

        private async void OnMessageReceived (SocketIOResponse response)
        {
            string jsonString = response.GetValue<string>();
            var commadDef = new { type = 0 };
            var command = JsonConvert.DeserializeAnonymousType(jsonString, commadDef);
            if (command == null)
            {
                Console.WriteLine("Could not deserialize command", jsonString);
                return;
            }

            dynamic parsedCommand;
            switch ((COMMAND_TYPE)command.type)
            {
                case COMMAND_TYPE.OBSTACLE_EVENT:
                    WallEOBstacleEventCommand obstacleEvent = JsonConvert.DeserializeObject<WallEOBstacleEventCommand>(jsonString);
                    parsedCommand = obstacleEvent;
                    break;
                default:
                    return;
                    break;
            }

            lstbxReceivedMessages.Invoke((MethodInvoker)delegate
            {
                lstbxReceivedMessages.Items.Add(parsedCommand);
            });
        }

        private WallEMovementCommand CreateMovementCommand(string movement, string action)
        {
            var movementCommand = new WallEMovementCommand
            {
                data = new WallEMovementCommandData
                {
                    movement = movement,
                    action = action
                }
            };
            return movementCommand;
        }

        private void EmitMovementCommand(string movement, string action)
        {
            var movementCommand = CreateMovementCommand(movement, action); ;
            string jsonString = JsonConvert.SerializeObject(movementCommand);
            client.EmitAsync("message", jsonString);
        }

        async private void OnDisconnected(object sender, string e)
        {
            btnConnect.Invoke((MethodInvoker)delegate
            {
                btnConnect.Text = "Connect";
                gbxControls.Enabled = false;
            });
        }

        async private void OnConnected(object sender, EventArgs e)
        {
            btnConnect.Invoke((MethodInvoker)delegate
            {
                btnConnect.Text = "Disconnect";
                gbxControls.Enabled = true;
            });
        }

        private void btnRegisterAsRemote_Click(object sender, EventArgs e)
        {
            var registrationCommmand = new WallERegistrationCommand
            {
                data = new WallERegistrationData
                {
                    role = "remote"
                }
            };
            string jsonString = JsonConvert.SerializeObject(registrationCommmand);
            client.EmitAsync("message", jsonString);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    EmitMovementCommand("forward", "stop");
                    break;
                case Keys.S:
                    EmitMovementCommand("backward", "stop");
                    break;
                case Keys.A:
                    EmitMovementCommand("left", "stop");
                    break;
                case Keys.D:
                    EmitMovementCommand("right", "stop");
                    break;
            }
        }

        #region Movement Commands
        public void MoveBackwardStart(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("backward", "start");
        }

        public void MoveBackwardStop(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("backward", "stop");
        }

        public void MoveForwardStart(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("forward", "start");
        }

        public void MoveForwardStop(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("forward", "stop");
        }

        public void MoveLeftStart(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("left", "start");
        }

        public void MoveLeftStop(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("left", "stop");
        }


        public void MoveRightStart(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("right", "start");
        }

        public void MoveRightStop(object sender, MouseEventArgs e)
        {
            EmitMovementCommand("right", "stop");
        }

        #endregion
    }
}