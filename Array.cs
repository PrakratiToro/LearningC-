using System;

class Program{
	static void Main(string[] args){
		int[] arr = new int[2] {1,2};
		//for (int i = 0 ; i < 10 ; i++){
		//	arr[i] = i + 100 ;
			//Console.WriteLine("Element[{0}] = {1}",i,arr[i]);
		//}
		
		int index = 0;
		foreach (int i in arr){
			Console.WriteLine("Element[{0}] = {1}",index, i);
			index++;
		}
	}
}
