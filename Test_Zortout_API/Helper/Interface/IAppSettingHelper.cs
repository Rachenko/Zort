namespace Test_Zortout_API.Helper.Interface
{
    public interface IAppSettingHelper
    {
        string GetValue(string KeyPath);
        T GetValue<T>(string keyPath);
    }
}
