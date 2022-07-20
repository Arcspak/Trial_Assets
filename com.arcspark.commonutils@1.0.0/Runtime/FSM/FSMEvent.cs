using System;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// An fsm event describes a change in state machine condition.
    /// </summary>
    /// <typeparam name="T">An enum representing event types.</typeparam>
    public class FSMEvent<T>
        where T : Enum
    {
        /// <summary>
        /// Construct FSM event.
        /// </summary>
        /// <param name="targetFSMState">Target FSM state.</param>
        /// <param name="FSMEventCode">Enum value of event.</param>
        public FSMEvent(
            Type targetFSMState,
            T FSMEventCode
        ){
            targetState = targetFSMState;
            eventCode = FSMEventCode;
        }

        /// <summary>
        /// Get target state.
        /// </summary>
        public Type TargetState
        {
            get => targetState;
        }

        /// <summary>
        /// Get event code.
        /// </summary>
        public T EventCode
        {
            get => eventCode;
        }

        private readonly Type targetState;
        private readonly T eventCode;
    }
}