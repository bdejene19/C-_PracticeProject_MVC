using System;
using Microsoft.EntityFrameworkCore;
namespace TestProject.Models
{
	public class Player
	{
        public int ID { get; set; }
        public string First { get; set; }
		public DateTime CreatedAt { get; set; }
		public int ShirtNum { get; set; }
		public int Starts { get; set; }
		public int Appearances { get; set; }
	}
}

