namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }
        //	FirstName(up to 50 characters, unicode)
        //	LastName(up to 50 characters, unicode)
        //	Address(up to 250 characters, unicode)
        //	Email(up to 80 characters, not unicode)
        //	HasInsurance

    }
}
