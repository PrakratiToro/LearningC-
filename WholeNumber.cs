using System;

class Program {
	static void Main(){
		int number;
		Console.Write("Enter a positive number: ");
		while (!int.TryParse(Console.ReadLine(), out number) || number <= 0){
		Console.Write("Invalid input! Please enter a positive number: ");
        }
        Console.WriteLine("You entered: " + number);
	}
}
