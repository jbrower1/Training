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
    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        [Key, Column(Order = 2)]
        public int GuardianID { get; set; }

        [Key, Column(Order = 3)]
        public int TeamID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public char Gender
        {
            get
            {
                return Gender;
            }
            set
            {
                Gender = char.ToUpper(value);
            }
        }

        public string AlbertaHealthCareNumber { get; set; }

        public string MedicalAlertDetails
        {
            get
            {
                return MedicalAlertDetails;
            }
            set
            {
                if(value == "")
                {
                    MedicalAlertDetails = null;
                }
                
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
