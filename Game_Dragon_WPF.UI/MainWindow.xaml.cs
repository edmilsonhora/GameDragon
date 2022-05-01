using Game_Dragon_WPF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game_Dragon_WPF.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random;
        DispatcherTimer gameTimer;
        DispatcherTimer createEnemiesTimer;
       
        Canvas canvas;
        BackGround backGround;
        BackGround backGround2;
        Dragon dragon;
        Energy energy;
        List<Boar> boars;
        List<Fire> fires;
        List<Flame> flames;
        List<Soldier> soldiers;
        List<Wasp> wasps;
        List<WaspFire> waspFires;
        List<Coin> coins;
        int timeToSoldies = 50, timeToBoars=80, timeToWasps = 120, timeToWaspFire = 60, timeToCoins = 10;        
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            canvas = new Canvas();
            canvas.Height = this.Height;
            canvas.Width = this.Width;
            this.AddChild(canvas);
            backGround = new BackGround(canvas,0);
            backGround2 = new BackGround(canvas,1200);
            dragon = new Dragon(canvas);
            energy = new Energy(canvas);
            boars = new List<Boar>();
            fires = new List<Fire>();
            flames = new List<Flame>();
            soldiers = new List<Soldier>();
            wasps = new List<Wasp>();
            waspFires = new List<WaspFire>();
            coins = new List<Coin>();
            backGround2.Draw();
            backGround.Draw();            
            dragon.Draw();
            energy.Draw();

            gameTimer = new DispatcherTimer(DispatcherPriority.Render);
            gameTimer.Interval = TimeSpan.FromMilliseconds(58);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            createEnemiesTimer = new DispatcherTimer(DispatcherPriority.Render);
            createEnemiesTimer.Interval = TimeSpan.FromMilliseconds(20);
            createEnemiesTimer.Tick += CreateEnemiesTimer_Tick;
            createEnemiesTimer.Start();


        }

        private void CreateEnemiesTimer_Tick(object sender, EventArgs e)
        {
            dragon.Gravity();

            if (timeToWasps <= 0)
            {
                var newWasp = new Wasp(canvas, random);
                newWasp.Draw();
                wasps.Add(newWasp);
                timeToWasps = random.Next(100, 250);
            }

            if(timeToSoldies <= 0)
            {
                var newSoldier = new Soldier(canvas, random);
                newSoldier.Draw();
                soldiers.Add(newSoldier);
                timeToSoldies = random.Next(100, 250);
            }

            if(timeToBoars <= 0)
            {
                var newBoar = new Boar(canvas, random);
                newBoar.Draw();
                boars.Add(newBoar);
                timeToBoars = random.Next(100, 350);
            }

            if(timeToWaspFire <= 0)
            {
                foreach (var wasp in wasps)
                {
                    waspFires.Add(wasp.Fire());
                }
                timeToWaspFire = 80;
            }

            if(timeToCoins <= 0)
            {
                int qtdCoins = random.Next(2, 7);
                int espaco = 40;
                for (int i = 0; i < qtdCoins; i++)
                {
                    var c = new Coin(canvas, espaco);
                    c.Draw();
                    coins.Add(c);
                    espaco += 40;
                }
                timeToCoins = random.Next(300, 600);
            }

            timeToBoars--;
            timeToSoldies--;
            timeToWasps--;
            timeToWaspFire--;
            timeToCoins--;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            energy.Reduzir();
            backGround.Move();
            backGround2.Move();
            soldiers.RemoveAll(p => !p.IsAlive);
            wasps.RemoveAll(p => !p.IsAlive);
            flames.RemoveAll(p => !p.IsAlive);
            boars.RemoveAll(p => !p.IsAlive);
            waspFires.RemoveAll(p => !p.IsAlive);
            fires.ForEach(p => p.Hide());
            fires.RemoveAll(p => !p.IsAlive);
            coins.RemoveAll(p => !p.IsAlive);
            dragon.Mover();
            
            soldiers.ForEach(p => p.Jump());
            soldiers.ForEach(p => p.Gravity());            
            soldiers.ForEach(p => p.Move(flames, fires));
            wasps.ForEach(p => p.Move(flames, fires));
            boars.ForEach(p => p.Move(flames, fires));
            fires.ForEach(p => p.Draw());
            fires.ForEach(p => p.Move());
            flames.ForEach(p => p.Move());
            waspFires.ForEach(p => p.Mover());
            coins.ForEach(p => p.Move(dragon));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                var newFlame = new Flame(canvas, dragon.Y);
                newFlame.Draw();
                flames.Add(newFlame);
            }

            if (e.Key == Key.Up)
                dragon.Jump();
        }
    }
}
