using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBoids
{
    class BoidObject
    {
        public double PosX;
        public double PosY;

        public int IntPosX;
        public int IntPosY;
        public int OldIntPosX;
        public int OldIntPosY;

        public double VelX;
        public double VelY;

        private static Random RandomDirection = new Random();

        public BoidObject()
        {
            // need to set initial position
            PosX = Form1.AreaWidth / 2; 
            PosY = Form1.AreaHeight / 2; 
            
            // random intial velocity
            VelX = RandomDirection.Next(-100, 100) / 100;
            VelY = RandomDirection.Next(-100, 100) / 100;
        }

        public void AdvancePosition(float Speed) 
        {
            float speed = GetSpeed();
            if (speed != 0) 
            {
                if (speed > 0.5)
                {
                    VelX = (VelX / speed) * 0.5F;
                    VelY = (VelY / speed) * 0.5F;
                }
                if (speed < 0.2)
                {
                    VelX = (VelX / speed) * 0.2F;
                    VelY = (VelY / speed) * 0.2F;
                }
            } 

            OldIntPosX = IntPosX;
            OldIntPosY = IntPosY;

            PosX += VelX * Speed; 
            PosY += VelY * Speed; 
                        
            IntPosX = (int)Math.Round(PosX);
            IntPosY = (int)Math.Round(PosY);
        }



        public float GetSpeed()
        {
            return (float)Math.Sqrt(VelX * VelX + VelY * VelY);
        }

        public void AvoidWall()
        {
            float PadX = Form1.AreaWidth / 20;
            float PadY = Form1.AreaHeight / 20;
            float TurnRate = 0.03F;

            if (PosX < PadX) // if particle is on right wall, set to left wall vice versa
            {
                VelX += TurnRate;
            }
            if (PosX > Form1.AreaWidth - PadX)
            {
                VelX -= TurnRate;
            }
            if (PosY < PadY) // if particle is on right wall, set to left wall vice versa
            {
                VelY += TurnRate;
            }
            if (PosY > Form1.AreaHeight - PadY)
            {
                VelY -= TurnRate;
            }

        }

        public void Wrap()
        {
            if (PosX < 2) // if particle is on right wall, set to left wall vice versa
                PosX += Form1.AreaWidth - 4;
            else if (PosX > Form1.AreaWidth - 2)
                PosX -= Form1.AreaWidth - 4;

            if (PosY < 2)
                PosY += Form1.AreaHeight - 4;
            else if (PosY > Form1.AreaHeight - 2)
                PosY -= Form1.AreaHeight - 4;
        }
    }
}
