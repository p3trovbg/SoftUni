using System.Collections.Generic;

namespace Exam.IssueTracker
{
    public class Issue
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }

        public string Assignee { get; set; }

        public IssueStatus IssueStatus { get; set; }

        public List<Issue> BlockedIssues { get; set; } = new List<Issue>();

        public List<Issue> BlockedByIssues { get; set; } = new List<Issue>();

        public Issue(string id, string title, int priority, string assignee)
        {
            this.Id = id;
            this.Title = title;
            this.Priority = priority;
            this.Assignee = assignee;
            this.IssueStatus = IssueStatus.ToDo;
        }
    }
}
