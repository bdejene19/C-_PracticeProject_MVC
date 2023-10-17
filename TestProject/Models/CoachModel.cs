using System;
using System.ComponentModel.DataAnnotations;
using TestProject.Players;

namespace TestProject.Models
{
	public class CoachModel
	{
		public int ID { get; set; }
		public string First { get; set; }
		public string Last { get; set; }
		
        [DisplayFormat(NullDisplayText = "No Management History")]
        public TeamClass TeamsManaged { get; set; }
	}
}

