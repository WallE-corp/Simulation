using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlInputProvider : IInputProvider
{
    Vector3 direction;
    Vector3 angularVelocity;
    public RemoteControlInputProvider()
    {
        angularVelocity = Vector3.zero;
    }

    public void HandleMovementCommand(MovementCommand moveCommand)
    {
        switch (moveCommand.direction)
        {
            case "left":
                if (moveCommand.action == "start") angularVelocity = -Vector3.up;
                else angularVelocity = Vector3.zero;
                break;
            case "right":
                if (moveCommand.action == "start") angularVelocity = Vector3.up;
                else angularVelocity = Vector3.zero;
                break;
            case "forward":
                if (moveCommand.action == "start") direction = Vector3.forward;
                else direction = Vector3.zero;
                break;
            case "backward":
                if (moveCommand.action == "start") direction = -Vector3.forward;
                else direction = Vector3.zero;
                break;
        }
    }

    public InputState GetInputState()
    {
        return new InputState
        {
            movementDir = direction,
            rotation = angularVelocity,
        };
    }
}
