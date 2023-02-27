namespace CadastralPersistence;

public class AppDbContext : IdentityDbContext, IAppDbContext
{
    public DbSet<Document> Documents { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreator != null)
        {
            if (!databaseCreator.CanConnect()) databaseCreator.Create();
            if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var ADMIN_ID = Guid.NewGuid().ToString();
        var ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        var MANAGER_ROLE_ID = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = ADMIN_ROLE_ID
            },
            new IdentityRole
            {
                Id = MANAGER_ROLE_ID,
                Name = "manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = MANAGER_ROLE_ID
            });

        var user = new AppUser
        {
            Id = ADMIN_ID,
            Email = "goncarovdaniil3@gmail.com",
            NormalizedEmail = "GONCAROVDANIIL3@GMAIL.COM",
            UserName = "goncarovdaniil3@gmail.com",
            NormalizedUserName = "GONCAROVDANIIL3@GMAIL.COM",
            EmailConfirmed = true
        };

        var ph = new PasswordHasher<AppUser>();
        user.PasswordHash = ph.HashPassword(user,"password"); // change password

        builder.Entity<AppUser>()
            .HasData(user);

        builder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID,
            });
    }
}