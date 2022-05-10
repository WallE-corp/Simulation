namespace MobileMock
{
    public enum COMMAND_TYPE {
        MOVEMENT = 4,
        REGISTRATION = 6,
        OBSTACLE_EVENT = 9,
        POSITION_DATA = 11
    }



    public class WallECommand
    {
        public int type { get; }
    }

    public class WallEMovementCommandData
    {
        public string movement;
        public string action;
    }
    public class WallEMovementCommand : WallECommand
    {
        public COMMAND_TYPE type = COMMAND_TYPE.MOVEMENT;
        public WallEMovementCommandData data { get; set; }
    }

    public class WallERegistrationData
    {
        public string role;
    }
    public class WallERegistrationCommand : WallECommand
    {
        public COMMAND_TYPE type = COMMAND_TYPE.REGISTRATION;
        public WallERegistrationData data { get; set; }
    }

    public class WallEObstacleEventData
    {
        public string documentId;
        public string imageUrl;
        public decimal x;
        public decimal y;
        public string label;
    }
    public class WallEOBstacleEventCommand : WallECommand
    {
        public COMMAND_TYPE type
        {
            get { return COMMAND_TYPE.OBSTACLE_EVENT; }
        }
        public WallEObstacleEventData data { get; set; }

        public override string ToString()
        {
            decimal x = Math.Round(data.x, 3, MidpointRounding.AwayFromZero);
            decimal y = Math.Round(data.y, 3, MidpointRounding.AwayFromZero);
            return $"Obstacle Event: {data.label}, {x}, {y}]";
        }
    }

    public class WallEPositionData
    {
        public decimal x;
        public decimal y;
    }
    public class WallEPositionDataCommand : WallECommand
    {
        public COMMAND_TYPE type { get; } = COMMAND_TYPE.POSITION_DATA;
        public WallEPositionData data { get; set; }
        public override string ToString()
        {
            return $"{Math.Round(data.x, 3, MidpointRounding.AwayFromZero)}, {Math.Round(data.y, 3, MidpointRounding.AwayFromZero)}";
        }
    }
}
