public static class ComplexStackSolution {
    public static void Main() {
        // True (stack was empty at the end)
        Console.WriteLine(CheckBraces("(a == 3 or (b == 5 and c == 6))"));
        // False ...wrong opening square bracket (stack had only '(' in it before it was popped and compared with ']')
        //                          here -------\/
        Console.WriteLine(CheckBraces("(students]i].Grade > 80 and students[i].Grade < 90"));
        // False ....missing closing ')' (stack had an extra '(' in it at the end when it was supposed to be empty
        //                 here -------\/
        Console.WriteLine(CheckBraces("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))"));
    }

    public static bool CheckBraces(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}