using System;
using System.Collections.Generic;
using System.Text;

namespace 状态模式
{

    public enum StateEnum
    {
        SMALL = 0,
        SUPER = 1,
        FIRE = 2,
        CAPE = 3
    }

    public class State
    {
        private int value;
        private State( int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return this.value;
        }
    }
    public class MarioStateMachine
    {
        private int score;
        private StateEnum currentState;

        public MarioStateMachine()
        {
            this.score = 0;
            this.currentState = StateEnum.SMALL;
        }

        public void obtainMushRoom()
        {
            if (currentState.Equals(StateEnum.SMALL))
            {
                this.currentState = StateEnum.SUPER;
                this.score += 100;
            }
        }

        public void obtainCape()
        {
            if (currentState.Equals(StateEnum.SMALL) || currentState.Equals(StateEnum.SUPER))
            {
                this.currentState = StateEnum.CAPE;
                this.score += 200;
            }
        }

        public void obtainFireFlower()
        {
            if (currentState.Equals(StateEnum.SMALL) || currentState.Equals(StateEnum.SUPER))
            {
                this.currentState = StateEnum.FIRE;
                this.score += 300;
            }
        }

        public void meetMonster()
        {
            if (currentState.Equals(StateEnum.SUPER))
            {
                this.currentState = StateEnum.SMALL;
                this.score -= 100;
                return;
            }

            if (currentState.Equals(StateEnum.CAPE))
            {
                this.currentState = StateEnum.SMALL;
                this.score -= 200;
                return;
            }

            if (currentState.Equals(StateEnum.FIRE))
            {
                this.currentState = StateEnum.SMALL;
                this.score -= 300;
                return;
            }
        }

        public int getScore()
        {
            return this.score;
        }

        public StateEnum getCurrentState()
        {
            return this.currentState;
        }
    }


}
