namespace bad_images;

public class UnitTest1
{
    [Fact]
    public async Task Test1Async()
    {
        // Arrange
        var logo = "https://raw.githubusercontent.com/crankingai/bad-images/main/JPEG_example_flower-jpg.png";

        // Act - load the image from the URL
        var filePath = Path.GetTempFileName();
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(logo);
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                await File.WriteAllBytesAsync(filePath, imageBytes);
            }
        }

        // Assert
        // Assume if the image resolved it is valid
        // if filePath has at least one byte
        var fileInfo = new FileInfo(filePath);
        Assert.True(fileInfo.Exists, "File does not exist");
        Assert.True(fileInfo.Length > 0, "File is empty");
    }
}
