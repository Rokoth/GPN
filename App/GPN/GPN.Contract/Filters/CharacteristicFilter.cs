using GPN.Contract.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GPN.Contract.Filters
{
    public class CharacteristicsFilter : Filter<Characteristics>
    {
        public CharacteristicsFilter(int? size, int? page, string sort, string name) : base(size, page, sort)
        {
            Name = name;
        }
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; }
    }

}
