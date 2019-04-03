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
    public class PlayerController
    {
       

        public List<Player> Player_List()
        {
            using (var context = new FSISContext())
            {
                return context.Players.ToList();
            }
        }
        public Team Player_Get(int playerid)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(playerid);
            }
        }

    }
}
