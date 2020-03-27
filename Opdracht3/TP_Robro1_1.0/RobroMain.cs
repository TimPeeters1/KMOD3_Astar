using System;
using System.Collections;
using System.Drawing;
using Robocode;
using TP.TaskNodes;

namespace TP
{
    public class RobroMain : Robot
    {
        public Node Root;
        public BlackBoard board = new BlackBoard();

        public override void Run()
        {
            board.Robot = this;
            board.Robot.IsAdjustRadarForRobotTurn = false;


            //Behaviour Tree
            Node fireSequence = new SequenceNode(board, new HealthNode(board, 30, true), new ScanNode(board), new AimNode(board), new FireNode(board));

            Node moveSequence = new SequenceNode(board, new HealthNode(board, 30, true), new MoveNode(board));

            Node ramSequence = new SequenceNode(board, new HealthNode(board, 30, false), new ScanNode(board), new RamNode(board));

            Root = new SelectorNode(board, fireSequence, moveSequence, ramSequence);

            while (true)
            {
                Root.Tick();
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            board.Robot.Out.WriteLine("Scanned Robot");

            board.ScannedRobot = evnt;
        }
    }
}
