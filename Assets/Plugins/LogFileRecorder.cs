using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace KEngine
{
    public class LogFileRecorder
    {
        private StreamWriter writer;

        /// <summary>
        /// 初始化记录器，在游戏退出时调用Close
        /// </summary>
        /// <param name="filePath">文件名中不能包含特殊字符比如:</param>
        /// <param name="mode"></param>
        public LogFileRecorder(string filePath, FileMode mode = FileMode.Create)
        {
            int index = 0;
            try
            {
                var fs = new FileStream(filePath, mode);
                writer = new StreamWriter(fs);
            }
            catch (IOException e)
            {
                filePath = Path.GetDirectoryName(filePath) + "/" + Path.GetFileNameWithoutExtension(filePath) + "_" + (index++) + Path.GetExtension(filePath);
                Debug.LogError(e.Message);
            }
        }

        public void WriteLine(string line)
        {
            writer.WriteLine(line);
            writer.Flush();
        }

        public void Close()
        {
            writer.Flush();
            writer.Close();
        }


        #region 记录函数执行耗时

        private static Dictionary<string, LogFileRecorder> loggers = new Dictionary<string, LogFileRecorder>();

        public static void CloseStream()
        {
            foreach (var kv in loggers)
            {
                kv.Value.Close();
            }
        }

        public static void WriteProfileLog(string logType, string line)
        {
            LogFileRecorder logger;
            if (!loggers.TryGetValue(logType, out logger))
            {
                logger = new LogFileRecorder(Application.persistentDataPath + "/profiler_" + logType + ".csv");
                loggers.Add(logType, logger);

                if (logType == "UI")
                {
                    logger.WriteLine("UI Name,Operation,Cost(ms)");
                }
                else
                {
                    logger.WriteLine("");
                }
            }

            logger.WriteLine(line);
        }

        #endregion
    }

    public static class LogFileManager
    {
        static LogFileRecorder logWritter;

        //把所有的日志都保存起来
        private static void OnLogCallback(string condition, string stackTrace, LogType type)
        {
            if (logWritter == null)
            {
                string filePath = "";
                var logName = "/log_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:
                    case RuntimePlatform.IPhonePlayer:
                        filePath = string.Format("{0}/{1}", Application.persistentDataPath, logName);
                        break;
                    case RuntimePlatform.WindowsPlayer:
                    case RuntimePlatform.WindowsEditor:
                    case RuntimePlatform.OSXEditor:
                        filePath = string.Format("{0}/../logs/{1}", Application.dataPath, logName);
                        break;
                    default:
                        filePath = string.Format("{0}/{1}", Application.persistentDataPath, logName);
                        break;
                }

                logWritter = new LogFileRecorder(filePath, FileMode.Append);
            }

            var time = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            //Environment.StackTrace是非常完整的堆栈包括Unity底层调用栈，而stackTrace只有exception才有堆栈，对于Log/LogWarning/LogError是没有堆栈，可以通过StackTrace加上堆栈 by qingqing.zhao test in unity2019.3.7
            // logWritter.WriteLine(string.Format("[{0}][{1}]{2}\n{3}", time, type, condition,  !string.IsNullOrEmpty(stackTrace)?stackTrace :Environment.StackTrace));
            //logWritter.WriteLine(string.Format("[{0}][{1}]{2}\n{3}", time, type, condition,  Environment.StackTrace ));
            logWritter.WriteLine(string.Format("[{0}][{1}]{2}\n{3}", time, type, condition,  stackTrace));
        }


        public static void Start()
        {
            Application.logMessageReceivedThreaded += OnLogCallback;
            // Application.logMessageReceived += OnLogCallback;
            //Debug.Log("unity logevent regisiter successd.");
        }


        public static void Destory()
        {
            Application.logMessageReceivedThreaded -= OnLogCallback;
            logWritter.Close();
        }
    }
}