using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATCSimTest
{
    public partial class Form1 : Form
    {
        Exercise testEx;
        
        Graphics radar;
        Pen acPen = new Pen(Color.White, 1f);
        SolidBrush trailBrush = new SolidBrush(Color.GhostWhite);
        Font lblFont = new Font("Verdana", 8.0f);
        float rSize = 10f;
        float tSize = 4f;
        int labelDist = 20;
        int timeControl = 3;

        SpeechSynthesizer speechSynth = new SpeechSynthesizer();
        SpeechRecognitionEngine speechRecogEngine = new SpeechRecognitionEngine();
        string srgsPath = Environment.CurrentDirectory + "\\srgs_grammar.xml";

        private Queue<Instruction> frequency;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = timeControl * 1000;

            LoadSpeechRecognition();

            testEx = new Exercise(3);
            acListBox.DataSource = testEx.acList;
            acListBox.DisplayMember = "Callsign";
            
            radar = radarScreen.CreateGraphics();
            updateDisplay();
            startBtn.Enabled = true;

            frequency = new Queue<Instruction>();
        }

        private void LoadSpeechRecognition()
        {
            Grammar grammar;
            try
            {
                grammar = new Grammar(new System.Speech.Recognition.SrgsGrammar.SrgsDocument(srgsPath));
            }
            catch (Exception e)
            {
                MessageBox.Show("Speech Recognition grammar not loaded! \n\n ////// \n" + e.Message);
                throw;
            }
            speechRecogEngine.LoadGrammarAsync(grammar);
            speechRecogEngine.SetInputToDefaultAudioDevice();
            speechRecogEngine.SpeechRecognized += SpeechRecogEngine_SpeechRecognized;
        }

        private void SpeechRecogEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            logBox.Text += e.Result.Text + "\n";
            logBox.Text += e.Result.Semantics["callsign"].Value + ", " + e.Result.Semantics["clearance"].Value + ", "
                + e.Result.Semantics["information"].Value + ", " + e.Result.Semantics["negative"].Value + "\n";
            //speechSynth.SpeakAsync(e.Result.Text);
            Instruction msg = new Instruction(e.Result.Semantics["callsign"].Value.ToString(), e.Result.Semantics["clearance"].Value.ToString(),
                e.Result.Semantics["information"].Value.ToString(), e.Result.Semantics["negative"].Value.ToString());
            frequency.Enqueue(msg);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            speechRecogEngine.RecognizeAsync(RecognizeMode.Multiple);
            startBtn.Enabled = false;
            pauseBtn.Enabled = true;
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            speechRecogEngine.RecognizeAsyncCancel();
            startBtn.Enabled = true;
            pauseBtn.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateState();
            updateDisplay();
        }

        private void updateState()
        {
            if (frequency.Count > 0)
            {

                Instruction msg = frequency.Dequeue();
                Aircraft ac;

                ac = testEx.acList.Find(x => x.Callsign.Equals(msg.Callsign.ToString()));
                
                if ((ac != null) && msg.Clearance.Substring(0,1).Equals("T"))
                {
                    string _turnToken = msg.Clearance.Substring(3);
                    int _turnDeg;
                    Int32.TryParse(_turnToken, out _turnDeg);
                    ac.ClearedHeading = _turnDeg;
                }
            }
            foreach (var ac in testEx.acList)
            {
                ac.MovementContinue(timeControl, 10);
                ac.TurnContinue(timeControl);
            }
        }

        private void updateDisplay()
        {
            radar.Clear(Color.LightSlateGray);
            foreach (var ac in testEx.acList)
            {
                showTrail(ac);
                radar.DrawEllipse(acPen, (int)ac.Position.X - rSize / 2, (int)ac.Position.Y - rSize / 2, rSize, rSize);
                drawLabel(ac);
            }
        }

        private void drawLabel(Aircraft ac)
        {
            Point origin = new Point((int)ac.Position.X, (int)ac.Position.Y);
            Point lblPoint = new Point(origin.X + labelDist, origin.Y - labelDist / 2);
            radar.DrawLine(acPen, origin, lblPoint);
            //0.CALLSIGN
            //1.AFL 2.CFL 3.GS
            //4.HDG
            radar.DrawString(String.Format("{0} \n{1} {2} N{3} \n{4:000}", ac.Callsign, ac.Level, ac.ClearedLevel, ac.GroundSpeed, ac.Heading), 
                lblFont, new SolidBrush(Color.White), lblPoint);
        }

        private void showTrail(Aircraft ac)
        {
            foreach (var p in ac.trail)
            {
                radar.FillEllipse(trailBrush, p.X - tSize / 2, p.Y - tSize / 2, tSize, tSize);
            }
        }

        private void turnTestbtn_Click(object sender, EventArgs e)
        {
            foreach (var ac in testEx.acList)
            {
                ac.ClearedHeading = 180;
                ac.InTurn = true;
            }
        }

    }
}
