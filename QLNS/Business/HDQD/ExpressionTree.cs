using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace Business.HDQD
{
    public class ExpressionTree
    {
        #region Properties

        public List<string> lstValue;
        public List<Boolean> lstIsLeaf;
        public List<Boolean> lstIsRoot ;
        public List<string> lstLeftNode;
        public List<string> lstRightNode ;
        int i = 0;
        int TreeNodeCount;
        BinaryTreeNode obtn;

        #endregion

        #region Method

        public  void GetExpressionTreeData(BinaryTreeNode btn)
        {
            if (btn.LeftChild.IsLeaf)
            {
                i += 1;
                // insert
                lstValue.Add(btn.LeftChild.Value);
                lstIsLeaf.Add(true);
                lstIsRoot.Add(false);
                lstLeftNode.Add(null);
                lstRightNode.Add(null);
            }
            else
            {
                GetExpressionTreeData(btn.LeftChild);
            }

            if (btn.RightChild.IsLeaf)
            {
                i += 1;
                // insert
                lstValue.Add(btn.RightChild.Value);
                lstIsLeaf.Add(true);
                lstIsRoot.Add(false);
                lstLeftNode.Add(null);
                lstRightNode.Add(null);
            }
            else
            {
                GetExpressionTreeData(btn.RightChild);
            }

            // insert btn
            i += 1;
            lstValue.Add(btn.Value);
            lstIsLeaf.Add(false);
            if (i != TreeNodeCount)
            {
                lstIsRoot.Add(false);
            }
            else
            {
                lstIsRoot.Add(true);
            }
            
            lstLeftNode.Add(btn.LeftChild.Value);
            lstRightNode.Add(btn.RightChild.Value);
        }

        ///
        /// Tạo một cây nhị phân 3 node với node gốc là toán tử, 2 node lá là toán hạng
        ///
        /// <param name="node" />
        /// <param name="opStack" />
        /// <param name="nodeStack" />
        private  void CreateSubTree(Stack<BinaryTreeNode> opStack, Stack<BinaryTreeNode> nodeStack)
        {
            BinaryTreeNode node = opStack.Pop();
            node.RightChild = nodeStack.Pop();
            node.LeftChild = nodeStack.Pop();
            nodeStack.Push(node);
        }

        public  BinaryTreeNode Infix2ExpressionTree(string infixExpression)
        {
            lstValue = new List<string>();
        lstIsLeaf = new List<Boolean>();
       lstIsRoot = new List<Boolean>();
        lstLeftNode = new List<string>();
        lstRightNode = new List<string>();

            //Lis prefix = new List();
            Stack<BinaryTreeNode> operatorStack = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> nodeStack = new Stack<BinaryTreeNode>();

            FormatExpression(ref infixExpression);

            IEnumerable enumer = infixExpression.Split(' ');
            obtn = new BinaryTreeNode();
            
            foreach (string s in enumer)
            {
                if (IsOperand(s))
                    nodeStack.Push(new BinaryTreeNode(s));
                else if (s == "(")
                    operatorStack.Push(new BinaryTreeNode(s));
                else if (s == ")")
                {
                    while (operatorStack.Peek().Value != "(")
                        CreateSubTree(operatorStack, nodeStack);
                    operatorStack.Pop();
                }
                else if (IsOperator(s))
                {
                    while (operatorStack.Count > 0 && GetPriority(operatorStack.Peek().Value) >= GetPriority(s))
                        CreateSubTree(operatorStack, nodeStack);

                    operatorStack.Push(new BinaryTreeNode(s));
                }

            }

            while (operatorStack.Count > 0)
                CreateSubTree(operatorStack, nodeStack);

            obtn = nodeStack.Peek();
            //TreeNodeCount = infixExpression.Split(' ').Except(new string[2]{"(",")"}.AsEnumerable()).Count();
            TreeNodeCount = infixExpression.Split(' ').Count();
            return obtn;
        }

        private  bool IsOperator(string str)
        {
            return Regex.Match(str, @"\(|\)|\+|\-|\*|\/|\%").Success;
        }

        public  bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\d+$|^([a-z]|[A-Z])$").Success;
        }

        public  int GetPriority(string op)
        {
            if (op == "*" || op == "/" || op == "%")
                return 2;
            if (op == "+" || op == "-")
                return 1;
            return 0;
        }

        public  void FormatExpression(ref string expression)
        {
            expression = expression.Replace(" ", "");

            expression = Regex.Replace(expression, @"\+|\-|\*|\/|\%|\)|\(", match =>
                String.Format(" {0} ", match.Value)
            );
            expression = expression.Replace("  ", " ");
            expression = expression.Trim();
        }


        #endregion
    }

    public class BinaryTreeNode
    {
        public BinaryTreeNode LeftChild;
        public BinaryTreeNode RightChild;
        public string Value;

        public bool IsLeaf
        {
            get { return this.LeftChild == null && this.RightChild == null; }
        }

        public BinaryTreeNode(string value)
        {
            Value = value;
        }

        public BinaryTreeNode()
        {

        }

    }
}
