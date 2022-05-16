using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Threading.Tasks;

namespace UnityQA.Tools
{
    public static class Logger
    {
        [MenuItem("UnitQA/PrintInfo")]
        public static void PrintInfo()
        {
            Application.logMessageReceivedThreaded += LogMessageReceivedThreaded;
            Debug.Log("Hello");
            Debug.Log("World");
            Debug.Log("QA");

            Application.logMessageReceivedThreaded -= LogMessageReceivedThreaded;
        }

        private static void LogMessageReceivedThreaded(string logString, string stackTrace, LogType type)
        {
            string path = "./LogsQA/Log" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            //const string path = "./artifacts/SavingLog.txt";

            SaveToFile(logString, path);
        }

        private static async Task SaveToFile(string stringToSave, string path) // Changed Task to void: https://stackoverflow.com/questions/14903887/warning-this-call-is-not-awaited-execution-of-the-current-method-continues
        {
            StreamWriter log = !File.Exists(path) ? new StreamWriter(path) : File.AppendText(path);

            await log.WriteLineAsync(stringToSave);

            log.Close();
        }
    }
}