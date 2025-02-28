namespace DotNET_Console_Application.Tests;

public class Pen_Tests
{
    [Fact]
    public void Test()
    {
        // Arrange Default
        Pen pen = new Pen();

        // Assert Default
        Assert.Equal("Bic", pen.Brand);
        Assert.Equal("Black", pen.Colour);
        Assert.Equal(50f, pen.InkLevelML);

        string brand = "Paper Mate";
        string colour = "Red";
        float inkLevelML = 60f;

        // Arrange Greedy
        pen = new Pen(brand, colour, inkLevelML);

        // Assert Greedy
        Assert.Equal(brand, pen.Brand);
        Assert.Equal(colour, pen.Colour);
        Assert.Equal(inkLevelML, pen.InkLevelML);

        // Act
        pen.Write(100);
        pen.Write(42);

        Assert.Equal(45.8f, pen.InkLevelML);

        pen.Write(200);

        Assert.Equal(25.8f, pen.InkLevelML);

        Assert.Throws<ArgumentOutOfRangeException>(() => pen.Write(400));

        Assert.Equal(25.8f, pen.InkLevelML);

        Assert.Throws<ArgumentOutOfRangeException>(() => pen.InkLevelML = -1f);
        Assert.Throws<ArgumentOutOfRangeException>(() => pen.InkLevelML = 60.5f);
        Assert.Throws<ArgumentOutOfRangeException>(() => pen.InkLevelML = 61f);

        pen.InkLevelML = 0f;
        Assert.Equal(0, pen.InkLevelML);

        pen.InkLevelML = 60f;
        Assert.Equal(60, pen.InkLevelML);

        pen.Write(100);
        Assert.Equal(50f, pen.InkLevelML);
    }
}
