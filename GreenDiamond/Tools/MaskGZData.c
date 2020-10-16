#include "C:\Factory\SubTools\libs\MaskGZData.h"

static uint X;
static uint Y;
static uint Z;
static uint A;

static uint Xorshift128(void)
{
	uint t;

	t = X;
	t ^= X << 11;
	t ^= t >> 8;
	t ^= A;
	t ^= A >> 19;
	X = Y;
	Y = Z;
	Z = A;
	A = t;

	return t;
}
void MaskGZData(autoBlock_t *fileData)
{
	uint size = getSize(fileData);
	uint index;

	X = size % 1009;
	Y = size % 1013;
	Z = size % 1019;
	A = size % 1021;

	for(index = 0; index < getSize(fileData); index++)
	{
		b_(fileData)[index] ^= Xorshift128() % 251 + 4;
	}
}
