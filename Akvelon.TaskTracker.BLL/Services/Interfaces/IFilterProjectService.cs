using System;
using System.Collections.Generic;
using Akvelon.TaskTracker.DAL.Entities;
using Akvelon.TaskTracker.DAL.Enums;

namespace Akvelon.TaskTracker.BLL.Services.Interfaces
{
    public interface IFilterProjectService
    {
        public IList<Project> FilterByStartDateAfter(IList<Project> projects, DateTime dateAfter);
        
        public IList<Project> FilterByEndDateBefore(IList<Project> projects, DateTime dateBefore);
        
        public IList<Project> FilterCountOfTasksInRange(IList<Project> projects, int start, int end);

        public IList<Project> FilterByProjectStatus(IList<Project> projects, ProjectStatus status);
    }
}