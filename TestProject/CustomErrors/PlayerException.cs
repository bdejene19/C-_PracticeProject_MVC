using System;
using TestProject.Players;
namespace TestProject.CustomErrors
{
	public class PlayerException<T> : Exception
	{

		public static string ErrorMessage { get; set; }
		public static T _Content { get; set; }
        //public Starts Content { get; set; }
        public PlayerException() : base()
		{
			ErrorMessage = "Player Object could not be created";
			
		}

		public PlayerException(PlayerClass PlayerProperties) 
		{
			ErrorMessage = "Player Object missing properties when created";
			OutField Details = PlayerProperties.PlayerDetails;
			StartsGreaterAppearances WrongRandomization = new(){ Starts = Details.Starts, Appearances = Details.Appearances, ErrorMessage = "" };
		}
		public OutFieldArgumentsNull PlayerArgumentsNull(PlayerClass PlayerProperties) 
		{
			ErrorMessage = "OutFeild Arguments contain null object;";
			OutFieldArgumentsNull ErrorObj = new() { ErrorMessage = ErrorMessage, InitialInput = PlayerProperties };
			return ErrorObj;
		}





	}
}

