using System;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;

namespace StdNounou.Core
{
    public static class CustomLogger
    {
        public enum E_LogType
        {
            Basic,
            Warning,
            Error
        }

        #region FromMonobehaviour

        public static void LogWarning(this MonoBehaviour sender, object message, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, E_LogType.Warning, atLine);
        public static void LogError(this MonoBehaviour sender, object message, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, E_LogType.Error, atLine);
        public static void Log(this MonoBehaviour sender, object message, E_LogType logType = E_LogType.Basic, [CallerLineNumber] int atLine = -1)
            => Log(sender.GetType(), message, sender.gameObject, atLine, logType);

        #endregion

        #region From object

        public static void LogWarning(this object sender, object message, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, E_LogType.Warning, atLine);
        public static void LogError(this object sender, object message, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, E_LogType.Error, atLine);

        #endregion

        #region From Static

        public static void LogWarning(Type sender, object message, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, E_LogType.Warning, atLine);
        public static void LogError(Type sender, object message, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, E_LogType.Error, atLine);
        public static void Log(Type sender, object message, E_LogType logType = E_LogType.Basic, [CallerLineNumber] int atLine = -1)
            => Log(sender, message, null, atLine, logType);

        #endregion

        private static void Log(Type scriptType, object message, GameObject sender, int atLine, E_LogType logType = E_LogType.Basic)
        {
            bool isManager = scriptType.ToString().Contains("Manager");
            string color = isManager ? "FF0000" : "0000FF";
            StringBuilder finalMessage = new StringBuilder();
            finalMessage.Append(atLine)
                        .Append($"[<color=#{color}><b>{scriptType}</b></color>")
                        .Append(isManager || sender == null ? "]" : $", <b>{sender.gameObject.name}</b>]")
                        .Append(" : ")
                        .Append(message);
            switch (logType)
            {
                case E_LogType.Basic:
                    Debug.Log(finalMessage.ToString(), sender);
                    break;
                case E_LogType.Warning:
                    Debug.LogWarning(finalMessage.ToString(), sender);
                    break;
                case E_LogType.Error:
                    Debug.LogError(finalMessage.ToString(), sender);
                    break;
            }
        }

        public static void Log(this object sender, object message, E_LogType logType = E_LogType.Basic, [CallerLineNumber] int atLine = -1)
        {
            Type scriptType = sender.GetType();
            bool isManager = scriptType.ToString().Contains("Manager");
            string color = isManager ? "FF0000" : "0000FF";
            StringBuilder finalMessage = new StringBuilder();
            finalMessage.Append(atLine)
                        .Append($"[<color=#{color}><b>{scriptType}</b></color>")
                        .Append(isManager ? "]" : $", <b>{sender}</b>]")
                        .Append(" : ")
                        .Append(message);

            GameObject senderObj = null;
            if (sender is MonoBehaviour)
                senderObj = (sender as MonoBehaviour).gameObject;

            switch (logType)
            {
                case E_LogType.Basic:
                    Debug.Log(finalMessage.ToString(), senderObj);
                    break;
                case E_LogType.Warning:
                    Debug.LogWarning(finalMessage.ToString(), senderObj);
                    break;
                case E_LogType.Error:
                    Debug.LogError(finalMessage.ToString(), senderObj);
                    break;
            }
        }
    } 
}
