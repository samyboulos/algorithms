﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MatrixRotation: Algorithm
    {

        public void Run()
        {
            int[,] matrix = new int[,] {{1,3,5,7},
                                    {10,11,16,20},
                                    {23,30,34,50},
                                    {9,12,17,22}};
            Rotate(matrix);
            Print(matrix);
        }

        private void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
	if (n == 0 || n==1)
	 return ;
	 
	int layers = (int)Math.Ceiling((double)n / 2);

	for (int layer = 0; layer < layers; layer++)
	{
		for (int swap = 0; swap < (n - 2 * layer -1); swap++)
		{
			int offset = n-layer-1;
			
			//top -> right
			int right= matrix[layer+ swap, offset];
			matrix[layer+ swap, offset] = matrix[layer, layer + swap];
			
			//right -> bottom
			int bottom = matrix[n-layer-1, offset-swap];
			matrix[n-layer-1, offset-swap] = right;
			
			//bottom -> left
			int left= matrix[offset-swap, layer];
			matrix[offset-swap, layer] = bottom;
			
			//left-> top
			matrix[layer, layer+swap] = left;
		}
		
	}
        }
        private void Print (int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int layers = (int)Math.Ceiling((double)n / 2);

            for (int layer = 0; layer < layers; layer++)
            {

                for (int topx = layer; topx < n - layer; topx++)
                {
                    Console.WriteLine(matrix[layer, topx]);
                }
                for (int righty = layer; righty < n - layer; righty++)
                {

                    Console.WriteLine(matrix[righty, n - layer - 1]);
                }
                for (int bottomx = n - layer - 1; bottomx >= layer; bottomx--)
                {
                    Console.WriteLine(matrix[n - layer - 1, bottomx]);
                }
                for (int lefty = n - layer - 1; lefty >= layer; lefty--)
                {
                    Console.WriteLine(matrix[lefty, layer]);
                }
            }
        }

    }
}