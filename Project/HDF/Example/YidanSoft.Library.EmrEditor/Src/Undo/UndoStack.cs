using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Actions;

namespace YidanSoft.Library.EmrEditor.Src.Undo
{
    /// <summary>
    /// This class implements an undo stack
    /// 这个类实现了一个撤销、重做栈
    /// </summary>
    public class UndoStack
    {
        public Stack<ZYEditorAction> undostack = new Stack<ZYEditorAction>();
        public Stack<ZYEditorAction> redostack = new Stack<ZYEditorAction>();

        public ZYEditorControl myZYEditorControl = null;

        /// <summary>
        /// </summary>
        public event EventHandler ActionUndone;
        /// <summary>
        /// </summary>
        public event EventHandler ActionRedone;

        public event OperationEventHandler OperationPushed;

        /// <summary>
        /// Gets/Sets if changes to the document are protocolled by the undo stack.
        /// Used internally to disable the undo stack temporarily while undoing an action.
        /// 当正在撤销一个动作时，使undo stack无效
        /// </summary>
        internal bool AcceptChanges = true;

        /// <summary>
        /// Gets if there are actions on the undo stack.
        /// 如果undostack.Count>0说明undo stack有可以撤销的内容
        /// </summary>
        public bool CanUndo
        {
            get
            {
                return undostack.Count > 0;
            }
        }

        /// <summary>
        /// Gets if there are actions on the redo stack.
        /// 重做栈中是否有内容
        /// </summary>
        public bool CanRedo
        {
            get
            {
                return redostack.Count > 0;
            }
        }

        /// <summary>
        /// Gets the number of actions on the undo stack.
        /// 数目
        /// </summary>
        public int UndoItemCount
        {
            get
            {
                return undostack.Count;
            }
        }

        /// <summary>
        /// Gets the number of actions on the redo stack.数目
        /// </summary>
        public int RedoItemCount
        {
            get
            {
                return redostack.Count;
            }
        }

        //int undoGroupDepth;
        //int actionCountInUndoGroup;

        //public void StartUndoGroup()
        //{
        //    if (undoGroupDepth == 0)
        //    {
        //        actionCountInUndoGroup = 0;
        //    }
        //    undoGroupDepth++;
        //    //Util.LoggingService.Debug("Open undo group (new depth=" + undoGroupDepth + ")");
        //}

        //public void EndUndoGroup()
        //{
        //    if (undoGroupDepth == 0)
        //        throw new InvalidOperationException("There are no open undo groups");
        //    undoGroupDepth--;
        //    //Util.LoggingService.Debug("Close undo group (new depth=" + undoGroupDepth + ")");
        //    if (undoGroupDepth == 0 && actionCountInUndoGroup > 1)
        //    {
        //        UndoQueue op = new UndoQueue(undostack, actionCountInUndoGroup);
        //        undostack.Push(op);
        //        if (OperationPushed != null)
        //        {
        //            OperationPushed(this, new OperationEventArgs(op));
        //        }
        //    }
        //}

        //public void AssertNoUndoGroupOpen()
        //{
        //    if (undoGroupDepth != 0)
        //    {
        //        undoGroupDepth = 0;
        //        throw new InvalidOperationException("No undo group should be open at this point");
        //    }
        //}

        /// <summary>
        /// Call this method to undo the last operation on the stack
        /// 调用这个方法，撤销最后一次操作
        /// </summary>
        public void Undo()
        {
            //AssertNoUndoGroupOpen();
            if (undostack.Count > 0)
            {
                ZYEditorAction uedit = (ZYEditorAction)undostack.Pop();
                redostack.Push(uedit);
                uedit.Undo();
                OnActionUndone();
            }
        }

        /// <summary>
        /// Call this method to redo the last undone operation
        /// </summary>
        public void Redo()
        {
            //AssertNoUndoGroupOpen();
            if (redostack.Count > 0)
            {
                ZYEditorAction uedit = (ZYEditorAction)redostack.Pop();
                undostack.Push(uedit);
                uedit.Redo();
                OnActionRedone();
            }
        }

        /// <summary>
        /// Call this method to push an UndoableOperation on the undostack, the redostack
        /// will be cleared, if you use this method.
        /// </summary>
        public void Push(ZYEditorAction operation)
        {


            if (operation == null)
            {
                throw new ArgumentNullException("operation");
            }

            if (AcceptChanges)
            {
                //StartUndoGroup();
                undostack.Push(operation);
                //actionCountInUndoGroup++;
                //if (myZYEditorControl != null)
                //{
                //    undostack.Push(new UndoableSetCaretPosition(this, myZYEditorControl.ActiveTextAreaControl.Caret.Position));
                //    actionCountInUndoGroup++;
                //}
                //EndUndoGroup();
                ClearRedoStack();
            }
        }

        /// <summary>
        /// Call this method, if you want to clear the redo stack
        /// </summary>
        public void ClearRedoStack()
        {
            redostack.Clear();
        }

        /// <summary>
        /// Clears both the undo and redo stack.
        /// </summary>
        public void ClearAll()
        {
            //AssertNoUndoGroupOpen();
            undostack.Clear();
            redostack.Clear();
            //actionCountInUndoGroup = 0;
        }

        /// <summary>
        /// </summary>
        protected void OnActionUndone()
        {
            if (ActionUndone != null)
            {
                ActionUndone(null, null);
            }
        }

        /// <summary>
        /// </summary>
        protected void OnActionRedone()
        {
            if (ActionRedone != null)
            {
                ActionRedone(null, null);
            }
        }

        //class UndoableSetCaretPosition : IUndoableOperation
        //{
        //    UndoStack stack;
        //    TextLocation pos;
        //    TextLocation redoPos;

        //    public UndoableSetCaretPosition(UndoStack stack, TextLocation pos)
        //    {
        //        this.stack = stack;
        //        this.pos = pos;
        //    }

        //    public void Undo()
        //    {
        //        redoPos = stack.myZYEditorControl.Caret.Position;
        //        stack.myZYEditorControl.Caret.Position = pos;
        //        stack.myZYEditorControl.SelectionManager.ClearSelection();
        //    }

        //    public void Redo()
        //    {

        //        stack.myZYEditorControl.Position = redoPos;
        //        stack.myZYEditorControl.SelectionManager.ClearSelection();
        //    }
        //}

    }

    public class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(ZYEditorAction op)
        {
            this.op = op;
        }

        ZYEditorAction op;

        public ZYEditorAction Operation
        {
            get
            {
                return op;
            }
        }
    }

    public delegate void OperationEventHandler(object sender, OperationEventArgs e);


    /// <summary>
    /// 一个行/列位置,文本编辑器里的行列位置,从0开始计数.
    /// </summary>
    public struct TextLocation 
    {
        /// <summary>
        /// Represents no text location (-1, -1).
        /// </summary>
        public static readonly TextLocation Empty = new TextLocation(-1, -1);

        public TextLocation(int column, int line)
        {
            x = column;
            y = line;
        }

        int x, y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Line
        {
            get { return y; }
            set { y = value; }
        }

        public int Column
        {
            get { return x; }
            set { x = value; }
        }
    }
}
