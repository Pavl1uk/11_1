namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                if (input == "private")
                {
                    PrintFields(fields, "private");
                }
                else if (input == "protected")
                {
                    PrintFields(fields, "protected");
                }
                else if (input == "public")
                {
                    PrintFields(fields, "public");
                }
                else if (input == "all")
                {
                    PrintAllFields(fields);
                }
            }
        }

        private static void PrintFields(FieldInfo[] fields, string accessModifier)
        {
            foreach (var field in fields)
            {
                string modifier = field.IsPrivate ? "private" :
                                  field.IsFamily ? "protected" :
                                  field.IsPublic ? "public" : "";

                if (modifier == accessModifier)
                {
                    Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static void PrintAllFields(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                string modifier = field.IsPrivate ? "private" :
                                  field.IsFamily ? "protected" :
                                  field.IsPublic ? "public" : "";

                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
