using System;

namespace BlazorServer.Stores
{
    public class ActionDispatcher : IActionDispatcher
    { 
        private Action<IAction> _registredActionHandlers;

        public void Subscript(Action<IAction> actionHandler)=> _registredActionHandlers += actionHandler;

        public void Unsubscript(Action<IAction> actionHandler)=> _registredActionHandlers -= actionHandler;
        
        public void Dispatch(IAction action)=>_registredActionHandlers?.Invoke(action);
        
    }
}