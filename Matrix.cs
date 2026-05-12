using System;

class Program{
	static void Main(){
		int[][] matrix = new int[][]{
			new int[]  {1,2},
			new int[]  {3,4},
			new int[]  {5,6}
		};
		
		foreach (int[] row in matrix){
         foreach (int item in row){
            Console.Write(item + " ");
         }
         Console.WriteLine(); 
      }
	}
}
