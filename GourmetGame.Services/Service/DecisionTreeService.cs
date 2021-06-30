using GourmetGame.Model.BinaryTree;
using GourmetGame.Model.Enumeration;
using GourmetGame.Services.IService;

namespace GourmetGame.Services.Service
{
    public class DecisionTreeService : IDecisionTreeService
    {
        private Node DecisionTreeRoot { get; set; }

        public DecisionTreeService(Node node)
        {
            DecisionTreeRoot = node;

            if (DecisionTreeRoot == null)
            {
                Node newTree = new Node("massa");
                newTree.YesNode = new Node("Lasanha", newTree);
                newTree.NoNode = new Node("Bolo de Chocolate", newTree);
                DecisionTreeRoot = newTree;
            }
        }

        /// <summary>
        /// Inserts in the node, rearranging itself so that it preserves the previous parent
        /// </summary>
        /// <param name="meal"></param>
        /// <param name="type"></param>
        public void InsertNode(string meal, string type)
        {
            Node auxNode = DecisionTreeRoot;
            Node newType = new Node(type,auxNode.Parent);
            Node NewMeal = new Node(meal,newType);
            
            if (auxNode == auxNode.Parent.YesNode)
            {
                auxNode.Parent.YesNode = newType;
            }
            else 
            {
                auxNode.Parent.NoNode = newType;
            }
            
            newType.YesNode = NewMeal;
            newType.NoNode = auxNode;            
            auxNode.Parent = newType;
        }

        /// <summary>
        /// Return node to first
        /// </summary>
        /// <returns></returns>
        public Node GoToRoot()
        {
            while (DecisionTreeRoot.Parent != null)
            {
                DecisionTreeRoot = DecisionTreeRoot.Parent;
            }

            return DecisionTreeRoot;
        }

        public string GetActualNodeValue()
        {
            return DecisionTreeRoot?.Name;
        }

        /// <summary>
        /// Move node depending on answer
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public GameStatus MovNode(bool answer)
        {
            GameStatus gameStatus = GameStatus.Continue;
            
            if (answer == true)
            {
                switch (DecisionTreeRoot.YesNode)
                {
                    case null:
                        gameStatus = GameStatus.Winner;
                        break;
                    default:
                        DecisionTreeRoot = DecisionTreeRoot.YesNode;
                        break;
                }
            }
            else
            {
                switch (DecisionTreeRoot.NoNode)
                {
                    case null:
                        gameStatus = GameStatus.Loser;
                        break;
                    default:
                        DecisionTreeRoot = DecisionTreeRoot.NoNode;
                        break;
                }
            }

            return gameStatus;
        }

        /// <summary>
        /// This method has been created for get parent name
        /// </summary>
        /// <returns></returns>
        public string GetParentName()
        {
            return DecisionTreeRoot.Parent.Name;
        }
    }
}