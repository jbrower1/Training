using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FSISSystem.JBrow.Data; 
using FSISSystem.JBrow.DAL;  
#endregion

namespace FSISSystem.JBrow.BLL
{
    public class TeamController
    {
        
        public List<Team> Team_List()
        {
            using (var context = new FSISContext())
            {
                return context.Teams.ToList();
            }
        }

        public Team Team_Get(int teamid)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(teamid);
            }
        }

    }
}
