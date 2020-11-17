using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBoids
{
    class BoidCalculations
    {

        public static BoidObject[] BoidArray;
        public static int VisionDistance = 10;
        public static double CohesionWeight = 0.0003;
        public static double SeparateWeight = 0.001F;
        public static double AlignmentWeight = 0.01F;
        public static float SpeedMultiplier = 1;
        // public static ParallelOptions LimitCores = new ParallelOptions();


        public static void Reset(int StartX, int StartY)
        {
            int BoidCount = 0; // initial number of boids 
            BoidArray = new BoidObject[BoidCount];

            for (int i = 0; i < BoidCount; i++)
            {
                BoidObject Boid = new BoidObject();

                Boid.PosX = StartX;
                Boid.PosY = StartY; 

                BoidArray[i] = Boid;
            }

        }

        public static void GenerateBoids(int x, int y)
        {
            BoidObject Boid = new BoidObject();

            Array.Resize(ref BoidArray, BoidArray.Length + 1);

            Boid.PosX = x;
            Boid.PosY = y; 

            BoidArray[BoidArray.Length - 1] = Boid;

        }

        public static void CalcBoidsCPUSEQ() 
        {
            foreach (BoidObject boid in BoidArray)
            {
                BoidObject[] BoidNeighbours = GetNeighbours(boid);

                double[] CohesiveVelocity = CohesionCalc(boid, BoidNeighbours);
                double[] AlignmentVelocity = AlignmentCalc(boid, BoidNeighbours);
                double[] SeparateVelocity = SeparateCalc(boid, BoidNeighbours);

                boid.VelX += (CohesiveVelocity[0] + AlignmentVelocity[0] + SeparateVelocity[0]);
                boid.VelY += (CohesiveVelocity[1] + AlignmentVelocity[1] + SeparateVelocity[1]);

                boid.AdvancePosition(SpeedMultiplier);
                boid.AvoidWall();
                boid.Wrap();
            }
        }
        public static void CalcBoidsCPUPAR() 
        {
            Parallel.For(0, (BoidArray.Length ),  i =>
            {
                BoidObject[] BoidNeighbours = GetNeighbours(BoidArray[i]);
                
                double[] CohesiveVelocity = CohesionCalc(BoidArray[i], BoidNeighbours);
                double[] AlignmentVelocity = AlignmentCalc(BoidArray[i], BoidNeighbours);
                double[] SeparateVelocity = SeparateCalc(BoidArray[i], BoidNeighbours);

                BoidArray[i].VelX += (CohesiveVelocity[0] + AlignmentVelocity[0] + SeparateVelocity[0]);
                BoidArray[i].VelY += (CohesiveVelocity[1] + AlignmentVelocity[1] + SeparateVelocity[1]);
            });

            for (int i = 0; i < BoidArray.Length; i++)
            {
                BoidArray[i].AdvancePosition(SpeedMultiplier); 
                BoidArray[i].AvoidWall();
                BoidArray[i].Wrap();
            }

        }

        public static void ValidateParCPU() // Unused. If you want to validate parallel results uncomment the function call in Form1.cs timer object
        {
            double[] ValidateSeqX = new double[BoidArray.Length];
            double[] ValidateSeqY = new double[BoidArray.Length];
            double[] ValidateParX = new double[BoidArray.Length];
            double[] ValidateParY = new double[BoidArray.Length];
            int count = 0;
            // Sequential version
            foreach (BoidObject boid in BoidArray)
            {
                BoidObject[] BoidNeighbours = GetNeighbours(boid);

                double[] CohesiveVelocity = CohesionCalc(boid, BoidNeighbours);
                double[] AlignmentVelocity = AlignmentCalc(boid, BoidNeighbours);
                double[] SeparateVelocity = SeparateCalc(boid, BoidNeighbours);

                ValidateSeqX[count] = (CohesiveVelocity[0] + AlignmentVelocity[0] + SeparateVelocity[0]);
                ValidateSeqY[count] = (CohesiveVelocity[1] + AlignmentVelocity[1] + SeparateVelocity[1]);
                count++;
            }
            // Parallel version
            Parallel.For(0, (BoidArray.Length), i =>
            {
                BoidObject[] BoidNeighbours = GetNeighbours(BoidArray[i]);

                double[] CohesiveVelocity = CohesionCalc(BoidArray[i], BoidNeighbours);
                double[] AlignmentVelocity = AlignmentCalc(BoidArray[i], BoidNeighbours);
                double[] SeparateVelocity = SeparateCalc(BoidArray[i], BoidNeighbours);

                ValidateParX[i] = (CohesiveVelocity[0] + AlignmentVelocity[0] + SeparateVelocity[0]);
                ValidateParY[i] = (CohesiveVelocity[1] + AlignmentVelocity[1] + SeparateVelocity[1]);
            });

            for (int i = 0; i < BoidArray.Length; i++)
            {
               if (ValidateSeqX[i] == ValidateParX[i] & ValidateSeqY[i] == ValidateParY[i])
               {
                    BoidArray[i].VelX += ValidateParX[i];
                    BoidArray[i].VelY += ValidateParY[i];
               }
               else
               {
                    throw new System.ArgumentException("Data discrepency between sequential and parallel");
               }
            }

            for (int i = 0; i < BoidArray.Length; i++)
            {
                BoidArray[i].AdvancePosition(SpeedMultiplier);
                BoidArray[i].AvoidWall();
                BoidArray[i].Wrap();
            }
        }

        public static double[] SeparateCalc(BoidObject Boid, BoidObject[] Neighbours) // find vector in opposite direction of neighbouring boids
        {

            double SumCloseX = 0;
            double SumCloseY = 0;

            for (int i = 0; i < Neighbours.Length; i++)
            {

                float PosDiff = GetDistance(Boid, Neighbours[i]);

                if (PosDiff < 10)
                {
                    SumCloseX = SumCloseX + (Boid.PosX - Neighbours[i].PosX);
                    SumCloseY = SumCloseY + (Boid.PosY - Neighbours[i].PosY);
                }

            }
            
            double[] Separate = new double[2];

            Separate[0] = SumCloseX * SeparateWeight;
            Separate[1] = SumCloseY * SeparateWeight;

            return Separate;

        }

        public static double[] AlignmentCalc(BoidObject Boid, BoidObject[] Neighbours) // Aim to match the velocity of surrounding boids 
        {
            
            double SumOfVelX = 0;
            double SumOfVelY = 0;

            for (int i = 0; i < Neighbours.Length; i++)
            {
                SumOfVelX = SumOfVelX + Neighbours[i].VelX;
                SumOfVelY = SumOfVelY + Neighbours[i].VelY;
            }

            double AvgVelX = SumOfVelX / Neighbours.Length;
            double AvgVelY = SumOfVelY / Neighbours.Length;

            double[] VelocityDiff = new double[2];

            VelocityDiff[0] = (AvgVelX - Boid.VelX) * AlignmentWeight;
            VelocityDiff[1] = (AvgVelY - Boid.VelY) * AlignmentWeight;

            return VelocityDiff; 
        }

        public static double[] CohesionCalc(BoidObject Boid, BoidObject[] Neighbours) // Aim to center of surrounding boids 
        {
            double SumOfPosX = 0;
            double SumOfPosY = 0;

            for (int i = 0; i < Neighbours.Length; i++)
            {
                SumOfPosX = SumOfPosX + Neighbours[i].PosX;
                SumOfPosY = SumOfPosY + Neighbours[i].PosY;
            }

            double AveragePosX = SumOfPosX / Neighbours.Length;
            double AveragePosY = SumOfPosY / Neighbours.Length;

            double[] PosDiff = new double[2];

            PosDiff[0] = (AveragePosX - Boid.PosX) * CohesionWeight;
            PosDiff[1] = (AveragePosY - Boid.PosY) * CohesionWeight;

            return PosDiff;

        }
        public static BoidObject[] GetNeighbours(BoidObject Boid) // get array of neighbouring boids within vision distance
        {
            int viewLeft = Boid.IntPosX - (VisionDistance / 2);
            int viewRight = Boid.IntPosX + (VisionDistance / 2);
            int viewUp = Boid.IntPosY + (VisionDistance / 2);
            int viewDown = Boid.IntPosY - (VisionDistance / 2);
            
            BoidObject[] Neighbours = new BoidObject[]{};

            int neighbourCount = 0;

            for (int i = 0; i < BoidArray.Length; i++)
            {
                if(viewLeft < BoidArray[i].IntPosX & viewRight > BoidArray[i].IntPosX)
                {
                    if (viewDown < BoidArray[i].IntPosY & viewUp > BoidArray[i].IntPosY)
                    {
                        Array.Resize(ref Neighbours, Neighbours.Length + 1);
                        Neighbours[neighbourCount] = BoidArray[i];
                        neighbourCount = neighbourCount + 1;
                    }
                }
            }
            return Neighbours;
        }

        public static float GetDistance(BoidObject Boid1, BoidObject Boid2)
        {
            double DiffX = Boid1.PosX - Boid2.PosX;
            double DiffY = Boid1.PosY - Boid2.PosY;

            float PosDiff = (float)Math.Sqrt(DiffX * DiffX + DiffY * DiffY); 

            return PosDiff;
        }

    }
}
