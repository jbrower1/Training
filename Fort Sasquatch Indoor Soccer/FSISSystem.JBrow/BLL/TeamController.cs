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
    public class TeamController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
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
        public int Team_Add(Team item)
        {
            using (var context = new FSISContext())
            {

                context.Teams.Add(item);
              
                context.SaveChanges();

                return item.TeamID;
            }

        }
        public int Team_Update(Team item)
        {
            using (var context = new FSISContext())
            {
                
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
               
                return context.SaveChanges();
            }
        }

       
        public int Team_Delete(int teamid)
        {
            using (var context = new FSISContext())
            {
                

                var existing = context.Teams.Find(teamid);
               
                context.Teams.Remove(existing);

                return context.SaveChanges();
            }
        }
    }
}
