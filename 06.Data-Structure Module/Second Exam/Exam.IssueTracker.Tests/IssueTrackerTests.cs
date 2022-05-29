using Exam.IssueTracker;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class IssueTrackerTests
{
    private IIssueTracker issueTracker;

    private Issue GetRandomIssue()
    {
        Random random = new Random();

        return new Issue(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            random.Next(1, 1_000_000_000),
            Guid.NewGuid().ToString());
    }

    [SetUp]
    public void Setup()
    {
        this.issueTracker = new IssueTracker();
    }

    // Correctness Tests

    [Test]
    public void Test1AddIssue_WithCorrectData_ShouldSuccessfullyAddIssue()
    {
        this.issueTracker.AddIssue(GetRandomIssue());
        this.issueTracker.AddIssue(GetRandomIssue());

        Assert.AreEqual(2, this.issueTracker.Count);
    }

    [Test]
    public void Test2Contains_WithExistentIssue_ShouldReturnTrue()
    {
        Issue issue = GetRandomIssue();

        this.issueTracker.AddIssue(issue);

        Assert.IsTrue(this.issueTracker.Contains(issue));
    }

    [Test]
    public void Test3Contains_WithNonexistentIssue_ShouldReturnTrue()
    {
        this.issueTracker.AddIssue(GetRandomIssue());

        Assert.IsFalse(this.issueTracker.Contains(GetRandomIssue()));
    }

    [Test]
    public void Test4Count_With5Issues_ShouldReturn5()
    {
        this.issueTracker.AddIssue(this.GetRandomIssue());
        this.issueTracker.AddIssue(this.GetRandomIssue());
        this.issueTracker.AddIssue(this.GetRandomIssue());
        this.issueTracker.AddIssue(this.GetRandomIssue());
        this.issueTracker.AddIssue(this.GetRandomIssue());

        Assert.AreEqual(5, this.issueTracker.Count);
    }

    [Test]
    public void Test14GetBacklog_WithTodoIssues_ShouldReturnCorrectIssues()
    {
        Issue issue = new Issue("Test1", "Title1", 200, "Pesho");
        Issue issue2 = new Issue("Test2", "Title2", 5, "Gosho");
        Issue issue3 = new Issue("Test3", "Title3", 10, "Sasho");
        Issue issue4 = new Issue("Test4", "Title4", 0, "Tosho");
        Issue issue5 = new Issue("Test5", "Title5", 0, "Misho");

        this.issueTracker.AddIssue(issue);
        this.issueTracker.AddIssue(issue2);
        this.issueTracker.AddIssue(issue3);
        this.issueTracker.AddIssue(issue4);
        this.issueTracker.AddIssue(issue5);

        issue.IssueStatus = (IssueStatus.InProgress);
        issue5.IssueStatus = (IssueStatus.Done);

        List<Issue> issues = this.issueTracker.GetBacklog().ToList();
        ;

        Assert.AreEqual(3, issues.Count);
        Assert.AreEqual(issue4, issues[0]);
        Assert.AreEqual(issue2, issues[1]);
        Assert.AreEqual(issue3, issues[2]);
    }

    [Test]
    public void Test20RemoveIssue_WithCorrectData_ShouldDecrementCount()
    {
        Issue issue = new Issue("A", "A", 200, "A");
        Issue issue2 = new Issue("B", "B", 10, "A");
        Issue issue3 = new Issue("C", "C", 10, "A");

        this.issueTracker.AddIssue(issue);
        this.issueTracker.AddIssue(issue2);
        this.issueTracker.AddIssue(issue3);

        this.issueTracker.RemoveIssue("B");

        Assert.AreEqual(2, this.issueTracker.Count);
    }

    // Performance Tests

    [Test]
    public void Test1AddIssue_With100000Results_ShouldPassQuickly()
    {
        List<Issue> issuesToAdd = new List<Issue>();

        int count = 100000;

        for (int i = 0; i < count; i++)
        {
            issuesToAdd.Add(new Issue(i + "", "Title" + i, i * 100, "Assignee" + i));
        }

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        for (int i = 0; i < count; i++)
        {
            this.issueTracker.AddIssue(issuesToAdd[i]);
        }

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(elapsedTime < 450);
    }
}
