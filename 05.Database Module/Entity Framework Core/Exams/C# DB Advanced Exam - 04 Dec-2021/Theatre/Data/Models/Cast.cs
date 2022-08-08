using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(4, 30)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; }
        //•	PhoneNumber  - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}"
        //. Valid phone numbers are: +44-53-468-3479, +44-91-842-6054, +44-59-742-3119 (required)

        [Required]
        public int PlayId { get; set; }

        [ForeignKey(nameof(PlayId))]
        public virtual Play Play { get; set; }
    }
}
