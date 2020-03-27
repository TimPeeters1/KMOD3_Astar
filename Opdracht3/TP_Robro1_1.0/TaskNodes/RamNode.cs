using System;
using System.Collections.Generic;
using System.Text;

namespace TP.TaskNodes
{
    class RamNode : Node
    {
        BlackBoard board;

        bool isMoving;

        public RamNode(BlackBoard _board)
        {
            board = _board;
        }

        public override ReturnStatus Tick()
        {
            if (board.ScannedRobot.Distance > 200 && !isMoving)
            {
                board.SetRobotColor(System.Drawing.Color.Black);
                isMoving = true;

                //Random Move offset
                Random r = new Random();
                int randomRotation = r.Next(-10, 10);

                board.Robot.TurnRight(board.ScannedRobot.Bearing + randomRotation);
                board.Robot.Ahead(board.ScannedRobot.Distance / 2);

                return ReturnStatus.Running;
            }
            else
            {
                isMoving = false;
                if (board.ScannedRobot.Distance > 100)
                {
                    board.Robot.TurnRight(board.ScannedRobot.Bearing);
                    board.Robot.Ahead(board.ScannedRobot.Distance);
                    return ReturnStatus.Failure;
                }
                else
                {
                    board.Robot.Scan();
                    return ReturnStatus.Success;
                }
            }
        }
    }
}
