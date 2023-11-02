namespace DailyPoetryH.Library.Services;

public class PoetryStorage : IPoetryStorage {
    private readonly IPreferenceStorage _preferenceStorage;

    public PoetryStorage(IPreferenceStorage preferenceStorage) {
        _preferenceStorage = preferenceStorage;
    }

    public bool IsInitialized =>
        _preferenceStorage.Get(PoetryStorageConstant.DbVersionKey, 0) ==
        PoetryStorageConstant.Version;
}

public static class PoetryStorageConstant {
    public const string DbVersionKey =
        nameof(PoetryStorageConstant) + "." + nameof(DbVersionKey);

    public const int Version = 1;
}