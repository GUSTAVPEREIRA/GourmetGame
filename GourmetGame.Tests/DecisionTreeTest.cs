using GourmetGame.Model.Enumeration;
using GourmetGame.Services.Service;
using System;
using Xunit;

namespace GourmetGame.Tests
{
    public class DecisionTreeTest
    {
        private DecisionTreeService Service;

        [Fact(DisplayName = "Once created the tree should contain a yes and no answer.")]
        public void TreeShouldContainYesAndNoAnswer()
        {
            string nodeRootName = "massa";
            string yesNodeName = "Lasanha";
            string noNodeName = "Bolo de Chocolate";
            var service = new DecisionTreeService(null);

            Assert.Equal(nodeRootName, service.GetActualNodeValue());
            service.MovNode(true);
            Assert.Equal(yesNodeName, service.GetActualNodeValue());

            service.GoToRoot();
            service.MovNode(false);
            Assert.Equal(noNodeName, service.GetActualNodeValue());
        }

        [Theory(DisplayName = "You must enter a series of categories without causing an error.")]
        [InlineData("Brigadeiro", "Doce", true)]
        [InlineData("Pernil", "Assado", false)]
        public void EnterSeriesCategoriesWithoutError(string meal, string type, bool answer)
        {
            if (Service == null)
            {
                Service = new DecisionTreeService(null);
            }

            try
            {
                Service.MovNode(answer);
                Service.InsertNode(meal, type);
                Service.GoToRoot();
                Service.MovNode(answer);
                Assert.Equal(type, Service.GetActualNodeValue());
                Service.MovNode(true);
                Assert.Equal(meal, Service.GetActualNodeValue());
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact(DisplayName = "The node must be at the root")]
        public void NodeMustAtTheRoot()
        {
            string nodeRootName = "massa";
            var service = new DecisionTreeService(null);

            Assert.Equal(GameStatus.Continue, service.MovNode(true));
            service.GoToRoot();
            Assert.Equal(nodeRootName, service.GetActualNodeValue());

            Assert.Equal(GameStatus.Continue, service.MovNode(false));
            service.GoToRoot();
            Assert.Equal(nodeRootName, service.GetActualNodeValue());
        }

        [Fact(DisplayName = "Must lose the game")]
        public void MustLoseTheGame()
        {
            var service = new DecisionTreeService(null);
            Assert.Equal(GameStatus.Continue, service.MovNode(false));
            Assert.Equal(GameStatus.Loser, service.MovNode(false));
        }

        [Fact(DisplayName = "Must win the game")]
        public void MustWinTheGame()
        {
            var service = new DecisionTreeService(null);
            Assert.Equal(GameStatus.Continue, service.MovNode(true));
            Assert.Equal(GameStatus.Winner, service.MovNode(true));
        }
    }
}