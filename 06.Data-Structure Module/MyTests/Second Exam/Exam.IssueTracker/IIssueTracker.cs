using System.Collections.Generic;

namespace Exam.IssueTracker
{
    public interface IIssueTracker
    {
        void AddIssue(Issue issue);

        void RemoveIssue(string issueId);

        bool Contains(Issue issue);

        int Count { get; }

        void MoveInProgress(string issueId);

        void MoveInDone(string issueId);

        void Blocks(string issueId, string blockedIssueId);

        IEnumerable<Issue> GetBacklog();

        IEnumerable<Issue> GetBlockedIssues();

        IEnumerable<Issue> GetLongestBlockChain();

        Dictionary<string, Dictionary<IssueStatus, List<Issue>>> GetAssigneeIssueGroupedByStatus();
    }
}
