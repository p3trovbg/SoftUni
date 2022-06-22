namespace _1._2_ADO_NET___Exercise
{
    public class DBQueries
    {
        public const string CREATE_TABLES_MINIONS_DB =
             @"CREATE TABLE Countries 
            (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))
            CREATE TABLE Towns
            (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))
            CREATE TABLE Minions
            (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))
            CREATE TABLE EvilnessFactors
            (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))
            CREATE TABLE Villains
            (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))
            CREATE TABLE MinionsVillains
            (MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

        public const string INSERT_INTO_TABLES_MINIONS_DB =
           @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

             INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)
             
             INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)
             
             INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')
             
             INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)
             
             INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";

        public const string GET_VILLIAN_NAMES =
            @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                FROM Villains AS v 
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
            GROUP BY v.Id, v.Name 
              HAVING COUNT(mv.VillainId) > 3 
            ORDER BY COUNT(mv.VillainId)";

        public const string GET_VILLIAN_WITH_ID = "SELECT Name FROM Villains WHERE Id = @Id";

        public const string GET_MINIONS_WITH_CURRENT_OWNER =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
    }
}
