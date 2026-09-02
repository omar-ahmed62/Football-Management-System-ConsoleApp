using Football_Mangment_Project.Models;
using System.Collections;
using System.Xml.Linq;

namespace Football_Mangment_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> AllTeams = new List<Team>();

            Console.WriteLine("  FOOTBALL MANGMENT SYSTEM");

            bool running = true;
            while (running)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("1. Player Mangment");
                Console.WriteLine("2. Team Mangment");
                Console.WriteLine("3. Match Mangment");
                Console.WriteLine("4. Exit");
                Console.WriteLine("===============");

                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                    PlayerMenu(AllTeams);
                else if (choice == "2")
                    TeamMenu(AllTeams);
                else if (choice == "3")
                    Console.WriteLine("Match Management selected");
                else if (choice == "4")
                    running = false;
                else
                    Console.WriteLine("Invalid choice\n");
            }



        }



        static void TeamMenu(List<Team> teams)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("===============");
                Console.WriteLine("--- Team Management ---");
                Console.WriteLine("1. Add Team");
                Console.WriteLine("2. Display All Teams");
                Console.WriteLine("3. Back");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();


                if (choice == "1")
                {
                    Console.Write("Enter Team Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Country Name: ");
                    string CountryName = Console.ReadLine();

                    Console.WriteLine("\n Select Continent Name: ");
                    var continent = Enum.GetValues(typeof(Continent));
                    int index_1 = 1;
                    foreach (Continent c in continent)
                    {
                        Console.WriteLine($"{index_1}. {c}");
                        index_1++;
                    }
                    Console.Write("choose: ");
                    int x = int.Parse(Console.ReadLine());
                    Continent selectedContinent = (Continent)(x - 1);

                    Country country = new Country(CountryName, selectedContinent);

                    Console.Write("\n Enter coach Name: ");
                    string CoachName = Console.ReadLine();
                    Coach coach = new Coach(CoachName, teams.Count + 1);


                    Console.WriteLine("\n Select TeamType: ");
                    var teamTypes = Enum.GetValues(typeof(TeamType));
                    int index_2 = 1;
                    foreach (TeamType t in teamTypes)
                    {
                        Console.WriteLine($"{index_2}. {t}");
                        index_2++;
                    }
                    Console.Write("choose: ");
                    int y = int.Parse(Console.ReadLine());
                    TeamType SelectedTeamType = (TeamType)(y - 1);

                    Team newTeam = new Team(name, country, SelectedTeamType, coach);
                    teams.Add(newTeam);

                    Console.WriteLine($"{name} added successfully!");
                }

                else if (choice == "2")
                {
                    foreach (Team t in teams)
                    {
                        Console.WriteLine($"Team Name: {t.TeamName}");
                    }
                }

                else if (choice == "3")
                    running = false;
                else
                    Console.WriteLine("Invalid");
            }

        }

        static Team SelectedTeam(List<Team>teams)
        {
            Console.WriteLine("select team: ");
            int index = 1;
            foreach (Team t in teams)
            {
                Console.WriteLine($"{index}.{t.TeamName}");
                index++;
            }
            Console.Write("choose: ");
            int x = int.Parse(Console.ReadLine());
            return teams[x - 1];
        }

        static void PlayerMenu(List<Team> teams)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("===============");
                Console.WriteLine("--- Player Management ---");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Display All Players");
                Console.WriteLine("3. Back");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if(teams.Count==0)
                    {
                        Console.WriteLine("Please add team first to assign players to");
                        TeamMenu(teams);
                    }

                    else
                    {
                        Team selectedTeam = SelectedTeam(teams);

                        Console.Write("Player Name: ");
                        string PlayerName= Console.ReadLine();

                        Console.Write("Shirt Number: ");
                        int ShirtNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Select Position: ");
                        var positions= Enum.GetValues(typeof(Position));
                        int index = 1;
                        foreach (Position position in positions)
                        {
                            Console.WriteLine($"{index}.{position}");
                            index++;
                        }
                        Console.Write("choose: ");
                        int y = int.Parse(Console.ReadLine());
                        Position selectedPosition = (Position)(y - 1);

                        Player player= new Player(PlayerName, selectedTeam.PlayerList.Count +1, ShirtNumber, selectedPosition);
                        selectedTeam.AddPlayer(player);
                        Console.WriteLine($"{PlayerName}({selectedPosition}) added successfully to {selectedTeam}");

                    }
                }

                else if (choice == "2")
                {
                    if (teams.Count == 0)
                    {
                        Console.WriteLine("No teams available");
                    }
                    else 
                    {
                        Team selectedTeam = SelectedTeam(teams);
                        Console.WriteLine($"Team Name:{selectedTeam.TeamName}");
                        foreach (Player p in selectedTeam.PlayerList)
                        {
                            Console.WriteLine($"\t{p.Name}");
                        }
                    }
                }

                else if (choice == "3")
                    running=false;
                else
                    Console.WriteLine("Invalid choise");
            }


        }

    }
}