using System;

class Program{
	static void Main(string[] args){
		int age =12;
		string result = (age>= 18) ? "Eligable to  vote" : "Not eligable";
		Console.WriteLine(result);
		
		object no = 20;
		string str = no as string;
		Console.WriteLine(str?? "Conversion failed");
	}
}
