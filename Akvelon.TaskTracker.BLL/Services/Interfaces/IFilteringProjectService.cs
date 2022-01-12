using System;
using System.Collections.Generic;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.BLL.Services.Interfaces
{
    public interface IFilteringProjectService
    {
        public IList<Project> FilteringByStartDateAfter(IList<Project> projects, DateTime dateAfter);
        
        public IList<Project> FilteringByEndDateBefore(IList<Project> projects, DateTime dateBefore);
        
        public IList<Project> FilteringCountOfTasksInRange(IList<Project> projects, int start, int end);

        public IList<Project> FilteringByProjectStatus(IList<Project> projects, ProjectStatus status);
    }
}