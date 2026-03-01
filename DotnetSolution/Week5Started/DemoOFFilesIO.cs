
namespace Week5Started
{
    internal class DemoOFFilesIO
    {
        static void Main(string[] args)
        {
            //char ch = (char)Console.Read();
            //Console.WriteLine(ch);

            //Console.ReadLine();

            //string s = Console.ReadLine();
            //Console.WriteLine(s);

            //ConsoleKeyInfo c = Console.ReadKey();
            //Console.WriteLine(c.Key);
            //Console.WriteLine(c.Modifiers);

            //ConsoleKeyInfo ch;
            //do
            //{
            //    ch = Console.ReadKey();
            //    Console.WriteLine(ch.Key);
            //    Console.WriteLine(ch.Modifiers);

            //    //if ((ch.Modifiers & ConsoleModifiers.Control) != 0)
            //    //    Console.WriteLine("Control Pressed");
            //    //if ((ch.Modifiers & ConsoleModifiers.Alt) != 0)
            //    //    Console.WriteLine("Alt Pressed");
            //    //if ((ch.Modifiers & ConsoleModifiers.Shift) != 0)
            //    //    Console.WriteLine("Shift Pressed");
            //} while ((char)ch.Key != 'Q');


            //byte b1 = 120;
            //byte b2 = 100;
            //Console.WriteLine($"{b1}: {Convert.ToString(b1,2)}");
            //Console.WriteLine($"{b2}: {Convert.ToString(b1,2)}");
            //byte result = (byte)(b1 | b2);
            //Console.WriteLine($"{result}: {Convert.ToString(result, 2)}");

            //==================== File Handling ====== file static class (line level)===========================
            //try
            //{
            //    string fileName = @"..\..\..\file1.txt";

            //    if (File.Exists(fileName))
            //    {
            //        Console.WriteLine("Already exists");
            //        string[] arr = { "aa", "bb", "cc", "dd" };
            //        File.WriteAllLines(fileName, arr);
            //    }
            //    else
            //    {
            //        File.Create(fileName);
            //    }

            //}
            //catch (DirectoryNotFoundException ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            //====================== File Handling 2 ==== write ========================
            //try
            //{
            //    string file = @"..\..\..\file1.txt";
            //    using (FileStream fs = new FileStream(file, FileMode.Create))
            //    {
            //        for (char ch = 'A'; ch <= 'Z'; ch++)
            //        {
            //            fs.WriteByte((byte)ch);
            //        }
            //    }

            //    //fs.Close();
            //    //fs.Dispose();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //======================== read ==============================
            //try
            //{
            //    string file = @"..\..\..\file1.txt";
            //    using FileStream fs = new FileStream(file, FileMode.Open);
            //    char ch;
            //    do
            //    {
            //        int i = fs.ReadByte();
            //        if (i != -1)
            //        {
            //            Console.Write((char)(i) + " ");
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    } while (true);

                //    //fs.Close();
                //    //fs.Dispose();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

                //================================== SteamWriter ========================
                //string file = @"..\..\..\file1.txt";
                //using FileStream fs = new FileStream(file, FileMode.Create);    //write - create mode   read - open mode
                //using StreamWriter sw= new StreamWriter(fs);
                //string[] data =
                //{
                //    "1,stud1,77",
                //    "2,stud2,89",
                //    "3,stud3,82"
                //};
                //foreach (var item in data)
                //{
                //    sw.WriteLine(item);
                //}

                //============================== File Handling ======= .cs File and .Seek() =====================================
                //try
                //{
                //    string directory = @"..\..\..\";
                //    if (!Directory.Exists(directory))
                //    {
                //        Console.WriteLine("Directory do not exists");
                //        return;
                //    }
                //    string file1 = "HashSetDemo.cs";
                //    using FileStream f = new FileStream(directory + file1, FileMode.Open);
                //    Console.WriteLine(directory + file1);
                //    f.Seek(3, 0);
                //    if (!File.Exists(directory + file1))
                //    {
                //        Console.WriteLine("File do not exists");
                //        return;
                //    }
                //    do
                //    {
                //        int i = f.ReadByte();
                //        if (i != -1)
                //        {
                //            Console.Write((char)(i));
                //        }
                //        else
                //        {
                //            break;
                //        }
                //    } while (true);


                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //}

                //======================== csv file ============================================================

                try
            {
                string directory = @"../../../";
                if (!Directory.Exists(directory))
                {
                    Console.WriteLine("Directory do not exists");
                    return;
                }
                string file1 = "data.csv";
                string path = directory + file1;
               
                Console.WriteLine(directory + file1);

                //using StreamWriter sw = new StreamWriter(path);   //write
                //do
                //{
                //    Console.WriteLine("Enter Data: ");
                //    string data = Console.ReadLine();r4
                //    if (data == "stop")
                //    {
                //        break;
                //    }
                //    sw.WriteLine(data);

                //} while (true);

                //using StreamWriter sw = new StreamWriter(path,true);   //append ,true
                //do
                //{
                //    Console.WriteLine("Enter Data: ");
                //    string data = Console.ReadLine();
                //    if (data == "stop")
                //    {
                //        break;
                //    }
                //    sw.WriteLine(data);

                //} while (true);

                using StreamReader sr = new StreamReader(path);    //read
                do
                {
                    string data = sr.ReadLine();
                    if (data == null)
                    {
                        break;
                    }
                    Console.WriteLine(data);

                } while (true);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



        }
    }
}
