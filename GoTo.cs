using System;

class Program{
	static void Main(){
		int attempts = 0;
		bool isPasswordCorrect = false;
		
		Retry:
			attempts++;
			Console.WriteLine($"Attempt {attempts} : Enter Password");
		
		if (attempts<3){
			Console.WriteLine("Passowrd Incorrect RETRY");
			goto Retry;
		}
		isPasswordCorrect = true;
		Console.WriteLine("ACCESS GRANTED");
		
	}
}
