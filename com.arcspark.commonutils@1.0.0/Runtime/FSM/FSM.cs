using System;
using System.Collections.Generic;
using System.Reflection;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// Finite State Machine.
    /// The managed FSM state MUST be one of the fields of the state machine.
    /// </summary>
    public class FSM
    {
        /// <summary>
        /// Construct a FSM directly.
        /// </summary>
        public FSM() {}

        /// <summary>
        ///Construct a FSM with initial state.
        /// </summary>
        /// <param name="initialState">Initial FSM state.</param>
        public FSM(FSMState initialState)
        {
            Init(initialState);
        }

        /// <summary>
        /// Initialize FSM with a state.
        /// </summary>
        /// <param name="initialState">Initial FSM state.</param>
        public void Init(FSMState initialState)
        {
            if (currentState != null)
                return;
            if (initialState == null)
                return;

            if (isStateLegally(initialState))
            {
                currentState = initialState;
                initialState.EnterState(null);
            }
        }

        /// <summary>
        /// Pass an event to FSM.
        /// </summary>
        /// <param name="evt">Event.</param>
        public void OnEvent<T>(FSMEvent<T> evt)
            where T : Enum
        {
            Type stateType = evt.TargetState;

            if (stateType != null &&
                currentState != null &&
                stateType == currentState.GetType()
            )
            {
                FSMState next = currentState.Transition(evt.EventCode);
                if (next != null && isStateLegally(next))
                {
                    if (currentState != next)
                    {
                        currentState.ExitState(next);
                        FSMState lastState = currentState;
                        currentState = next;
                        next.EnterState(lastState);
                    }
                }
            }
        }

        private bool isStateLegally(FSMState state)
        {
            Type t = state.GetType();
            List<FieldInfo> fields = new List<FieldInfo>(
                GetType().GetFields(
                    BindingFlags.Static |
                    BindingFlags.Public |
                    BindingFlags.NonPublic
                )
            );
            FieldInfo result = fields.Find(p => p.FieldType == t);
            return result != null;
        }

        /// <summary>
        /// Current FSM state.
        /// </summary>
        public FSMState CurrentState
        {
            get => currentState;
        }

        protected FSMState currentState;
    }
}