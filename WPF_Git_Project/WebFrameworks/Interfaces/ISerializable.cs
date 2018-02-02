﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFrameworks.Interfaces
{
    public interface ISerializable
    {
        T FromJSON<T>(string json);
        string ToJSON();

        T FromXML<T>(string xml);
        string ToXML();
    }
}
