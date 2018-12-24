using System;

namespace MyBook
{
    public class App
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "https://api.itbook.store/1.0";

        public static void Initialize()
        {
            if (UseMockDataStore)
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, CloudDataStore>();
        }
    }
}
