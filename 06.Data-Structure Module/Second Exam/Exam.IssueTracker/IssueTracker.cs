using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.IssueTracker
{
    public class IssueTracker : IIssueTracker
    {
        Dictionary<string, Issue> tracker = new Dictionary<string, Issue>();

        public int Count => tracker.Count;

        public void AddIssue(Issue issue)
        {
            tracker.Add(issue.Id, issue);
        }

        public void Blocks(string issueId, string blockedIssueId)
        {
            if (!tracker.ContainsKey(issueId) || !tracker.ContainsKey(blockedIssueId))
            {
                throw new ArgumentException();
            }
            tracker[issueId].BlockedIssues.Add(tracker[blockedIssueId]);
        }


        public bool Contains(Issue issue)
        {
            return tracker.ContainsKey(issue.Id);
        }

        public Dictionary<string, Dictionary<IssueStatus, List<Issue>>> GetAssigneeIssueGroupedByStatus()
        {
          var status = new Dictionary<string, Dictionary<IssueStatus, List<Issue>>>();
            foreach (var item in tracker.Values)
            {
                var asignee = item.Assignee;
                var issueStatus = item.IssueStatus;
                status.Add(asignee, new Dictionary<IssueStatus, List<Issue>>());
                status[asignee].Add(item.IssueStatus, item.BlockedByIssues);
            }

            return status;
        }

        public IEnumerable<Issue> GetBacklog()
        {
            return tracker.Values.Where(x => x.IssueStatus.Equals(IssueStatus.ToDo)).OrderBy(x => x.Priority);
        }

        public IEnumerable<Issue> GetBlockedIssues()
        {
            return tracker.Values.Where(x => x.BlockedByIssues.Count != 0).OrderBy(x => x.Priority).ThenByDescending(x => x.Title);
        }

        public IEnumerable<Issue> GetLongestBlockChain()
        {
            return tracker.Values.Where(x => x.BlockedByIssues.Count == 0);
        }


        public void MoveInDone(string issueId)
        {
            if (!tracker.ContainsKey(issueId))
            {
                throw new ArgumentException();
            }
            tracker[issueId].IssueStatus = IssueStatus.Done;
        }

        public void MoveInProgress(string issueId)
        {
            if (!tracker.ContainsKey(issueId))
            {
                throw new ArgumentException();
            }
            if (!tracker[issueId].IssueStatus.Equals(IssueStatus.ToDo))
            {
                throw new ArgumentException();
            }

            tracker[issueId].IssueStatus = IssueStatus.InProgress;
        }

        public void RemoveIssue(string issueId)
        {
            if (!tracker.ContainsKey(issueId))
            {
                throw new ArgumentException();
            }

            tracker.Remove(issueId);
        }
    }
}
