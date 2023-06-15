using System;


// Black -> or Black or Red
// Red -> only Black
// Every leaf node (NIL or null node) is black.
// Search O(Log n)
// Every path from a node to its descendant leaf nodes contains an equal number of black nodes (this property is known as black depth or black height).
/*                      20
 *             15
 *      10           16
 *  8       14
 *  RightRotate(15)
                     20
 *              10
 *        8           15
 *              14          16      
 *              
 *              B            RightRotat(B)->         A
 *          A     y          <-LeftRotat(A)    a         B    
 *        a  b                                        b      y
 *              
 */
// R B INSERT (T z)
// y = T nil
// x = T root
// while x != T.nil
//       y = x
//       if z.key < x.left
//            x = x.left
//            y = x.right
// z.p == y
// if y == T.nill
//    T.root = z
//else if z.key < y.key
//      y.left = z
//else y.right = z
// z.left = T.nill
// z. right = T.nill
//z.colr = RED
// R B INSERT (T z)

// R B INSERT FIXUP(T z)
// whlie z.p color == RED
//       if z.p == z.p.p.left
//          y = z.p.p.right
//          if y.color == RED
//             z.p.color = BLACK
//             Y.color = BLACK
//             z.p.p.color = RED
//          else if z == z.p.right
//                  z = z.p
//                  LeftRotate(T,z)
//               z.p.color = BLACK
//               z.p.p.color = RED
//               RightRotate(T,z.p.p)

// Add log(n)


namespace DataStructure.Utils.DataStructore
{

    enum Color
    {
        Red,
        Black
    }
    class RedBlackTree
    {
        public class Node
        {
            public Color colour;
            public Node left;
            public Node right;
            public Node parent;
            public int data;

            public Node(int data) { this.data = data; }
            public Node(Color colour) { this.colour = colour; }
            public Node(int data, Color colour) { this.data = data; this.colour = colour; }
        }
        private Node root;
        public RedBlackTree() { }
     
        private void LeftRotate(Node X)
        {
            Node Y = X.right; 
            X.right = Y.left;
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent;            }
            if (X.parent == null)
            {
                root = Y;
            }
            if (X == X.parent.left)
            {
                X.parent.left = Y;
            }
            else
            {
                X.parent.right = Y;
            }
            Y.left = X; 
            if (X != null)
            {
                X.parent = Y;
            }

        }

        private void RightRotate(Node Y)
        {
            Node X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;
            if (Y != null)
            {
                Y.parent = X;
            }
        }
 
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (root != null)
            {
                InOrderDisplay(root);
            }
        }
        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key < temp.data)
                {
                    temp = temp.left;
                }
                if (key > temp.data)
                {
                    temp = temp.right;
                }
                if (key == temp.data)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found", key);
                return null;
            }
        }

        public void Insert(int item)
        {
            Node newItem = new Node(item);
            if (root == null)
            {
                root = newItem;
                root.colour = Color.Black;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.data < X.data)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.data < Y.data)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = Color.Red;
            InsertFixUp(newItem);
        }
        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplay(current.right);
            }
        }
        private void InsertFixUp(Node item)
        {
            while (item != root && item.parent.colour == Color.Red)
            {
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == Color.Red)
                    {
                        item.parent.colour = Color.Black;
                        Y.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }
                    else 
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    Node X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.colour == Color.Black)
                    {
                        item.parent.colour = Color.Red;
                        X.colour = Color.Red;
                        item.parent.parent.colour = Color.Black;
                        item = item.parent.parent;
                    }
                    else 
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = Color.Black;            }
        }
     
    }

}

