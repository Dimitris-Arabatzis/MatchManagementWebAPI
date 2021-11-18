using AutoMapper;
using MatchManagementWebAPI.Data;
using MatchManagementWebAPI.Models;
using MatchManagementWebAPI.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MatchManagementWebAPI.Tests
{
    public class MatchServiceTests
    {
        private Mock<IMatchOddRepo> matchOddRepoMock;
        private Mock<IMapper> mapperMock;
        private Mock<IMatchRepo> matchRepoMock;
        private Mock<IMatchService> matchServiceMock;

        [SetUp]
        public void Setup()
        {

            matchOddRepoMock = new Mock<IMatchOddRepo>();
            mapperMock = new Mock<IMapper>();
            matchRepoMock = new Mock<IMatchRepo>();
            matchServiceMock = new Mock<IMatchService>();

        }

        [Test]
        public void CanAddMatchOdd_MatchOddDoesNotExist_ReturnsTrue()
        {
            //Arrange

            matchOddRepoMock.Setup(x => x.GetMatchOddsByMatchId(It.IsAny<int>()))
                .Returns(new List<MatchOdd>());
            MatchOddService matchService = new MatchOddService(matchOddRepoMock.Object, mapperMock.Object, matchRepoMock.Object, matchServiceMock.Object);

            //Act

            bool result = matchService.CanAddMatchOdd(1, Specifier.HomeTeamWin);

            //Assert

            Assert.AreEqual(true, result);
        }
    }
}