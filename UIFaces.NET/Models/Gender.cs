using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UIFaces.NET.Models
{
    public enum Gender
    {
        [EnumMember(Value = "male")]
        Male,

        [EnumMember(Value = "female")]
        Female
    }

}
