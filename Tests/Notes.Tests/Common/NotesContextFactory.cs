using System;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common;

public class NotesContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
    
    public static Guid NotesIdForDelete = Guid.NewGuid();
    public static Guid NotesIdForUpdate = Guid.NewGuid();

    public static NotesDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new NotesDbContext(options);
        context.Database.EnsureCreated();

        context.Notes.AddRange(
            new Note()
            {
                CreationDate = DateTime.Today,
                EditDate = null,
                Details = "Details1",
                Title = "Title1",
                Id = Guid.Parse("CDF2C83B-453F-4F09-9651-79505C9A4B3C"),
                UserId = UserAId
            },
            new Note()
            {
                CreationDate = DateTime.Today,
                EditDate = null,
                Details = "Details2",
                Title = "Title2",
                Id = Guid.Parse("C249B7D3-0585-4336-8D98-B89F2D71817F"),
                UserId = UserBId
            },
            new Note()
            {
                CreationDate = DateTime.Today,
                EditDate = null,
                Details = "Details3",
                Title = "Title3",
                Id = NotesIdForDelete,
                UserId = UserAId,
            },
            new Note()
            {
                CreationDate = DateTime.Today,
                EditDate = null,
                Details = "Details4",
                Title = "Title4",
                Id = NotesIdForUpdate,
                UserId = UserBId,
            });
        
        context.SaveChanges();
        
        return context;
    }

    public static void Destroy(NotesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}