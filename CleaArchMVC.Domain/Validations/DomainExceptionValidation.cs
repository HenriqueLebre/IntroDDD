using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaArchMVC.Domain.Validations
{
    public class DomainExceptionValidation : Exception
    {

        public DomainExceptionValidation(string erro) : base(erro) { }
        
        public static void When(bool hasError, string error)
        {
            if (hasError) 
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
