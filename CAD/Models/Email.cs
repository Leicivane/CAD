using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CAD.Models
{
    public class Email : RegularExpressionAttribute
    {
        static Email()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(Email), typeof(RegularExpressionAttributeAdapter));
        }

        /// <summary>
        /// from: http://stackoverflow.com/a/6893571/984463
        /// </summary>
        public Email()
            : base(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                   + "@"
                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")
        { }
    }
}