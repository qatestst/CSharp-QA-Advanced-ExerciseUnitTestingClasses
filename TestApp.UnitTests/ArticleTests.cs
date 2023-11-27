using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    // TODO: write the setup method
    private Article _article;
    [SetUp]
    public void SetUp()
    { 
        this._article = new Article();
    }


    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData =
            {
            "Article Content Author",    
            "Article2 Content2 Author2",    
            "Article3 Content3 Author3"    
        };
        // Act
        Article result = this._article.AddArticles(articleData);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article() 
                {
                    Author = "Teodor",
                    Content = "Some text",
                    Title = "Begginers QA Programming"
                
                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "New  text",
                    Title = "A brief overview"

                },
            }
        };

        string expected = $"A brief overview - New  text: Ivan{Environment.NewLine}Begginers QA Programming - Some text: Teodor";
        //Act
        string actual = this._article.GetArticleList(inputArticle, "title");

        //Assert
        Assert.AreEqual(expected, actual);


    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Teodor",
                    Content = "Some text",
                    Title = "Begginers QA Programming"

                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "New  text",
                    Title = "A brief overview"

                },
            }
        };

        string expected = $"A brief overview - New  text: Ivan{Environment.NewLine}Begginers QA Programming - Some text: Teodor";
        //Act
        string actual = this._article.GetArticleList(inputArticle, "content");

        //Assert
        Assert.AreEqual(expected, actual);


    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Teodor",
                    Content = "Some text",
                    Title = "Begginers QA Programming"

                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "New  text",
                    Title = "A brief overview"

                },
                
            }
        };

        string expected = $"A brief overview - New  text: Ivan{Environment.NewLine}Begginers QA Programming - Some text: Teodor";
        //Act
        string actual = this._article.GetArticleList(inputArticle, "author");

        //Assert
        Assert.AreEqual(expected, actual);


    }



    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Teodor",
                    Content = "Some text",
                    Title = "Begginers QA Programming"

                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "New  text",
                    Title = "A brief overview"

                },
            }
        };

        string expected = string.Empty;
        //Act
        string actual = this._article.GetArticleList(inputArticle, "no-criteria");

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenEmptyListOfArticlesIsGiven()
    {
        //Arrange
        Article inputArticle = new Article() 
        {
            ArticleList = new()
        };

        string expected = string.Empty;
        //Act
        string actual = this._article.GetArticleList(inputArticle, "title");

        //Assert
        Assert.AreEqual(expected, actual);
    }

}
