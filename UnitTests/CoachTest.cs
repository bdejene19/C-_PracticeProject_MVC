using System;
using System.Xml.Linq;
using TestProject.Players;
using Xunit;
public class CoachTest
{
	[Theory]
	[InlineData("Mikel Arteta", true)]
	//[InlineData("Mikel Arteta", true)]

	public void CreatingCoach_SetsDefaults_Empty(string Name, bool IsActive)
	{
		Coach CurrCoach = new()
		{
			Name = Name,
			IsActive = IsActive,
		};

		GenericStack<string> DefaultManagement = new();
		CoachHistory DefaultRecord = new();

		byte ExpectedBaseRecord = 0, ExpectedHistoryLength = 0;

		Assert.Equivalent(DefaultManagement, CurrCoach.ManagementHistory);
		Assert.Equal(DefaultRecord, CurrCoach.WinRecord);

		Assert.Equal(ExpectedHistoryLength, CurrCoach.ManagementHistory.Top + 1);
		Assert.Equal(ExpectedBaseRecord, CurrCoach.WinRecord.Wins);
		Assert.Equal(ExpectedBaseRecord, CurrCoach.WinRecord.Draws);
		Assert.Equal(ExpectedBaseRecord, CurrCoach.WinRecord.Losses);

	}

	[Fact]
	public void GettingActiveTeams()
	{

	}

	public struct TeamsManagedSetup
	{
		public bool Active { get; set; }
		public GenericStack<string> TeamsManged { get; set; }
		public string? Expected { get; set; }
	}

	public static IEnumerable<object[]> GetTeamsManagedList()
	{
		//IEnumerable<string> Names = Enumerable;
		yield return new object[] { new TeamsManagedSetup() { Active = true, TeamsManged = new GenericStack<string>(DefaultVal: new List<string>() { "Barcelona", "Manchester City" }), Expected = "Manchester City" } };
		yield return new object[] { new TeamsManagedSetup() { Active = false, TeamsManged = new GenericStack<string>(DefaultVal: new List<string>() { "Barcelona", "Manchester City" }), Expected = null } };
        yield return new object[] { new TeamsManagedSetup() { Active = false, TeamsManged = new GenericStack<string>(), Expected = null } };


    }

    [Theory]
    [MemberData(nameof(GetTeamsManagedList))]
    public void GettingActiveTeam_Retrieves_TopElementFromManagedHistory_OrNull(TeamsManagedSetup Setup)
	{

        Coach CurrCoach = new()
        {
            Name = "Bemnet Dejene",
			IsActive = Setup.Active,				
            ManagementHistory = Setup.TeamsManged,
        };

		string? ExpectedValue = Setup.Expected;
		string ActualValue = CurrCoach.GetCurrentActiveTeam();

        Assert.Equal(ExpectedValue, ActualValue);
	}

	[Theory]
	[InlineData("", 1)]
    [InlineData("Draws", 2)]
    [InlineData("Losses", 3)]
	public void GetGamesRecord_ReturnsNumber_And_OverridesDynamically(string RecordType, byte ExpectedVal)
	{
        Coach CurrCoach = new()
        {
            Name = "Bemnet Dejene",
            IsActive = true,
			WinRecord = new() { Wins = 1, Draws = 2, Losses = 3}
        };

		byte ActualValue = CurrCoach.GetGamesRecord(RecordType);

		Assert.Equal(ExpectedVal, ActualValue);
    }

	[Fact]
	public void ToggleIsActive_DefaultOfTrue()
	{

		Coach CurrCoach = new()
		{
			Name = "Bemnet Dejene",
			IsActive = true,
        };
        CurrCoach.ToggleActive();
        bool ExpectedIsActive = false;



        Assert.Equal(ExpectedIsActive, CurrCoach.IsActive);

        CurrCoach.ToggleActive();
        ExpectedIsActive = true;

        Assert.Equal(ExpectedIsActive, CurrCoach.IsActive);




    }

}


