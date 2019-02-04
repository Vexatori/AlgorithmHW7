using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHW7
{
    public static class GraphClass
    {
        private static int[] colors;

        public static int[] GetColors
        {
            get => colors;
        }

        /// <summary>
        /// Инициализация класса начальными данными
        /// </summary>
        /// <param name="adjMatrix">Матрица смежности</param>
        public static void GraphClassInit( MatrixClass adjMatrix )
        {
            colors = new int[ adjMatrix.Size ];
        }

        /// <summary>
        /// Проверка связности графа (применен обход в глубину)
        /// </summary>
        /// <param name="adjMatrix">Матрица смежности</param>
        /// <param name="vertex">Начало обхода</param>
        /// <returns></returns>
        public static bool IsConnectedGraph( MatrixClass adjMatrix, int vertex )
        {
            if ( vertex >= 0 & vertex < adjMatrix.Size )
            {
                colors[ vertex ] = 1;
            }
            else
            {
                throw new ArgumentException();
            }

            for ( int i = 0; i < adjMatrix.Size; ++i )
            {
                if ( adjMatrix.Matrix[ vertex * adjMatrix.Size + i ] < 1000 && colors[ i ] == 0 )
                {
                    IsConnectedGraph( adjMatrix, i );
                }
            }

            colors[ vertex ] = 2;

            return !colors.Contains( 0 );
        }
    }
}