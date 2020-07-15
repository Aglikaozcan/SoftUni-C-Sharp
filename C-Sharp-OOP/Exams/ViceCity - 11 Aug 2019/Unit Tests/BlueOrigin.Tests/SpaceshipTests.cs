namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void Constructor_ShouldSetProperValues()
        {
            var name = "AA";
            var capacity = 10;
            var astronauts = new List<Astronaut>();
            var spaceship = new Spaceship(name, capacity);

            Assert.AreEqual(name, spaceship.Name);
            Assert.AreEqual(capacity, spaceship.Capacity);
            Assert.That(spaceship.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase (null, 10)]
        [TestCase ("", 10)]
        public void Constructor_ShouldThrowException_WhenStationNameIsNullOrEmpty(string stationName, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(stationName, capacity));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Aa", -1));
        }

        [Test]
        public void AddAstronaut_ThrowsException_WhenCapacityIsEcxeeded()
        {
            var spaceship = new Spaceship("aa", 1);
            spaceship.Add(new Astronaut("bb", 11.1));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("vv", 2.2)));
        }

        [Test]
        public void AddAstronaut_ThrowsException_WhenAddingSameAstronaut()
        {
            var spaceship = new Spaceship("aa", 1);
            var astronaut = new Astronaut("bb", 11.1);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void AddAstronaut_WorksCorrectly()
        {
            var spaceship = new Spaceship("aa", 1);
            var astronaut = new Astronaut("bb", 11.1);

            spaceship.Add(astronaut);

            Assert.That(spaceship.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_WorksCorrectly()
        {
            var spaceship = new Spaceship("aa", 1);
            var astronaut = new Astronaut("bb", 11.1);

            spaceship.Add(astronaut);

            var actual = spaceship.Remove(astronaut.Name);
            var expected = true;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}