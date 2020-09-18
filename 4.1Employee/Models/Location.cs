using _4._1Employee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace _4._1Employee.Models
{
    [Table("location")]
    public partial class Location
    {
        // Initialize the navigation property.
        public Location()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("id", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        // Sets the maximum length of a string for validation.
        [StringLength(30)]
        [Column("name", TypeName = "varchar(30)")]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        [Column("address", TypeName = "varchar(30)")]
        public string Address { get; set; }
        [Required]
        // Sets both the maximum (first argument) and minimum length of the string.
        [StringLength(6, MinimumLength = 6)]
        [Column("postalcode", TypeName = "char(6)")]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(30)]
        [Column("city", TypeName = "varchar(30)")]
        public string City { get; set; }


        // This property represents a list of all the related entities which have this entity's primary key as their foreign key. It saves using LINQ to try and filter on the primary key and makes things more readable.
        [InverseProperty(nameof(Employee.Location))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
