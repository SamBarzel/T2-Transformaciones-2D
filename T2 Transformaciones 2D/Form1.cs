namespace T2_Transformaciones_2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Point[] Poligono;
        private Point[] PoligonoT;
        private Graphics g;//objeto grafico
        private int cX, cY;//centro del plano

        //metodo que se encarga de dibujar el palno cartesiano 
        private void plano_Paint(object sender, PaintEventArgs e)
        {
            Pen pluma = new Pen(Color.Black);//pluma para dibujar
            Font f = new Font("Arial", 8);//fuente para escribir
            Brush b = Brushes.Black;//pincel para escribir
            g = e.Graphics;//asignamos el objeto grafico

            //Nuevo Punto de Origen
            cX = plano.Width / 2;//centro del plano
            cY = plano.Height / 2;//centro del plano

            g.DrawLine(pluma, 0, cY, plano.Width, cY);//eje x
            g.DrawLine(pluma, cX, 0, cX, plano.Height);//eje y

            for (int i = -10; i <= 10; i++)
            {
                int x = cX + i * 20;//multiplicamos por 20 para que la escala sea de 20 pixeles
                int y = cY - i * 20;//multiplicamos por 20 para que la escala sea de 20 pixeles

                g.DrawString(i.ToString(), f, b, new Point(x, cY));
                g.DrawString(i.ToString(), f, b, new Point(cX, y));
            }
            g = plano.CreateGraphics();//asignamos el objeto grafico
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnPoligono_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos los valores del TextBox y los convertimos a enteros
                int x1P = int.Parse(textBox1P.Text);
                int y1P = int.Parse(textBox2P.Text);
                int x2P = int.Parse(textBox3P.Text);
                int y2P = int.Parse(textBox4P.Text);
                int x3P = int.Parse(textBox5P.Text);
                int y3P = int.Parse(textBox6P.Text);

                //Dibujamos el poligono usando los datos obtenidos
                Poligono = new Point[]
                {
                    new Point(x1P, y1P),
                    new Point(x2P, y2P),
                    new Point(x3P, y3P)
                };
                for (int i = 0; i < Poligono.Length; i++)
                {
                    Poligono[i].X = Poligono[i].X * 20 + cX;
                    Poligono[i].Y = (Poligono[i].Y * -1) * 20 + cY;
                }
                g.DrawPolygon(new Pen(Color.Blue), Poligono);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese valores al textbox");
            }
        }

        private void btnTraslacion_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos los datos de los texBox y los convertimos a enteros
                int x1 = int.Parse(textBox1P.Text);
                int y1 = int.Parse(textBox2P.Text);
                int x2 = int.Parse(textBox3P.Text);
                int y2 = int.Parse(textBox4P.Text);
                int x3 = int.Parse(textBox5P.Text);
                int y3 = int.Parse(textBox6P.Text);
                int T_x = int.Parse(textBox7T.Text);
                int T_y = int.Parse(textBox8T.Text);

                //Aplicamos la formula de la traslacion
                int Tx1 = x1 + T_x;
                int Ty1 = y1 + T_y;
                int Tx2 = x2 + T_x;
                int Ty2 = y2 + T_y;
                int Tx3 = x3 + T_x;
                int Ty3 = y3 + T_y;

                //Dibujamos el poligono trasladado con los datos obtenidos
                PoligonoT = new Point[]
                {
                    new Point(Tx1, Ty1),
                    new Point(Tx2, Ty2),
                    new Point(Tx3, Ty3)
                };
                for (int i = 0; i < PoligonoT.Length; i++)
                {
                    PoligonoT[i].X = PoligonoT[i].X * 20 + cX;
                    PoligonoT[i].Y = (PoligonoT[i].Y * -1) * 20 + cY;
                }
                g.DrawPolygon(new Pen(Color.Red), PoligonoT);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese valores al textbox");
            }
        }

        private void btnEscalamiento_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos los datos de los texBox y los convertimos a enteros
                int x1 = int.Parse(textBox1P.Text);
                int y1 = int.Parse(textBox2P.Text);
                int x2 = int.Parse(textBox3P.Text);
                int y2 = int.Parse(textBox4P.Text);
                int x3 = int.Parse(textBox5P.Text);
                int y3 = int.Parse(textBox6P.Text);
                int S_x = int.Parse(textBox9E.Text);
                int S_y = int.Parse(textBox10E.Text);

                //Aplicamos la formula del escalamiento
                int Ex1 = x1 * S_x;
                int Ey1 = y1 * S_y;
                int Ex2 = x2 * S_x;
                int Ey2 = y2 * S_y;
                int Ex3 = x3 * S_x;
                int Ey3 = y3 * S_y;

                //Dibujamos el poligono escalado con los datos obtenidos
                PoligonoT = new Point[]
                {
                    new Point(Ex1, Ey1),
                    new Point(Ex2, Ey2),
                    new Point(Ex3, Ey3)
                };
                for (int i = 0; i < PoligonoT.Length; i++)
                {
                    PoligonoT[i].X = PoligonoT[i].X * 20 + cX;
                    PoligonoT[i].Y = (PoligonoT[i].Y * -1) * 20 + cY;
                }
                g.DrawPolygon(new Pen(Color.Green), PoligonoT);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese valores al textbox");
            }
        }
    }
}
