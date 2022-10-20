using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAWSDK.Interfaces
{
    public interface IAppVersionAndBuild
    {
        string GetVersionNumber();
        string GetBuildNumber();
        string GetPackageName();
    }
}
