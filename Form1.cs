using System.Diagnostics;
using System.Drawing.Text;

namespace Space_Invaders
{
    public partial class Form1 : Form

    {
        private SpaceCraft StarRocket = new SpaceCraft(539, 605, 5); // Objeto nave
        private List<Shooting> shootings = new List<Shooting>(); // Lista de disparos
        private List<Invader> invaders = new List<Invader>(); // Lista de invasores
        private List<PictureBox> invaderPictureBoxes = new List<PictureBox>(); // Lista Picture de Invaders
        private HashSet<PictureBox> disabledInvaders = new HashSet<PictureBox>(); // Almacena los PictureBox de invasores deshabilitados
        private Invader[,] Invader_Matrix;
        private int enemyActiveBulletCount = 0; // Contador de disparos enemigos activos
        private int rows = 2;//Cantidad de filas dentro de mi matriz
        private int columns = 15;//Cantidad de columna dentro de mi matriz
        private bool moveRight = true;
        private const int MaxActiveBullets = 1; // Establece el m�ximo de balas activas permitidas
        private int activeBulletCount = 0; // Variable para rastrear el n�mero actual de balas activas
        private bool formOpened = false;
        private System.Windows.Forms.Timer enemyBulletSpawnTimer = new System.Windows.Forms.Timer();


        public Form1()
        {
            //Iicializadores de las funciones del codigo
            InitializeComponent();
            InitializeInvaders();
            InitializeTimers();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

        }

