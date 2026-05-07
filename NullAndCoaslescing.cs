using System;
class Program{
	static void Main(string [] args){
		int? num = null;
		int result = num ?? 100;
		Console.WriteLine(result);
	}	
}
