using System;
using System.Collections.Generic;
using System.Text;
using Robocode;

namespace TP.TaskNodes
{
    class AimNode : Node
    {
        BlackBoard board;

        bool isRotating;

        public AimNode(BlackBoard _board)
        {
            board = _board;
        }

        public override ReturnStatus Tick()
        {
            if (board.ScannedRobot == null && board.ScannedRobot.Distance > 100)
            {
                    return ReturnStatus.Failure;
            }

            if (Math.Abs(board.GunBearingAngle()) > 5 && !isRotating)
            {
                board.SetRobotColor(System.Drawing.Color.DarkRed);
                isRotating = true;

                board.Robot.TurnRadarRight(board.RadarBearingAngle());
                board.Robot.TurnRight(board.ScannedRobot.Bearing);

                return ReturnStatus.Running;
            }
            else
            {
                isRotating = false;
                return ReturnStatus.Success;
            }



            
        }

    }
}
