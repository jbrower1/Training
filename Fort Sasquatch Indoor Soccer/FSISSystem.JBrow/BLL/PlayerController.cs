using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FSISSystem.JBrow.Data; 
using FSISSystem.JBrow.DAL;
using System.Data.SqlClient;
using System.ComponentModel;
#endregion

namespace FSISSystem.JBrow.BLL
{
    [DataObject]
    public class PlayerController
    {

        public List<Player> Players_GetByTeam(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByTeam @TeamID",
                                    new SqlParameter("TeamID", teamid));
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Player_GetByAgeGender(int age, string gender)
        {
            
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = context.Database.SqlQuery<Player>
                   ("Player_GetByAgeGender @Age, @Gender ", 
                    new SqlParameter("Age", age), 
                    new SqlParameter("Gender", char.Parse(gender)));
                return results.ToList();
            }
        }

    }
}
