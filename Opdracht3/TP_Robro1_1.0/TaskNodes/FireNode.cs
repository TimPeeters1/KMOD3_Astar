using System;
using System.Collections.Generic;
using System.Text;
using Robocode;

namespace TP.TaskNodes
{
    class FireNode : Node
    {
        BlackBoard board;

        public FireNode(BlackBoard board)
        {
            this.board = board;
        }

        public override ReturnStatus Tick()
        {
            if (board.ScannedRobot == null || board.ScannedRobot.Distance > 300)
            {
                return ReturnStatus.Failure;
            }

            if (Math.Abs(board.GunBearingAngle()) > 5)
            {
                return ReturnStatus.Failure;
            }
            else
            {
                board.Robot.SetAllColors(System.Drawing.Color.Orange);

                board.Robot.Fire(3);
                return ReturnStatus.Success;
            }

        }
    }
}
