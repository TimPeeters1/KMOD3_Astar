using System;
using System.Collections.Generic;
using System.Text;
using Robocode;

namespace TP
{
    //Reference:
    //https://www.gamasutra.com/blogs/ChrisSimpson/20140717/221339/Behavior_trees_for_AI_How_they_work.php

    public abstract class Node
    {
        public enum ReturnStatus
        {
            Success,
            Failure,
            Running
        }

        public BlackBoard BlackBoard;

        public abstract ReturnStatus Tick();

    }
}
