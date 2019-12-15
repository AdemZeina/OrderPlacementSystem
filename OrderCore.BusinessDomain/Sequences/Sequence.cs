using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Order.Domain.Sequences
{
    public class Sequence
    {

        public static readonly Sequence OrderSequence = new Sequence(nameof(OrderSequence), "ORDER", "{0:000000}");

        private const string Sys_InvalidSequenceName = "Invalid Sequence Name";
        private const string Sys_DuplicateSequenceCodePrefix = "Duplicate Sequence Code Prefix";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Sequence name</param>
        /// <param name="codePrefix">we will use prefix if format is empty,ex:LOG-100</param>
        /// <param name="format">if format not null, we will not use prefix</param>
        public Sequence(string name, string codePrefix, string format = "") {
            if (!SequenceHelper.SequenceNameRegex.IsMatch(name))
                throw new Exception(Sys_InvalidSequenceName);
            if (SequenceHelper.CodePrefixes.Contains(codePrefix))
                throw new Exception(Sys_DuplicateSequenceCodePrefix);
            SequenceHelper.CodePrefixes.Add(codePrefix);
            CodePrefix = codePrefix;
            Name = name;
            Format = format;
        }


        public string Name { get; private set; }

        public string CodePrefix { get; private set; }

        public string Format { get; set; }

        private static class SequenceHelper
        {
            public static readonly HashSet<string> CodePrefixes = new HashSet<string>();
            public static readonly Regex SequenceNameRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
        }
    }
}
