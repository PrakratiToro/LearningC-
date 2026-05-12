using System;
using System.Collections.Generic;

class Program{
	static void Main(){
		List<string> fruits = new List<string> {"Apple","Mango","Banana"};
		Dictionary<int,string> names = new Dictionary<int,string> {
			{1,"A"},
			{2,"B"},
			{3,"C"}
		};
		foreach(string fruit in fruits){
			Console.WriteLine(fruit);
		}
		foreach(KeyValuePair<int,string> name in names){
			Console.WriteLine(name);
		}
	}
}
