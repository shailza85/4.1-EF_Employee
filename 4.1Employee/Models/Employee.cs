using _4._1Employee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _4._1Employee
{
    // Declares the name of the database table.
    [Table("employee")]
    public partial class Employee
    {


        // All annotations will bind to the next property in the file.

        // Declare a primary key.
        [Key]
        // Specifies AUTO_INCREMENT.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Declare the column name and the data type.
        // MySQL data type, NOT C# data type.
        [Column("id", TypeName = "int(10)")]
        // Declare the C# property that will map onto that database column.
        public int ID { get; set; }

        [Column("location_id", TypeName = "int(10)")]
        public int LocationID { get; set; }

        [Column("firstname", TypeName = "varchar(30)")]
        // Specifies NOT NULL on nullable types.
        // Ints do not require this to be NOT NULL as they are not nullable.
        // You must make a nullable int (int?) in order to specify NULL.
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }

        [Column("lastname", TypeName = "varchar(30)")]
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        [Column("dateofbirth", TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Column("hiredate", TypeName = "date")]
        public DateTime HireDate { get; set; }

        [Column("enddate", TypeName = "date")]
        public DateTime? EndDate { get; set; }

        // Points to the property representing the foreign key column.
        [ForeignKey(nameof(LocationID))]
        // By using nameof() it saves us from breaking it accidentally by renaming things, as long as we use Ctrl+R+R to rename them. For some reason the migration from an existing database doesn't use this, which is why things breaks
        [InverseProperty(nameof(Models.Location.Employees))]
        public virtual Location Location { get; set; }
    }
}
