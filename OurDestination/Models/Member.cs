using System;
using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string MemberName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public Nationality? Nationality { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public Religion? Religion { get; set; }
        public Gender? Gender { get; set; }
        public string EducationalQualification { get; set; }
        public string NIDNo { get; set; }
        public string PassportNo { get; set; }
        public string TinNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NomineeName { get; set; }
        public string RelationWithNominee { get; set; }
        public string NomineeNIDNo { get; set; }
        public string NomineePhoneNo { get; set; }
        public int? userid { get; set; }
        public int? comid { get; set; }
        public bool IsActive { get; set; }
        public DateTime? EntryDate { get; set; }



        public int? BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
    }

    public class BloodGroup
    {
        public int BloodGroupId { get; set; }
        public string BloodGroupName { get; set; }
    }

    public enum MaritalStatus
    {
        Marit,
        Unmarit
    }
    public enum Nationality
    {
       Bangladeshi
    }

    public enum Religion
    {
        Muslim,
        Himdu,
        Buddho
    }
     public enum Gender
    {
        Male,
        Female,
        Other
    }

}
