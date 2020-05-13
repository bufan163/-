using System;
using System.Collections.Generic;
using System.Text;

namespace 状态模式3
{
    /// <summary>
    /// 状态模式能双向绑定
    /// </summary>
    public enum StateEnum
    {
        SMALL = 0,
        SUPER = 1,
        FIRE = 2,
        CAPE = 3
    }
    public interface IMario
    { //所有状态类的接口
        StateEnum getName();
        //以下是定义的事件
        void obtainMushRoom();
        void obtainCape();
        void obtainFireFlower();
        void meetMonster();
    }
    /// <summary>
    /// 状态类
    /// </summary>
    public class SmallMario : IMario
    {
        private MarioStateMachine stateMachine;
        public SmallMario(MarioStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public StateEnum getName()
        {
            return StateEnum.SMALL;
        }
        public void obtainMushRoom()
        {
            stateMachine.setCurrentState(new SuperMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 100);
        }
        public void obtainCape()
        {
            stateMachine.setCurrentState(new CapeMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 200);
        }
        public void obtainFireFlower()
        {
            stateMachine.setCurrentState(new FireMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 300);
        }
        public void meetMonster()
        {
            // do nothing...
        }
    }

    public class SuperMario : IMario
    {
        private MarioStateMachine stateMachine;
        public SuperMario(MarioStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public StateEnum getName()
        {
            return StateEnum.SUPER;
        }
        public void obtainMushRoom()
        {
            // do nothing...
        }
        public void obtainCape()
        {
            stateMachine.setCurrentState(new CapeMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 200);
        }
        public void obtainFireFlower()
        {
            stateMachine.setCurrentState(new FireMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 300);
        }
        public void meetMonster()
        {
            stateMachine.setCurrentState(new SmallMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() - 100);
        }
    }
    public class CapeMario : IMario
    {
        private MarioStateMachine stateMachine;
        public CapeMario(MarioStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public StateEnum getName()
        {
            return StateEnum.SUPER;
        }
        public void obtainMushRoom()
        {
            // do nothing...
        }
        public void obtainCape()
        {
            stateMachine.setCurrentState(new CapeMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 200);
        }
        public void obtainFireFlower()
        {
            stateMachine.setCurrentState(new FireMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 300);
        }
        public void meetMonster()
        {
            stateMachine.setCurrentState(new SmallMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() - 100);
        }
    }
    public class FireMario : IMario
    {
        private MarioStateMachine stateMachine;
        public FireMario(MarioStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public StateEnum getName()
        {
            return StateEnum.SUPER;
        }
        public void obtainMushRoom()
        {
            // do nothing...
        }
        public void obtainCape()
        {
            stateMachine.setCurrentState(new CapeMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 200);
        }
        public void obtainFireFlower()
        {
            stateMachine.setCurrentState(new FireMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() + 300);
        }
        public void meetMonster()
        {
            stateMachine.setCurrentState(new SmallMario(stateMachine));
            stateMachine.setScore(stateMachine.getScore() - 100);
        }
    }

    // 省略 CapeMario、FireMario类...

    public class MarioStateMachine
    {
        private int score;
        private IMario currentState; // 不再使用枚举来表示状态

        public MarioStateMachine()
        {
            this.score = 0;
            this.currentState = new SmallMario(this);
        }

        public void obtainMushRoom()
        {
            this.currentState.obtainMushRoom();
        }

        public void obtainCape()
        {
            this.currentState.obtainCape();
        }

        public void obtainFireFlower()
        {
            this.currentState.obtainFireFlower();
        }

        public void meetMonster()
        {
            this.currentState.meetMonster();
        }

        public int getScore()
        {
            return this.score;
        }

        public StateEnum getCurrentState()
        {
            return this.currentState.getName();
        }

        public void setScore(int score)
        {
            this.score = score;
        }

        public void setCurrentState(IMario currentState)
        {
            this.currentState = currentState;
        }
    }
}
