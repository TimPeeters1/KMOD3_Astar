using System;
using System.Collections.Generic;
using System.Text;

namespace TP.TaskNodes
{
    class MoveNode : Node
    {
        BlackBoard board;

        bool isMoving;

        public MoveNode(BlackBoard _board)
        {
            board = _board;
        }

        public override ReturnStatus Tick()
        {
            if(board.ScannedRobot.Distance > 300 && !isMoving)
            {
                board.SetRobotColor(System.Drawing.Color.Blue);
                isMoving = true;

                //Random Move offset
                Random r = new Random();
                int randomRotation = r.Next(-40, 40);

                board.Robot.TurnRight(board.ScannedRobot.Bearing + randomRotation);
                board.Robot.Ahead(board.ScannedRobot.Distance / 4);

                board.Robot.Scan();
                return ReturnStatus.Running;
            }
            else
            {
                isMoving = false;
                if (board.ScannedRobot.Distance > 100)
                {
                    return ReturnStatus.Failure;
                }
                else
                {
                    return ReturnStatus.Success;
                }
            }       
        }
    }
}
