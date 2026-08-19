using Football_Mangment_Project.Models;
using System.Collections;

namespace Football_Mangment_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player Mohamed_Salah= new Player("mohamed salah",1,10,Position.RW);

            Player marmoush = new Player("Omar Marmoush", 2, 22, Position.LW);

            Country Egypt = new Country("Egypt", Continent.Africa);
            
           
            Coach EgyptCoach = new Coach("hossam hassan",1);
            
            
            Team EgyptTeam = new Team("Egypt national team", Egypt, TeamType.NationalTeam, EgyptCoach);

            EgyptTeam.PlayerAdded += (p, t) => Console.WriteLine($"Add Operation==>player {p.Name} added to {t.TeamName}");


            EgyptTeam.AddPlayer(Mohamed_Salah);
            EgyptTeam.AddPlayer(marmoush);


            EgyptTeam.PlayerRemoved += (p, t) => Console.WriteLine($"Remove Operation==> player {p.Name} removed from {t.TeamName}");
            EgyptTeam.RemovePlayer(marmoush);

            foreach (Player player in EgyptTeam.PlayerList)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine(EgyptTeam);
            Console.WriteLine(EgyptTeam.Country.CountryName);
            Console.WriteLine(EgyptTeam.Coach);



            Tournament worldCup = new Tournament("World Cup", TournamentType.NationalTeamsTournament);

            worldCup.AddTeam(EgyptTeam);

            Console.WriteLine(worldCup);
            Console.WriteLine(EgyptTeam);

           

            foreach (Team item in worldCup.TeamsParticipated)
            {
                Console.WriteLine(item);
            }




            var LW = EgyptTeam.SearchPlayer(p => p.Position == Position.LW);
            Console.WriteLine("Strikers:");
            foreach (var s in LW)
                Console.WriteLine(s);




        }

    }
}
