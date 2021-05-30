using System;
using System.ComponentModel.DataAnnotations;
using csharp_webapi.Entities;
using csharp_webapi.Builders;

namespace csharp_webapi.Models
{
    public class ContactModel
    {
        [Required]
        [StringLength(50, MinimumLength=0, 
        ErrorMessage = "Name must be between 0 and 50 characters")]
        public String? name { get; set; }
    
        [Required]
        [StringLength(20, MinimumLength=0, 
        ErrorMessage = "Number must be between 0 and 20 characters")]
        public String? number { get; set; }

        [Required]
        [StringLength(1000, MinimumLength=0,
        ErrorMessage = "Image must be between 0 and 1000 characters")]
        public String? image { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength=0, 
        ErrorMessage = "Name must be between 0 and 20 characters")]
        public String? pronouns { get; set; }

        [Required]
        [StringLength(1000, MinimumLength=0, 
        ErrorMessage = "Name must be between 0 and 1000 characters")]
        public String? desc { get; set; }

        public Contact ToContact() 
        {
            ContactBuilder builder = new ContactBuilder();
            builder.Desc(this.desc!);
            builder.Image(this.image!);
            builder.Pronous(this.pronouns!);
            builder.Number(this.number!);
            builder.Name(this.name!);

            return builder.Build();
        }
    }
}
