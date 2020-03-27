using System;
using System.Collections.Generic;
using System.Text;
using Robocode;

namespace TP.TaskNodes
{
    class ScanNode : Node
    {
        BlackBoard board;

        bool isScanning;
        double radarStart;

        public ScanNode(BlackBoard _board)
        {
            board = _board;
        }

        public override ReturnStatus Tick()
        {
            if (board.ScannedRobot == null)
            {
                board.Robot.SetAllColors(System.Drawing.Color.ForestGreen);
                board.Robot.TurnRadarLeft(360);

                return ReturnStatus.Success;
            }
            else
            {
                board.Robot.SetAllColors(System.Drawing.Color.DarkGreen);
                
                if (board.ScannedRobot.Bearing > 0)
                {
                    board.Robot.TurnRadarRight(180);
                    return ReturnStatus.Success;
                }
                else
                {
                    board.Robot.TurnRadarLeft(180);
                    return ReturnStatus.Success;
                }
            }
        }
    }
}
