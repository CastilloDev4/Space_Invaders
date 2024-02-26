using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Invader
    {
        //Parametros designados a los invasores
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Life { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Image InvaderImage { get; set; }
        private int speedX = 20;//Velocidad a la que se mueven
        private bool moveRight = true;

        //Constructor de invader
        public Invader(int x, int y, int life, int width, int height, Image image) 
        {
            PositionX = x;
            PositionY = y;
            Life = life;
            Width = width;
            Height = height;
            InvaderImage = image;
        }

        //Metodo de posicion para generar el movimiento de los invaders
        public void Move()
        {

            if (moveRight)
            {
                PositionX += speedX;
            }
            else
            {
                PositionX -= speedX;
            }
        }

        public void ReverseDirection() //FUNCION PARA REVERTIR EL MOVIMIENTO HACIA AL DERECHA
        {
            moveRight = !moveRight;
        }

        

    }
     
    
    }
