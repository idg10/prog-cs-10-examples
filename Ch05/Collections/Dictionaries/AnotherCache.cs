namespace Dictionaries;

public class AnotherCache
{
    private readonly Dictionary<string, UserInfo> _cachedUserInfo = new ();

    public void UseCache(string userHandle)
    {
        UserInfo info = _cachedUserInfo[userHandle];
    }
}
