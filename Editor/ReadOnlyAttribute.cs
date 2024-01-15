using System;
using UnityEngine;

namespace StdNounou.Core.Editor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyAttribute : PropertyAttribute { }
}
