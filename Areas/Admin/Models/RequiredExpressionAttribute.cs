using System;

namespace DoAnASP1.Areas.Admin.Models
{
    internal class RequiredExpressionAttribute : Attribute
    {
        private string v;

        public RequiredExpressionAttribute(string v)
        {
            this.v = v;
        }
    }
}