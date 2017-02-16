 $(document).ready(function() {
     var GameOn = true
     var FPS = 60
     var LoopTime = 1000 / FPS
     var clickCount = 0
     var newItem = ""
         //  setInterval(
     function GameLoop() {
         if (GameOn != true) {
             clearInterval(game)
         };
         //  Run Game Loop!
         //check user data
         $("#thing").click(function() {
             $.get("click", function(res) {})
         });
         $("#item").click(function() {
             $.post("item", { itemID: 1, itemCost: 200 }, function(res) {
                 // TODO get actual variables
                 if (res.playergold < 200) {} else {
                     $.post("addItem", function(res) {})
                     newItem = res.item;
                 }
             })
         });
         $.post("#automatic", { userID: 1 }, function(res) {
             clickCount += res.clicks;
         });
         redraw(4);
         //End Game Loop
     }

     var game = setInterval(GameLoop, 16.66);

     function redraw(clickCount, newItem) {
         $("#thingcount").replaceWith("<h2>Click count is: " + clickCount + ". </h2>");
         if (newItem) {
             $("#items").append("<li>" + newItem + "</li>");
         }
         return;
     }
 })