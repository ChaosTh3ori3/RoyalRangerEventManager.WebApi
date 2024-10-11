using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RangerEventManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasePersonEntity",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Surename = table.Column<string>(type: "text", nullable: false),
                    Forname = table.Column<string>(type: "text", nullable: false),
                    TroopNumber = table.Column<int>(type: "integer", nullable: true),
                    TroopName = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePersonEntity", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Concept = table.Column<string>(type: "text", nullable: false),
                    StatDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreCampStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PreCampEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AfterCampStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AfterCampEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.CampId);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_UserEntity_BasePersonEntity_PersonId",
                        column: x => x.PersonId,
                        principalTable: "BasePersonEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileEntity",
                columns: table => new
                {
                    FileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentFileId = table.Column<long>(type: "bigint", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    FolderName = table.Column<string>(type: "text", nullable: true),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntity", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileEntity_FileEntity_ParentFileId",
                        column: x => x.ParentFileId,
                        principalTable: "FileEntity",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationEntity",
                columns: table => new
                {
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Laditude = table.Column<double>(type: "double precision", nullable: false),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEntity", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_LocationEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantEntity",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    ContributionPaid = table.Column<bool>(type: "boolean", nullable: false),
                    ContributionPaidDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CanSwim = table.Column<bool>(type: "boolean", nullable: false),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantEntity", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_ParticipantEntity_BasePersonEntity_PersonId",
                        column: x => x.PersonId,
                        principalTable: "BasePersonEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationEntity",
                columns: table => new
                {
                    RegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullNameFields = table.Column<bool>(type: "boolean", nullable: false),
                    GenderField = table.Column<bool>(type: "boolean", nullable: false),
                    BirthDateField = table.Column<bool>(type: "boolean", nullable: false),
                    TroopFields = table.Column<bool>(type: "boolean", nullable: false),
                    ContractField = table.Column<bool>(type: "boolean", nullable: false),
                    FirstContactPersonFields = table.Column<bool>(type: "boolean", nullable: false),
                    SecondContactPersonFields = table.Column<bool>(type: "boolean", nullable: false),
                    AddressFields = table.Column<bool>(type: "boolean", nullable: false),
                    MedicationFields = table.Column<bool>(type: "boolean", nullable: false),
                    AllergiesFields = table.Column<bool>(type: "boolean", nullable: false),
                    DiseasesFields = table.Column<bool>(type: "boolean", nullable: false),
                    HealthInsuranceField = table.Column<bool>(type: "boolean", nullable: false),
                    VaccinationsField = table.Column<bool>(type: "boolean", nullable: false),
                    CanSwimField = table.Column<bool>(type: "boolean", nullable: false),
                    CloatingSizeField = table.Column<bool>(type: "boolean", nullable: false),
                    CoastField = table.Column<bool>(type: "boolean", nullable: false),
                    CostFieldValue = table.Column<float>(type: "real", nullable: false),
                    FirstAdditionalField = table.Column<bool>(type: "boolean", nullable: false),
                    FirstAdditionalFieldName = table.Column<string>(type: "text", nullable: true),
                    SecondAdditionalField = table.Column<bool>(type: "boolean", nullable: false),
                    SecondAdditionalFieldName = table.Column<string>(type: "text", nullable: true),
                    ThirdAdditionalField = table.Column<bool>(type: "boolean", nullable: false),
                    ThirdAdditionalFieldName = table.Column<string>(type: "text", nullable: true),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationEntity", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_RegistrationEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampEmployees",
                columns: table => new
                {
                    CampEntity1CampId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeesPersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampEmployees", x => new { x.CampEntity1CampId, x.EmployeesPersonId });
                    table.ForeignKey(
                        name: "FK_CampEmployees_Camps_CampEntity1CampId",
                        column: x => x.CampEntity1CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampEmployees_UserEntity_EmployeesPersonId",
                        column: x => x.EmployeesPersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampLeaders",
                columns: table => new
                {
                    CampEntityCampId = table.Column<long>(type: "bigint", nullable: false),
                    LeadersPersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampLeaders", x => new { x.CampEntityCampId, x.LeadersPersonId });
                    table.ForeignKey(
                        name: "FK_CampLeaders_Camps_CampEntityCampId",
                        column: x => x.CampEntityCampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampLeaders_UserEntity_LeadersPersonId",
                        column: x => x.LeadersPersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeadlineEntity",
                columns: table => new
                {
                    DeadlineId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ExpiredDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResponsiblePersonId = table.Column<long>(type: "bigint", nullable: false),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadlineEntity", x => x.DeadlineId);
                    table.ForeignKey(
                        name: "FK_DeadlineEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeadlineEntity_UserEntity_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEntity",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ResponsiblePersonId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntity", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_EventEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEntity_UserEntity_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinanceEntity",
                columns: table => new
                {
                    FinanceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResponsiblePersonId = table.Column<long>(type: "bigint", nullable: false),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceEntity", x => x.FinanceId);
                    table.ForeignKey(
                        name: "FK_FinanceEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanceEntity_UserEntity_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialEntity",
                columns: table => new
                {
                    MaterialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ResponsiblePersonId = table.Column<long>(type: "bigint", nullable: false),
                    TroopNumber = table.Column<int>(type: "integer", nullable: false),
                    TroopName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PlaceToUse = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    AmountUnit = table.Column<string>(type: "text", nullable: false),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialEntity", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_MaterialEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialEntity_UserEntity_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntity",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ResponsiblePersonId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ToBeDoneDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false),
                    DoneDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CampId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntity", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskEntity_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEntity_UserEntity_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "UserEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersonEntity",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    ParticipantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersonEntity", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_ContactPersonEntity_BasePersonEntity_PersonId",
                        column: x => x.PersonId,
                        principalTable: "BasePersonEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPersonEntity_ParticipantEntity_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "ParticipantEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeculiarityEntity",
                columns: table => new
                {
                    PeculiarityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ToBeDoneDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false),
                    DoneDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ParticipantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeculiarityEntity", x => x.PeculiarityId);
                    table.ForeignKey(
                        name: "FK_PeculiarityEntity_ParticipantEntity_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "ParticipantEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingEntity",
                columns: table => new
                {
                    BookingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BankAccount = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IncommingFinanceId = table.Column<long>(type: "bigint", nullable: true),
                    OutgoingFinanceId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntity", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingEntity_FinanceEntity_IncommingFinanceId",
                        column: x => x.IncommingFinanceId,
                        principalTable: "FinanceEntity",
                        principalColumn: "FinanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingEntity_FinanceEntity_OutgoingFinanceId",
                        column: x => x.OutgoingFinanceId,
                        principalTable: "FinanceEntity",
                        principalColumn: "FinanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntity_IncommingFinanceId",
                table: "BookingEntity",
                column: "IncommingFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntity_OutgoingFinanceId",
                table: "BookingEntity",
                column: "OutgoingFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CampEmployees_EmployeesPersonId",
                table: "CampEmployees",
                column: "EmployeesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CampLeaders_LeadersPersonId",
                table: "CampLeaders",
                column: "LeadersPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonEntity_ParticipantId",
                table: "ContactPersonEntity",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_DeadlineEntity_CampId",
                table: "DeadlineEntity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_DeadlineEntity_ResponsiblePersonId",
                table: "DeadlineEntity",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntity_CampId",
                table: "EventEntity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntity_ResponsiblePersonId",
                table: "EventEntity",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_CampId",
                table: "FileEntity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_ParentFileId",
                table: "FileEntity",
                column: "ParentFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceEntity_CampId",
                table: "FinanceEntity",
                column: "CampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinanceEntity_ResponsiblePersonId",
                table: "FinanceEntity",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEntity_CampId",
                table: "LocationEntity",
                column: "CampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEntity_CampId",
                table: "MaterialEntity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialEntity_ResponsiblePersonId",
                table: "MaterialEntity",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEntity_CampId",
                table: "ParticipantEntity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_PeculiarityEntity_ParticipantId",
                table: "PeculiarityEntity",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEntity_CampId",
                table: "RegistrationEntity",
                column: "CampId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntity_CampId",
                table: "TaskEntity",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntity_ResponsiblePersonId",
                table: "TaskEntity",
                column: "ResponsiblePersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEntity");

            migrationBuilder.DropTable(
                name: "CampEmployees");

            migrationBuilder.DropTable(
                name: "CampLeaders");

            migrationBuilder.DropTable(
                name: "ContactPersonEntity");

            migrationBuilder.DropTable(
                name: "DeadlineEntity");

            migrationBuilder.DropTable(
                name: "EventEntity");

            migrationBuilder.DropTable(
                name: "FileEntity");

            migrationBuilder.DropTable(
                name: "LocationEntity");

            migrationBuilder.DropTable(
                name: "MaterialEntity");

            migrationBuilder.DropTable(
                name: "PeculiarityEntity");

            migrationBuilder.DropTable(
                name: "RegistrationEntity");

            migrationBuilder.DropTable(
                name: "TaskEntity");

            migrationBuilder.DropTable(
                name: "FinanceEntity");

            migrationBuilder.DropTable(
                name: "ParticipantEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropTable(
                name: "Camps");

            migrationBuilder.DropTable(
                name: "BasePersonEntity");
        }
    }
}
