using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PascalABCCompiler.Parsers;
using PascalABCCompiler.PascalABCNewParser;
using PascalABCCompiler.Errors;
using PascalABCCompiler.SyntaxTree;


namespace LightSemantic.Test
{
    class Program
    {
        static string testFile = "../../Test.pas";
//        static NameInfoVisitor info = null;
        static program_module tree = null;
        static void Init()
        {
            Controller cc = new Controller();
            cc.Parsers.Add(new PascalABCNewLanguageParser());
            List<Error> ee = new List<Error>();
            tree = cc.Compile(testFile, File.ReadAllText(testFile), ee, ParseMode.Normal) as program_module;

            if (ee.Count > 0)
            {
                Console.WriteLine("error");
                ee.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("success");
//                info = new NameInfoVisitor();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Compiling test");
            Init();/*
            while (true)
            {
                Console.Write("> ");

                string[] command = Console.ReadLine().Split(' ');

                if (command[0] == "get" && command[1] == "info")
                {
                    int line, column;
                    if (int.TryParse(command[2], out line) && int.TryParse(command[3], out column))
                    {
                        info.visit(tree, new SourceContext(line, column, line, column));
                        if (info.res == null)
                        {
                            Console.WriteLine("Can't find info about this");
                        }
                        else if (info.res.Item2 == null)
                        {
                            Console.WriteLine("Can't find info about " + info.res.Item1);
                        }
                        else
                        {
                            Console.WriteLine(info.res.Item1 + " : " + info.res.Item2);
                        }
                    }
                    else
                        Console.WriteLine("incorrect parameters");
                }
                else if (command[0] == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("unknown command");
                }
            }*/
        }
    }
}
