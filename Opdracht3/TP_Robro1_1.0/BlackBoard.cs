using System;
using System.Collections;
using Robocode;

namespace TP
{
    public class BlackBoard
    {
        public Robot Robot;
        public ScannedRobotEvent ScannedRobot;

        public float radarTimer = 10;
        public bool radarTurnLeft = true;

        public bool hasScannedRobot = false;

        public double RadarBearingAngle()
        {
            double _absoluteBearing = Robot.Heading + ScannedRobot.Bearing;
            double _bearingFromRadar = Robocode.Util.Utils.NormalRelativeAngleDegrees(_absoluteBearing - Robot.RadarHeading);

            return _bearingFromRadar;
        }

        public double GunBearingAngle()
        {
            double _absoluteBearing = Robot.Heading + ScannedRobot.Bearing;
            double _bearingFromGun = Robocode.Util.Utils.NormalRelativeAngleDegrees(_absoluteBearing - Robot.GunHeading);

            return _bearingFromGun;
        }

        public void SetRobotColor(System.Drawing.Color _color)
        {
            if (Robot.BodyColor != _color)
            {
                Robot.SetAllColors(_color);
            }
        }

        public void ScanSweep() //Sweeps the robot radar near the target to improve the aim of the robot.
        {

            if (ScannedRobot != null)
            {
                if (radarTimer > 0)
                {
                    if (!radarTurnLeft)
                    {
                        Robot.TurnRadarRight(3);
                    }
                    else
                    {
                        Robot.TurnRadarLeft(3);
                    }
                }
                else
                {
                    if (radarTurnLeft)
                    {
                        radarTurnLeft = false;
                    }
                    else
                    {
                        radarTurnLeft = true;
                    }
                    hasScannedRobot = false;
                    radarTimer = 5;
                }
                radarTimer--;
            }
        }
    }
}