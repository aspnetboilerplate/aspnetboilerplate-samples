﻿namespace Acme.ProjectName.SignalR
{
    public static class SignalRFeature
    {
        public static bool IsAvailable
        {
            get
            {
#if FEATURE_SIGNALR
                return true;
#else
                return false;
#endif
            }
        }
    }
}
