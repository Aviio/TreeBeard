// ==============================================================================
// This is a modified version of this.Log:LoggingExtensions.log4net.Log4NetLog.cs
// ==============================================================================

// ==============================================================================
// 
// RealDimensions Software, LLC - Copyright © 2012 - Present - Released under the Apache 2.0 License
// 
// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
//
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
// ==============================================================================
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Util;
using System;
using System.Globalization;
using System.Runtime;

namespace TreeBeard.Utils
{
    public sealed class Log4NetLog
    {
        private readonly ILog _logger;

        // ignore Log4NetLog in the call stack
        private static readonly Type _declaringType = typeof(Log4NetLog);

        public Log4NetLog(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        public static void Initialize()
        {
            XmlConfigurator.Configure();
        }

        public bool IsDebugEnabled()
        {
            return _logger.IsDebugEnabled;
        }

        public bool IsErrorEnabled()
        {
            return _logger.IsErrorEnabled;
        }

        public bool IsFatalEnabled()
        {
            return _logger.IsFatalEnabled;
        }

        public bool IsInfoEnabled()
        {
            return _logger.IsInfoEnabled;
        }

        public bool IsWarnEnabled()
        {
            return _logger.IsWarnEnabled;
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Debug(string message, params object[] formatting)
        {
            if (_logger.IsDebugEnabled) Log(Level.Debug, message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Debug(Func<string> message)
        {
            if (_logger.IsDebugEnabled) Log(Level.Debug, message);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Info(string message, params object[] formatting)
        {
            if (_logger.IsInfoEnabled) Log(Level.Info, message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Info(Func<string> message)
        {
            if (_logger.IsInfoEnabled) Log(Level.Info, message);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Warn(string message, params object[] formatting)
        {
            if (_logger.IsWarnEnabled) Log(Level.Warn, message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Warn(Func<string> message)
        {
            if (_logger.IsWarnEnabled) Log(Level.Warn, message);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Error(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            Log(Level.Error, message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Error(Func<string> message)
        {
            // don't check for enabled at this level
            Log(Level.Error, message);
        }

        public void Error(Func<string> message, Exception exception)
        {
            Log(Level.Error, message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Fatal(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            Log(Level.Fatal, message, formatting);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Fatal(Func<string> message)
        {
            // don't check for enabled at this level
            Log(Level.Fatal, message);
        }

        public void Fatal(Func<string> message, Exception exception)
        {
            Log(Level.Fatal, message, exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        private void Log(Level level, Func<string> message)
        {
            Log(level, message(), null);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        private void Log(Level level, Func<string> message, Exception exception)
        {
            _logger.Logger.Log(_declaringType, level, message(), exception);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        private void Log(Level level, string message, params object[] formatting)
        {
            // SystemStringFormat is used to evaluate the message as late as possible. A filter may discard this message.
            _logger.Logger.Log(_declaringType, level, new SystemStringFormat(CultureInfo.CurrentCulture, message, formatting), null);
        }
    }
}