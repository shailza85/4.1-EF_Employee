using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1Employee.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {

        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        // These properties allow the context to be read and written to.
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        // Called when we're configuring a database connection.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            // If we aren't already configured.
            if (!optionsBuilder.IsConfigured)
            {
                // Initialize the connection to a MySQL server.
                optionsBuilder
                    .UseMySql("server=localhost;port=3306;user=root;database=company_employees",
                        // Retreived from PHPMyAdmin under Home > Database Server > Server Version.
                        x => x.ServerVersion("10.4.14-MariaDB"));

                /*
                    Connection strings are used to define an entire connection profile in one string. They are composed of attributes and values separated by semicolons.
                    
                    server=VALUE - Declares the server address for the connection.
                    port=VALUE - Declares the port for the conenction.
                    user=VALUE - Declares the database username for the connection.
                    password=VALUE - Declares that username's password for the connection (if applicable).
                    database=VALUE - Declares the database name to connect to.
                */

                // server=localhost;port=3306;user=root;database=code_first_cars
            }
        }

        // Called when we're doing database migrations, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Address)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PostalCode)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.City)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Location()
                    {
                        ID = -1,
                        Name = "Super Duper Store",
                        Address = "123 Main Street",
                        PostalCode = "T6M5W2",
                        City = "Edmonton"
                    },
                    new Location()
                    {
                        ID = -2,
                        Name = "Awesome Store",
                        Address = "567 Side Street",
                        PostalCode = "T8M2X2",
                        City = "Vancouver"
                    },
                    new Location()
                    {
                        ID = -3,
                        Name = "Corporate Headquarters",
                        Address = "246 Boulevard Street",
                        PostalCode = "T2Y8Z2",
                        City = "Edmonton"
                    },
                    new Location()
                    {
                        ID = -4,
                        Name = "Silly Store",
                        Address = "357 Back Street",
                        PostalCode = "T9T7L2",
                        City = "Calgary"
                    },
                    new Location()
                    {
                        ID = -5,
                        Name = "Elmo Store",
                        Address = "852 Sesame Street",
                        PostalCode = "T9M2A9",
                        City = "Edmonton"
                    }
                    );
            });

            // Declare advanced column configuration for our model.
            modelBuilder.Entity<Employee>(entity =>
            {
                // If you have foreign keys, declare them here as "HasIndex".
                entity.HasIndex(e => e.LocationID)
                    // By using nameof() we don't have to worry about weird names when we rename the classes.
                    .HasName("FK_" + nameof(Employee) + "_" + nameof(Location));

                // PLEASE don't try to memorize this. Copy/paste it and change the column name.
                entity.Property(e => e.FirstName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LastName)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                // Enforce the Foreign Key
                // Specify the relationship between the child and parent
                entity.HasOne(child => child.Location)
                // Specify the relationship between the parent and child(ren)
                    .WithMany(parent => parent.Employees)
                // Specify the property acting as the foreign key
                    .HasForeignKey(child => child.LocationID)
                // Specify delete behaviour
                // If the foreign key value is NOT NULL, you must use Cascade
                // If you want to use restrict, push the seed data with Cascade, then change it to Restrict and push again (I'm not sure why it doesn't let you do that to start with)
                    .OnDelete(DeleteBehavior.Restrict)
                // Name the foreign key
                    .HasConstraintName("FK_" + nameof(Employee) + "_" + nameof(Location));

                List<Employee> employees = new List<Employee>();
                Random rng = new Random();
                string[] names = { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles", "Christopher", "Daniel", "Matthew", "Anthony", "Donald", "Mark", "Paul", "Steven", "Andrew", "Kenneth", "Joshua", "Kevin", "Brian", "George", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan", "Jacob", "Gary", "Nicholas", "Eric", "Jonathan", "Stephen", "Larry", "Justin", "Scott", "Brandon", "Benjamin", "Samuel", "Frank", "Gregory", "Raymond", "Alexander", "Patrick", "Jack", "Dennis", "Jerry", "Tyler", "Aaron", "Jose", "Henry", "Adam", "Douglas", "Nathan", "Peter", "Zachary", "Kyle", "Walter", "Harold", "Jeremy", "Ethan", "Carl", "Keith", "Roger", "Gerald", "Christian", "Terry", "Sean", "Arthur", "Austin", "Noah", "Lawrence", "Jesse", "Joe", "Bryan", "Billy", "Jordan", "Albert", "Dylan", "Bruce", "Willie", "Gabriel", "Alan", "Juan", "Logan", "Wayne", "Ralph", "Roy", "Eugene", "Randy", "Vincent", "Russell", "Louis", "Philip", "Bobby", "Johnny", "Bradley", "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen", "Nancy", "Lisa", "Margaret", "Betty", "Sandra", "Ashley", "Dorothy", "Kimberly", "Emily", "Donna", "Michelle", "Carol", "Amanda", "Melissa", "Deborah", "Stephanie", "Rebecca", "Laura", "Sharon", "Cynthia", "Kathleen", "Amy", "Shirley", "Angela", "Helen", "Anna", "Brenda", "Pamela", "Nicole", "Samantha", "Katherine", "Emma", "Ruth", "Christine", "Catherine", "Debra", "Rachel", "Carolyn", "Janet", "Virginia", "Maria", "Heather", "Diane", "Julie", "Joyce", "Victoria", "Kelly", "Christina", "Lauren", "Joan", "Evelyn", "Olivia", "Judith", "Megan", "Cheryl", "Martha", "Andrea", "Frances", "Hannah", "Jacqueline", "Ann", "Gloria", "Jean", "Kathryn", "Alice", "Teresa", "Sara", "Janice", "Doris", "Madison", "Julia", "Grace", "Judy", "Abigail", "Marie", "Denise", "Beverly", "Amber", "Theresa", "Marilyn", "Danielle", "Diana", "Brittany", "Natalie", "Sophia", "Rose", "Isabella", "Alexis", "Kayla", "Charlotte" };
                string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzales", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper", "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson", "Watson", "Brooks", "Chavez", "Wood", "James", "Bennet", "Gray", "Mendoza", "Ruiz", "Hughes", "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez" };
                for (int i = -1; i >= -100; i--)
                {
                    employees.Add(new Employee()
                    {
                        ID = i,
                        FirstName = names[rng.Next(0, 200)],
                        LastName = lastNames[rng.Next(0, 100)],
                        DateOfBirth = new DateTime(rng.Next(1950, 1981), rng.Next(1, 13), rng.Next(1, 29)),
                        HireDate = new DateTime(rng.Next(2000, 2015), rng.Next(1, 13), rng.Next(1, 29)),
                        EndDate = rng.Next(1, 6) == 3 ? new DateTime?(new DateTime(rng.Next(2015, 2019), rng.Next(1, 13), rng.Next(1, 29))) : null,
                        LocationID = rng.Next(-5, 0)

                    });
                }

                entity.HasData(employees.ToArray());
            });

            // Call the partial method in case we add some stuff to another file later.
            OnModelCreatingPartial(modelBuilder);
        }

        // Not technically needed, but the scaffolding generates it for later use, so we can add it if we want for future-proofing.
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
