namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTableAndMovieTable : DbMigration
    {
        public override void Up()
        {
            //Sql("DBCC CHECKIDENT (Genres, reseed, 0)");

            Sql("INSERT INTO Genres(ID,Name) VALUES(1,'Comedy')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(2,'Action')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(3,'Family')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(4,'Romance')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(5,'Suspense')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(6,'Thriler')");

           Sql("DBCC CHECKIDENT (MOVIES, reseed, 0)");
            // Movies
            Sql("INSERT INTO MOVIES(Name,GenreID,ReleaseDate,DateAdded,NumberInStock) VALUES('HangOver',1,'2012-01-25','2016-08-28',4)");
            Sql("INSERT INTO MOVIES(Name,GenreID,ReleaseDate,DateAdded,NumberInStock) VALUES('Die hard',2,'2000-01-25','2012-08-28',4)");
            Sql("INSERT INTO MOVIES(Name,GenreID,ReleaseDate,DateAdded,NumberInStock) VALUES('The Terminator',2,'2004-01-25','2010-08-28',4)");
            Sql("INSERT INTO MOVIES(Name,GenreID,ReleaseDate,DateAdded,NumberInStock) VALUES('Toy Story',3,'2011-01-25','2014-08-28',4)");
            Sql("INSERT INTO MOVIES(Name,GenreID,ReleaseDate,DateAdded,NumberInStock) VALUES('Titanic',3,'2008-01-25','2009-08-28',4)");
            Sql("INSERT INTO MOVIES(Name,GenreID,ReleaseDate,DateAdded,NumberInStock) VALUES('Meet Joe Black',3,'2008-01-25','2009-08-28',4)");
        }
        
        public override void Down()
        {
        }
    }
}
