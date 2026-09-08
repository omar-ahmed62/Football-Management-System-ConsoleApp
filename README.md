# Football Management System
A console-based football management system built in **C#**, developed as a hands-on project to learn and apply core Object-Oriented Programming, **C#** advanced topics and .NET concepts — including ADO.NET and SQL Server integration.

The project simulates a simplified football management system: managing teams, players, coaches, and matches, tracking goals, and calculating results — all through an interactive console menu.

## Features
- **Team Management** — create teams with a name, country, type (National/Club), and coach; view all teams
- **Player Management** — add players to a team with a shirt number and position; view a team's squad
- **Match Management** — create matches between two teams, record goals with the scoring player, finish a match, and view results
- **Input Validation** — all user input is validated (empty names, non-numeric input, out-of-range menu choices) so the program never crashes on bad input
- **Database Persistence** — teams and players are saved to a SQL Server database using data access layer

## Concepts Applied

This project was built specifically to practice:

- **Inheritance** — `Person` as an abstract base class for `Player` and `Coach`
- **Composition & Aggregation** — a `Team` owns its `Players`, a `Match` owns its `Goals`
- **Encapsulation & Validation** — business rules enforced inside constructors (e.g. a team can't play itself, a shirt number must be valid, a player can't be added twice)
- **Delegates & Events** — `PlayerAdded`, `PlayerRemoved`, and `MatchFinished` events using `Action<T>`
- **LINQ** — `Where`, `Count`, `GroupBy`, `FirstOrDefault`, and query syntax used for filtering players and calculating the tournament's top scorer
- **Enums** — used for `Position`, `Continent`, `TeamType`, and `TeamGoal`
- **ADO.NET** — `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, and parameterized queries to safely read/write data and prevent SQL injection

## Architecture

This project follows a simplified **3-Tier Architecture**:

| Layer | Responsibility | Files |
|---|---|---|
| **Presentation Layer** | Interactive console menu, user input/output | `Program.cs` |
| **Business Logic Layer** | Validation and enforcing business rules | `Business/` (`Team_Business`, `Player_Business`, `Country_Business`, `Coach_Business`) |
| **Data Access Layer** | Direct SQL Server communication via ADO.NET | `Data_Access/` (`DB_Layer`) |

Each layer only communicates with the layer directly below it — the console never talks to the database directly.
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
├── Data_Access/
│   └── DB_Layer.cs      (ADO.NET connection, CRUD operations)
├── Business/
│   ├── Country_Business.cs
│   ├── Coach_Business.cs
│   ├── Team_Business.cs
│   └── Player_Business.cs
├── DataBase/
│   └── FootballConsoleDB_Schema.sql   (database creation script)
└── Program.cs            (interactive console menu)
```

## Database Setup

1. Open SQL Server Management Studio
2. Run the script in `Football_Mangment_Project/DataBase/FootballConsoleDB_Schema.sql` to create the `FootballConsoleDB` database and its tables
3. The connection string in `DB_Layer.cs` uses `Data Source=.` (local default SQL Server instance) — update it if your instance name is different

## Getting Started
1. Clone the repository
2. Run the database setup steps above
3. Open `Football_Mangment_Project.slnx` in Visual Studio
4. Make sure .NET 10.0 is installed
5. Build and run the project (`F5`)
6. Follow the on-screen menu to add teams, players, and matches

## Roadmap
- [x] Connect Team and Player creation to a SQL Server database via ADO.NET
- [ ] Expose Tournament / Top Scorer features in the console menu
- [ ] Add Search / Remove Player options
- [ ] Save Match and Goal data to the database
- [ ] Explore Entity Framework Core as an alternative to raw ADO.NET
