namespace ArtistAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYoutubeUrl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Album_ID", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "Album_ID" });
            RenameColumn(table: "dbo.Songs", name: "Album_ID", newName: "AlbumId");
            AddColumn("dbo.Songs", "Youtube", c => c.String());
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "AlbumId");
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int());
            DropColumn("dbo.Songs", "Youtube");
            RenameColumn(table: "dbo.Songs", name: "AlbumId", newName: "Album_ID");
            CreateIndex("dbo.Songs", "Album_ID");
            AddForeignKey("dbo.Songs", "Album_ID", "dbo.Albums", "ID");
        }
    }
}
