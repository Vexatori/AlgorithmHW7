using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgorithmHW7
{
    public class MatrixClass
    {
        private int[] matrix;
        private int size;

        public int[] Matrix
        {
            get => this.matrix;
            set => this.matrix = value;
        }

        public int Size
        {
            get => this.size;
            set => this.size = value;
        }

        /// <summary>
        /// Метод считывает матрицу из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void InsertFromFile( string path )
        {
            matrix = File.ReadAllText( path ).Split( new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries )
                         .Select( int.Parse ).ToArray();
            size = (int) Math.Sqrt( matrix.Length );
        }

        /// <summary>
        /// Вывод матрицы
        /// </summary>
        public void ShowMatrix()
        {
            for ( int i = 0; i < size; i++ )
            {
                for ( int j = 0; j < size; j++ )
                {
                    Console.Write( $"{matrix[ i * size + j ],5} " );
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}