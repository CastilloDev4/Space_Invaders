using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Shooting
    {
        //Propiedades asigandas a la bala
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool Status { get; set; }
        public int Damage { get; private set; }
        public PictureBox BulletPictureBox { get; set; }

        //Constructor de la clase
        public Shooting(int x, int y, int damage)
        {
            PositionX = x;
            PositionY = y;
            Status = true;
            Damage = damage;

            // Bala creada desde codigo volviendo el pictureBox un objeto
            BulletPictureBox = new PictureBox();
            BulletPictureBox.Size = new Size(6, 20); // TAMAÑO
            BulletPictureBox.BackColor = Color.Red; // COLOR
            BulletPictureBox.Location = new Point(PositionX, PositionY); //POSICION
        }

        public void Move()
        {
                if (Status)
                {
                    // Mueve la bala
                    PositionY=PositionY-15;//De esta forma resta la posicion de Y en 15 unidades
                                           //Y no de uno en uno
                    BulletPictureBox.Location = new Point(PositionX, PositionY);

                    // Verifica si la bala ha salido de la pantalla
                    if (PositionY < 0)
                    {
                        // Si la bala está fuera de la pantalla, desactiva su estado
                        Status = false;
                        // Elimina la imagen de la bala del formulario
                        BulletPictureBox.Parent.Controls.Remove(BulletPictureBox);
                    }
                }
            

        }

        //Cambia el estado de la bala
        public void Disarm()
        {
            Status = false;
        }
    }
}