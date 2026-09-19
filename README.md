# Football Management System
A console-based football management system built in **C#**, developed as a hands-on project to learn and apply core Object-Oriented Programming, **C#** advanced topics and .NET concepts — including ADO.NET, Entity Framework Core and SQL Server integration.

The project simulates a simplified football management system: managing teams, players, coaches, and matches, tracking goals, and calculating results — all through an interactive console menu.

## Features
- **Team Management** — create teams with a name, country, type (National/Club), and coach; view all teams
- **Player Management** — add players to a team with a shirt number and position; view a team's squad
- **Match Management** — create matches between two teams, record goals with the scoring player, finish a match, and view results
- **Input Validation** — all user input is validated (empty names, non-numeric input, out-of-range menu choices) so the program never crashes on bad input
- **Database Persistence** — teams and players are saved to a SQL Server database using data access layer and EF CORE

## Concepts Applied

This project was built specifically to practice:

- **Inheritance** — `Person` as an abstract base class for `Player` and `Coach`
- **Composition & Aggregation** — a `Team` owns its `Players`, a `Match` owns its `Goals`
- **Encapsulation & Validation** — business rules enforced inside constructors (e.g. a team can't play itself, a shirt number must be valid, a player can't be added twice)
- **Delegates & Events** — `PlayerAdded`, `PlayerRemoved`, and `MatchFinished` events using `Action<T>`
- **LINQ** — `Where`, `Count`, `GroupBy`, `FirstOrDefault`, and query syntax used for filtering players and calculating the tournament's top scorer
- **Enums** — used for `Position`, `Continent`, `TeamType`, and `TeamGoal`
- **ADO.NET** — `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, and parameterized queries to safely read/write data and prevent SQL injection
- **Entity Framework Core** — `Migrations`, `DBContext`, `DBSet`


## ADO.NET vs. EF Core — Two Complete Implementations
 
This project exists in **two parallel, fully working versions**, kept in separate Git branches, to compare raw ADO.NET against an ORM (EF Core) hands-on rather than just reading about the difference.
 
| | **`main` branch** | **`ef-core-version` branch** |
|---|---|---|
| **Data access** | Raw ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) | Entity Framework Core (Code-First) |
| **Database** | `FootballConsoleDB` | `FootballEFCoreDB` (separate DB) |
| **Business layer** | Explicit `Business/` classes (`Team_Business`, `Player_Business`, etc.) hand-writing every SQL statement with `SqlParameter` | No separate Business layer — LINQ queries against the `DbContext` directly (e.g `context.Countries.FirstOrDefault(c => c.CountryName == name)`) |
| **Duplicate/lookup logic** | Manual "check-then-add" pattern calling `GetID()` before every insert | Same logic, but expressed as LINQ (`FirstOrDefault`, `.Include()`) instead of raw SQL strings |
| **Relationships** | Foreign keys only — no navigation, resolved manually by ID everywhere | Real navigation properties (`Team.Coach`, `Match.HomeTeam`, `Goal.Scorer`, etc.), configured via Fluent API in `OnModelCreating` |
| **Schema creation** | Hand-written `.sql` script (`FootballConsoleDB_Schema.sql`) | EF Core Migrations (`Add-Migration`, `Update-Database`) generated from the C# model |
| **Getting entities from the DB** | Read into a `DataTable`, then manually mapped field-by-field | Entities materialized directly as C# objects by EF Core |

### What building both versions actually taught
 
- **How much boilerplate an ORM removes** — the entire `Business/` layer (4 classes, each repeating the same connection/parameter/command pattern) disappears in the EF Core version, replaced by a few lines of LINQ per operation.
- **Relationship configuration is still your job either way** — EF Core didn't remove the need to *think* about the schema (one-to-one Team↔Coach, `DeleteBehavior.NoAction` on Match's two Team foreign keys to avoid SQL Server's multiple-cascade-path error). It just moved that thinking from SQL `FOREIGN KEY` clauses into C# Fluent API calls.
- **Raw SQL still has its place** — for simple, fully-controlled scenarios (a small console app talking to one predictable schema), ADO.NET is completely viable and arguably easier to reason about line-by-line. EF Core's real payoff shows up as the domain model grows and relationships multiply.

## Architecture in ADO.NET

This project follows a simplified **3-Tier Architecture**:

| Layer | Responsibility | Files |
|---|---|---|
| **Presentation Layer** | Interactive console menu, user input/output | `Program.cs` |
| **Business Logic Layer** | Validation and enforcing business rules | `Business/` (`Team_Business`, `Player_Business`, `Country_Business`, `Coach_Business`) |
| **Data Access Layer** | Direct SQL Server communication via ADO.NET | `Data_Access/` (`DB_Layer`) |

Each layer only communicates with the layer directly below it — the console never talks to the database directly.


## Project Structure in **`main` branch**

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

## Project Structure in **`ef-core-version` branch**

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
│
│── Context.cs
└── Program.cs            (interactive console menu)
```

 
### Branches at a glance
 
- [`main`](../../tree/main) — the ADO.NET version (actively documented as the "primary" version in this README)
- [`ef-core-version`](../../tree/ef-core-version) — the complete EF Core rewrite described above
  
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
- [x] Save Match and Goal data to the database
- [x] Explore Entity Framework Core as an alternative to raw ADO.NET
- [ ] Expose Tournament / Top Scorer features in the console menu
- [ ] Add Search / Remove Player options
