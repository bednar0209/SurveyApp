using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Model
{
    public class Survey : BaseEntity
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        
    }
}
