using AnketFinal.Services;
namespace AnketFinal
{
    public enum DeviceOrientation
    {
        Undefined,
        Landscape,
        Portrait
    }
    public partial class DeviceOrientationService : IDeviceIdService
    {
        public string GetDeviceId()
        {
            // Implement the GetDeviceId() method logic here
            return "YourPlatformSpecificId";
        }
    }
}

