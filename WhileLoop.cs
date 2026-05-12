using System;
class Example{
	static void Main(){
		string input;
		while(true){
			Console.Write("Enter the word('exit' to stop)");
			input = Console.ReadLine();
			if (input.ToLower() == "exit")
				break;
			Console.WriteLine($"You have entered this word = {input}");
		}
	}
}
