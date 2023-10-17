using System;
using TestProject.Players;
using Xunit;
public class TeamTest
{

	[Fact]
	public void TeamObj_CorrectlyCreated()
	{
		string ExpectedLeague = "EPL";
		Coach ExpectedCoach = new(CoachName: "Bemnet Dejene", Active: true, ManagedTeams: new(DefaultVal: new() { "Arsenal" }));
		GenericStack<PlayerClass> ExpectedTeam = new();

		TeamClass NewTeam = new(DefaultLeague: "EPL", DefaultCoach: ExpectedCoach, DefaultTeam: new()); ;


		Assert.Equal(ExpectedLeague, NewTeam.League);
		Assert.Equivalent(ExpectedCoach, NewTeam.TeamCoach);
		Assert.Equivalent(ExpectedTeam, NewTeam.Team);
	}

	[Fact]
	public void ChangeCoach_OnTeamObject()
	{
        Coach ExpectedCoach = new(CoachName: "Bemnet Dejene", Active: true, ManagedTeams: new(DefaultVal: new List<string>() { "Arsenal" }));

		TeamClass NewTeam = new(DefaultLeague: "EPL", DefaultCoach: new Coach(), DefaultTeam: new()); ;

		NewTeam.ChangeCoach(ExpectedCoach);

		Assert.Equivalent(ExpectedCoach, NewTeam.TeamCoach);
    }

	[Fact]
	public void GetterMethods_ReturnCorrectValue()
	{
        Coach Coach = new(CoachName: "Bemnet Dejene", Active: true, ManagedTeams: new(DefaultVal: new List<string>() { "Arsenal" }));

        TeamClass NewTeam = new(DefaultLeague: "EPL", DefaultCoach: Coach, DefaultTeam: new());

		byte ExpectedLeaguePosition = 1;
		string ExpectedLeague = "EPL";

		Assert.Equal(ExpectedLeaguePosition, NewTeam.GetLeaguePosition());
		Assert.Equal(ExpectedLeague, NewTeam.GetLeague());
    }


	public struct TeamTestPlayerSetup
	{
		public GenericStack<PlayerClass> BasePlayerList { get; set; }
		public Exception? ExpectedResult { get; set;}
	}
	public static IEnumerable<object[]> GetPlayersForTeam()
	{

		yield return new object[] { new TeamTestPlayerSetup() { BasePlayerList = new(DefaultVal: new List<PlayerClass>(Enumerable.Range(1, 42).Select(x => new PlayerClass()))), ExpectedResult = new Exception() } };
        yield return new object[] { new TeamTestPlayerSetup() { BasePlayerList = new(DefaultVal: new List<PlayerClass>(Enumerable.Range(1, 41).Select(x => new PlayerClass()))), ExpectedResult = null } };


    }
    [Theory]
	[MemberData(nameof(GetPlayersForTeam))]
	public void AddPlayerToTeam_ThrowsError_TeamLimitReached(TeamTestPlayerSetup Setup) 
	{
		GenericStack<PlayerClass> BasePlayerList = Setup.BasePlayerList;

		TeamClass ActualTeam = new(DefaultTeam: BasePlayerList, DefaultCoach: new Coach(), DefaultLeague: "EPL");

		Exception? ExpectedResult = new();



	}
}


