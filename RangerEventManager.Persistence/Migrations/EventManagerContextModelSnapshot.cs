﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RangerEventManager.Persistence;

#nullable disable

namespace RangerEventManager.Persistence.Migrations
{
    [DbContext(typeof(EventManagerContext))]
    partial class EventManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CampEntityUserEntity", b =>
                {
                    b.Property<long>("CampEntityCampId")
                        .HasColumnType("bigint");

                    b.Property<long>("LeadersPersonId")
                        .HasColumnType("bigint");

                    b.HasKey("CampEntityCampId", "LeadersPersonId");

                    b.HasIndex("LeadersPersonId");

                    b.ToTable("CampLeaders", (string)null);
                });

            modelBuilder.Entity("CampEntityUserEntity1", b =>
                {
                    b.Property<long>("CampEntity1CampId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeesPersonId")
                        .HasColumnType("bigint");

                    b.HasKey("CampEntity1CampId", "EmployeesPersonId");

                    b.HasIndex("EmployeesPersonId");

                    b.ToTable("CampEmployees", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Base.BasePersonEntity", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PersonId"));

                    b.Property<string>("Forname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("TroopName")
                        .HasColumnType("text");

                    b.Property<int?>("TroopNumber")
                        .HasColumnType("integer");

                    b.HasKey("PersonId");

                    b.ToTable("BasePersonEntity", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.BookingEntity", b =>
                {
                    b.Property<long>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BookingId"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("BankAccount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("IncommingFinanceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("OutgoingFinanceId")
                        .HasColumnType("bigint");

                    b.HasKey("BookingId");

                    b.HasIndex("IncommingFinanceId");

                    b.HasIndex("OutgoingFinanceId");

                    b.ToTable("BookingEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.CampEntity", b =>
                {
                    b.Property<long>("CampId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CampId"));

                    b.Property<DateTime?>("AfterCampEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("AfterCampStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Archived")
                        .HasColumnType("boolean");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Number"));

                    b.Property<DateTime?>("PreCampEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("PreCampStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StatDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CampId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.DeadlineEntity", b =>
                {
                    b.Property<long>("DeadlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DeadlineId"));

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiredDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ResponsiblePersonId")
                        .HasColumnType("bigint");

                    b.HasKey("DeadlineId");

                    b.HasIndex("CampId");

                    b.HasIndex("ResponsiblePersonId");

                    b.ToTable("DeadlineEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.EventEntity", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("EventId"));

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ResponsiblePersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("EventId");

                    b.HasIndex("CampId");

                    b.HasIndex("ResponsiblePersonId");

                    b.ToTable("EventEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.FileEntity", b =>
                {
                    b.Property<long>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("FileId"));

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<string>("FolderName")
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<long?>("ParentFileId")
                        .HasColumnType("bigint");

                    b.HasKey("FileId");

                    b.HasIndex("CampId");

                    b.HasIndex("ParentFileId");

                    b.ToTable("FileEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.FinanceEntity", b =>
                {
                    b.Property<long>("FinanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("FinanceId"));

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<long>("ResponsiblePersonId")
                        .HasColumnType("bigint");

                    b.HasKey("FinanceId");

                    b.HasIndex("CampId")
                        .IsUnique();

                    b.HasIndex("ResponsiblePersonId");

                    b.ToTable("FinanceEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.LocationEntity", b =>
                {
                    b.Property<long>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("LocationId"));

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<double>("Laditude")
                        .HasColumnType("double precision");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LocationId");

                    b.HasIndex("CampId")
                        .IsUnique();

                    b.ToTable("LocationEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.MaterialEntity", b =>
                {
                    b.Property<long>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MaterialId"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("AmountUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceToUse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ResponsiblePersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("TroopName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TroopNumber")
                        .HasColumnType("integer");

                    b.HasKey("MaterialId");

                    b.HasIndex("CampId");

                    b.HasIndex("ResponsiblePersonId");

                    b.ToTable("MaterialEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.PeculiarityEntity", b =>
                {
                    b.Property<long>("PeculiarityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PeculiarityId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DoneDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ToBeDoneDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PeculiarityId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("PeculiarityEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.RegistrationEntity", b =>
                {
                    b.Property<long>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RegistrationId"));

                    b.Property<bool>("AddressFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("AllergiesFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("BirthDateField")
                        .HasColumnType("boolean");

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<bool>("CanSwimField")
                        .HasColumnType("boolean");

                    b.Property<bool>("CloatingSizeField")
                        .HasColumnType("boolean");

                    b.Property<bool>("CoastField")
                        .HasColumnType("boolean");

                    b.Property<bool>("ContractField")
                        .HasColumnType("boolean");

                    b.Property<float>("CostFieldValue")
                        .HasColumnType("real");

                    b.Property<bool>("DiseasesFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("FirstAdditionalField")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstAdditionalFieldName")
                        .HasColumnType("text");

                    b.Property<bool>("FirstContactPersonFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("FullNameFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("GenderField")
                        .HasColumnType("boolean");

                    b.Property<bool>("HealthInsuranceField")
                        .HasColumnType("boolean");

                    b.Property<bool>("MedicationFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("SecondAdditionalField")
                        .HasColumnType("boolean");

                    b.Property<string>("SecondAdditionalFieldName")
                        .HasColumnType("text");

                    b.Property<bool>("SecondContactPersonFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("ThirdAdditionalField")
                        .HasColumnType("boolean");

                    b.Property<string>("ThirdAdditionalFieldName")
                        .HasColumnType("text");

                    b.Property<bool>("TroopFields")
                        .HasColumnType("boolean");

                    b.Property<bool>("VaccinationsField")
                        .HasColumnType("boolean");

                    b.HasKey("RegistrationId");

                    b.HasIndex("CampId")
                        .IsUnique();

                    b.ToTable("RegistrationEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.TaskEntity", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TaskId"));

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DoneDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ResponsiblePersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ToBeDoneDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TaskId");

                    b.HasIndex("CampId");

                    b.HasIndex("ResponsiblePersonId");

                    b.ToTable("TaskEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.ContactPersonEntity", b =>
                {
                    b.HasBaseType("RangerEventManager.Persistence.Entities.Base.BasePersonEntity");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.HasIndex("ParticipantId");

                    b.ToTable("ContactPersonEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.ParticipantEntity", b =>
                {
                    b.HasBaseType("RangerEventManager.Persistence.Entities.Base.BasePersonEntity");

                    b.Property<long>("CampId")
                        .HasColumnType("bigint");

                    b.Property<bool>("CanSwim")
                        .HasColumnType("boolean");

                    b.Property<bool>("ContributionPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ContributionPaidDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasIndex("CampId");

                    b.ToTable("ParticipantEntity", (string)null);
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.User.UserEntity", b =>
                {
                    b.HasBaseType("RangerEventManager.Persistence.Entities.Base.BasePersonEntity");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("UserEntity", (string)null);
                });

            modelBuilder.Entity("CampEntityUserEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", null)
                        .WithMany()
                        .HasForeignKey("CampEntityCampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("LeadersPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampEntityUserEntity1", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", null)
                        .WithMany()
                        .HasForeignKey("CampEntity1CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("EmployeesPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.BookingEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.FinanceEntity", "IncommingFinance")
                        .WithMany("IncommingBookings")
                        .HasForeignKey("IncommingFinanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.FinanceEntity", "OutgoingFinance")
                        .WithMany("OutgoingBookings")
                        .HasForeignKey("OutgoingFinanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("IncommingFinance");

                    b.Navigation("OutgoingFinance");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.DeadlineEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithMany("Deadlines")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", "ResponsiblePerson")
                        .WithMany()
                        .HasForeignKey("ResponsiblePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("ResponsiblePerson");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.EventEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithMany("Events")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", "ResponsiblePerson")
                        .WithMany()
                        .HasForeignKey("ResponsiblePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("ResponsiblePerson");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.FileEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithMany("Files")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.FileEntity", "ParentFile")
                        .WithMany()
                        .HasForeignKey("ParentFileId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Camp");

                    b.Navigation("ParentFile");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.FinanceEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithOne("Finance")
                        .HasForeignKey("RangerEventManager.Persistence.Entities.Camp.FinanceEntity", "CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", "ResponsiblePerson")
                        .WithMany()
                        .HasForeignKey("ResponsiblePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("ResponsiblePerson");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.LocationEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithOne("Location")
                        .HasForeignKey("RangerEventManager.Persistence.Entities.Camp.LocationEntity", "CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.MaterialEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithMany("Materials")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", "ResponsiblePerson")
                        .WithMany()
                        .HasForeignKey("ResponsiblePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("ResponsiblePerson");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.PeculiarityEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.ParticipantEntity", "Participant")
                        .WithMany("Peculiarities")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.RegistrationEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithOne("Registration")
                        .HasForeignKey("RangerEventManager.Persistence.Entities.Camp.RegistrationEntity", "CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.TaskEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithMany("Tasks")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.User.UserEntity", "ResponsiblePerson")
                        .WithMany()
                        .HasForeignKey("ResponsiblePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("ResponsiblePerson");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.ContactPersonEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.ParticipantEntity", "Participant")
                        .WithMany("ContactPersons")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.Base.BasePersonEntity", null)
                        .WithOne()
                        .HasForeignKey("RangerEventManager.Persistence.Entities.Camp.ContactPersonEntity", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.ParticipantEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Camp.CampEntity", "Camp")
                        .WithMany("Participants")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangerEventManager.Persistence.Entities.Base.BasePersonEntity", null)
                        .WithOne()
                        .HasForeignKey("RangerEventManager.Persistence.Entities.Camp.ParticipantEntity", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.User.UserEntity", b =>
                {
                    b.HasOne("RangerEventManager.Persistence.Entities.Base.BasePersonEntity", null)
                        .WithOne()
                        .HasForeignKey("RangerEventManager.Persistence.Entities.User.UserEntity", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.CampEntity", b =>
                {
                    b.Navigation("Deadlines");

                    b.Navigation("Events");

                    b.Navigation("Files");

                    b.Navigation("Finance");

                    b.Navigation("Location");

                    b.Navigation("Materials");

                    b.Navigation("Participants");

                    b.Navigation("Registration");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.FinanceEntity", b =>
                {
                    b.Navigation("IncommingBookings");

                    b.Navigation("OutgoingBookings");
                });

            modelBuilder.Entity("RangerEventManager.Persistence.Entities.Camp.ParticipantEntity", b =>
                {
                    b.Navigation("ContactPersons");

                    b.Navigation("Peculiarities");
                });
#pragma warning restore 612, 618
        }
    }
}
