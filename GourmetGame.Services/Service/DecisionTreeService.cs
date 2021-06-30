using GourmetGame.Model.BinaryTree;
using GourmetGame.Model.Enumeration;

namespace GourmetGame.Services.Service
{
    public class DecisionTreeService
    {
        private Node DecisionTreeRoot { get; set; }

        public DecisionTreeService(Node node)
        {
            DecisionTreeRoot = node;

            if (DecisionTreeRoot == null)
            {
                Node newTree = new Node("massa", null);
                newTree.YesNode = new Node("Lasanha", newTree);
                newTree.NoNode = new Node("Bolo de Chocolate", newTree);
                DecisionTreeRoot = newTree;
            }
        }

        public void InsertNode(string meal, string type)
        {
            Node auxNode = DecisionTreeRoot;
            Node newType = new Node(type,auxNode.Parent);
            Node NewMeal = new Node(meal,newType);

            // check if current node is one yes response
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

        public GameStatus MovNode(bool answer)
        {
            GameStatus gameStatus = GameStatus.Continue;

            // if answer is yes
            if (answer == true)
            {
                if (DecisionTreeRoot.YesNode == null)
                {
                    gameStatus = GameStatus.Winner;
                }
                else
                {
                    DecisionTreeRoot = DecisionTreeRoot.YesNode;
                }
            }
            else
            {
                if (DecisionTreeRoot.NoNode == null)
                {
                    gameStatus = GameStatus.Loser;
                }
                else
                {
                    DecisionTreeRoot = DecisionTreeRoot.NoNode;
                }
            }

            return gameStatus;
        }

        public string GetParentName()
        {
            return DecisionTreeRoot.Parent.Name;
        }
    }
}