using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MLP_hw2
{
    public partial class MLP : Form
    {
        Graphics objGraphics;
       

        string path = "mlp data/";  // data set file path
        string path1 = "mlp data/"; // data set file path
        private int _hiddenDims = 2;        // Number of hidden neurons.
        private int _inputDims = 2;        // Number of input neurons.
        private int _iteration;            // Current training iteration.
        private int _restartAfter = 2000;   // Restart training if iterations exceed this.
        private Layer _hidden;              // Collection of hidden neurons.
        private Layer _inputs;              // Collection of input neurons.
        private List<Pattern> _patterns;    // 2/3 patterns for training .
        private List<Pattern> allPatterns;  //collection of all pattern.
        private List<Pattern> _test;    // 1/3 patterns for testing.
        private Neuron _output;            // Output neuron.
        private Random _rnd = new Random(); // Global random number generator.

        int dimenstion = 0;
        
        //[STAThread]
        //static void Main()
        //{
        //    new MLP();
        //}

        public MLP()
        {
            InitializeComponent();
            btnTrain.Enabled = false;
            objGraphics = pnlCanvas.CreateGraphics();
            string[] filePaths = Directory.GetFiles(path, "*.txt");
            foreach (string file in filePaths)
            {
                cbFileName.Items.Add(Path.GetFileNameWithoutExtension(file));
                
            }
            
        }

        private void Train()
        {
            double error;
            double act;
            do
            {
                error = 0;
                foreach (Pattern pattern in _patterns)
                {
                    act = Activate(pattern);
                    double delta = pattern.Output - act;
                    //Console.WriteLine("output : "+pattern.Output);
                    AdjustWeights(delta);
                    error += Math.Pow(delta, 2);
                   
                }
                error = error / 2;  //E(n)=1/2(平方差瞬間值的總合)
                Console.WriteLine("Iteration {0}\t  Error {1:0.000}", _iteration, error);
                _iteration++;
                
            } while (error > 0.1 && _iteration <= _restartAfter);
            for (int i = 0; i < _output.Weight.Count; i++)
            {
                Console.Write("("+i+")" + "final weights " + " : " + Math.Round(_output.Weight.ElementAt(i).Value, 3) + " ");
            }
            Console.WriteLine();
        }

        private void Test()
        {
            Console.WriteLine("\nBegin network testing\nPress Ctrl C to exit\n");

            foreach (Pattern testP in _test)
            {
                
                Console.Write("Input x, y: ");
                string values = "";
                for (int i = 0; i < _inputDims; i++)
                {
                    if (i < _inputDims - 1)
                        values += testP.Inputs[i] + ", ";
                    else
                        values += testP.Inputs[i];
                }

                Console.WriteLine(values);
                double actAns = Activate(new Pattern(values, _inputDims - 1));
                Console.WriteLine("{0:0}\n ", actAns);
            }
            DrawPatterns();
        }

        private double Activate(Pattern pattern)
        {
            for (int i = 0; i < pattern.Inputs.Length; i++)
            {
                _inputs[i].Output = pattern.Inputs[i];
            }
            foreach (Neuron neuron in _hidden)
            {
                neuron.Activate();
            }
            _output.Activate();
           
            return _output.Output;
            
        }

        private void AdjustWeights(double delta)
        {
            _output.AdjustWeights(delta);
            foreach (Neuron neuron in _hidden)
            {
                neuron.AdjustWeights(_output.ErrorFeedback(neuron));
            }
        }

        private void Initialise()
        {
            _inputs = new Layer(_inputDims);
            _hidden = new Layer(_hiddenDims, _inputs, _rnd);
            _output = new Neuron(_hidden, _rnd);
            _iteration = 0;
            Console.WriteLine("Network Initialised");
        }

        private void LoadPatterns()
        {
            _inputDims = dimenstion;
            _patterns = new List<Pattern>();
            allPatterns = new List<Pattern>();
            _test = new List<Pattern>();
            StreamReader file = File.OpenText("Patterns.csv");
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
               
                allPatterns.Add(new Pattern(line, _inputDims));
               
            }
            
            file.Close();
            allPatterns=ShuffleList(allPatterns);
            Console.WriteLine("pattern number : "+allPatterns.Count());
            int tmp=allPatterns.Count*2/3;
            for (int i = 0; i < tmp ; i++ )
            {
                _patterns.Add(allPatterns.ElementAt(i));
            }

            for (int i = tmp; i < allPatterns.Count(); i++)
            {
                _test.Add(allPatterns.ElementAt(i));
            }
            Console.WriteLine("train: "+_patterns.Count()+" test : "+_test.Count());
        }

        private void cbFileName_SelectedValueChanged(object sender, EventArgs e)
        {
            cbFileName.Enabled = false;
            
            path1 += cbFileName.Text+".txt";
            ClearCSV();
            StreamReader sr = new StreamReader(path1);
            StreamWriter sw = new StreamWriter("Patterns.csv");
            
            //System.IO.File.WriteAllText("Patterns.csv", string.Empty);
            int j=0;
            while (!sr.EndOfStream)
            {
                string tmpLine = sr.ReadLine();
                string[] tmpData = System.Text.RegularExpressions.Regex.Split(tmpLine, @"\s+");
                List<string> tmpData1=new List<string>();//用來存放已經去掉空白的部分
                j = 0;
                for (int i = 0; i < tmpData.Length; i++)
                {
                    
                    if (tmpData[i].Trim() != "")
                    {
                        j++;
                        tmpData1.Add(tmpData[i]);
                    }
                }

                for (int i = 0; i < j; i++)
                {
                    if (i < j - 1)
                    {
                       sw.Write(tmpData1.ElementAt(i) + ",");
                    }
                    else if (i == j - 1)
                    {
                        
                        sw.WriteLine(tmpData1.ElementAt(i) );
                    }
                    
                }
            }
            dimenstion = j-1;
            Console.WriteLine("dimension : "+dimenstion);
            sw.Close();
            sr.Close();
            
        }

        private void DrawPatterns()
        {
            foreach (Pattern sample in _test)
            {

                double posX = (pnlCanvas.Width / 2) + sample.Inputs[0] * 10;
                double posY = (pnlCanvas.Height / 2) - sample.Inputs[1] * 10;

                Pen pen;
                if (sample.Output == 1)
                {
                    pen = new Pen(Color.Aqua);
                }
                else
                {
                    pen = new Pen(Color.Pink);
                }

                objGraphics.DrawLine(pen, new Point((int)posX - 3, (int)posY), new Point((int)posX + 3, (int)posY));
                objGraphics.DrawLine(pen, new Point((int)posX, (int)posY - 3), new Point((int)posX, (int)posY + 3));
            }
        } 

        private void DrawSamples()
        {
            foreach (Pattern sample in _patterns)
            {
                
                double posX = (pnlCanvas.Width / 2) + sample.Inputs[0] * 10;
                double posY = (pnlCanvas.Height / 2) - sample.Inputs[1] * 10;

                Pen pen;
                if (sample.Output == 1)
                {
                    pen = new Pen(Color.Blue);
                }
                else
                {
                    pen = new Pen(Color.Red);
                }

                objGraphics.DrawLine(pen, new Point((int)posX - 3, (int)posY), new Point((int)posX + 3, (int)posY));
                objGraphics.DrawLine(pen, new Point((int)posX, (int)posY - 3), new Point((int)posX, (int)posY + 3));
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            objGraphics.DrawLine(new Pen(Color.Gainsboro), new Point(0, pnlCanvas.Height / 2), new Point(pnlCanvas.Width, pnlCanvas.Height / 2));
            objGraphics.DrawLine(new Pen(Color.Gainsboro), new Point(pnlCanvas.Width / 2, 0), new Point(pnlCanvas.Width / 2, pnlCanvas.Height));
        
        }

        private void btnSetHidden_Click(object sender, EventArgs e)
        {
            _hiddenDims = Convert.ToInt32( txtHidden.Text);
            btnTrain.Enabled = true;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            
            LoadPatterns();
            DrawSamples();
            Initialise();
            Train();
            Test();
        }

        public void ClearCSV()
        {
            StreamWriter Writer = new StreamWriter("Patterns.csv", false);
            string lines = ",,,,,,,,,,";
            Writer.Write(lines);
            Writer.Close();
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

    }
}
