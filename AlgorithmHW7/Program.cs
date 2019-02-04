using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHW7
{
    class Program
    {
        static void Main( string[] args )
        {
            #region Считывание матрицы (смежности) из файла

            MatrixClass matrix = new MatrixClass();
            matrix.InsertFromFile(@"D:\adj.txt");
            matrix.ShowMatrix();

            #endregion

            #region Проверка связности графа

            GraphClass.GraphClassInit(matrix);
            Console.WriteLine($"Граф связный? -> {GraphClass.IsConnectedGraph(matrix, 1)}\n");

            #endregion

            #region Вывод кратчайших путей от заданной точки

            DijkstraAlgorithm.Init(matrix);
            DijkstraAlgorithm.Algorithm(matrix, 0);
            DijkstraAlgorithm.ShowMinDistances();

            #endregion

            Console.ReadLine();
        }
    }
}