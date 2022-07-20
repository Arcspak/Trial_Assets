using System;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// Base class of all custom FSMState classes.
    /// </summary>
    public abstract class FSMState
    {
        /// <summary>
        /// Called when the state enters.
        /// </summary>
        /// <param name="fromState">State of the source.</param>
        public virtual void EnterState(FSMState fromState)
        {
            sourceState = fromState;
        }

        /// <summary>
        /// Called when the state exits
        /// </summary>
        public virtual void ExitState(FSMState nextState) {}

        /// <summary>
        /// Handle event code and control whether to transfer state.
        /// </summary>
        /// <param name="eventCode">Event code.</param>
        /// <returns>
        /// State after transfer.
        /// If you don't want to transfer state, you can return null.
        /// </returns>
        public abstract FSMState Transition<T>(T eventCode)
            where T: Enum;

        protected FSMState sourceState;
    }
}