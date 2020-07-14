using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository myRepository;

    [SetUp]
    public void Setup()
    {
        myRepository = new HeroRepository();
    }

    [Test]
    public void Constructor_Works_Correctly()
    {
        Assert.That(this.myRepository.Heroes, Is.EqualTo(new List<Hero>()));
    }

    [Test]
    public void Create_Method_Throws_Exception_When_Hero_Is_Null()
    {
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() => this.myRepository.Create(hero));
    }

    [Test]
    public void Create_Method_Throws_Exception_When_Hero_Already_Exists()
    {
        Hero hero = new Hero("aa", 1);
        this.myRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => this.myRepository.Create(hero));
    }

    [Test]
    public void Create_Method_Returns_Message_When_Hero_Is_Added_Successfully()
    {
        Hero hero = new Hero("aa", 1);
        var actual = this.myRepository.Create(hero);
        var expected = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase (null)]
    [TestCase (" ")]
    public void Remove_Method_Throws_Exception_When_String_Is_NullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => this.myRepository.Remove(name));
    }

    [Test]
    public void Remove_Method_Returns_True()
    {
        Hero hero = new Hero("aa", 1);
        this.myRepository.Create(hero);

        var actual = this.myRepository.Remove("aa");
        var expected = true;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetHeroWithHighestLevel_Works_Correctly()
    {
        Hero hero = new Hero("aa", 1);
        Hero biggerHero = new Hero("bb", 2);
        this.myRepository.Create(hero);
        this.myRepository.Create(biggerHero);

        var actual = this.myRepository.GetHeroWithHighestLevel();
        var expected = biggerHero;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetHero_Works_Correctly()
    {
        Hero hero = new Hero("aa", 1);
        this.myRepository.Create(hero);

        var actual = this.myRepository.GetHero("aa");
        var expected = hero;

        Assert.AreEqual(expected, actual);
    }
}