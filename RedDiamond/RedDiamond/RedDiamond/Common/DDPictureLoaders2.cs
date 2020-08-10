﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;

namespace Charlotte.Common
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	/// <summary>
	/// Unload()する必要なし。
	/// 必要あり -> DDPictureLoader
	/// </summary>
	public static class DDPictureLoaders2
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		private class PictureWrapper : DDPicture
		{
			public Func<int> Func_GetHandle;
			public DDPicture.PictureInfo Info;

			// <---- prm

			public PictureWrapper()
				: base(() => null, v => { }, v => { })
			{ }

			protected override DDPicture.PictureInfo GetInfo()
			{
				this.Info.Handle = this.Func_GetHandle();
				return this.Info;
			}
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static DDPicture Wrapper(Func<int> getHandle, int w, int h)
		{
			DDPicture.PictureInfo info = new DDPicture.PictureInfo()
			{
				Handle = -1,
				W = w,
				H = h,
			};

			return new PictureWrapper()
			{
				Func_GetHandle = getHandle,
				Info = info,
			};
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static DDPicture Wrapper(Func<int> getHandle, I2Size size)
		{
			return Wrapper(getHandle, size.W, size.H);
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static DDPicture Wrapper(DDSubScreen subScreen)
		{
			return Wrapper(() => subScreen.GetHandle(), subScreen.GetSize());
		}
	}
}
