using NUnit.Framework;
using ExtendedDatabase;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtendedDatabase
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, "Georgi")]
        [TestCase(6, "Mitko")]
        [TestCase(10, "Martin")]
        public void DatebaseShouldIncreaseCountOnArray(long id, string name)
        {
            Person person = new Person(id, name);
            ExtendedDatabase test = new ExtendedDatabase(person);
            Assert.AreEqual(1, test.Count);
        }


        [TestCase(20)]
        [TestCase(50)]
        [TestCase(100)]
        public void DatebaseShouldThrowExceptionIfAddArrayWithMoreElementsThanSixteen(int count)
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                persons.Add(new Person(i, i.ToString()));
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons.ToArray()));
        }


        [TestCase("Georgi")]
        [TestCase("Mitko")]
        [TestCase("Martin")]
        public void DatabaseShouldThrowExceptionIfContainsCurrentName(string name)
        {
            Person person = new Person(5, name);
            ExtendedDatabase test = new ExtendedDatabase(person);
            Assert.Throws<InvalidOperationException>(() => test.Add(person));
        }
        [TestCase("Martin")]
        public void DatabaseShouldAddPerson(string name)
        {
            Person person = new Person(5, name);
            ExtendedDatabase test = new ExtendedDatabase(person);
            Assert.AreEqual(person, test.FindByUsername(name));
        }

        [TestCase(10)]
        public void DatabaseShouldAddPerson(long id)
        {
            Person person = new Person(id, "Martin");
            ExtendedDatabase test = new ExtendedDatabase(person);
            Assert.AreEqual(person, test.FindById(id));
        }
        [TestCase(5)]
        [TestCase(10)]
        public void DatabaseShouldThrowExceptionIfContainsSameId(long id)
        {
            Person person = new Person(id, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);
            Assert.Throws<InvalidOperationException>(() => test.Add(person));
        }
        [Test]
        public void DatebaseShouldThrowExceptionIfAddMorePersonsThanSixteen()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 16; i++)
            {
                persons.Add(new Person(i, i.ToString()));
            }
            ExtendedDatabase test = new ExtendedDatabase(persons.ToArray());
            Assert.Throws<InvalidOperationException>(() => test.Add(new Person(5, "Minko")));

        }

        [Test]
        public void DatebaseShouldThrowExceptionIfTryRemoveElementByEmptyArray()
        {
            ExtendedDatabase test = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => test.Remove());
        }

        [Test]
        public void DatebaseShouldRemovePersonAndReduceTheSizeOnArray()
        {
            Person person = new Person(10, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);
            test.Remove();
            Assert.AreEqual(0, test.Count);
        }

        [Test]
        public void DatebaseShouldThrowExceptionIfNotExistCurrentUsername()
        {
            Person person = new Person(10, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => test.FindByUsername("Gosho"));
        }

        [Test]
        public void DatebaseShouldReturnExistUsername()
        {
            Person person = new Person(10, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);

            Assert.AreEqual(person, test.FindByUsername("Marko"));
        }

        [Test]
        public void DatebaseShouldReturnFalseIfNameIsWithDifferentSensitive()
        {
            Person person = new Person(10, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);
            Assert.Throws<InvalidOperationException>(() => test.FindByUsername("marko"));
        }


        [Test]
        public void DatebaseShouldThrowExceptionIfCurrentUsernameIsNull()
        {
            Person person = new Person(10, "Marko".ToLower());
            ExtendedDatabase test = new ExtendedDatabase(person);

            Assert.Throws<ArgumentNullException>(() => test.FindByUsername(null));
        }

        [Test]
        public void DatebaseShouldThrowExceptionIfUserIsNotPresentThisId()
        {
            Person person = new Person(10, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => test.FindById(5));
        }

        [Test]
        public void DatebaseShouldReturnExistUsernameWithId()
        {
            Person person = new Person(10, "Marko");
            ExtendedDatabase test = new ExtendedDatabase(person);

            Assert.AreEqual(person, test.FindById(10));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(-3)]
        [TestCase(-122)]
        public void DatebaseShouldThrowExceptionIfCurrentUsernameIsNull(long id)
        {
            Person person = new Person(id, "Marko".ToLower());
            ExtendedDatabase test = new ExtendedDatabase(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => test.FindById(id));
        }



        //this.count--;
        //this.persons [this.count] = null;
    }
}