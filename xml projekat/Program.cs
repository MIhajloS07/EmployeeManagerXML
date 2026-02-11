using System;
using System.IO;
using System.Threading;
using System.Xml;

namespace XML_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
                "employees.xml"
            );
            Console.WriteLine(filePath);
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(filePath))
            {
                XmlDeclaration xmlDecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(xmlDecl);
                XmlElement rootElement = doc.CreateElement("employees");
                doc.AppendChild(rootElement);
                doc.Save(filePath);
            }
            doc.Load(filePath);
            XmlElement root = doc.DocumentElement;
            if (root == null)
            {
                root = doc.CreateElement("employees");
                doc.AppendChild(root);
            }
            string option = string.Empty;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("             -> MADE BY MIHAJLO <-               ");
            Console.ResetColor();
            Console.WriteLine("-> Enter option (type /help for commands) <-");
            ConsoleUI.Menu();
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" > "); option = Console.ReadLine();
                    Console.ResetColor();
                    // options logic
                    switch (option.TrimEnd())
                    {
                        case "/add":
                            EmployeeXmlService.AddEmployee(doc, root, filePath);
                            break;
                        case "/delete":
                            EmployeeXmlService.DeleteEmployee(doc, root, filePath);
                            break;
                        case "/show":
                            EmployeeXmlService.ShowEmployees(doc, root);
                            break;
                        case "/help":
                            ConsoleUI.Help();
                            break;
                        case "/clear":
                            Console.Clear();
                            break;
                        case "/save":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Employees saved to XML file | {DateTime.Now}");
                            Console.WriteLine();
                            Console.ResetColor();
                            doc.Save(filePath);
                            break;
                        case "/sort":
                            EmployeeXmlService.UpdateEmployeeId(root);
                            doc.Save(filePath);
                            break;
                        case "/update -fullname":
                            EmployeeXmlService.UpdateEmployeeName(doc, root, filePath);
                            break;
                        case "/update -age":
                            EmployeeXmlService.UpdateEmployeeAge(doc, root, filePath);
                            break;
                        case "/update -role":
                            EmployeeXmlService.UpdateEmployeeRole(doc, root, filePath);
                            break;
                        case "/exit":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Exiting application");
                            for (int i = 3; i > 0; i--)
                            {
                                Console.WriteLine($"> {i}");
                                Thread.Sleep(1000); // 1sec        
                            }
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown command. Type /help");
                            Console.WriteLine();
                            Console.ResetColor();
                            break;
                    }
                }
                catch (XmlException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"XML ERROR: {ex.Message}");
                    Console.ResetColor();
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.WriteLine();
                }
                catch (NullReferenceException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Null reference: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            } while (option != "/exit");
            doc.Save(filePath);
        }
    }
}