        private void InitializeInvaders() //Inicializador de la matriz
        {
            Invader_Matrix = new Invader[rows, columns];//Se genera la matriz como un invader para
                                                        //que tome las propiedades designadas a la calse invader
            //Bucle para inicializar cada invasor en la matriz y crear controles visuales
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    //Determinar la imagen y la vida del invasor seg�n su posici�n en la matriz
                    Image selectedImage = (row < rows / 2) ? Properties.Resources.InvaderAzul : Properties.Resources.InvaderVerde;
                    int life = (row < rows / 2) ? 3 : 2;
                    //Creacion del objeto
                    Invader invader = new Invader(col * 60, row * 60, life, 70, 70, selectedImage);
                    invaders.Add(invader);
                    //Aqui se asignan el invasor a su posicion correspondiente
                    Invader_Matrix[row, col] = invader;
                    //Aqui se crea el control visual
                    PictureBox invaderPictureBox = new PictureBox();
                    invaderPictureBox.Image = selectedImage;
                    invaderPictureBox.Size = new Size(70, 70);
                    invaderPictureBox.Location = new Point(50 + col * 60, 50 + row * 60);
                    invaderPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    invaderPictureBoxes.Add(invaderPictureBox);
                    this.Controls.Add(invaderPictureBox);
                }
            }
        }

        //Aqui se crea la bala enemiga
        private void EnemyBullet(int startX, int startY)
        {
            //Creracion del control visual de la bala
            PictureBox bullet = new PictureBox();
            bullet.BackColor = Color.Yellow;
            bullet.Size = new Size(5, 10);
            bullet.Location = new Point(startX, startY);
            this.Controls.Add(bullet);
            bullet.BringToFront();//Se envia la bala al frente

            System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();
            bulletTimer.Interval = 20; // Velocidad de la bala (puedes ajustarla)
            bulletTimer.Tick += (sender, e) =>
            {
                bullet.Top += 12; // Velocidad vertical de la bala hacia abajo

                // Verificar colisi�n con la nave
                if (bullet.Bounds.IntersectsWith(SpaceShip.Bounds))
                {
                    if (!formOpened)
                    {
                        OpenNewForm(); // Abre el nuevo formulario en caso de colisi�n
                        formOpened = true;
                    }
                    
                    bulletTimer.Stop(); // Detiene el temporizador de la bala
                    this.Controls.Remove(bullet); // Remueve la bala del formulario
                    enemyActiveBulletCount--; // Disminuye el contador de balas enemigas activas
                }

                // Verificar si la bala sali� de la pantalla
                if (bullet.Bottom > this.ClientSize.Height)
                {
                    bulletTimer.Stop(); // Detiene el temporizador de la bala
                    this.Controls.Remove(bullet); // Remueve la bala del formulario
                    enemyActiveBulletCount--; // Disminuye el contador de balas enemigas activas
                }
            };

            bulletTimer.Start();
        }
        
       //Envento del control del timer
        private void enemyBulletSpawnTimer_Tick(object sender, EventArgs e)
        {
            // Solo crea una bala enemiga si no hay otras balas enemigas activas
            if (enemyActiveBulletCount == 0)
            {
                //Aqui toma como referencias la posicion de mi nave
                int startX = StarRocket.PositionX + (SpaceShip.Width / 2);
                int startY = 0; // Desde la parte superior del formulario
                EnemyBullet(startX, startY);
                enemyActiveBulletCount++;
            }
        }
        private void InitializeTimers()
        {
            // TIMER DE LAS BALAS
            timer1.Enabled = true;
            timer1.Interval = 1; // VELOCIDAD A LA QUE VAN LAS BALAS
            timer1.Tick += timer1_Tick;//Timer de la balas

            // TEMPORIZADOR DE MOVIMIENTO DE LOS MARCIANOS
            invaderTimer.Enabled = true;
            invaderTimer.Interval = 1;
            invaderTimer.Start();

            //TEMPORIZADOR BALAS ENEMIGAS
           // bulletTimer.Enabled= true;  
            bulletTimer.Interval = 100; // Intervalo para el disparo autom�tico (puedes ajustarlo)
            bulletTimer.Tick += bulletTimer_Tick;
            bulletTimer.Start();

            enemyBulletSpawnTimer.Interval = 100; // Intervalo de 1 segundo para la generaci�n de balas enemigas
            enemyBulletSpawnTimer.Tick += enemyBulletSpawnTimer_Tick;
            enemyBulletSpawnTimer.Start();

        }


        private bool AllInvadersDisabled()
        {
            //Contador de los invaders deshabilitados
            int disabledCount = 0;
            //Recorrido para cada uno de los invasores
            foreach (PictureBox invaderPictureBox in invaderPictureBoxes)
            {
                //Aqui se verifica si el invader esta inhabilitado
                if (!invaderPictureBox.Visible)
                {
                    //Y va incrementando segun la cantidad de invasores deshabilitados
                    disabledCount++;
                }
            }

            // Verifica si el n�mero de invasores deshabilitados es igual al total de invasores
            return disabledCount == invaderPictureBoxes.Count;
        }

        //Metodo de movimiento de la nave
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Se crean case para lograr el movimiento atraves de la asignacion
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    StarRocket.Moves(-10, 0);
                    break;

                case Keys.D:
                case Keys.Right:
                    StarRocket.Moves(10, 0);
                    break;

                case Keys.W:
                case Keys.Up:
                    StarRocket.Moves(0, -10);
                    break;

                case Keys.S:
                case Keys.Down:
                    StarRocket.Moves(0, 10);
                    break;

                case Keys.Space:
                    //if (activeBulletCount < MaxActiveBullets) // Verifica si se puede disparar una nueva bala
                    // {
                    int PointX = StarRocket.PositionX + (SpaceShip.Width / 2);
                    Shooting shot = new Shooting(PointX, StarRocket.PositionY, 1);
                    shootings.Add(shot);

                    PictureBox bulletPictureBox = shot.BulletPictureBox;
                    this.Controls.Add(bulletPictureBox);

                    activeBulletCount++; // Incrementa el contador de balas activas
                                         // }
                    break;
            }

            SpaceShip.Location = new Point(StarRocket.PositionX, StarRocket.PositionY);
            SpaceShip.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool allInvadersDisabled = AllInvadersDisabled(); // Verifica si todos los invasores est�n deshabilitados
            //Verifica los invasores y si no se ha abrierto un formulario extra
            if (allInvadersDisabled && !formOpened)
            {
                OpenNewForm(); // Abre el nuevo formulario solo si todos los invasores est�n deshabilitados
                formOpened = true; // Marca que el formulario adicional se ha abierto
            }

            //Realiza un recorrido por todas las balas generadas
            foreach (Shooting currentShot in shootings.ToList())
            {
                if (currentShot.Status) // Verifica si la bala est� activa
                {
                    currentShot.Move(); // Mueve la bala

                    bool collisionDetected = false;

                    //Realiza un recorrido atravez de los picture box
                    foreach (PictureBox invaderPictureBox in invaderPictureBoxes)
                    {
                        // Verifica si el invasor es visible, no est� deshabilitado y colisiona con la bala
                        if (invaderPictureBox.Visible && !disabledInvaders.Contains(invaderPictureBox) &&
                            invaderPictureBox.Bounds.IntersectsWith(currentShot.BulletPictureBox.Bounds))
                        {
                            // Desactiva el invasor y lo agrega a la lista de invasores deshabilitados
                            invaderPictureBox.Visible = false;
                            disabledInvaders.Add(invaderPictureBox);
                            collisionDetected = true;
                            currentShot.Disarm(); // Inhabilita la bala al golpear un invasor
                            break; // Sale del bucle, la bala choc� con un invasor
                        }
                    }
                    // Elimina la bala si choc� con un invasor o si alcanz� el l�mite superior de la pantalla
                    if (collisionDetected || currentShot.PositionY < 0)
                    {
                        shootings.Remove(currentShot);
                        this.Controls.Remove(currentShot.BulletPictureBox);
                    }
                }
            }

            // Invalida el �rea del PictureBox para forzar un nuevo dibujo
            SpaceShip.Invalidate();
        }
        private void OpenNewForm()
        {
            // Crear y mostrar un nuevo formulario
            Form2 form2 = new Form2(); // Reemplaza 'Form2' con el nombre de tu nuevo formulario
            form2.Show();
            this.Hide();
        }
        //Envento del movimiento de los invarores
        private void invaderTimer_Tick(object sender, EventArgs e)
        {
            InvadersMove();
        }

        private void InvadersMove()
        {
            foreach (var invader in invaders)
            {
                invader.Move();//Mueve cada invasor
            }

            // Verifica si la matriz llega al borde de la pantalla
            if (InvadersAtEdges())
            {
                // Cambia la direcci�n de movimiento de toda la matriz
                moveRight = !moveRight;

                //MOVIMIENTO HACIA ABAJO DE LOS INVASORES, ENTRE MAS GRANDE SEA EL NUMERO MAS VA A BAJAR
                foreach (var invader in invaders)
                {
                    invader.PositionY += 20;
                }

                // Revierte el movimiento para que rebote en el borde
                foreach (var invader in invaders)
                {
                    invader.ReverseDirection(); //llamado a el nuevo metodo agregado en la clase invader
                }
            }

            RedrawInvaders();
        }

        private bool InvadersAtEdges()
        {
            foreach (var invader in invaders)
            {
                //empieza en 0
                if (invader.PositionX <= 0 || invader.PositionX >= ClientSize.Width - invader.Width) /* CLIENTSIZE.WIDTH: 
                                                                                                      * Es el ancho de la ventana del formulario. 
                                                                                                      * Representa el valor maximo en el eje X */
                /* INVADER.WIDTH:
                 * Es el ancho del invasor. 
                *Restar este valor de ClientSize.Width 
                *da la posici�n m�xima permitida en el eje X para un invasor, toda la matriz*/


                {
                    return true;
                }
            }
            return false;
        }


        private void RedrawInvaders()
        {
            /* Determina el n�mero de invasores a actualizar 
              (toma el m�nimo entre la cantidad de invasores y la cantidad de PictureBox)*/
            int count = Math.Min(invaders.Count, invaderPictureBoxes.Count);

            for (int i = 0; i < count; i++)
            {
                // Actualiza la ubicaci�n del PictureBox para reflejar la posici�n actual del invasor
                invaderPictureBoxes[i].Location = new Point(invaders[i].PositionX, invaders[i].PositionY);
            }
        }

        private void bulletTimer_Tick(object sender, EventArgs e)
        {
            // Verifica si el n�mero de balas activas es menor que el l�mite establecido
            if (activeBulletCount < MaxActiveBullets)
            {
                int randomInvaderIndex = new Random().Next(0, invaders.Count);
                Invader selectedInvader = invaders[randomInvaderIndex];// Selecciona un invasor aleatorio
                // Calcula la posici�n en la que aparecer� la bala en relaci�n con el invasor seleccionado
                int pointX = selectedInvader.PositionX + (selectedInvader.Width / 2);
                int pointY = selectedInvader.PositionY + selectedInvader.Height;
                // Crea una bala en la posici�n calculada
                EnemyBullet(pointX, pointY);
                activeBulletCount++;// Incrementa el contador de balas activas
            }
        }
    }
}