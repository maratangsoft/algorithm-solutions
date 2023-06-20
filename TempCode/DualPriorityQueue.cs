using System;
using System.Collections.Generic;

public class DualPriorityQueue
{
	List<int> maxHeap = new List<int>();
	List<int> minHeap = new List<int>();

	public int[] solution(string[] operations)
	{
		foreach (string operation in operations)
		{
			ExecuteOperation(operation);
		}

		int[] answer = { 0, 0 };

		if (maxHeap.Count == 0) return answer;

		int lastNode = maxHeap.Count - 1;
		int lastNodeWithChildren = lastNode / 2;

		for (int node = lastNodeWithChildren; node >= 0; --node)
		{
			MaxHeapify(node, lastNode);
			MinHeapify(node, lastNode);
		}

		answer[0] = maxHeap[0];
		answer[1] = minHeap[0];
		
		return answer;
	}

	private void ExecuteOperation(string operation)
	{
		string operationType = operation.Substring(0, 1);
		int orderedNumber = int.Parse(operation.Substring(2));

		int lastNode = maxHeap.Count - 1;

		switch (operationType)
		{
			case "I":
				Enqueue(orderedNumber);
				break;

			case "D":
				if (maxHeap.Count == 0) return;

				if (operation.Substring(2, 1) == "-")
				{
					DequeueMin(lastNode);
				}
				else
				{
					DequeueMax(lastNode);
				}
				break;

			default:
				//Console.WriteLine("wrong operation");
				return;
		}
	}

	private void Enqueue(int element)
	{
		maxHeap.Add(element);
		minHeap.Add(element);
	}

	// sort min heap and remove min value
	private void DequeueMin(int lastNode)
	{
		int lastNodeWithChildren = lastNode / 2;
		for (int node = lastNodeWithChildren; node >= 0; --node)
		{
			MinHeapify(node, lastNode);
		}

		int minValue = minHeap[0];
		maxHeap.Remove(minValue);
		minHeap.RemoveAt(0);
	}

	// sort max heap and remove max value
	private void DequeueMax(int lastNode)
	{
		int lastNodeWithChildren = lastNode / 2;
		for (int node = lastNodeWithChildren; node >= 0; --node)
		{
			MaxHeapify(node, lastNode);
		}

		int maxValue = maxHeap[0];
		maxHeap.RemoveAt(0);
		minHeap.Remove(maxValue);
	}

	private void MaxHeapify(int parent, int lastNode)
	{
		int leftChild = parent * 2 + 1;
		int rightChild = leftChild + 1;
		int biggest = parent;

		if (leftChild <= lastNode &&
			maxHeap[leftChild] > maxHeap[biggest])
		{
			biggest = leftChild;
		}

		if (rightChild <= lastNode &&
			maxHeap[rightChild] > maxHeap[biggest])
		{
			biggest = rightChild;
		}

		if (biggest != parent)
		{
			int temp = maxHeap[biggest];
			maxHeap[biggest] = maxHeap[parent];
			maxHeap[parent] = temp;

			MaxHeapify(biggest, lastNode);
		}
	}

	private void MinHeapify(int parent, int lastNode)
	{
		int leftChild = parent * 2 + 1;
		int rightChild = leftChild + 1;
		int smallest = parent;

		if (leftChild <= lastNode &&
			minHeap[leftChild] < minHeap[smallest])
		{
			smallest = leftChild;
		}

		if (rightChild <= lastNode &&
			minHeap[rightChild] < minHeap[smallest])
		{
			smallest = rightChild;
		}

		if (smallest != parent)
		{
			int temp = minHeap[smallest];
			minHeap[smallest] = minHeap[parent];
			minHeap[parent] = temp;

			MinHeapify(smallest, lastNode);
		}
	}
}