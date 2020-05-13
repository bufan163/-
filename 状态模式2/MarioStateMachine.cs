using System;
using System.Collections.Generic;
using System.Text;

namespace 状态模式2
{
    /// <summary>
    /// 查表法
    /// </summary>
    public enum EventEnum
    {
        GOT_MUSHROOM = 0,
        GOT_CAPE = 1,
        GOT_FIRE = 2,
        MET_MONSTER = 3
    }
    public enum StateEnum
    {
        SMALL = 0,
        SUPER = 1,
        FIRE = 2,
        CAPE = 3
    }
    public class MarioStateMachine
    {
        private int score;
        private StateEnum currentState;

        StateEnum[,] transitionTable = new StateEnum[4, 4]{
          {StateEnum.SUPER, StateEnum.CAPE, StateEnum.FIRE, StateEnum.SMALL},
          {StateEnum.SUPER, StateEnum.CAPE, StateEnum.FIRE, StateEnum.SMALL},
          {StateEnum.CAPE, StateEnum.CAPE, StateEnum.CAPE, StateEnum.SMALL},
          {StateEnum.FIRE, StateEnum.FIRE, StateEnum.FIRE, StateEnum.SMALL}
          };

        int[,] actionTable = new int[4, 4] {
          {+100, +200, +300, +0},
          {+0, +200, +300, -100},
          {+0, +0, +0, -200},
          {+0, +0, +0, -300}
         };

        public MarioStateMachine()
        {
            this.score = 0;
            this.currentState = StateEnum.SMALL;
        }

        public void obtainMushRoom()
        {
            executeEvent(EventEnum.GOT_MUSHROOM);
        }

        public void obtainCape()
        {
            executeEvent(EventEnum.GOT_CAPE);
        }

        public void obtainFireFlower()
        {
            executeEvent(EventEnum.GOT_FIRE);
        }

        public void meetMonster()
        {
            executeEvent(EventEnum.MET_MONSTER);
        }

        private void executeEvent(EventEnum ee)
        {
            int stateValue = (int)currentState;
            int eventValue = (int)ee;
            this.currentState = transitionTable[stateValue, eventValue];
            this.score = actionTable[stateValue, eventValue];
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
