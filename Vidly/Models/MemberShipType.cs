using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name="Membership Type")]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscontRate { get; set; }

        // para propositos de validacao. ver Customer class / custom validation
        // outra opção seria implementar enumerador;
        public static readonly byte Unknown = 0;
        public static readonly byte PayasYouGo = 1;

    }
}