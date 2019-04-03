using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FSISSystem.JBrow.Data; 
using FSISSystem.JBrow.DAL;
using System.Data.SqlClient;
#endregion

namespace FSISSystem.JBrow.BLL
{
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

    }
}
