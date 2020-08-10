using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;

namespace Charlotte
{
	public class ResourcePicture
	{
		public DDPicture Pic_DeepForestA1 = DDPictureLoaders.Standard(@"PixelArtWorld\DeepForest-A1.png");
		public DDPicture Pic_DeepForestA2 = DDPictureLoaders.Standard(@"PixelArtWorld\DeepForest-A2.png");
		public DDPicture Pic_DeepForestA5 = DDPictureLoaders.Standard(@"PixelArtWorld\DeepForest-A5.png");
		public DDPicture Pic_DeepForestB = DDPictureLoaders.Standard(@"PixelArtWorld\DeepForest-B.png");
		public DDPicture Pic_RuinF = DDPictureLoaders.Standard(@"PixelArtWorld\Ruin-F.png");

		public DDPicture Pic_LFCharaSogen01 = DDPictureLoaders.Standard(@"PixelArtWorld\LF-Chara-Sogen01.png");

		public DDTable<DDPicture> DeepForestA1;
		public DDTable<DDPicture> DeepForestA2;
		public DDTable<DDPicture> DeepForestA5;
		public DDTable<DDPicture> DeepForestB;
		public DDTable<DDPicture> RuinF;

		public DDTable<DDPicture> LFCharaSogen01;

		public ResourcePicture()
		{
			this.DeepForestA1 = GetDerivationTable(this.Pic_DeepForestA1, 16, 12);
			this.DeepForestA2 = GetDerivationTable(this.Pic_DeepForestA2, 16, 12);
			this.DeepForestA5 = GetDerivationTable(this.Pic_DeepForestA5, 8, 16);
			this.DeepForestB = GetDerivationTable(this.Pic_DeepForestB, 16, 16);
			this.RuinF = GetDerivationTable(this.Pic_RuinF, 16, 16);

			this.LFCharaSogen01 = GetDerivationTable(this.Pic_LFCharaSogen01, 12, 8);
		}

		private static DDTable<DDPicture> GetDerivationTable(DDPicture pic, int w, int h)
		{
			DDTable<DDPicture> table = new DDTable<DDPicture>(w, h);

			int dw = pic.Get_W() / w;
			int dh = pic.Get_H() / h;

			if (dw * w != pic.Get_W()) throw new DDError(); // 2bs
			if (dh * h != pic.Get_H()) throw new DDError(); // 2bs

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					table[x, y] = DDDerivations.GetPicture(pic, x * dw, y * dh, dw, dh);
				}
			}
			return table;
		}
	}
}
