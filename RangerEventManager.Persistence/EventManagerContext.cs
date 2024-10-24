using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RangerEventManager.Persistence.Entities.Base;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.Persistence.Entities.User;

namespace RangerEventManager.Persistence;

public class EventManagerContext(DbContextOptions<EventManagerContext> options) : DbContext(options)
{
    public DbSet<UserEntity> ResponsiblePersons { get; set; }
    public DbSet<CampEntity> Camps { get; set; }
    public DbSet<DeadlineEntity> Deadlines { get; set; }
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<FileEntity> Files { get; set; }
    public DbSet<FinanceEntity> Finances { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<MaterialEntity> Materials { get; set; }
    public DbSet<ParticipantEntity> Participants { get; set; }
    public DbSet<PeculiarityEntity> Peculiarities { get; set; }
    public DbSet<RegistrationEntity> Registrations { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Person Tables
        modelBuilder.Entity<BasePersonEntity>()
            .ToTable(nameof(BasePersonEntity))
            .HasKey(p => p.PersonId);

        modelBuilder.Entity<ContactPersonEntity>()
            .ToTable(nameof(ContactPersonEntity));

        modelBuilder.Entity<ParticipantEntity>()
            .ToTable(nameof(ParticipantEntity));
        
        //Participants
        modelBuilder.Entity<ParticipantEntity>()
            .HasMany(p => p.ContactPersons)
            .WithOne(c => c.Participant)
            .HasForeignKey(c => c.ParticipantId);
        
        modelBuilder.Entity<ParticipantEntity>()
            .HasMany(p => p.Peculiarities)
            .WithOne(p => p.Participant)
            .HasForeignKey(p => p.ParticipantId);
        
        //Peculiarity
        modelBuilder.Entity<PeculiarityEntity>()
            .ToTable(nameof(PeculiarityEntity))
            .HasKey(p => p.PeculiarityId);
        
        //Locations
        modelBuilder.Entity<LocationEntity>()
            .ToTable(nameof(LocationEntity))
            .HasKey(p => p.LocationId);
        
        //Deadlines
        modelBuilder.Entity<DeadlineEntity>()
            .ToTable(nameof(DeadlineEntity))
            .HasKey(d => d.DeadlineId);
        
        modelBuilder.Entity<DeadlineEntity>()
            .HasOne(t => t.ResponsiblePerson)
            .WithMany()
            .HasForeignKey(t => t.ResponsiblePersonId);
        
        //Tasks
        modelBuilder.Entity<TaskEntity>()
            .ToTable(nameof(TaskEntity))
            .HasKey(t => t.TaskId);
        
        modelBuilder.Entity<TaskEntity>()
            .HasOne(t => t.ResponsiblePerson)
            .WithMany()
            .HasForeignKey(t => t.ResponsiblePersonId);
        
        //Event
        modelBuilder.Entity<EventEntity>()
            .ToTable(nameof(EventEntity))
            .HasKey(e => e.EventId);

        modelBuilder.Entity<EventEntity>()
            .HasOne(e => e.ResponsiblePerson)
            .WithMany()
            .HasForeignKey(e => e.ResponsiblePersonId);
        
        //File
        modelBuilder.Entity<FileEntity>()
            .ToTable(nameof(FileEntity))
            .HasKey(p => p.FileId);
        
        modelBuilder.Entity<FileEntity>()
            .HasOne(f => f.ParentFile)
            .WithMany()
            .HasForeignKey(f => f.ParentFileId)
            .OnDelete(DeleteBehavior.Restrict);
        
        //Material
        modelBuilder.Entity<MaterialEntity>()
            .ToTable(nameof(MaterialEntity))
            .HasKey(p => p.MaterialId);
        
        modelBuilder.Entity<MaterialEntity>()
            .HasOne(m => m.ResponsiblePerson)
            .WithMany()
            .HasForeignKey(m => m.ResponsiblePersonId);
        
        //Finance
        modelBuilder.Entity<FinanceEntity>()
            .ToTable(nameof(FinanceEntity))
            .HasKey(p => p.FinanceId);
        
        modelBuilder.Entity<FinanceEntity>()
            .HasOne(f => f.ResponsiblePerson)
            .WithMany()
            .HasForeignKey(f => f.ResponsiblePersonId);
        
        modelBuilder.Entity<BookingEntity>()
            .HasOne(b => b.IncommingFinance)
            .WithMany(f => f.IncommingBookings)
            .HasForeignKey(b => b.IncommingFinanceId)
            .OnDelete(DeleteBehavior.Restrict);  

        modelBuilder.Entity<BookingEntity>()
            .HasOne(b => b.OutgoingFinance)
            .WithMany(f => f.OutgoingBookings)
            .HasForeignKey(b => b.OutgoingFinanceId)
            .OnDelete(DeleteBehavior.Restrict);  
        
        modelBuilder.Entity<BookingEntity>()
            .ToTable(nameof(BookingEntity))
            .HasKey(r => r.BookingId);
        
        //Registration
        modelBuilder.Entity<RegistrationEntity>()
            .ToTable(nameof(RegistrationEntity))
            .HasKey(r => r.RegistrationId);
        
        //User
        modelBuilder.Entity<UserEntity>()
            .ToTable(nameof(UserEntity));

        //Camp
        ConfigureCampEntity(modelBuilder.Entity<CampEntity>());
    }

    private void ConfigureCampEntity(EntityTypeBuilder<CampEntity> builder)
    {
        builder
            .HasKey(c => c.CampId);

        builder
            .HasMany(c => c.Leaders)
            .WithMany()
            .UsingEntity(j => j.ToTable("CampLeaders"));
        
        builder
            .HasMany(c => c.Employees)
            .WithMany()
            .UsingEntity(j => j.ToTable("CampEmployees"));

        builder
            .HasMany(c => c.Participants)
            .WithOne(p => p.Camp)
            .HasForeignKey(p => p.CampId);
        
        builder.
            HasOne(c => c.Location)
            .WithOne(l => l.Camp)
            .HasForeignKey<LocationEntity>(l => l.CampId);
        
        builder
            .HasMany(c => c.Deadlines)
            .WithOne(d => d.Camp)
            .HasForeignKey(d => d.CampId);

        builder
            .HasMany(c => c.Tasks)
            .WithOne(t => t.Camp)
            .HasForeignKey(t => t.CampId);
        
        builder
            .HasMany(c => c.Events)
            .WithOne(e => e.Camp)
            .HasForeignKey(e => e.CampId);
        
        builder
            .HasMany(c => c.Files)
            .WithOne(f => f.Camp)
            .HasForeignKey(f => f.CampId);

        builder
            .HasMany(c => c.Materials)
            .WithOne(m => m.Camp)
            .HasForeignKey(m => m.CampId);
        
        builder
            .HasOne(c => c.Finance)
            .WithOne(f => f.Camp)
            .HasForeignKey<FinanceEntity>(f => f.CampId);
        
        builder
            .HasOne(c => c.Registration)
            .WithOne(r => r.Camp)
            .HasForeignKey<RegistrationEntity>(r => r.CampId);
    }
}
