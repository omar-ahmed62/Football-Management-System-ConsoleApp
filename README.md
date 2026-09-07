# Football Management System
A console-based football management system built in **C#**, developed as a hands-on project to learn and apply core Object-Oriented Programming, **C#** advanced topics and .NET concepts.

The project simulates a simplified football management system: managing teams, players, coaches, and matches, tracking goals, and calculating results — all through an interactive console menu.

## Features
- **Team Management** — create teams with a name, country, type (National/Club), and coach; view all teams
- **Player Management** — add players to a team with a shirt number and position; view a team's squad
- **Match Management** — create matches between two teams, record goals with the scoring player, finish a match, and view results
- **Input Validation** — all user input is validated (empty names, non-numeric input, out-of-range menu choices) so the program never crashes on bad input

## Concepts Applied

This project was built specifically to practice:

- **Inheritance** — `Person` as an abstract base class for `Player` and `Coach`
- **Composition & Aggregation** — a `Team` owns its `Players`, a `Match` owns its `Goals`
- **Encapsulation & Validation** — business rules enforced inside constructors (e.g. a team can't play itself, a shirt number must be valid, a player can't be added twice)
- **Delegates & Events** — `PlayerAdded`, `PlayerRemoved`, and `MatchFinished` events using `Action<T>`
- **LINQ** — `Where`, `Count`, `GroupBy`, `FirstOrDefault`, and query syntax used for filtering players and calculating the tournament's top scorer
- **Enums** — used for `Position`, `Continent`, `TeamType`, and `TeamGoal`

## Project Structure

```
Football_Mangment_Project/
├── Models/
│   ├── Person.cs        (abstract base class)
│   ├── Player.cs
│   ├── Coach.cs
│   ├── Country.cs
│   ├── Team.cs
│   ├── Tournament.cs
│   ├── Match.cs
│   └── Goal.cs
└── Program.cs            (interactive console menu)
```

## Related Project

This project's data model is designed to eventually connect to a real SQL Server database:
 [Football-Management-System-Database](https://github.com/omar-ahmed62/Football-Management-System-Database)


## Getting Started
1. Clone the repository
2. Open `Football_Mangment_Project.slnx` in Visual Studio
3. Make sure .NET 10.0 is installed
4. Build and run the project (`F5`)
5. Follow the on-screen menu to add teams, players, and matches

## Roadmap

- [ ] Expose Tournament / Top Scorer features in the console menu
- [ ] Add Search / Remove Player options
- [ ] Connect to the SQL Server database via ADO.NET / EF Core
