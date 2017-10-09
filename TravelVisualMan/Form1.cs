using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelVisualMan {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
        // Method filling the the matrix with cities and distances
        private int[,] MatrixFill(int nodes) {
            Random rnd = new Random();
            int edge;
            int[,] cities = new int[nodes, nodes];

            for (int i = 0; i < nodes; i++) {
                for (int j = 0; j < nodes; j++) {
                    if (cities[i, j] != 0)// If space allready is filled.
                        continue;
                    else if (j == i) { // Distance to the node itself is 0.
                        cities[i, j] = 0;
                    }
                    else {
                        edge = rnd.Next(1, 10);
                        cities[i, j] = edge;
                        cities[j, i] = edge;
                    }
                }
            }
            /*for (int i = 0; i < nodes; i++) {
                for (int j = 0; j < nodes; j++) {
                    Console.Write(cities[i,j] + " ");
                    if (j == nodes-1)
                        Console.WriteLine();
                }
            }*/
            Console.WriteLine();
            return cities;
        }
        // Method calculating total cost of a route
        private int GetCost(int[] route, int[,] cities) {
            int cost = 0;

            for (int i = 0; i < route.Length - 1; i++) {
                cost += cities[route[i], route[i + 1]];
            }
            cost += cities[route[route.Length - 1], route[0]];
            return cost;
        }
        // Method making a random solution
        private int[] Random(int numbOfCities, int[,] cities) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int i = 0;
            Random rnd = new Random();
            int[] route = new int[numbOfCities];
            int[] exists = new int[numbOfCities];

            while (i < numbOfCities) {
                int rando = rnd.Next(numbOfCities);
                if (exists[rando] == 1)
                    continue;
                else {
                    route[i] = rando;
                    exists[rando] = 1;
                    i++;
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            DataGridView.Rows[Count].Cells[2].Value = elapsedMs;
            return route;
        }
        // Making an iterative random solution
        private int[] IterativeRandom(int numbOfCities, int[,] cities, int iterations) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int j, cost;
            int minCost = Int32.MaxValue;
            Random rnd = new Random();
            int[] route, exists;
            int[] cheapest = new int[numbOfCities];

            for (int i = 0; i < iterations; i++) {
                cost = 0;
                j = 0;
                exists = new int[numbOfCities];
                route = new int[numbOfCities];
                while (j < numbOfCities) {
                    int rando = rnd.Next(numbOfCities);
                    if (exists[rando] == 1)
                        continue;
                    else {
                        route[j] = rando;
                        exists[rando] = 1;
                        j++;
                    }
                }
                cost = GetCost(route, cities);

                if (cost < minCost) {
                    minCost = cost;
                    Array.Copy(route, cheapest, numbOfCities);
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            DataGridView.Rows[Count].Cells[2].Value = elapsedMs;
            return cheapest;
        }
        // Making a greedy solution
        private int[] Greedy(int numbOfCities, int[,] cities) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int[] exists = new int[numbOfCities];
            int[] route = new int[numbOfCities];
            Random rnd = new Random();

            int city = rnd.Next(numbOfCities);
            exists[city] = 1;
            route[0] = city;
            for (int i = 1; i < numbOfCities; i++) {
                int min = Int32.MaxValue;
                for (int j = 0; j < numbOfCities; j++) {
                    if (cities[route[i - 1], j] < min && cities[route[i - 1], j] != 0 && exists[j] != 1) {
                        min = cities[route[i - 1], j];
                        city = j;
                    }
                }
                route[i] = city;
                exists[city] = 1;
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            DataGridView.Rows[Count].Cells[2].Value = elapsedMs;
            return route;
        }
        // Method improving the initial solutions
        private int Improve(int[] initial, int[,] cities) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int cost = GetCost(initial, cities);
            int temp, newCost;
            int stagnation = 0;
            int[] cheapest = new int[initial.Length];
            bool stop = false;
            Random rnd = new Random();

            Array.Copy(initial, cheapest, initial.Length);
            while (!stop) {
                int city1 = rnd.Next(initial.Length);
                int city2 = rnd.Next(initial.Length);

                while (city1 == city2) {
                    city2 = rnd.Next(initial.Length);
                }

                temp = initial[city1];
                initial[city1] = initial[city2];
                initial[city2] = temp;

                newCost = GetCost(initial, cities);
                if (newCost < cost) {
                    Array.Copy(initial, cheapest, initial.Length);
                    cost = newCost;
                    stagnation = 0;
                }
                else {
                    stagnation++;
                }
                if (stagnation > 1000) {
                    stop = true;
                }
                Array.Copy(cheapest, initial, cheapest.Length);
            }
            //PrintRoute(cheapest);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            DataGridView.Rows[Count].Cells[4].Value = elapsedMs;
            return cost;
        }

        private void StartBtn_Click(object sender, EventArgs e) {
            int ncities = 1000;
            int [,] cities = MatrixFill(ncities);

            for(int i = 0; i < 100; i++) {
                RandomFill(ncities, cities);
                IterativeRandomFill(ncities, cities);
                GreedyFill(ncities, cities);
            }
        }

        private void RandomFill(int ncities, int[,] cities) {
            DataGridView.Rows.Add();
            DataGridView.Rows[Count].Cells[0].Value = "Random";
            int[] random = Random(ncities, cities);
            int cost = GetCost(random, cities);
            DataGridView.Rows[Count].Cells[1].Value = cost;
            int imp = Improve(random, cities);
            DataGridView.Rows[Count].Cells[3].Value = imp;
        }

        private void IterativeRandomFill(int ncities, int[,] cities) {
            DataGridView.Rows.Add();
            DataGridView.Rows[Count].Cells[0].Value = "Iterative Random";
            int[] iterativeRandom = IterativeRandom(ncities, cities, 5);
            int cost = GetCost(iterativeRandom, cities);
            DataGridView.Rows[Count].Cells[1].Value = cost;
            int imp = Improve(iterativeRandom, cities);
            DataGridView.Rows[Count].Cells[3].Value = imp;
        }

        private void GreedyFill(int ncities, int[,] cities) {
            DataGridView.Rows.Add();
            DataGridView.Rows[Count].Cells[0].Value = "Greedy";
            int[] greedy = Greedy(ncities, cities);
            int cost = GetCost(greedy, cities);
            DataGridView.Rows[Count].Cells[1].Value = cost;
            int imp = Improve(greedy, cities);
            DataGridView.Rows[Count].Cells[3].Value = imp;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private int Count {
            get { return DataGridView.RowCount-2; }
        }
    }
}
