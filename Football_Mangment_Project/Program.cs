using Football_Mangment_Project.Business;
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
            List<Match> AllMatches = new List<Match>();

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
                    MatchMenu(AllTeams, AllMatches);
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
                    while (string.IsNullOrWhiteSpace(name) || name.All(char.IsDigit))
                    {
                        Console.Write("Invalid Name. Enter Team Name: ");
                        name = Console.ReadLine();
                    }

                    Console.Write("Enter Country Name: ");
                    string CountryName = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(CountryName) || CountryName.All(char.IsDigit))
                    {
                        Console.Write("Invalid Name. Enter Country Name: ");
                        CountryName = Console.ReadLine();
                    }

                    Console.WriteLine("\n Select Continent Name: ");
                    var continent = Enum.GetValues(typeof(Continent));
                    int index_1 = 1;
                    foreach (Continent c in continent)
                    {
                        Console.WriteLine($"{index_1}. {c}");
                        index_1++;
                    }
                    Console.Write("choose: ");
                    int x;
                    while ( !int.TryParse(Console.ReadLine(), out x) || x < 1 || x > continent.Length )
                    {
                        Console.Write("Invalid option, try again: ");
                    }
                    Continent selectedContinent = (Continent)(x - 1);

                    Country country = new Country(CountryName, selectedContinent);

                    int countryId = Country_Business.GetID(CountryName);
                    if (countryId == 0)
                    {
                        Country_Business.AddCountry(CountryName, selectedContinent);
                        countryId = Country_Business.GetID(CountryName);
                    }

                    Console.Write("\n Enter coach Name: ");
                    string CoachName = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(CoachName) || CoachName.All(char.IsDigit))
                    {
                        Console.Write("Invalid Name. Enter coach Name: ");
                        CoachName = Console.ReadLine();
                    }
                    Coach coach = new Coach(CoachName, teams.Count + 1);

                    int coachId = Coach_Business.GetID(CoachName);
                    while (coachId != 0)
                    {
                        Console.Write($"Coach '{CoachName}' already manages another team. Enter a different coach name: ");
                        CoachName = Console.ReadLine();
                        coachId = Coach_Business.GetID(CoachName);
                    }
                    Coach_Business.AddCoach(CoachName);
                    coachId = Coach_Business.GetID(CoachName);

                    Console.WriteLine("\n Select TeamType: ");
                    var teamTypes = Enum.GetValues(typeof(TeamType));
                    int index_2 = 1;
                    foreach (TeamType t in teamTypes)
                    {
                        Console.WriteLine($"{index_2}. {t}");
                        index_2++;
                    }
                    Console.Write("choose: ");
                    int y;
                    while (!int.TryParse(Console.ReadLine(), out y) || y < 1 || y > teamTypes.Length)
                    {
                        Console.Write("Invalid, try again: ");
                    }
                    TeamType SelectedTeamType = (TeamType)(y - 1);

                    Team newTeam = new Team(name, country, SelectedTeamType, coach);

                    Team_Business.AddTeam(name, countryId, SelectedTeamType, coachId);
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
            int index = 1;
            foreach (Team t in teams)
            {
                Console.WriteLine($"{index}.{t.TeamName}");
                index++;
            }
            Console.Write("choose: ");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x < 1 || x > teams.Count)
            {
                Console.Write("Invalid option, try again: ");
            }
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
                        Console.WriteLine("select team: ");
                        Team selectedTeam = SelectedTeam(teams);

                        Console.Write("Player Name: ");
                        string PlayerName= Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(PlayerName) || PlayerName.All(char.IsDigit))
                        {
                            Console.Write("Invalid Name. Enter Player Name: ");
                            PlayerName = Console.ReadLine();
                        }

                        Console.Write("Shirt Number: ");
                        int ShirtNumber;
                        while (!int.TryParse(Console.ReadLine(), out ShirtNumber) || ShirtNumber < 1 || ShirtNumber >= 100)
                        {
                            Console.Write("Invalid option, try again: ");
                        }


                        Console.WriteLine("Select Position: ");
                        var positions= Enum.GetValues(typeof(Position));
                        int index = 1;
                        foreach (Position position in positions)
                        {
                            Console.WriteLine($"{index}.{position}");
                            index++;
                        }

                        Console.Write("choose: ");
                        int y;
                        while (!int.TryParse(Console.ReadLine(), out y) || y < 1 || y > positions.Length)
                        {
                            Console.Write("Invalid option, try again: ");

                        }
                        Position selectedPosition = (Position)(y - 1);

                        Player player= new Player(PlayerName, selectedTeam.PlayerList.Count +1, ShirtNumber, selectedPosition);

                        int teamId = Team_Business.GetID(selectedTeam.TeamName);
                        Player_Business.AddPlayer(PlayerName, ShirtNumber, selectedPosition, teamId);

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

        static Match SelectedMatch(List<Match> matches)
        {
            int index = 1;
            foreach (Match m in matches)
            {
                Console.WriteLine($"{index}.{m.HomeTeam} vs {m.AwayTeam}");
                index++;
            }
            Console.Write("choose: ");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x < 1 || x > matches.Count)
            {
                Console.Write("Invalid option, try again: ");
            }
            return matches[x - 1];
        }

        static Player SelectedPlayer(Team team)
        {
            int index = 1;
            foreach (Player p in team.PlayerList)
            {
                Console.WriteLine($"{index}.{p.Name}");
                index++;
            }
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x < 1 || x > team.PlayerList.Count)
            {
                Console.Write("Invalid option, try again: ");
            }
            return team.PlayerList[x - 1];
        }
        static void MatchMenu(List<Team> teams,List<Match> matches) 
        {
            bool running = true;
            while(running)
            {
                Console.WriteLine("===============");
                Console.WriteLine("--- Match Management ---");
                Console.WriteLine("1. Create Match");
                Console.WriteLine("2. Add Goal");
                Console.WriteLine("3. Finish Match");
                Console.WriteLine("4. Display All Matches"); 
                Console.WriteLine("5. Back");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (teams.Count < 2)
                    {
                        Console.WriteLine("No Enough Teams for match creation");
                        TeamMenu(teams);
                    }
                    else
                    {
                        Console.WriteLine("Select Home Team ");
                        Team HomeTeam = SelectedTeam(teams);
                        Console.WriteLine("Select Away Team ");
                        Team AwayTeam = SelectedTeam(teams);

                        while(HomeTeam == AwayTeam)
                        {
                            Console.WriteLine("Home Team and Away Team cannot be the same. \n Select Away Team again:");
                            AwayTeam = SelectedTeam(teams);
                        }

                        Match match = new Match(HomeTeam, AwayTeam);
                        matches.Add(match);
                        Console.WriteLine($"Match added successfully \n {HomeTeam} vs {AwayTeam}");
                    }
                }

                else if (choice == "2")
                {
                    if(matches.Count == 0 )
                    {
                        Console.WriteLine("No available matches");
                    }
                    else 
                    {
                        Match selectedMatch = SelectedMatch(matches);
                        Console.WriteLine("1. Home Team");
                        Console.WriteLine("2. Away Team");
                        Console.Write("Which team scored? ");
                        int teamChoice;
                        while (!int.TryParse(Console.ReadLine(), out teamChoice) || (teamChoice != 1 && teamChoice != 2))
                        {
                            Console.Write("Invalid option, try again: ");
                        }

                        Team TeamScored;
                        TeamGoal teamGoal;
                        if(teamChoice == 1)
                        {
                            TeamScored = selectedMatch.HomeTeam;
                            teamGoal = TeamGoal.Home;
                        }
                        else
                        {
                            TeamScored = selectedMatch.AwayTeam;
                            teamGoal = TeamGoal.Away;
                        }

                        if (TeamScored.PlayerList.Count == 0)
                        {
                            Console.WriteLine($"{TeamScored.TeamName} has no players yet. Please add one first.");
                            PlayerMenu(teams);
                        }
                        else
                        {
                            Console.WriteLine("choose scorer");
                            Player Scorer = SelectedPlayer(TeamScored);

                            Goal goal = new Goal(Scorer);
                            selectedMatch.AddGoal(goal, teamGoal);

                            Console.WriteLine($"Goal added: {Scorer.Name}");
                        }

                    }
                }

                else if (choice == "3")
                {
                    if (matches.Count == 0)
                    {
                        Console.WriteLine("No available matches");
                    }
                    else
                    {
                        Match selectedMatch = SelectedMatch(matches);
                        selectedMatch.FinishMatch();
                        Console.WriteLine($"Match finished: {selectedMatch.GetResult()}");
                        Console.WriteLine($"Winner: {selectedMatch.GetWinner()}");
                    }
                }

                else if (choice== "4")
                {
                    foreach(Match match in matches)
                    {
                        Console.WriteLine($"{match.HomeTeam}: {match.GetHomeGoals()}  vs {match.AwayTeam}: {match.GetAwayGoals()} ");
                        Console.WriteLine($"winner: {match.GetWinner()} ");

                    }
                }

                else if (choice == "5")
                    running = false;
                else
                    Console.WriteLine("Invalid choice");
            }

        }
    }
}