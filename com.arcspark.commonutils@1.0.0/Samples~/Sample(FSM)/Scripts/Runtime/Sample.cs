using Arcspark.CommonUtils;
using UnityEngine;

namespace Arcspark.Sample.FSMSample
{
    public enum FSMStateT0_Events
    { 
        EVENT_0
    }

    public class FSMStateT0 : FSMState
    {
        public override void EnterState(FSMState fromState)
        {
            base.EnterState(fromState);

            Debug.Log("Enter State T0");
        }

        public override void ExitState(FSMState nextState) 
        {
            Debug.Log("Exit State T0");
        }

        public override FSMState Transition<T>(T eventCode)
        {
            switch (eventCode)
            {
                case FSMStateT0_Events.EVENT_0:
                    return new FSMStateT1();
            }
            return null;
        }
    }

    public class FSMStateT1 : FSMState
    {
        public override void EnterState(FSMState fromState)
        {
            base.EnterState(fromState);

            Debug.Log("Enter State T1");
        }

        public override void ExitState(FSMState nextState)
        {
            Debug.Log("Exit State T1");
        }

        public override FSMState Transition<T>(T eventCode)
        {
            return null;
        }
    }

    public class FSMTest : FSM
    {
        public FSMTest(FSMState initialState)
            :base(initialState){}

        private static FSMStateT0 _0;
        private static FSMStateT1 _1;
    }

    public class Sample : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            FSMTest fsm = new FSMTest(new FSMStateT0());

            Debug.Log(fsm.CurrentState);

            fsm.OnEvent(
                new FSMEvent<FSMStateT0_Events>(
                    typeof(FSMStateT0), 
                    FSMStateT0_Events.EVENT_0
                ));

            Debug.Log(fsm.CurrentState);
        }
    }
}