﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketIOClient;
using Newtonsoft.Json;


namespace Wall_remote_controller
{
   
    public partial class Form1 : Form
    {
        SocketIO? client;

        public Form1()
        {
            InitializeComponent();
            addressTbx.Text = "127.0.0.1:3000";
            gbxControls.Enabled = false;
        }

        async private void connectBtn_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                string address = addressTbx.Text;
                client = new SocketIO($"http://{address}");
                client.OnConnected += OnConnected;
                client.OnDisconnected += OnDisconnected;

            }

            if (client.Connected == false)
            {
                await client.ConnectAsync();
            } else
            {
                await client.DisconnectAsync();
                
            }

            
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
            connectBtn.Invoke((MethodInvoker)delegate
            {
                connectBtn.Text = "Connect";
                gbxControls.Enabled = false;
            });
        }

        async private void OnConnected(object sender, EventArgs e)
        {
            connectBtn.Invoke((MethodInvoker)delegate
            {
                connectBtn.Text = "Disconnect";
                gbxControls.Enabled = true;
            });
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