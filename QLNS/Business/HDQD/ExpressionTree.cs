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

        static List<string> lstValue = new List<string>();
        static List<Boolean> lstIsLeaf = new List<Boolean>();
        static List<Boolean> lstIsRoot = new List<Boolean>();
        static List<string> lstLeftNode = new List<string>();
        static List<string> lstRightNode = new List<string>();
        static BinaryTreeNode btn;


        #endregion

        #region Method

        public static void GetExpressionTreeData(BinaryTreeNode btn)
        {
            if (btn.LeftChild.IsLeaf)
            {
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
            lstValue.Add(btn.Value);
            lstIsLeaf.Add(false);
            lstIsRoot.Add(false);
            lstLeftNode.Add(btn.LeftChild.Value);
            lstRightNode.Add(btn.RightChild.Value);
        }

        ///
        /// Tạo một cây nhị phân 3 node với node gốc là toán tử, 2 node lá là toán hạng
        ///
        /// <param name="node" />
        /// <param name="opStack" />
        /// <param name="nodeStack" />
        private static void CreateSubTree(Stack<BinaryTreeNode> opStack, Stack<BinaryTreeNode> nodeStack)
        {
            BinaryTreeNode node = opStack.Pop();
            node.RightChild = nodeStack.Pop();
            node.LeftChild = nodeStack.Pop();
            nodeStack.Push(node);
        }

        public static BinaryTreeNode Infix2ExpressionTree(string infixExpression)
        {
            //Lis prefix = new List();
            Stack<BinaryTreeNode> operatorStack = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> nodeStack = new Stack<BinaryTreeNode>();

            FormatExpression(ref infixExpression);

            IEnumerable enumer = infixExpression.Split(' ');

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

            return nodeStack.Peek();
        }

        private static bool IsOperator(string str)
        {
            return Regex.Match(str, @"\+|\-|\*|\/|\%").Success;
        }

        public static bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\d+$|^([a-z]|[A-Z])$").Success;
        }

        public static int GetPriority(string op)
        {
            if (op == "*" || op == "/" || op == "%")
                return 2;
            if (op == "+" || op == "-")
                return 1;
            return 0;
        }

        public static void FormatExpression(ref string expression)
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
        public int Count;

        public bool IsLeaf
        {
            get { return this.LeftChild == null && this.RightChild == null; }
        }

        public BinaryTreeNode(string value)
        {
            Value = value;
        }

    }
}
