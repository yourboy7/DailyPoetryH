using System.Net.Mime;

namespace DailyPoetryH.Library.Services;

public class PoetryStorage : IPoetryStorage {
    public const string DbName = "poetrydb.sqlite3";

    public static readonly string PoetryDbPath =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder
                .LocalApplicationData), DbName);

    private readonly IPreferenceStorage _preferenceStorage;

    public PoetryStorage(IPreferenceStorage preferenceStorage) {
        _preferenceStorage = preferenceStorage;
    }

    public bool IsInitialized =>
        _preferenceStorage.Get(PoetryStorageConstant.DbVersionKey, 0) ==
        PoetryStorageConstant.Version;

    public async Task InitializeAsync() {
        await using var dbFileStream =
            new FileStream(PoetryDbPath, FileMode.OpenOrCreate);
        await using var dbAssetStream =
            typeof(PoetryStorage).Assembly.GetManifestResourceStream(DbName);
        await dbAssetStream.CopyToAsync(dbFileStream);

        _preferenceStorage.Set(PoetryStorageConstant.DbVersionKey,
            PoetryStorageConstant.Version);
    }
}

public static class PoetryStorageConstant {
    public const string DbVersionKey =
        nameof(PoetryStorageConstant) + "." + nameof(DbVersionKey);

    public const int Version = 1;
}