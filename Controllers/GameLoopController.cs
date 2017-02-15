using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace clickerCoder.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        [Route("game")]
        public IActionResult Game()
        {
            // delay rate in MS
            int FPS = 60;
            bool GameOn = true;
            HttpContext.Session.SetInt32("loops2", 0);
            HttpContext.Session.SetInt32("total", 0);
            while (GameOn == true)
            {
                int time1 = Environment.TickCount;
                // check for user input.
                int input = GetUserInput.readClick();
                // update game variables based upon changes.
                UpdateGameState.click();
                UpdateGameState.automatic();
                // If anything has changed, draw the screen
                if (RenderGame.check())
                {
                    RenderGame.draw();
                }
                // delay until FPS ms have passed. 
                CheckDelay.wait(FPS, time1);
            }
            return View("Index");
        }
    }
    public static class GetUserInput
    {
        public static int readClick()
        {
            int results = 0;

            return results;
        }
    }
    public static class UpdateGameState
    {
        public static void click()
        {
            
        }
        public static void automatic(){

        }
    }
    public static class RenderGame
    {
        public static bool check()
        {
            if (false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void draw()
        {
            // call draw the page function.
        }
    }

    public static class CheckDelay
    {
        public static void wait(int FPS, int time1)
        {
            // check system time after game loop
            int time2 = Environment.TickCount;
            int breaktime = FPS;
            // so long as the delay between start of loop and end of loop is < FPS, delay and recheck
            do
            {
                // keep checking
                time2 = Environment.TickCount;
                // Look at the difference
                breaktime = time2 - time1;
                // delay 5ms
                System.Threading.Thread.Sleep(5);
            }
            while (breaktime < FPS);
            return;
        }
    }
}
