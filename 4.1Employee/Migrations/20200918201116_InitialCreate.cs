using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _4._1Employee.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    address = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    postalcode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    city = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    location_id = table.Column<int>(type: "int(10)", nullable: false),
                    firstname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    lastname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    dateofbirth = table.Column<DateTime>(type: "date", nullable: false),
                    hiredate = table.Column<DateTime>(type: "date", nullable: false),
                    enddate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Location",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "location",
                columns: new[] { "id", "address", "city", "name", "postalcode" },
                values: new object[,]
                {
                    { -1, "123 Main Street", "Edmonton", "Super Duper Store", "T6M5W2" },
                    { -2, "567 Side Street", "Vancouver", "Awesome Store", "T8M2X2" },
                    { -3, "246 Boulevard Street", "Edmonton", "Corporate Headquarters", "T2Y8Z2" },
                    { -4, "357 Back Street", "Calgary", "Silly Store", "T9T7L2" },
                    { -5, "852 Sesame Street", "Edmonton", "Elmo Store", "T9M2A9" }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "dateofbirth", "enddate", "firstname", "hiredate", "lastname", "location_id" },
                values: new object[,]
                {
                    { -1, new DateTime(1959, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Olivia", new DateTime(2007, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jimenez", -1 },
                    { -49, new DateTime(1980, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bruce", new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turner", -4 },
                    { -40, new DateTime(1975, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", new DateTime(2003, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gonzales", -4 },
                    { -38, new DateTime(1959, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evelyn", new DateTime(2007, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moore", -4 },
                    { -37, new DateTime(1974, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marie", new DateTime(2014, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carter", -4 },
                    { -31, new DateTime(1975, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Randy", new DateTime(2013, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lewis", -4 },
                    { -14, new DateTime(1965, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rose", new DateTime(2011, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walker", -4 },
                    { -10, new DateTime(1968, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Debra", new DateTime(2007, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edwards", -4 },
                    { -6, new DateTime(1976, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walter", new DateTime(2012, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wright", -4 },
                    { -5, new DateTime(1968, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amanda", new DateTime(2001, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robinson", -4 },
                    { -4, new DateTime(1957, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christina", new DateTime(2014, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mendoza", -4 },
                    { -2, new DateTime(1963, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Benjamin", new DateTime(2004, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", -4 },
                    { -98, new DateTime(1971, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madison", new DateTime(2000, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", -3 },
                    { -95, new DateTime(1960, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amy", new DateTime(2001, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberts", -3 },
                    { -89, new DateTime(1979, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Christian", new DateTime(2005, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torres", -3 },
                    { -83, new DateTime(1960, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edward", new DateTime(2002, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rivera", -3 },
                    { -82, new DateTime(1973, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ashley", new DateTime(2014, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morales", -3 },
                    { -77, new DateTime(1951, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kyle", new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stewart", -3 },
                    { -76, new DateTime(1978, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ryan", new DateTime(2008, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jackson", -3 },
                    { -69, new DateTime(1977, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Betty", new DateTime(2000, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott", -3 },
                    { -60, new DateTime(1960, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremy", new DateTime(2014, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", -3 },
                    { -56, new DateTime(1964, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Helen", new DateTime(2005, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harris", -3 },
                    { -50, new DateTime(1972, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Larry", new DateTime(2000, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ward", -4 },
                    { -51, new DateTime(1951, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samantha", new DateTime(2014, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott", -3 },
                    { -54, new DateTime(1951, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", new DateTime(2013, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gonzales", -4 },
                    { -58, new DateTime(1951, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", new DateTime(2006, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moore", -4 },
                    { -90, new DateTime(1959, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Donna", new DateTime(2006, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wood", -5 },
                    { -88, new DateTime(1978, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karen", new DateTime(2013, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguez", -5 },
                    { -87, new DateTime(1960, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evelyn", new DateTime(2002, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morgan", -5 },
                    { -81, new DateTime(1955, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shirley", new DateTime(2012, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", -5 },
                    { -75, new DateTime(1973, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Grace", new DateTime(2000, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", -5 },
                    { -67, new DateTime(1975, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Debra", new DateTime(2003, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", -5 },
                    { -66, new DateTime(1964, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dennis", new DateTime(2000, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", -5 },
                    { -65, new DateTime(1961, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jack", new DateTime(2007, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", -5 },
                    { -63, new DateTime(1962, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Andrew", new DateTime(2003, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", -5 },
                    { -33, new DateTime(1969, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jeremy", new DateTime(2002, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", -5 },
                    { -30, new DateTime(1977, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "George", new DateTime(2008, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gutierrez", -5 },
                    { -29, new DateTime(1954, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Patricia", new DateTime(2008, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanders", -5 },
                    { -28, new DateTime(1954, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Olivia", new DateTime(2003, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", -5 },
                    { -20, new DateTime(1967, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan", new DateTime(2006, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", -5 },
                    { -19, new DateTime(1953, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ethan", new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mendoza", -5 },
                    { -100, new DateTime(1966, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sandra", new DateTime(2006, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murphy", -4 },
                    { -99, new DateTime(1980, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Noah", new DateTime(2007, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anderson", -4 },
                    { -93, new DateTime(1975, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jose", new DateTime(2014, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lopez", -4 },
                    { -92, new DateTime(1952, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thomas", new DateTime(2001, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harris", -4 },
                    { -73, new DateTime(1955, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Johnny", new DateTime(2012, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howard", -4 },
                    { -62, new DateTime(1953, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony", new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", -4 },
                    { -55, new DateTime(1955, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Victoria", new DateTime(2012, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alvarez", -4 },
                    { -36, new DateTime(1973, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roger", new DateTime(2005, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rivera", -3 },
                    { -27, new DateTime(1965, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jean", new DateTime(2012, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adams", -3 },
                    { -25, new DateTime(1977, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert", new DateTime(2011, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long", -3 },
                    { -79, new DateTime(1950, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gregory", new DateTime(2001, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torres", -1 },
                    { -78, new DateTime(1963, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roger", new DateTime(2005, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robinson", -1 },
                    { -71, new DateTime(1950, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ethan", new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", -1 },
                    { -70, new DateTime(1959, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", new DateTime(2005, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook", -1 },
                    { -64, new DateTime(1957, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Janice", new DateTime(2009, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jones", -1 },
                    { -61, new DateTime(1957, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Benjamin", new DateTime(2002, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", -1 },
                    { -59, new DateTime(1957, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ann", new DateTime(2004, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hill", -1 },
                    { -48, new DateTime(1980, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexis", new DateTime(2010, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", -1 },
                    { -47, new DateTime(1971, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jeffrey", new DateTime(2001, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Campbell", -1 },
                    { -46, new DateTime(1959, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Richard", new DateTime(2013, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morales", -1 },
                    { -45, new DateTime(1974, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Barbara", new DateTime(2000, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rivera", -1 },
                    { -44, new DateTime(1953, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jennifer", new DateTime(2006, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", -1 },
                    { -43, new DateTime(1971, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Timothy", new DateTime(2008, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", -1 },
                    { -41, new DateTime(1957, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gary", new DateTime(2011, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myers", -1 },
                    { -39, new DateTime(1959, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edward", new DateTime(2012, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kim", -1 },
                    { -35, new DateTime(1956, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ralph", new DateTime(2002, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", -1 },
                    { -34, new DateTime(1961, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heather", new DateTime(2003, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moore", -1 },
                    { -26, new DateTime(1954, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marilyn", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanchez", -1 },
                    { -21, new DateTime(1969, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", new DateTime(2003, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green", -1 },
                    { -13, new DateTime(1950, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert", new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruiz", -1 },
                    { -7, new DateTime(1960, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Victoria", new DateTime(2007, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Williams", -1 },
                    { -80, new DateTime(1950, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diane", new DateTime(2004, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin", -1 },
                    { -85, new DateTime(1954, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexis", new DateTime(2002, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adams", -1 },
                    { -96, new DateTime(1951, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bruce", new DateTime(2009, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramos", -1 },
                    { -8, new DateTime(1968, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jonathan", new DateTime(2010, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reed", -2 },
                    { -17, new DateTime(1964, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roy", new DateTime(2009, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flores", -3 },
                    { -15, new DateTime(1951, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diana", new DateTime(2003, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberts", -3 },
                    { -11, new DateTime(1967, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Joan", new DateTime(2000, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hernandez", -3 },
                    { -3, new DateTime(1973, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Melissa", new DateTime(2004, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patel", -3 },
                    { -97, new DateTime(1953, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nancy", new DateTime(2012, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gonzales", -2 },
                    { -86, new DateTime(1956, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Joan", new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wood", -2 },
                    { -84, new DateTime(1955, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerald", new DateTime(2014, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", -2 },
                    { -74, new DateTime(1977, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walter", new DateTime(2011, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook", -2 },
                    { -72, new DateTime(1974, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Patricia", new DateTime(2000, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanchez", -2 },
                    { -68, new DateTime(1975, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Judith", new DateTime(2001, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long", -2 },
                    { -91, new DateTime(1972, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eric", new DateTime(2009, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott", -5 },
                    { -57, new DateTime(1971, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Benjamin", new DateTime(2010, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hall", -2 },
                    { -52, new DateTime(1950, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vincent", new DateTime(2009, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brooks", -2 },
                    { -42, new DateTime(1954, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jesse", new DateTime(2010, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hall", -2 },
                    { -32, new DateTime(1978, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Danielle", new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ross", -2 },
                    { -24, new DateTime(1979, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evelyn", new DateTime(2007, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ortiz", -2 },
                    { -23, new DateTime(1969, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Larry", new DateTime(2006, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carter", -2 },
                    { -22, new DateTime(1953, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Johnny", new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", -2 },
                    { -18, new DateTime(1965, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karen", new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howard", -2 },
                    { -16, new DateTime(1979, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marilyn", new DateTime(2012, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mendoza", -2 },
                    { -12, new DateTime(1967, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gregory", new DateTime(2012, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ortiz", -2 },
                    { -9, new DateTime(1953, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carol", new DateTime(2001, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", -2 },
                    { -53, new DateTime(1956, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evelyn", new DateTime(2002, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reed", -2 },
                    { -94, new DateTime(1967, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amber", new DateTime(2014, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alvarez", -5 }
                });

            migrationBuilder.CreateIndex(
                name: "FK_Employee_Location",
                table: "employee",
                column: "location_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
