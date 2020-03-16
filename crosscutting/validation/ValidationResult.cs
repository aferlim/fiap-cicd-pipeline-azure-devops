using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crosscutting.validation
{
    public class ValidationResult
    {
        public bool Valid
        {
            get
            {
                return Errors.Count <= 0;
            }
        }
        public List<string> Errors { get; set; } = new List<string> { };

        public ValidationResult AddError(string error)
        {
            Errors.Add(error);
            return this;
        }
    }
}