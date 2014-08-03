using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Data
{
    public class AgileTaskKeeperContext : DbContext
    {
        private DbSet<AgileTask> AgileTasks { get; set; }
        private DbSet<TeamMember> TeamMembers { get; set; }

        //Agile Task Functions
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

        public IEnumerable<AgileTask> GetAllTasks()
        {
            using (var db = new AgileTaskKeeperContext())
            {
                return db.AgileTasks.ToList();
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

        public bool UpdateTask(AgileTask updateTask)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var taskToUpdate = db.AgileTasks.Find(updateTask.Title);
                if (taskToUpdate != null)
                {
                    taskToUpdate.Body = updateTask.Body;
                    taskToUpdate.MyStatus = updateTask.MyStatus;
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
                var taskToDelete = db.AgileTasks.Find(deletedTask.Title);

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
                return db.TeamMembers.ToList();
            }
        }

        public void AddATeamMember(TeamMember member)
        {
            var memberToAdd = member;

            using (var db = new AgileTaskKeeperContext())
            {
                db.TeamMembers.Add(memberToAdd);
                db.SaveChanges();
            }
        }
    }
}