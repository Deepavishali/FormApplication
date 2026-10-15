using System.ComponentModel.DataAnnotations;


    namespace DatabaseMigration.Models
    {
        public class User
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
            public string? Name { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Mobile number is required")]
            [Phone(ErrorMessage = "Invalid phone number format")]
            [StringLength(15, MinimumLength = 10, ErrorMessage = "Mobile number must be between 10 and 15 digits")]
            public string? Mobile { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime? DateOfBirth { get; set; }

            [StringLength(20)]
            public string? Gender { get; set; }

            [StringLength(250)]
            public string? Address { get; set; }

            [StringLength(100)]
            public string? City { get; set; }

            [StringLength(100)]
            public string? State { get; set; }

            [StringLength(20)]
            [Display(Name = "Postal Code")]
            public string? PostalCode { get; set; }

            public bool IsActive { get; set; } = true;

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    }

