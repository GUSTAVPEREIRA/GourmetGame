using GourmetGame.Model.BinaryTree;
using GourmetGame.Model.Enumeration;

namespace GourmetGame.Services.IService
{
    public interface IDecisionTreeService
    {
        public void InsertNode(string meal, string type);
        public Node GoToRoot();
        public string GetActualNodeValue();
        public GameStatus MovNode(bool answer);
        public string GetParentName();
    }
}
