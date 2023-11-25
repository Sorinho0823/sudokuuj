using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuuj

    /* gyozelmi feltétel, akkor kéne, ha már nincs ues mezo
    miért a Createfiled metodusban hozunk étre eseménykezelot? */
{
    public partial class Form1 : Form
    {
        private List<sudoku> _sudokus = new List<sudoku>();
        private Random random = new Random();
        private sudoku aktualisFeladvany = null;
        public Form1()
        {
            InitializeComponent();
            CreatePlayField();
            LoadSudokus();
            NewGame();
        }

        private void CreatePlayField()
        {
            int lineWidth = 5;
            for (int sor = 0; sor < 9; sor++)
            {
                for (int oszlop = 0; oszlop < 9; oszlop++)
                {
                    sudokufield sf = new sudokufield();
                    sf.Top = sor * sf.Height + (int)(Math.Floor((double)(sor / 3))) * lineWidth;
                    sf.Left = oszlop *sf.Width+ (int)(Math.Floor((double)(oszlop / 3))) * lineWidth;
                    panel1.Controls.Add(sf);
                   // MouseDown += Form1_MouseDown; //miért ide kell az esemény?
                }
            }
        }

       /*private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            string Valtozo //= ""; //valtozo = null;? miért szoveges változo? 
            foreach (var sf in panel1.Controls)
            {Valtozo = sf.va

            }
            aktualisFeladvany.Solution=Valtozo.

        }*/

        private void LoadSudokus()
        {
            _sudokus.Clear();
            StreamReader sr = new StreamReader("sudoku.csv", Encoding.Default); 
            
                sr.ReadLine(); //első sor nem kell, mert az csak fejléc
            while (!sr.EndOfStream)     
            {
                string[] line = sr.ReadLine().Split(',');
                sudoku s = new sudoku();
                s.Quiz = line[0];
                s.Solution= line[1];
                _sudokus.Add(s);
            }


            sr.Close();     //ha lezarom akkor nem kell a using
        

        }

        private sudoku GetRandomQuiz()

        {
            int RandomSzam = random.Next(_sudokus.Count);
            return _sudokus[RandomSzam];
        }
        private void NewGame()
        {

            aktualisFeladvany = GetRandomQuiz();
            int counter = 0;
            foreach (var sf in panel1.Controls.OfType<sudokufield>())
            {
                sf.Value = int.Parse(aktualisFeladvany.Quiz[counter].ToString());
                sf.Active = sf.Value == 0;
                counter++;
            }

        }
    }
}
