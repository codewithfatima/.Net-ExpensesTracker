//models are our data like expense 
// - thse are simpole classes respresting the data you app handle . no logic goes here 

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebApp.Models
{
    public class Expense

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Add the '?' to tell C# this property is allowed to be null
        [Required(ErrorMessage ="Category is required")]
        [StringLength(50, ErrorMessage ="Category cannot be more be long than 50 characters..")]
        public string? Category { get; set; }

        [Range(0.01, 1000000, ErrorMessage ="Amount must be greater than than 0.")]
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

