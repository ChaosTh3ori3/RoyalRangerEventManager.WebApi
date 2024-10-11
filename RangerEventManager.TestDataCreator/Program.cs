using Microsoft.EntityFrameworkCore;
using RangerEventManager.Persistence;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.Persistence.Entities.User;

public class Program
{
 
    public static void Main(params string[] args)
    {
        var contextOptions = new DbContextOptionsBuilder<EventManagerContext>()
            .UseNpgsql("User ID=postgres;Password=password;Server=localhost;Port=5432;Database=RREM")
            .Options;
    
        var context = new EventManagerContext(contextOptions);

        var type = "";
        while (type != "end")
        {
            Console.WriteLine("What do you want to create? Camp => camp | User => user | end" );
            type = Console.ReadLine();

            switch (type)
            {
                case "camp": AddCamp(context); break;
                case "user": AddUser(context); break;
            }
            context.SaveChanges();
        }
    }

    private static void AddCamp(EventManagerContext context)
    {
        var user = context.Users.First();

        var camp = new CampEntity()
        {
            Concept = "",
            Name = "Name Camp",
            StatDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow,
            Leaders = new List<UserEntity>()
            {
                user
            }
        };
        
        Console.WriteLine("add something? y - n");

        var adding = Console.ReadLine();
        while (adding != "n")
        {
            Console.WriteLine("employee, participant, location, deadline, task, event, file, material, finance, registration");
        
            var addSomething = Console.ReadLine();

            if (addSomething == "full")
            {
                camp.Employees ??= new List<UserEntity>();

                camp.Employees.Add(user);
                var contactPerson = new ContactPersonEntity()
                {
                    Forname = "Name",
                    Surename = "Surename",
                    Mail = "mail@mail.com"
                };
                
                camp.Participants ??= new List<ParticipantEntity>();
                
                camp.Participants.Add(new ParticipantEntity()
                {
                    Forname = "Name",
                    Surename = "Surename",
                    Mail = "mail@mail.com",
                    TroopName = "Troop Name",
                    TroopNumber = 1234,
                    CanSwim = true,
                    ContactPersons = new List<ContactPersonEntity>(){contactPerson},
                    Peculiarities = new List<PeculiarityEntity>()
                    {
                        new PeculiarityEntity()
                        {
                            Name = "Peculiaritie",
                            Description = "Peculiaritie Description",
                            ToBeDoneDate = DateTime.UtcNow,
                        }
                    }
                });
                camp.Location = new LocationEntity()
                {
                    Name = "Name",
                    Laditude = 123.4,
                    Longitude = 123.4,
                    Link = "www.a.de"
                };
                camp.Deadlines ??= new List<DeadlineEntity>();
                
                camp.Deadlines.Add(new DeadlineEntity()
                {
                    Name = "Name",
                    Description = "Deadline Description",
                    ExpiredDateTime = DateTime.UtcNow,
                    ResponsiblePerson = user
                });
                camp.Tasks ??= new List<TaskEntity>();

                camp.Tasks.Add(new TaskEntity()
                {
                    Name = "Name",
                    ResponsiblePerson = user,
                    Description = "Task Description",
                    ToBeDoneDateTime = DateTime.UtcNow,
                });
                
                camp.Events ??= new List<EventEntity>();

                camp.Events.Add(new EventEntity()
                {
                    Name = "Name",
                    Description = "Event Description",
                    ResponsiblePerson = user,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow

                });
                camp.Files ??= new List<FileEntity>();
                
                Console.WriteLine("File or folder?");
                var fileOrFolder = Console.ReadLine();

                camp.Files.Add(new FileEntity()
                {
                    Link = "test"
                });
                camp.Files.Add(new FileEntity()
                {
                    FolderName = "test"
                });
                camp.Materials ??= new List<MaterialEntity>();
                
                camp.Materials.Add(new MaterialEntity()
                {
                    Name = "Name",
                    Description = "Material Description",
                    ResponsiblePerson = user ,
                    TroopName = "Troop Name",
                    TroopNumber = 1234,
                    Amount = 1,
                    AmountUnit = "KG",
                    PlaceToUse = "Küche"
                });
                camp.Finance = new FinanceEntity()
                {
                    ResponsiblePerson = user,
                    IncommingBookings = new List<BookingEntity>()
                    {
                        new BookingEntity()
                        {
                            BookingDate = DateTime.UtcNow,
                            Amount = 100.1,
                            Description = "Booking Description",
                            Name = "Booking Name",
                            BankAccount = "Bank Account"
                        }
                    },
                    OutgoingBookings = new List<BookingEntity>()
                    {
                        new BookingEntity()
                        {
                            BookingDate = DateTime.UtcNow,
                            Amount = 1.1,
                            Description = "Booking Description",
                            Name = "Booking Name",
                            BankAccount = "Bank Account"
                        }
                    }
                };
                camp.Registration = new RegistrationEntity();

            }
            if (addSomething is "employee")
            {
                camp.Employees ??= new List<UserEntity>();

                camp.Employees.Add(user);
            } else if (addSomething is "participant")
            {
                var contactPerson = new ContactPersonEntity()
                {
                    Forname = "Name",
                    Surename = "Surename",
                    Mail = "mail@mail.com"
                };
                
                camp.Participants ??= new List<ParticipantEntity>();
                
                camp.Participants.Add(new ParticipantEntity()
                {
                    Forname = "Name",
                    Surename = "Surename",
                    Mail = "mail@mail.com",
                    TroopName = "Troop Name",
                    TroopNumber = 1234,
                    CanSwim = true,
                    ContactPersons = new List<ContactPersonEntity>(){contactPerson},
                    Peculiarities = new List<PeculiarityEntity>()
                    {
                        new PeculiarityEntity()
                        {
                            Name = "Peculiaritie",
                            Description = "Peculiaritie Description",
                            ToBeDoneDate = DateTime.UtcNow,
                        }
                    }
                });
            } else if (addSomething is "location")
            {
                camp.Location = new LocationEntity()
                {
                    Name = "Name",
                    Laditude = 123.4,
                    Longitude = 123.4,
                    Link = "www.a.de"
                };
            } else if (addSomething is "deadline")
            {
                camp.Deadlines ??= new List<DeadlineEntity>();
                
                camp.Deadlines.Add(new DeadlineEntity()
                {
                    Name = "Name",
                    Description = "Deadline Description",
                    ExpiredDateTime = DateTime.UtcNow,
                    ResponsiblePerson = user
                });
            }else if (addSomething is "task")
            {
                camp.Tasks ??= new List<TaskEntity>();

                camp.Tasks.Add(new TaskEntity()
                {
                    Name = "Name",
                    ResponsiblePerson = user,
                    Description = "Task Description",
                    ToBeDoneDateTime = DateTime.UtcNow,
                });
            }else if (addSomething is "event")
            {
                camp.Events ??= new List<EventEntity>();

                camp.Events.Add(new EventEntity()
                {
                    Name = "Name",
                    Description = "Event Description",
                    ResponsiblePerson = user,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow

                });
            }else if (addSomething is "file")
            {
                camp.Files ??= new List<FileEntity>();
                
                Console.WriteLine("File or folder?");
                var fileOrFolder = Console.ReadLine();

                if (fileOrFolder == "file")
                {
                    camp.Files.Add(new FileEntity()
                    {
                        Link = "test"
                    });
                }else if (fileOrFolder == "folder")
                {
                    camp.Files.Add(new FileEntity()
                    {
                        FolderName = "test"
                    });
                }
            }else if (addSomething is "material")
            {
                camp.Materials ??= new List<MaterialEntity>();
                
                camp.Materials.Add(new MaterialEntity()
                {
                    Name = "Name",
                    Description = "Material Description",
                    ResponsiblePerson = user ,
                    TroopName = "Troop Name",
                    TroopNumber = 1234,
                    Amount = 1,
                    AmountUnit = "KG",
                    PlaceToUse = "Küche"
                });
            }else if (addSomething is "finance")
            {
                camp.Finance = new FinanceEntity()
                {
                    ResponsiblePerson = user,
                    IncommingBookings = new List<BookingEntity>()
                    {
                        new BookingEntity()
                        {
                            BookingDate = DateTime.UtcNow,
                            Amount = 100.1,
                            Description = "Booking Description",
                            Name = "Booking Name",
                            BankAccount = "Bank Account"
                        }
                    },
                    OutgoingBookings = new List<BookingEntity>()
                    {
                        new BookingEntity()
                        {
                            BookingDate = DateTime.UtcNow,
                            Amount = 1.1,
                            Description = "Booking Description",
                            Name = "Booking Name",
                            BankAccount = "Bank Account"
                        }
                    }
                };
            }else if (addSomething is "registration")
            {
                camp.Registration = new RegistrationEntity();
            }
            
            Console.WriteLine("add something else? y - n");
            adding = Console.ReadLine();
        }
        
        context.Camps.Add(camp);
    }

    private static void AddUser(EventManagerContext context)
    {
        context.Users.Add(
            new UserEntity()
            {
                Forname = "John Doe",
                Surename = "John Doe",
                Mail = "johndoe@gmail.com",
                TroopName = "Troop",
                TroopNumber = 123,
                UserName = "johndoe@gmail.com"
            });
    }
 
}