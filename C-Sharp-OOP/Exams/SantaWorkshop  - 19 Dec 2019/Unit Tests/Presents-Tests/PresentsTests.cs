namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class PresentsTests
    {
        private Bag mybag;

        [SetUp]
        public void Setup()
        {
            this.mybag = new Bag();
        }

        [Test]
        public void Constructor_Initializes_Bag_Correctly()
        {
            Assert.That(mybag.GetPresents(), Is.EqualTo(new List<Present>()));
        }

        [Test]
        public void Create_Method_Throws_Exception_When_Present_Is_Null()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => this.mybag.Create(present));
        }

        [Test]
        public void Create_Method_Throws_Exception_When_Adding_Existing_Present()
        {
            Present present = new Present("aa", 2.2);
            this.mybag.Create(present);

            Assert.Throws<InvalidOperationException>(() => this.mybag.Create(present));
        }

        [Test]
        public void Create_Method_Returns_Message_When_Present_Is_Added_Successfully()
        {
            Present present = new Present("aa", 2.2);

            var actual = this.mybag.Create(present);
            var expected = $"Successfully added present { present.Name}.";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_Method_Returns_True()
        {
            Present present = new Present("aa", 2.2);
            this.mybag.Create(present);

            var actual = this.mybag.Remove(present);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentWithLeastMagic_Works_Correctly()
        {
            Present present = new Present("aa", 2.2);
            Present secodPresent = new Present("bb", 3.2);
            this.mybag.Create(present);
            this.mybag.Create(secodPresent);

            var actual = this.mybag.GetPresentWithLeastMagic();
            var expected = present;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresent_Works_Correctly()
        {
            Present present = new Present("aa", 2.2);
            this.mybag.Create(present);

            var actual = this.mybag.GetPresent("aa");
            var expected = present;

            Assert.AreEqual(expected, actual);
        }
    }
}
