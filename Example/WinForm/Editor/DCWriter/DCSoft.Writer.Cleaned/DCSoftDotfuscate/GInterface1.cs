using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    public interface IXTextUndo
    {
        bool InGroup
        {
            get;
            set;
        }

        void Undo(GEventArgs3 args);

        void Redo(GEventArgs3 args);
    }
}
