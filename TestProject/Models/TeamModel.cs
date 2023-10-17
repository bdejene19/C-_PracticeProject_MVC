using System;
using TestProject.Player;
using TestProject.Players;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
	[Table("Teams")]
	public class TeamModel
	{
		
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		public League ParentLeague { get; set; }
		public List<PlayerClass> Players { get; set; }
		public Coach Coach { get; set; }
	}
}

