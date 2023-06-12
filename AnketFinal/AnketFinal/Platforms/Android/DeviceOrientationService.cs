using Android.Content;
using Android.Runtime;
using Android.Views;
using static Android.Provider.Settings;

namespace AnketFinal
{
    public partial class DeviceOrientationService : IDeviceIdService
    {

        public DeviceOrientation GetOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientation.Landscape : DeviceOrientation.Portrait;

        }
        public interface IGetDeviceInfo { string GetDeviceID(); }
        internal class GetDeviceInfo : IGetDeviceInfo
        {
            public string GetDeviceID()
            {
                var context = Android.App.Application.Context;

                string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);

                return id;
            }
        }
    }
}
