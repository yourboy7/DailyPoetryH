using DailyPoetryH.Library.Services;
using Moq;

namespace DailyPoetryH.UnitTest.Services;

public class PoetryStorageTest {
    [Fact]
    public void IsInitialized_Initialized() {
        var preferenceStorageMock = new Mock<IPreferenceStorage>();
        preferenceStorageMock
            .Setup(p => p.Get(PoetryStorageConstant.DbVersionKey, 0))
            .Returns(PoetryStorageConstant.Version);
        var mockPreferenceStorage = preferenceStorageMock.Object;
        var poetryStorage = new PoetryStorage(mockPreferenceStorage);
        Assert.True(poetryStorage.IsInitialized);
    }
}