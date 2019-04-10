using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#endregion

namespace FSISSystem.JBrow.Data
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required(ErrorMessage ="Team Name is a required field")]
        [MaxLength(50, ErrorMessage = "Team Name is limited to 50 Characters")]
        public string TeamName { get; set; }
        [Required(ErrorMessage = "Coach Name is a required field")]
        [MaxLength(75, ErrorMessage = "Coach Name is limited to 75 Characters")]
        public string Coach { get; set; }
        [Required(ErrorMessage = "Assistant Coach Name is a required field")]
        [MaxLength(75, ErrorMessage = "Assistant Coach Name is limited to 75 Characters")]
        public string AssistantCoach { get; set; }
        [Range(0,int.MaxValue, ErrorMessage = "Wins must be 0 or greater")]       
        public int? Wins { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Losses must be 0 or greater")]
        public int? Losses { get; set; }

    }
}
