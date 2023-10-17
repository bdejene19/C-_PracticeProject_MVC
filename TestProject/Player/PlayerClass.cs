using System;
using System.Collections.Generic;

namespace TestProject.Players
{
	public class PlayerClass
	{

        public OutField PlayerDetails;

        public PlayerClass()
        {
        }

        public PlayerClass(OutField details)
		{

                PlayerDetails = details;
                

           

        }

        public void ChangeName(string Name, bool IsFirst = true)
        {
            if (Name.Length == 0)
            {
                throw new MissingFieldException("Empty name", Name);
            }
            if (IsFirst)
            {
                this.PlayerDetails.First = Name;
            } else
            {
                this.PlayerDetails.Last = Name;
            }
        }
        public void ChangeName(string FirstName, string LastName)
        {
            this.PlayerDetails.First = FirstName;
            this.PlayerDetails.Last = LastName;
        }
       
    }

    public struct CoachHistory
    {
        public byte Wins { get; set; }
        public byte Draws { get; set; }
        public byte Losses { get; set; }

        public CoachHistory()
        {
            Wins = 0;
            Draws = 0;
            Losses = 0;
        }

        public CoachHistory(byte BaseWins, byte BaseDraws, byte BaseLosses)
        {
            Wins = BaseWins;
            Draws = BaseDraws;
            Losses = BaseLosses;
        }

    }
    public class Coach
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }


        public GenericStack<string> ManagementHistory { get; set; } = new();
        public CoachHistory WinRecord { get; set; } = new();


        public Coach()
        {
            Name = "";
            IsActive = true;
        }

        public Coach(string CoachName, bool Active = false, GenericStack<string>? ManagedTeams = null, CoachHistory? Record = null)
        {
            ManagedTeams ??= new();
            Record ??= new();
           
            Name = CoachName;
            IsActive = Active;
            ManagementHistory = ManagedTeams;
            WinRecord = (CoachHistory)Record;

        }


        public GenericStack<string> GetTeamsManaged()
        {
            return ManagementHistory;
        }
        public void ToggleActive()
        {
            IsActive = !IsActive;
        }
        public string? GetCurrentActiveTeam()
        {
            try
            {
                if (!IsActive)
                {
                    return null;

                }

                return ManagementHistory.GetTop();
            } catch
            {
                throw new IndexOutOfRangeException("Top Value for stack un-indexible");
            }
        }

        public CoachHistory GetGamesRecord()
        {
            return WinRecord;
        }

        public byte GetGamesRecord(string RecordType = "Wins")
        {
            if (RecordType == "Draws")
            {
                return WinRecord.Draws;
            }

            if (RecordType == "Losses")
            {
                return WinRecord.Losses;
            }

            return WinRecord.Wins;
        }
    }

    public class TeamClass
    {
        public GenericStack<PlayerClass> Team { get; set; }
        public string League { get; set; }
        private static byte TeamLimit { get; set; } = 42;
        public Coach TeamCoach { get; set; }
        public byte LeaguePosition { get; set; }   

        public TeamClass()
        {

        }
        public TeamClass(GenericStack<PlayerClass>? DefaultTeam, Coach? DefaultCoach, string? DefaultLeague)
        {

            DefaultTeam ??= new();
            DefaultLeague ??= "";
            DefaultCoach ??= new();

            Team = DefaultTeam;
            TeamCoach ??= DefaultCoach;
            League ??= DefaultLeague;
            LeaguePosition = 1;
        }


        public void ChangeCoach(Coach NewCoach)
        {
            TeamCoach = NewCoach;
        }


        private bool SquadLimitReached()
        {
            if (Team.Top + 1 == TeamLimit)
            {
                return true;

            }
            return false;
        }

        public string GetLeague()
        {
            return League;
        }

        public byte GetLeaguePosition()
        {
            return LeaguePosition;
        }

        public void ChangeLeaguePosition(byte check)
        {
            LeaguePosition += check;
        }
        public void AddPlayer(PlayerClass PlayerIn)
        {
            
            if (SquadLimitReached())
            {
                throw new Exception("Team Limit Reached");
            }
            Team.PushToStack(PlayerIn);

        }

        public void RemovePlayer(PlayerClass PlayerOut)
        {

        }
    }
}

