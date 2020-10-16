#include "C:\Factory\SubTools\libs\MaskGZData.h"

void MaskGZData(autoBlock_t *fileData)
{
	uint size = getSize(fileData) / 3;
	uint index;

	for(index = 0; index < size; index++)
	{
		swapByte(fileData, index, size + index * 2);
	}
	for(index = 0; index < getSize(fileData); index++)
	{
		b_(fileData)[index] ^= 'o';
	}
}
