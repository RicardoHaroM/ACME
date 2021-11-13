using System;
using System.Collections;
using System.IO;

namespace ACME
{
    //Binary tree to order the schedule
    class Node
    {
        string employeeName;
        Node left, right;
        DateTime? startHour, endHour;

        public Node(string employeeName=null, DateTime ? startHour = null, DateTime? endHour = null)
        {
            this.employeeName = employeeName;
            left = null;
            right = null;
            this.startHour = startHour;
            this.endHour = endHour;
        }
        public void enterData(string employeeName,DateTime? startHour, DateTime? endHour, ref Hashtable resultsTable)
        {
            if (employeeName == null)
            {
                this.employeeName = employeeName;
                this.startHour = startHour;
                this.endHour = endHour;
            }
            else
                compare(employeeName, startHour,endHour, ref resultsTable);
        }
        //function to compare the hours
        public void compare(string employeeName, DateTime? startHour, DateTime? endHour, ref Hashtable resultsTable,bool change = false)
        {
            if(this.startHour>startHour && this.endHour < endHour)
            {
                compareTO(employeeName, startHour, endHour, ref resultsTable);
                string tempName = this.employeeName;
                DateTime? tempStart = this.startHour;
                DateTime? tempEnd = this.endHour;
                this.employeeName = employeeName;
                this.startHour = startHour;
                this.endHour = endHour;
                compare(tempName, tempStart, tempEnd,ref resultsTable,true);
                
            }
            else if ((this.startHour <= startHour && this.endHour > startHour) |(this.startHour == startHour && this.endHour == endHour)|(this.endHour < startHour))
            {
                if(!change)
                    if (!(this.endHour < startHour))
                        add(this.employeeName, employeeName, resultsTable);
                if (this.right == null)
                    this.right = new Node(employeeName, startHour, endHour);
                else
                    this.right.compare(employeeName, startHour, endHour,ref resultsTable,change);

            }
            else if ((this.startHour > startHour && this.endHour >= endHour && this.startHour < endHour)|(this.startHour > endHour))
            {
                if(!change)
                    if (!(this.startHour > endHour))
                        add(this.employeeName, employeeName, resultsTable);
                if (this.left == null)
                    this.left = new Node(employeeName, startHour, endHour);
                else
                    this.left.compare(employeeName, startHour, endHour,ref resultsTable,change);
            }
        }
        //function to add the pairs of employees 
        public void add(string employe1, string employe2,Hashtable resultsTable )
        {
            string key = employe1 + "-" + employe2;
            if (resultsTable.ContainsKey(key))
            {
                int value = (int)resultsTable[key];
                value++;
                resultsTable[key] = value; 
            }
            else if(resultsTable.ContainsKey(employe2 + "-" + employe1))
            {
                int value = (int)resultsTable[employe2 + "-" + employe1];
                value++;
                resultsTable[employe2 + "-" + employe1] = value;
            }
            else
            {
                resultsTable.Add(key, 1);
            }
        }
        //function to compare hours when we change a Node
        public void compareTO(string employeeName, DateTime? startHour, DateTime? endHour, ref Hashtable resultsTable)
        {
            if (!(this.startHour > startHour && this.startHour > endHour) && !(this.endHour<startHour))
            {
                add(this.employeeName, employeeName, resultsTable);
                if (this.right != null)
                    this.right.compareTO(employeeName, startHour, endHour, ref resultsTable);
                if(this.left !=null)
                    this.left.compareTO(employeeName, startHour, endHour, ref resultsTable);

            }
            
        }
    }
    class ACME
    {
        Hashtable days;
        Hashtable resultsTable;
        public ACME()
        {
            days = new Hashtable();
            resultsTable = new Hashtable();
            
        }
        public bool input(StreamReader sr)
        {
            bool check;
            string inputNumber = sr.ReadLine();
            if (inputNumber != ".")
            {
                check = true;
                int employeesNumber = Convert.ToInt32(inputNumber);
                for (int i = 0; i < employeesNumber; i++)
                {
                    string inputLine = sr.ReadLine();
                    string[] employeeInformation = inputLine.Split('=');
                    string[] elements = employeeInformation[1].Split(',');
                    for (int j = 0; j < elements.Length; j++)
                    {
                        string day = elements[j].Substring(0, 2);
                        string[] hours = elements[j].Substring(2, elements[j].Length - 2).Split('-');
                        if (days.ContainsKey(day))
                        {
                            Node temp = (Node)days[day];
                            temp.enterData(employeeInformation[0], Convert.ToDateTime(hours[0]), Convert.ToDateTime(hours[1]), ref resultsTable);
                        }
                        else
                        {
                            days.Add(day, new Node(employeeInformation[0], Convert.ToDateTime(hours[0]), Convert.ToDateTime(hours[1])));
                        }
                    }
                }
                print();
            }
            else
                check = false;
            
            return check;
        }
        public void print()
        {
            foreach (DictionaryEntry de in resultsTable)
            {
                Console.WriteLine("{0}: {1}", de.Key, de.Value);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            StreamReader sr = new StreamReader("../test/test.txt");
            do
            {
                ACME acme = new ACME();
                check = acme.input(sr);
            } while (check);
            sr.Close();
            
        }
    }
}
