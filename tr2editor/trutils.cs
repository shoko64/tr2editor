using System;
using System.Text;

namespace trUtils
{
	public class tr2Utils
	{
		public tr2Utils()
		{

		}

		public static bool checkTrFile(byte[] trFile)
		{
			// Very basic verification
			string search = ".tr2";
			string searchText = Encoding.UTF8.GetString(trFile);
			if (searchText.Contains(search))
				return true;
			return false;
		}

		public static byte[] getPart(byte[] trFile, int startIndex, int endIndex, bool rmPadding, bool isLitleEndian = false)
		{
			// Grabs a defined part of the tr file, then removes padding if necessary
			byte[] newArr = new byte[endIndex - startIndex];
			int c = 0;
			for (int i = startIndex; i < endIndex; i++)
			{
				newArr[c] = trFile[i];
				c++;
			}
			if (isLitleEndian)
			{
				if (BitConverter.IsLittleEndian)
					Array.Reverse(newArr);
			}
			if (rmPadding)
				newArr = removePadding(newArr);
			return newArr;
		}

		public static byte[] removePadding(byte[] byteArr)
		{
			// Removes padding of a bytearray
			int lastIndex = Array.FindLastIndex(byteArr, b => b != 0);
			Array.Resize(ref byteArr, lastIndex + 1);
			return byteArr;
		}

		public static byte[] getDataBlock(byte[,] pointerBlock, byte[] trFile, int size, int index)
		{
			// Gets the data block from the tr file using the data from the pointer block
			byte[] dataBlock = new byte[size];
			byte[] currentPointerData = getSingleArr(index, pointerBlock);
			int blockOffset = BitConverter.ToInt32(getPart(currentPointerData, 0x0, 0x5, false, false));
			for (int i = 0; i < dataBlock.Length; i++)
			{
				dataBlock[i] = trFile[blockOffset + i];
			}
			return dataBlock;
		}


		public static int getDataSize(int index, byte[,] pointerBlock)
		{
			// Gets the size of the data specified in its entry
			byte[] currentPointerData = getSingleArr(index, pointerBlock);
			byte[] secSize = getPart(currentPointerData, 0x8, 0xC, false, false);
			int iSecSize = BitConverter.ToInt32(secSize);
			return iSecSize;
		}

		public static byte[] getSingleArr(int index, byte[,] pointerBlock)
		{
			// Converts a 2d array row to a 1d array
			byte[] newArr = new byte[pointerBlock.GetLength(1)];
			for (int i = 0; i < newArr.Length; i++)
			{
				newArr[i] = pointerBlock[index, i];
			}
			return newArr;
		}

		public static string getEntryName(byte[,] dataBlock, int index)
		{
			// Gets the name of the entry from the data
			byte[] single = getSingleArr(index, dataBlock);
			return Encoding.ASCII.GetString(getPart(single, 0x0, 0x2F, true));

		}
		public static string getDataType(byte[,] dataBlock, int index)
		{
			// Gets the encoding type of the data
			byte[] single = getSingleArr(index, dataBlock);
			return Encoding.ASCII.GetString(getPart(single, 0x40, 0x4F, true));
		}

		public static string getBlockData(byte[,] dataBlock, int index)
		{
			// Gets the actual data from the block and checks the encoding type
			byte[] single = getSingleArr(index, dataBlock);
			string dataType = getDataType(dataBlock, index);
			int startOffset = BitConverter.ToInt32(getPart(single, 0x84, 0x89, false));
			int endOffset = 0;
			if (dataType == "INT")
			{
				endOffset = startOffset;
				startOffset = endOffset - 0x4;
			}
			else
			{
				endOffset = BitConverter.ToInt32(getPart(single, 0x90, 0x95, false));
			}
			byte[] data = new byte[endOffset - startOffset];
			for (int i = 0; i < endOffset - startOffset; i++)
			{
				data[i] = single[startOffset + i];
			}
			string str = "";
			switch (dataType)
			{
				case ("UTF-8"):
					str = Encoding.UTF8.GetString(data);
					break;
				case ("UTF-16LE"):
					str = Encoding.Unicode.GetString(data);
					break;
				case ("INT"):
					str = BitConverter.ToInt32(data).ToString();
					break;
				case ("ASCII"):
				case ("FLOAT"):
					str = Encoding.ASCII.GetString(data);
					break;
				default:
					str = "Data encoding : " + dataType + " is not supported.";
					break;
			}
			return str;
		}

		public static int addOffsetPadding(int dataOffset, int mod, int eq)
		{
			// Adds padding
			while (dataOffset % mod != eq)
			{
				dataOffset++;
			}
			return dataOffset;
		}

		public static byte[,] getPointerBlock(byte[] trFile)
		{
			// Gets the pointer block from the tr file
			int pointerTableOffset = 0x44;
			int pointerLength = 0x14;
			int entryNum = BitConverter.ToInt32(getPart(trFile, 0x39, 0x3D, false, true), 0); // Gets the number of entries
			byte[,] pointerBlock = new byte[entryNum, pointerLength];
			for (int i = 1; i <= entryNum; i++) // Goes through all of the entries
			{
				for (int j = 0; j < pointerLength; j++)
				{
					pointerBlock[i - 1, j] = trFile[(pointerTableOffset + (pointerLength * (i - 1))) + j];
				}
			}

			return pointerBlock;
		}
	}
}