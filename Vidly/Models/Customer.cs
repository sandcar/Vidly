using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Min18yearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }

    // custom validation;

    public class Min18yearsIfAMember: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;

            // outra opção seria implementar enumerador ao invés das props estaticas na classe;
            if (customer.MemberShipTypeId == MemberShipType.Unknown 
                || customer.MemberShipTypeId == MemberShipType.PayasYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthday is required");

            // maiores de 18;

            var age = (DateTime.Now.Year - customer.BirthDate.Value.Year);

            return (age >= 18 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old"));

        }

    }
}