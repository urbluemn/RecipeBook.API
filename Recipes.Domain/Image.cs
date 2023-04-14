using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public string ImagePath { get; set; }
    }
}