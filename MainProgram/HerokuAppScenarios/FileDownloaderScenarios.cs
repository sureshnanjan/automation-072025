using HerokuOperations;


namespace HerokuAppScenarios;

public class FileDownloaderScenarios
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FileDownLoadIsTitleOk()
    {
        string expected = "File Downloader";
        IDownloader downloader;
        string actual = downloader.GetFileDownloadTitle();
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetCountOfFiles_ReturnsCorrectCount()
    {
        int expectedCount = 1;
        int actualCount = downloader.GetCountOfFiles();
        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void GetAllFileNames_ReturnsFileNames()
    {
        var fileNames = downloader.GetAllFileNames();
        Assert.IsNotNull(fileNames);
        Assert.AreEqual(1, fileNames.Count);
        Assert.AreEqual("testfile.txt", fileNames.First());
    }

}

}
