namespace AnketFinal;
using AnketFinal.Services;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        DependencyService.Register<IDeviceIdService, DeviceOrientationService>();
    }
}
    public interface IDeviceIdService
    {
        string GetDeviceId();
    }

    public partial class DeviceOrientationService : IDeviceIdService
    {
        public string GetDeviceId(string id)
        {
            // Implementation logic for retrieving the device ID
            return id;
        }
    }


