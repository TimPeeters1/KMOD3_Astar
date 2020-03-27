using System;
using System.Collections.Generic;
using System.Text;

namespace TP.TaskNodes
{
    class HealthNode : Node
    {
        BlackBoard board;

        float energyAmount;
        bool doFail; //does the node fail or succeed when the energy is below a certain amount

        public HealthNode(BlackBoard _board, float _energyAmount, bool _doFail)
        {
            board = _board;
            energyAmount = _energyAmount;
            doFail = _doFail;
        }

        public override ReturnStatus Tick()
        {
            if(board.Robot.Energy < energyAmount)
            {
                if (doFail)
                {
                    return ReturnStatus.Failure;
                }
                else
                {
                    return ReturnStatus.Success;
                }
            }
            else
            {
                if (doFail)
                {
                    return ReturnStatus.Success;
                }
                else
                {
                    return ReturnStatus.Failure;
                }
            }
        }
    }
}
