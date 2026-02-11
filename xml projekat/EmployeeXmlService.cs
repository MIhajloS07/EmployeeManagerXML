using System;
using System.Xml;

namespace XML_project
{
    internal class EmployeeXmlService
    {
        public static void CreateElements(string fullname, string age, string role, XmlElement root, XmlDocument doc)
        {
            int newId = GenerateNextId(root);
            XmlElement employee = doc.CreateElement("employee");
            employee.SetAttribute("id", newId.ToString());
            XmlElement fullNameEl = doc.CreateElement("fullName");
            fullNameEl.InnerText = fullname;
            XmlElement ageEl = doc.CreateElement("age");
            ageEl.InnerText = age;
            XmlElement roleEl = doc.CreateElement("role");
            roleEl.InnerText = role;
            employee.AppendChild(fullNameEl);
            employee.AppendChild(ageEl);
            employee.AppendChild(roleEl);
            root.AppendChild(employee);
        }
        public static int GenerateNextId(XmlElement root)
        {
            int maxId = 0;
            XmlNodeList xmlNode = root.SelectNodes("employee");
            foreach (XmlNode emp in xmlNode)
            {
                if (int.TryParse(emp.Attributes["id"]?.Value, out int empId))
                {
                    if (empId > maxId) maxId = empId;
                }
            }
            return maxId + 1;
        }
        public static void AddEmployee(XmlDocument doc, XmlElement root, string filePath)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter full name: "); string fullname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Full name field cannot be empty! Try again -> ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                fullname = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter age: "); int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid age (must be 18 yrs or older), try again: ");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter role: "); string role = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(role))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Role field cannot be empty! Try again -> ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                role = Console.ReadLine();
            }
            // Creating elements
            CreateElements(fullname.Trim(), age.ToString(), role.Trim(), root, doc);
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Employee {fullname.Trim()} added.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.ResetColor();
            // Saving xml file
            doc.Save(filePath);
        }
        public static void DeleteEmployee(XmlDocument doc, XmlElement root, string filePath)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" >  DELETE EMPLOYEE");
            Console.Write("Enter employee id > "); string userId = Console.ReadLine();
            Console.ResetColor();
            XmlNode node = root.SelectSingleNode($"/employees/employee[@id='{userId}']");
            if (!int.TryParse(userId, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("         Invalid ID format.       ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            else
            {
                if (node != null)
                {
                    root.RemoveChild(node);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($" Employee with id {userId} removed. ");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    doc.Save(filePath);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Employee with id {userId} not found.");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
        // Reassigns employee IDs sequentially starting from 1
        public static void UpdateEmployeeId(XmlElement root)
        {
            XmlNodeList nodeList = root.SelectNodes("employee");
            if (nodeList.Count <= 0)
            {
                throw new ArgumentException("No employee for sort");
            }
            else
            {
                int resetId = 1;
                foreach (XmlNode employee in nodeList)
                {
                    if (employee.Attributes["id"] != null)
                    {
                        employee.Attributes["id"].Value = resetId.ToString();
                        resetId++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Employees sorted and aranged by ID to XML file | {DateTime.Now} | total employees -> {resetId - 1}");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        public static void UpdateEmployeeName(XmlDocument doc, XmlElement root, string filePath)
        {
            string employeeId;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" >  UPDATE EMPLOYEE NAME");
            Console.WriteLine("--------------------------");
            Console.Write("Enter employee ID > ");
            Console.ResetColor();
            employeeId = Console.ReadLine();
            if (!int.TryParse(employeeId, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("         Invalid ID format.       ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            // Select entered employee (ID)
            XmlNode employee = root.SelectSingleNode($"/employees/employee[@id='{employeeId}']");
            if (employee == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Employee with id {employeeId} not found.");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------");
                Console.Write("Enter new name for employee: ");
                Console.ResetColor();
                string newEmployeeName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newEmployeeName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Field cannot be empty! Try again -> ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    newEmployeeName = Console.ReadLine();
                }
                if (employee["fullName"].InnerText == newEmployeeName.Trim())
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("This value is the same as before.");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    employee["fullName"].InnerText = newEmployeeName.Trim();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("        Employee name updated        ");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    doc.Save(filePath);
                }
            }
        }
        public static void UpdateEmployeeAge(XmlDocument doc, XmlElement root, string filePath)
        {
            string employeeId;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" >  UPDATE EMPLOYEE AGE");
            Console.WriteLine("--------------------------");
            Console.Write("Enter employee ID > ");
            Console.ResetColor();
            employeeId = Console.ReadLine();
            if (!int.TryParse(employeeId, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("         Invalid ID format.       ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            // Select entered employee (ID)
            XmlNode employee = root.SelectSingleNode($"/employees/employee[@id='{employeeId}']");
            if (employee == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Employee with id {employeeId} not found.");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------");
                Console.Write("Enter new age for employee: ");
                Console.ResetColor(); int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age < 18)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid age (must be 18 yrs or older), try again: ");
                    Console.ResetColor();
                }
                if (employee["age"].InnerText == age.ToString())
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("This value is the same as before.");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    employee["age"].InnerText = age.ToString();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("        Employee age updated         ");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    doc.Save(filePath);
                }
            }
        }
        public static void UpdateEmployeeRole(XmlDocument doc, XmlElement root, string filePath)
        {
            string employeeId;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" >  UPDATE EMPLOYEE ROLE");
            Console.WriteLine("--------------------------");
            Console.Write("Enter employee ID > ");
            Console.ResetColor();
            employeeId = Console.ReadLine();
            if (!int.TryParse(employeeId, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("         Invalid ID format.       ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            // Select entered employee (ID)
            XmlNode employee = root.SelectSingleNode($"/employees/employee[@id='{employeeId}']");
            if (employee == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Employee with id {employeeId} not found.");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------");
                Console.Write("Enter new role for employee: ");
                Console.ResetColor();
                string newEmployeeRole = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newEmployeeRole))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Field cannot be empty! Try again -> ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    newEmployeeRole = Console.ReadLine();
                }
                if (employee["role"].InnerText == newEmployeeRole.Trim())
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("This value is the same as before.");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    employee["role"].InnerText = newEmployeeRole.Trim();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("        Employee role updated        ");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    doc.Save(filePath);
                }
            }
        }
        public static void ShowEmployees(XmlDocument doc, XmlElement root)
        {
            XmlNodeList nodeList = root.SelectNodes("employee");
            Console.WriteLine();
            if (nodeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Employees count is zero.");
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("       ->  EMPLOYEES        ");
                foreach (XmlNode nodeXml in nodeList)
                {
                    // Check
                    string idXml = nodeXml.Attributes["id"] != null ? nodeXml.Attributes["id"].Value : "N/A";
                    string fullNameXml = nodeXml["fullName"] != null ? nodeXml["fullName"].InnerText : "N/A";
                    string ageXml = nodeXml["age"] != null ? nodeXml["age"].InnerText : "N/A";
                    string roleXml = nodeXml["role"] != null ? nodeXml["role"].InnerText : "N/A";
                    // Write
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("+----------------------------+");
                    Console.WriteLine($"ID: {idXml}");
                    Console.WriteLine($"Full Name: {fullNameXml}");
                    Console.WriteLine($"Age: {ageXml}");
                    Console.WriteLine($"Role: {roleXml}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
