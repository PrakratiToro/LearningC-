using System;

class Program{
	static void Main(string[] args){
		//Implicit
		int age = 10;
		double convertedage = age;
		Console.WriteLine($"age = {age}");
		Console.WriteLine($"convertedage = {convertedage}");
		
		//Explicit
		int number= 20;
		char convertednumber = (char)number;
		Console.WriteLine($"number = {number}");
		Console.WriteLine($"convertednumber = {convertednumber}");
		
		//Type Conversion Using Convert Class
		string str = "123";
        int num = Convert.ToInt32(str);
		Console.WriteLine($"str = {str}");
        Console.WriteLine($"num = {num}");
		
		//Parse() Method
		string str1 = "456";
        int num1 = int.Parse(str1);
		Console.WriteLine($"str1 = {str1}");
        Console.WriteLine($"num1 = {num1}");
		
		//TryParse
		string str2 = "789";
        if (int.TryParse(str2, out int result)) {
			Console.WriteLine($"str2 = {str2}");
            Console.WriteLine($"result = {result}");
        } 
		else {
        	Console.WriteLine("Conversion failed.");
        }
		
		string str3 = "abc";
		if (int.TryParse(str3, out int result1)) {
			Console.WriteLine($"str3 = {str3}");
            Console.WriteLine($"result = {result1}");
        } 
		else {
        	Console.WriteLine("Conversion failed.");
        }
	}
}
