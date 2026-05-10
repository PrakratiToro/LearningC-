using System;
class Program{
	static void Main(string[] args){
		Console.WriteLine("Enter number");
		int getDayNumber = int.Parse(Console.ReadLine());
		string dayType = GetDayType(getDayNumber);
		Console.WriteLine($"Day Number: {getDayNumber}");
      	Console.WriteLine($"Day Type: {dayType}");
	}
	
	static string GetDayType(int dayNumber) =>
		dayNumber switch {
			1 or 7 => "Weekend" ,
			>=2 and <=6 => "Weekday" ,
			_ => "Invalid"
	};
	
}
