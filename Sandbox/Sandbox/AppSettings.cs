﻿﻿using Xamarin.Forms;

namespace Sandbox
{
    public partial class App : Application 
    {
        public static readonly string AppServiceUrl = "https://graph.windows.net/";
        public static readonly string AadApplicationId = "00000000-0000-0000-0000-000000000000";
        public static readonly string AadObjectId = "00000000-0000-0000-0000-000000000000";
        public static readonly string AadTenantId = "00000000-0000-0000-0000-000000000000";
        public static readonly string AadRedirectUri = "http://somedomain.azurewebsites.net/.auth/login/done";
        public static readonly string AadAuthority = "https://login.windows.net/common/";

        public const string Organization = "myorganization";
    }
}