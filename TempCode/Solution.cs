using System;

public class Solution
{
	int numOfNodes;
	int numOfNetworks = 0;
	int numOf
	bool[]? isChecked;

	public int solution(int n, int[,] computers)
	{
		numOfNodes = n;
		isChecked = new bool[numOfNodes];

		for (int currentNode = 0; currentNode < numOfNodes; currentNode++)
		{
			SearchConnectedNode(0, computers);
		}

		int answer = 0;
		return answer;
	}

	// uses DFS
	void SearchConnectedNode(int currentNode, int[,] computers)
	{
		int firstUnchecked = -1;
		int lastNode = numOfNodes - 1;

		for (int j = 0; j < numOfNodes; ++j)
		{
			if (!isChecked[j])
			{
				firstUnchecked = j;
				break;
			}
		}
		if (firstUnchecked == -1)
		{
			numOfNetworks++;
			return;
		}

		for (int i = currentNode; i < numOfNodes; i++)
		{
			for ()

			if (i != currentNode && computers[currentNode, i] == 1)
			{
				isChecked[currentNode] = true;
				SearchConnectedNode(i, computers);
			}
		}
	}
}