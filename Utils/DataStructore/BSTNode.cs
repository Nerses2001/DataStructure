

namespace DataStructure.Utils.DataStructore
{
    public class BSTNode<T>
    {
        private T _data;
        private BSTNode<T> _left;
        private BSTNode<T> _right;
        private BSTNode<T> _parent;

        public T Data
        {
            get { return _data; }
            set { _data = value; }

        }
        public BSTNode<T> Left
        {

            get { return _left; }
            set { _left = value; }
        }
        public BSTNode<T> Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public BSTNode<T> Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public BSTNode()
        {
            _left = null;
            _right = null;
            _parent = null;
        }

        public BSTNode(T obj)
        {
            _data = obj;
            _left = null;
            _right = null;
            _parent = null;
        }

        public bool AddLeft(BSTNode<T> node)
        {
            if (_left == null)
            {
                _left = node;
                _left._parent = this;
                return true;
            }

            return false;
        }

        public bool AddRight(BSTNode<T> node)
        {
            if (_right == null)
            {
                _right = node;
                _right._parent = this;
                return true;
            }

            return false;
        }
    }
}
