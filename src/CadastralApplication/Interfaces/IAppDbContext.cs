namespace CadastralApplication.Interfaces;

public interface IAppDbContext
{
    DbSet<Document> Documents { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}