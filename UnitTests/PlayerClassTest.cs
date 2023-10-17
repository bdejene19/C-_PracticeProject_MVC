using TestProject.Players;

using Xunit;

public class PlayerClassTest
{
    [Fact]
    public void ChangeMethod_FirstName()
    {
        string FirstName = "Tyler";
        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = Random.Shared.Next(0, 38),
                Starts = Random.Shared.Next(0, 38),
                ShirtNum = Random.Shared.Next(0, 100),
                First = "FirstName",
                Last = "LastName",
            }
        };

        NewPlayer.ChangeName(FirstName);
        Assert.Equal(NewPlayer.PlayerDetails.First, FirstName);
    }

    [Fact]
    public void ChangeMethod_LastName()
    {
        string LastName = "Lescott";

        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = Random.Shared.Next(0, 38),
                Starts = Random.Shared.Next(0, 38),
                ShirtNum = Random.Shared.Next(0, 100),
                First = "FirstName",
                Last = "LastName",
            }
        };

        NewPlayer.ChangeName(LastName, false);
        Assert.Equal(NewPlayer.PlayerDetails.Last, LastName);
    }

    [Fact]
    public void ChangeMethod_ChangeBothNames()
    {
        string FirstName = "Tyler";
        string LastName = "Lescott";

        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = Random.Shared.Next(0, 38),
                Starts = Random.Shared.Next(0, 38),
                ShirtNum = Random.Shared.Next(0, 100),
                First = "FirstName",
                Last = "LastName",
            }
        };


        NewPlayer.ChangeName(FirstName, LastName);

        OutField Details = NewPlayer.PlayerDetails;

        Assert.Equal(FirstName, Details.First);
        Assert.Equal(LastName, Details.Last);
    }

    [Theory]
    [InlineData("")]
    [InlineData("", false)]
    public void ChangeName_EmptyString_ThrowsException(string Name, bool IsFirst = true)
    {
        string PlayerName = Name;

        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = Random.Shared.Next(0, 38),
                Starts = Random.Shared.Next(0, 38),
                ShirtNum = Random.Shared.Next(0, 100),
                First = "FirstName",
                Last = "LastName",
            }
        };

        Assert.Throws<MissingFieldException>(() => NewPlayer.ChangeName(Name, IsFirst));

    }

    [Theory]
    [InlineData("Bemnet")]
    [InlineData("Bemnet", false)]
    public void ChangeName_Updates_FullName_Simultaneously(string Name, bool IsFirst = true)
    {
        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = Random.Shared.Next(0, 38),
                Starts = Random.Shared.Next(0, 38),
                ShirtNum = Random.Shared.Next(0, 100),
                First = "",
                Last = "Dejene",
            }
        };
        NewPlayer.ChangeName(Name, IsFirst);

        OutField DefaultPlayer = NewPlayer.PlayerDetails;

        Assert.Equal($"{DefaultPlayer.First} {DefaultPlayer.Last}", DefaultPlayer.Fullname);
    }

    [Theory]
    [InlineData("Dejene")]
    public void ChangeLast_Updates_LastName_And_FullName(string LastName)
    {
        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = Random.Shared.Next(0, 38),
                Starts = Random.Shared.Next(0, 38),
                ShirtNum = Random.Shared.Next(0, 100),
                First = "Bemnet",
                Last = "",
            }
        };

        OutField DefaultPlayer = NewPlayer.PlayerDetails;
        DefaultPlayer.Last = LastName;
        Assert.Equal(DefaultPlayer.Last, LastName);
        Assert.Equal(DefaultPlayer.Fullname, $"{DefaultPlayer.First} {DefaultPlayer.Last}");
    }



    [Theory]
    [InlineData(0, 1)]
    public void Starts_GreaterThan_TotalAppearances(int InitialStarts, int InitialAppearances)
    {

        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = 0,
                Starts = 0,
                ShirtNum = Random.Shared.Next(0, 100),
                First = "Bemnet",
                Last = "Dejene",
            }
        };

        OutField DefaultPlayer = NewPlayer.PlayerDetails;

        DefaultPlayer.Starts = InitialStarts;
        DefaultPlayer.Appearances = InitialAppearances;


        Assert.InRange(DefaultPlayer.Starts, 0, DefaultPlayer.Appearances);
    }

    [Fact]
    public void StartPercentage_NotNull_And_UnderOrEquals_100()
    {
        PlayerClass NewPlayer = new()
        {
            PlayerDetails =
            {
                Appearances = 32,
                Starts = 17,
                ShirtNum = Random.Shared.Next(0, 100),
                First = "Bemnet",
                Last = "Dejene",
            }
        };

        OutField DefaultPlayer = NewPlayer.PlayerDetails;

        Assert.InRange(DefaultPlayer.StartPercentage, 0, 100);
    }
}
