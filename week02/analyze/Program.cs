Console.WriteLine("\n======================\nMysteryStack1\n======================");
Console.WriteLine(MysteryStack1.Run("racecar"));
Console.WriteLine(MysteryStack1.Run("stressed"));
Console.WriteLine(MysteryStack1.Run("a nut for a jar of tuna"));

Console.WriteLine("\n======================\nMysteryStack2\n======================");
Console.WriteLine(MysteryStack2.Run("5 3 7 + *"));
Console.WriteLine(MysteryStack2.Run("6 2 + 5 3 - /"));
try {
    MysteryStack2.Run("3 +");
    Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 1!");
}
catch (ApplicationException e) {
    Console.WriteLine(e.Message);
}

try {
    MysteryStack2.Run("5 0 /");
    Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 2!");
}
catch (ApplicationException e) {
    Console.WriteLine(e.Message);
}

try {
    MysteryStack2.Run("3 8 %");
    Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 3!");
}
catch (ApplicationException e) {
    Console.WriteLine(e.Message);
}

try {
    MysteryStack2.Run("5 3 4 +");
    Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 4!");
}
catch (ApplicationException e) {
    Console.WriteLine(e.Message);
}