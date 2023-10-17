using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestProject.Players;
namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public TestController()
        {

        }
        [HttpGet]
        public PlayerClass GetRandomPlayer()
        {
        
                OutField PlayerDetails = new()
                {
                    Appearances = Random.Shared.Next(0, 38),
                    First = "Bemnet",
                    Last = "Dejene",
                    ShirtNum = Random.Shared.Next(0, 38),
                    Starts = Random.Shared.Next(0, 38),

                };
                PlayerClass NewPlayer = new(PlayerDetails);

                return NewPlayer;
                     
        }
    }
}