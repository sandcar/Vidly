namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionPopulateMovies2 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MOVIES");
            Sql("DBCC CHECKIDENT (MOVIES, reseed, 1)");
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
