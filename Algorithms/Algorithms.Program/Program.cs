﻿using Algorithms.Sort.Exercises;

Console.WriteLine("1. Run Sort");
Console.WriteLine("Enter key:");
var stringEntry = Console.ReadLine();
if (!int.TryParse(stringEntry, out int value))
{
    throw new ArgumentException($"{value} cant be parsed to Int32");
}


switch (value)
{
    case 1:
        {
            SortExercises.TestBubbleSort();
            break;
        }
    case 2:
        {
            SortExercises.TestMergeSort();
            break;
        }
    case 3:
        {
            SortExercises.TestQuickSort();
            break;
        }
    default:
        {
            Console.WriteLine("Methode not found.");
            break;
        }
}
