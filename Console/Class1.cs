
namespace console
{
    public class Node
    {
        public Node Next { get; set; }
        public object Data;
        public Node() { }
        public Node(object data) { Data = data; }
    }
    public class StackEventArgs : EventArgs 
    {
    public string EventMessage { get; }
    public StackEventArgs(string eventMessage) {  EventMessage = eventMessage; }
    }

    public class Stack : Node 
    {
        Node? Top;
        public delegate void StackClearingHandler(object sender, StackEventArgs e);
        public event StackClearingHandler StackEvent;
        public Stack() { }
        public void Pop()
        {
            if (Top == null) return;
            Node n = Top;
            Top = Top.Next;
            OnStackEvent("Deleted the top element!");
        }
        public void Push(object i)
        {
            Node n = new Node(i);
            n.Next = Top;
            Top = n;
            OnStackEvent("Added the element to the top!");
        }
        public void Clear()
        {
            Top = null;
            OnStackEvent("Stack is now empty!");
        }
        private void OnStackEvent(string message) 
        {
            StackEvent?.Invoke(this, new StackEventArgs(message));
        }

    }
   
}
