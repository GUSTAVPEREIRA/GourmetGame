using GourmetGame.Model.Enumeration;
using GourmetGame.Services.Service;

namespace GourmetGame.Controllers
{
    public class GameController
    {
        private DecisionTreeService binaryTreeService;

        public GameController()
        {
            binaryTreeService = new DecisionTreeService(null);
        }

        public string GetValue()
        {
            var value = binaryTreeService.GetActualNodeValue();

            return value;
        }

        public GameStatus AnswerQuestion(bool answer)
        {
            var status = binaryTreeService.MovNode(answer);

            return status;
        }

        public void Insert(string meal, string type)
        {
            binaryTreeService.InsertNode(meal, type);
        }

        public void RestartGame()
        {            
            var tree = binaryTreeService.GoToRoot();
            binaryTreeService = new DecisionTreeService(tree);
        }

        public string GetQuestionDescription()
        {
            return binaryTreeService.GetParentName();
        }
    }
}