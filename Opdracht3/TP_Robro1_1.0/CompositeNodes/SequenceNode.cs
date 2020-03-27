using System;
using System.Collections.Generic;
using System.Text;

namespace TP
{
    class SequenceNode : Node //The AND type node, all children nodes need to return succes.
    {
        Node[] childNodes;

        public SequenceNode(BlackBoard _blackBoard, params Node[] _childNodes)
        {
            this.BlackBoard = _blackBoard;
            this.childNodes = _childNodes;
        }
       
        public override ReturnStatus Tick()
        {
            foreach (Node node in childNodes)
            {
                switch (node.Tick())
                {
                    case ReturnStatus.Success:
                         this.BlackBoard.Robot.Out.WriteLine(node.ToString());
                         continue;
                    case ReturnStatus.Failure:
                        return ReturnStatus.Failure;
                    case ReturnStatus.Running:
                        return ReturnStatus.Running;
                }
                
            }

            return ReturnStatus.Success;
        }
    }
}
