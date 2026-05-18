using System;

class Program{
	static void Main(){
		Console.WriteLine("Enter the target");
		int target = int.Parse(Console.ReadLine());
		
		int start = 0;
		while(start<= target){
			Console.WriteLine($"Start = {start}");
			start++;
		}
	}
}
