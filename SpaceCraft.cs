using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class SpaceCraft
    {
        //Parametros designados para la nave
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int LifePoints { get; private set; }

        //Constructor de la nave
        public SpaceCraft(int X, int Y,  int lifePoints)
        {
            PositionX = X;
            PositionY = Y;
            LifePoints = lifePoints;
        }

        //Metodo para definir la forma del movimiento
        public void Moves(int deltaX, int deltaY)
        {
            PositionX += deltaX;
            PositionY += deltaY;
        }

    }
}
