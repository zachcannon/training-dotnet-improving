using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Data
{
    public class AgileTaskKeeperContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        //Agile Task Functions
        public IEnumerable<AgileTask> GetAllTasks()
        {
            using (var db = new AgileTaskKeeperContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.AgileTasks.Include(at => at.AssignedTeamMembers).ToList();
            }
        }

        public AgileTask GetTaskFromDb(String taskName)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                AgileTask task = db.AgileTasks.Find(taskName);
                if (task != null)
                    return task;
            }
            return new AgileTask("NoTaskFound", "NoTaskFound");
        }

        public AgileTask AddTaskToDb(AgileTask task)
        {
            var taskToAdd = task;

            using (var db = new AgileTaskKeeperContext())
            {
                db.AgileTasks.Add(taskToAdd);
                db.SaveChanges();
                return task;
            }
        }

        public bool UpdateTask(AgileTask newVersionOfTask)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var taskToUpdate = db.AgileTasks.Include(tm => tm.AssignedTeamMembers)
                    .SingleOrDefault(id => id.AgileTaskId == newVersionOfTask.AgileTaskId);

                if (taskToUpdate != null)
                {
                    // Set the static values for the AgileTaskClass
                    db.Entry(taskToUpdate).CurrentValues.SetValues(newVersionOfTask);
                     
                    // Remove categories that are not in the id list anymore
                    foreach (var removeCheck in taskToUpdate.AssignedTeamMembers.ToList())
                    {
                        if ((newVersionOfTask.AssignedTeamMembers.SingleOrDefault(id => id.TeamMemberId == removeCheck.TeamMemberId) == null))
                            taskToUpdate.AssignedTeamMembers.Remove(removeCheck);
                    }

                    // Add categories that are not in the DB list but in id list
                    foreach (var member in newVersionOfTask.AssignedTeamMembers)
                    {
                        if (taskToUpdate.AssignedTeamMembers.SingleOrDefault(id => id.TeamMemberId == member.TeamMemberId) == null)
                        {
                            db.TeamMembers.Attach(member);
                            taskToUpdate.AssignedTeamMembers.Add(member);
                        }
                    }

                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public bool DeleteTask(AgileTask deletedTask)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var taskToDelete = db.AgileTasks.Find(deletedTask.AgileTaskId);

                if (taskToDelete != null)
                {
                    db.AgileTasks.Remove(taskToDelete);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        //Team Member Functions
        public IEnumerable<TeamMember> GetAllTeamMembers()
        {
            using (var db = new AgileTaskKeeperContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.TeamMembers.Include(tm => tm.AgileTasks).ToList();
            }
        }

        public void AddATeamMember(TeamMember member)
        {
            var teamMember = member;
            using (var db = new AgileTaskKeeperContext())
            {
                db.TeamMembers.Add(teamMember);
                db.SaveChanges();
            }
        }

        public void RemoveTeamMember(int teamMemberIdToRemove)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var teamMemberToRemove = db.TeamMembers.Find(teamMemberIdToRemove);
                
                //Look through all tasks, where you find the team members idToRemove, clear that line
                //foreach (AgileTask task in db.AgileTasks.ToList())
                //{
                //    if (task.TeamMemberId == teamMemberIdToRemove)
                //    {
                //        task.TeamMemberId = null;
                //    }
                //}

                db.TeamMembers.Remove(teamMemberToRemove);
                db.SaveChanges();
            }
        }
    }
}