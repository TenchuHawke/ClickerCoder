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
            return View("Game");
        }

        [HttpGet]
        [Route("click")]

        public JsonResult clicked()
        {
            System.Console.WriteLine("CLICKED");
            return Json(new { data = "hi", info = "stuff" });
        }
        [HttpPostAttribute]
        [Route("item")]

        public JsonResult item(int itemId, int itemCost)
        {
            System.Console.WriteLine("Item:" + itemId.ToString() + "  cost:"
            + itemCost.ToString());
            return Json(new { playergold = 500, item = "Axe" });
        }
        [HttpPostAttribute]
        [Route("addItem")]
        public JsonResult addItem()
        {
            System.Console.WriteLine("Bobo: cost:");
            return Json(new { playergold = 500, item = "Axe" });
        }
        [HttpPostAttribute]
        [Route("Automatic")]
        public JsonResult automatic(int userId)
        {
            System.Console.WriteLine("Auto:" + userId.ToString());
            return Json(new { clicks = 1000 });
        }
    }

    public static class gameloop2
    {
        public static void clicked()
        {
            System.Console.WriteLine("CLICKED");
            return;
        }
    }
    public static class GameLoop
    {
        public static void run(int click, int time)
        {
            int time1 = Environment.TickCount;
            // check for user input.
            int input = GetUserInput.readClick();
            // update game variables based upon changes.
            UpdateGameState.click(input);
            UpdateGameState.automatic();
            // If anything has changed, draw the screen
            if (RenderGame.check())
            {
                RenderGame.draw();
            }
            // delay until FPS ms have passed. 
            // CheckDelay.wait(FPS, time1);
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
        public static void click(int input)
        {

        }
        public static void automatic()
        {

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
