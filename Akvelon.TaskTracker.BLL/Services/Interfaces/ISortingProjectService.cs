using System.Collections.Generic;
using Akvelon.TaskTracker.DAL.Entities;

namespace Akvelon.TaskTracker.BLL.Services.Interfaces
{
    public interface ISortingProjectService
    {
        public IList<Project> SortByStartDateDescending(IList<Project> projects);
        
        public IList<Project> SortByCompletionDateAscending(IList<Project> projects);
        
        public IList<Project> SortByPriorityDescending(IList<Project> projects);

        public IList<Project> SortByStatusAscending(IList<Project> projects);
    }
}