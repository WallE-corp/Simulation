namespace MobileMock
{
    public class WallEMovementCommandData
    {
        public string movement;
        public string action;
    }

    public abstract class WallECommand
    {
        public abstract int type
        {
            get;
        }

    }

    public class WallEMovementCommand : WallECommand
    {
        int _type = 4;
        public WallEMovementCommandData data { get; set; }

        public override int type
        {
            get { return _type; }
        }
    }

    public class WallERegistrationData
    {
        public string role;
    }
    public class WallERegistrationCommand : WallECommand
    {
        int _type = 6;
        public WallERegistrationData data { get; set; }

        public override int type
        {
            get { return _type; }
        }
    }
}
