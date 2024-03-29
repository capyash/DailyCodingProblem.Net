﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace YashCapoor.DailyCodingProblem.Solutions
{
    /// <inheritdoc cref="IProblem386Solution"/>
    public class Problem386Solution : IProblemSolution, IProblem386Solution
    {
        /// <inheritdoc />
        public void SolveProblem()
        {
            Console.WriteLine("Enter your string: ");
            var input = Console.ReadLine();
            Console.WriteLine($"Your string ordered by decreasing order of frequency: {SortStringByDecreasingFrequency(input)}");
        }

        /// <inheritdoc />
        public string SortStringByDecreasingFrequency(string input)
        {
            // Brute force - add them to sorted list

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var list = new Dictionary<char, int>();
            foreach (var character in input.ToCharArray())
            {
                if (list.ContainsKey(character))
                {
                    list[character] = list[character] + 1;
                }
                else
                {
                    list[character] = 1;
                }
            }

            var sb = new StringBuilder(input.Length);

            foreach (var character in list.OrderByDescending(x => x.Value).Select(x => x.Key).Distinct())
            {
                sb.Append(character, list[character]);
            }

            return sb.ToString();

        }
    }
}