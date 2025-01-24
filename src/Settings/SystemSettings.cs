// File to hold constants and settings
// Change this to follow your setup

namespace VillageRMS.Settings
{
    public static class SystemSettings
    {
        public const string ApiURL = "http://localhost";
        public const string ApiURLPort = "3000";

        public const string DBUrl = "http://localhost";
        public const string DBPort = "3306";

        public const string db = "rms";
        public const string dbusername = "group3";
        public const string dbpassword = "your_password";

        //endpoints
        public const string testEndpoint = "test";
        public const string nextID = "nextid";
        public const string customers = "customers";
        public const string categories = "category";
        public const string equipment = "equipment";
        public const string rental = "rental";
    }
}
