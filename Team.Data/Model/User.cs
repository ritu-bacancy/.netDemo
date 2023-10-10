using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Data.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]

        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Email { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Password { get; set; }

        public int? TotalMatchesPlayed { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ContactNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string DOB { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public char IsActiveMember { get; set; } = 'N';

    }
}
