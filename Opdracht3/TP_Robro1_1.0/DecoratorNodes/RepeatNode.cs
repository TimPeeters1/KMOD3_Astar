using System;
using System.Collections.Generic;
using System.Text;

namespace TP.TaskNodes
{

    //DecoratorNode
    class RepeatNode : Node
    {

        bool repeatTillFail;
        Node parentNode;
        bool repeatInfinite;
        int repeatAmount;

        public RepeatNode(bool _repeatTillFail, Node _parentNode, bool _repeatInfinite, int _repeatAmount)
        {
            this.repeatTillFail = _repeatTillFail;
            this.parentNode = _parentNode;
            this.repeatAmount = _repeatAmount;
        }

        public override ReturnStatus Tick()
        {
            //if (!repeatInfinite)
            //{
            //    for (int i = 0; i < repeatAmount; i++)
            //    {
            //        parentNode.Tick();
                    
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < int.MaxValue; i++)
            //    {
            //        parentNode.Tick();
            //    }
            //}

            throw new System.NotImplementedException();
        }
    }
}
