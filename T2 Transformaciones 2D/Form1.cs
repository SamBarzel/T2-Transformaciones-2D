namespace T2_Transformaciones_2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Point[] Poligono;
        private Graphics g;//objeto grafico
        private int cX, cY;//centro del plano
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
    }
}
