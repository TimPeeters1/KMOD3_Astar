using System;
using System.Collections.Generic;
using System.Text;

namespace TP
{
    class SelectorNode : Node //The OR type node, returns succes if one node in the children returns succes
    {
        Node[] childNodes;

        public SelectorNode(BlackBoard _blackBoard, params Node[] _childNodes)
        {
            this.BlackBoard = _blackBoard;
            this.childNodes = _childNodes;
        }

        public override ReturnStatus Tick()
        {
            foreach(Node node in childNodes)
            {
                switch (node.Tick())
                {
                    case ReturnStatus.Failure:
                         continue;
                    case ReturnStatus.Running:
                        return ReturnStatus.Running;
                    case ReturnStatus.Success:
                        return ReturnStatus.Success;
                }
            }

            return ReturnStatus.Failure;
        }
    }
}
