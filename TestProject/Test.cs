using System;
namespace TestProject
{
	public class Test
	{
		public int Id { get; set; }
		public string First { get; set; }
		public string Last { get; set; }
		public Test(int testID, string firstName, string lastName)
		{
			Id = testID;
			First = firstName;
			Last = lastName;
		}

		public string GetFullName()
		{
			string FullName = $"{First} {Last}";
			return FullName;
		}
	}
}

