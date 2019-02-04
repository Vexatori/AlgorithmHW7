using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHW7
{
    public static class DijkstraAlgorithm
    {
        private static int[] minDist;
        private static int[] vertexs;
        private static int min;
        private static int minIndex;

        /// <summary>
        /// Инициализация класса начальными данными
        /// </summary>
        /// <param name="adjMatrix">Матрица смежности</param>
        public static void Init( MatrixClass adjMatrix )
        {
            minDist = new int[ adjMatrix.Size ];
            vertexs = new int[ adjMatrix.Size ];
            for ( int i = 0; i < adjMatrix.Size; i++ )
            {
                minDist[ i ] = Int32.MaxValue;
                vertexs[ i ] = 1;
            }
        }

        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        /// <param name="adjMatrix">Матрица смежности</param>
        /// <param name="vertex">Вершина, для которой ищутся кратчайшие пути до других вершин</param>
        public static void Algorithm( MatrixClass adjMatrix, int vertex )
        {
            if ( GraphClass.IsConnectedGraph( adjMatrix, vertex ) ) //<- если граф не связный, то выкидываем исключение, иначе продолжаем
            {
                if ( vertex >= 0 & vertex < adjMatrix.Size )
                {
                    minDist[ vertex ] = 0; //<- задаем у заданной вершины минимальный путь равный 0, т.к. мы уже в ней находимся
                }
                else
                {
                    throw new ArgumentException();
                }

                do
                {
                    minIndex = 1000;
                    min = 1000;
                    for ( int i = 0; i < adjMatrix.Size; i++ )
                    {
                        if ( ( vertexs[ i ] == 1 ) && ( minDist[ i ] < min ) ) 
                        {
                            min = minDist[ i ];
                            minIndex = i;
                        }
                    }

                    if ( minIndex == 1000 )
                    {
                        break;
                    }

                    if ( minIndex != Int32.MaxValue )
                    {
                        for ( int i = 0; i < adjMatrix.Size; i++ )
                        {
                            if ( adjMatrix.Matrix[ minIndex * adjMatrix.Size + i ] < 1000 )
                            {
                                int temp = min + adjMatrix.Matrix[ minIndex * adjMatrix.Size + i ];
                                if ( temp < minDist[ i ] )
                                {
                                    minDist[ i ] = temp;
                                }
                            }
                        }

                        vertexs[ minIndex ] = 0;
                    }
                } while ( minIndex < 1000 );
            }
            else
            {
                throw new Exception( "Граф не связный" );
            }
        }

        /// <summary>
        /// Вывод минимальных путей от заданной вершины до других
        /// </summary>
        public static void ShowMinDistances()
        {
            for ( int i = 0; i < minDist.Length; i++ )
            {
                Console.Write( $"x{i,-3}" );
            }

            Console.WriteLine();
            for ( int i = 0; i < minDist.Length; i++ )
            {
                Console.Write( $"{minDist[ i ],-3} " );
            }
        }
    }
}