using System.Linq;
namespace LINQ_LandonBarnett
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new games array with Game and params
            Game[] games = new Game[]
            {
                new Game("Minecraft", 'E', "Adventure-Action Sandbox"),
                new Game("CS:GO", 'M', "FPS"),
                new Game("Elden Ring", 'M', "Adventure-Adventure Rpg"),
                new Game("Valorant", 'T', "FPS"),
                new Game("Halo 3", 'M', "Adventure FPS"),
                new Game("ZombCube", 'E', "FPS Survival"),
                new Game("Magnet Destroyer", 'E', "Hyper-Casual"),
                new Game("Paddle Balls", 'E', "Arcade-Casual"),
                new Game("Rocket League", 'E', "Action Racing"),
                new Game("Fifa 22", 'E', "Sport"),
            };

            //each game title with less than 9 characters can be called by "shortGames"
            var shortGames = from game in games
                             where game.Title.Length < 9
                             select $"Game Title: {game.Title.ToUpper()}";

            //prints games in shortGames with less than 9 characters
            foreach(var game in shortGames)
            {
                Console.WriteLine(game);
            }

            //minecraft variable finds the game titled minecraft and selects it stating the games title,esrb, and genre
            var mineCraft = games.Where(game => game.Title == "Minecraft")
                            .Select(game => $"Title: {game.Title}, ESRB: {game.Esrb}, Genre: {game.Genre}");
            
            //prints the first or default in minecraft var
            Console.WriteLine(mineCraft.FirstOrDefault());

            //selects each t rated game from games
            var tRated = from game in games
                         where game.Esrb == 'T'
                         select game.Title;

            //prints t rated games aka Valorant
            Console.WriteLine("T Rated Games");
            foreach(var game in tRated)
            {
                Console.WriteLine(game);
            }

            //finds each e rated game that is also a part of the Action genre from games
            var eRatedAction = from game in games
                               where game.Esrb == 'E' && game.Genre.Contains("Action")
                               select game.Title;

            //prints e rated action games
            Console.WriteLine("E Rated Action Games");
            foreach (var game in eRatedAction)
            {
                Console.WriteLine(game);
            }
        }
    }
}
