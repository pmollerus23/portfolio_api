using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models {
    
    [Table("user_creds")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("first_name")]
        [MaxLength(40)] 
        public string FirstName { get; set; } = string.Empty;
        
        [Column("last_name")]
        [MaxLength(40)] 
        public string LastName { get; set; } = string.Empty;
        
        [Column("email")]
        [MaxLength(70)] 
        public string Email { get; set; } = string.Empty;
        
        [Column("password")]
        [MaxLength(100)] 
        public string Password { get; set; } = string.Empty;
        
        [Column("roles")]
        public  List<string> Roles { get; set; } = new List<string>();
    }
}
