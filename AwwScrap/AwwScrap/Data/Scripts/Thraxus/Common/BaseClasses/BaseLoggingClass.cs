﻿using System;
using AwwScrap.Common.Enums;
using AwwScrap.Common.Interfaces;
using AwwScrap.Common.Utilities;
using VRage.Game;

namespace AwwScrap.Common.BaseClasses
{
	public abstract class BaseLoggingClass : ICommon
	{
		public event Action<string, string, LogType, bool, int, string> OnWriteToLog;
		public event Action<ICommon> OnClose;

		public bool IsClosed { get; private set; }

		public virtual void Close()
		{
			if (IsClosed) return;
			IsClosed = true;
			OnClose?.Invoke(this);
		}

		public virtual void Update(ulong tick) { }

		protected abstract string Id { get; }

		public void WriteToLog(string caller, string message, LogType type, bool showOnHud = false, int duration = CommonSettings.DefaultLocalMessageDisplayTime, string color = MyFontEnum.Green)
		{
			OnWriteToLog?.Invoke($"{Id}: {caller}", message, type, showOnHud, duration, color);
		}
	}
}