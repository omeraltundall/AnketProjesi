
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace AnketFinal
{
    public partial class DeviceOrientationService : IDeviceIdService
    {
        public DeviceOrientation GetOrientation()
        {
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;

        }
        public interface IGetDeviceInfo { string GetDeviceID(); }
        internal class GetDeviceInfo : IGetDeviceInfo
        {
            public string GetDeviceID()
            {
                var id = UIDevice.CurrentDevice.IdentifierForVendor.AsString().Replace("-", "");

                return id;
            }
        }
    }
}
