﻿using AgileTaskKeeper.Models;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TeamMember>().Property(r => r.TeamMemberId)
                         .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        //Agile Task Functions
        public IEnumerable<AgileTask> GetAllTasks()
        {
            using (var db = new AgileTaskKeeperContext())
            {
                return db.AgileTasks.Include(tm => tm.TeamMember).Include(tl => tl.TeamMember.TaskList).ToList();
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

        public bool UpdateTask(AgileTask updateTask)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var taskToUpdate = db.AgileTasks.Find(updateTask.Title);
                if (taskToUpdate != null)
                {
                    taskToUpdate.Body = updateTask.Body;
                    taskToUpdate.MyStatus = updateTask.MyStatus;
                    taskToUpdate.TeamMemberId = updateTask.TeamMemberId;
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
                return db.TeamMembers.Include(tl => tl.TaskList).ToList();
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
                foreach (AgileTask task in db.AgileTasks.ToList())
                {
                    if (task.TeamMemberId == teamMemberIdToRemove)
                    {
                        task.TeamMemberId = null;
                    }
                }

                db.TeamMembers.Remove(teamMemberToRemove);
                db.SaveChanges();
            }
        }
    }
}