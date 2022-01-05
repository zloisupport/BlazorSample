using System;

namespace BlazorServer.Stores
{
    public interface IActionDispatcher
    {
        void Subscript(Action<IAction> actionHandler);
        void Unsubscript(Action<IAction> actionHandler);
        void Dispatch(IAction action);
    }
}